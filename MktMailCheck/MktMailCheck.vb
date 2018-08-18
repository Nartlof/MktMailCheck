Imports System.IO
Imports System.Data.OleDb

Public Class MktMailCheck

    Shared ReadOnly Property MktDbFile As String = Application.StartupPath & "\MktDbFile.mdb"
    Shared ReadOnly Property ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & MktDbFile
    Private Sub MktMailCheck_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Se o banco de dados não existe, deve ser criado
        If Not File.Exists(MktDbFile) Then
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
                    Comm.CommandText = "CREATE TABLE SpamTraps (SpamTrapName varchar(250) NOT NULL PRIMARY KEY)"
                    Conn.Close()
                End Using
            End Using
        End If
    End Sub
End Class
