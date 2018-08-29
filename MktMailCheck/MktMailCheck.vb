Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class MktMailCheck

    Shared ReadOnly Property MktDbFile As String = Application.StartupPath & "\MktDbFile.mdb"
    Shared ReadOnly Property ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & MktDbFile

#Region "Eventos do formulario"
    Private Sub MktMailCheck_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Se o banco de dados não existe, deve ser criado
        If Not File.Exists(MktDbFile) Then
            MsgBox("Não foi encontrado o banco de dados. Um novo será criado.", MsgBoxStyle.Exclamation, "Erro ao abrir o banco")
            CreateNewDatabase()
        End If
        SetFormPosition()
    End Sub

    Private Sub MktMailCheck_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MsgBox("Quer mesmo sair e encerrar o programa?", MsgBoxStyle.YesNo, "Confirmação") = MsgBoxResult.No Then
            e.Cancel = True
        Else
            SaveFormPosition()
        End If
    End Sub

#End Region

#Region "Itens do Menu"

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub EmailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailsToolStripMenuItem.Click
        Dim EmailStream As Stream = Nothing
        If OpenCsvFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                EmailStream = OpenCsvFileDialog.OpenFile()
                If (EmailStream IsNot Nothing) Then
                    Dim MailRegex As New Regex("^[a-z]\w+([-+.]\w+)*@[a-z]\w+([-.]\w+)*\.\w+([-.]\w+)*[a-z]$")
                    Dim StLable As ToolStripItem = BarraDeStatus.Items.Item(1)
                    Dim Endereco As String = ""
                    Dim Encontrados As Integer = 0
                    Dim Adicionados As Integer = 0
                    BarraDeStatus.Items.Item(0).Text = "Importando:"
                    StLable.Text = ""
                    Using Conn As New OleDbConnection(ConnectionString)
                        Using Comm As New OleDbCommand("", Conn)
                            Dim MailAdress As New OleDbParameter("@Email", "")
                            Comm.Parameters.Add(MailAdress)
                            Using Reader As New StreamReader(EmailStream)
                                Conn.Open()
                                While Not Reader.EndOfStream
                                    Endereco = Reader.ReadLine
                                    Endereco = Endereco.ToLower.Trim
                                    If MailRegex.IsMatch(Endereco) Then
                                        Comm.CommandText = "Select Count(*) from EmailTable where Email=@Email"
                                        MailAdress.Value = Endereco
                                        Encontrados += 1
                                        If Comm.ExecuteScalar = 0 Then
                                            Comm.CommandText = "Insert Into EmailTable (Email) Values (@Email)"
                                            Comm.ExecuteNonQuery()
                                            Adicionados += 1
                                        End If
                                    End If
                                    StLable.Text = String.Format("{0} endereços adcionados de {1} encontrados", Adicionados, Encontrados)
                                End While
                                Conn.Close()
                            End Using
                        End Using
                    End Using
                End If
            Catch Ex As Exception
                MessageBox.Show("Erro ao ler o arquivo: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (EmailStream IsNot Nothing) Then
                    EmailStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub EmailsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EmailsToolStripMenuItem2.Click
        If SaveCsvFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If SaveCsvFileDialog.FileName <> "" Then
                    Dim StLable As ToolStripItem = BarraDeStatus.Items.Item(1)
                    Dim Exportados As Integer = 0
                    BarraDeStatus.Items.Item(0).Text = "Exportando:"
                    StLable.Text = ""
                    Using Conn As New OleDbConnection(ConnectionString)
                        Using Comm As New OleDbCommand("Select Email from EmailTable order by Email", Conn)
                            Using ExpFile As New FileStream(SaveCsvFileDialog.FileName, FileMode.Create)
                                Using Writer As New StreamWriter(ExpFile)
                                    Dim Reader As OleDbDataReader
                                    Conn.Open()
                                    Reader = Comm.ExecuteReader
                                    While Reader.Read
                                        Writer.WriteLine(Reader.Item("Email"))
                                        Exportados += 1
                                        StLable.Text = String.Format("{0} endereços exportados", Exportados)
                                    End While
                                    Writer.Flush()
                                    Conn.Close()
                                End Using
                            End Using
                        End Using
                    End Using
                End If
            Catch Ex As Exception
                MessageBox.Show("Erro ao ler o arquivo: " & Ex.Message)
            End Try
        End If
    End Sub

#End Region

#Region "Rotinas de suporte"
    Private Sub SetFormPosition()
        If (ModifierKeys And Keys.Shift) = 0 Then
            Dim initLocation As String = My.Settings.InitialLocation
            Dim il As Point = New Point(0, 0)
            Dim sz As Size = Size
            Dim St As FormWindowState = FormWindowState.Normal
            If Not String.IsNullOrWhiteSpace(initLocation) Then
                Dim parts As String() = initLocation.Split(","c)
                If parts.Length >= 2 Then
                    il = New Point(Integer.Parse(parts(0)), Integer.Parse(parts(1)))
                End If
                If parts.Length >= 4 Then
                    sz = New Size(Integer.Parse(parts(2)), Integer.Parse(parts(3)))
                End If
                If parts.Length >= 5 Then
                    St = [Enum].Parse(St.GetType, parts(4))
                End If
            End If
            Size = sz
            Location = il
            WindowState = St
        End If
    End Sub
    Private Sub SaveFormPosition()
        If (ModifierKeys And Keys.Shift) = 0 Then
            Dim loc As Point = Location
            Dim siz As Size = Size
            Dim WSt As FormWindowState = WindowState
            If WSt = FormWindowState.Minimized Then WSt = FormWindowState.Normal
            If WindowState <> FormWindowState.Normal Then
                loc = RestoreBounds.Location
                siz = RestoreBounds.Size
            End If
            Dim initLocation As String = String.Join(",", loc.X, loc.Y, siz.Width, siz.Height, WSt)
            My.Settings.InitialLocation = initLocation
            My.Settings.Save()
        End If
    End Sub
    Private Sub CreateNewDatabase()
        Dim Catalog As New ADOX.Catalog
        Catalog.Create(ConnectionString)

        Using Conn As New OleDbConnection(ConnectionString)
            Using Comm As New OleDbCommand("", Conn)
                Conn.Open()
                'Criando a tabela que vai conter os endereços de email
                'Campo email contem o endereço propriamente dito. É definido como primário para não haver repetição
                'Campo VrStatus diz o estatus da verificação:
                '    0 - Valor padrão - não verificado
                '    1 - Sinal verde - verificado e válido. Pode enviar.
                '    2 - Sinal azul - não há como saber sem enviar uma mensagem.
                '    3 - Sinal laranja - verificado como "pega-tudo". Não há garantia de caixa postal única
                '    4 - Sinal vermelho - endereço inválido. Não vale a pena mandar pois será bounce
                '    5 - Sinal preto - provável armadilha
                'Campo VrDate contem a data da última verificação do estatus para verificação a intervalos de tempo.
                Comm.CommandText = "CREATE TABLE EmailTable (
                                              Email varchar(250) NOT NULL PRIMARY KEY,
                                              VrStatus int NOT NULL DEFAULT 0,
                                              VrDate date NOT NULL DEFAULT Now())"
                Comm.ExecuteNonQuery()
                'Criando a tabela de servidores smtp. Serve para marcar quais são armadilha ou pega-tudo e define o intervalo de tempo entre chamadas
                'Campo ServerDomain contem o domínio propriamente dito
                'Campo MxServer contem o servidor MX principal
                'Campo MxIP contem o IP do MX
                'Campo VrStatus contem o status do servidor
                '    0 - não verificado
                '    1 - operacional - normal
                '    2 - operacional - Não informa status sem envio. Não adianta verificar
                '    3 - operacional - pega-tudo Não precisa testar e-mails pois vai aceitar tudo.
                '    4 - falhado - Não enviar mensagem até a próxima verificação
                '    5 - armadilha - é definido caso o servidor MX esteja listado na tabela de armadilhas spamtrap
                'Campo VrDate contem a data da última verificação do servidor
                'Campo LastSend contem a data e hora da última verificação de endereço. Só usa nos operacionais normais
                Comm.CommandText = "CREATE TABLE SmtpServers (
                                            ServerDomain varchar(250) NOT NULL PRIMARY KEY,
                                            MxServer varchar(250) NOT NULL DEFAULT '',
                                            MxIP varchar(15) NOT NULL DEFAULT '',
                                            VrStatus int  NOT NULL DEFAULT 0,
                                            VrDate date NOT NULL DEFAULT Now(),
                                            LastSend datetime NOT NULL DEFAULT Now())"
                Comm.ExecuteNonQuery()
                'Criando tabela de armadilhas. Contem os nomes dos servidores MX que correspondem a armadilhas de spamtrap
                'Campo ServerName contem o nome do servidor spamtrap
                Comm.CommandText = "CREATE TABLE SpamTraps (ServerName varchar(250) NOT NULL PRIMARY KEY)"
                Conn.Close()
            End Using
        End Using
    End Sub

#End Region

End Class
