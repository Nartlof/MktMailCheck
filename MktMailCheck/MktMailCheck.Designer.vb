<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MktMailCheck
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MktMailCheckMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpamTrapsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpamTrapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCsvFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveCsvFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.BarraDeStatus = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ProgressoLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EmailsToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MktMailCheckMenuStrip.SuspendLayout()
        Me.BarraDeStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'MktMailCheckMenuStrip
        '
        Me.MktMailCheckMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem, Me.EditarToolStripMenuItem, Me.ImportarToolStripMenuItem, Me.ExportarToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MktMailCheckMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MktMailCheckMenuStrip.Name = "MktMailCheckMenuStrip"
        Me.MktMailCheckMenuStrip.Size = New System.Drawing.Size(637, 24)
        Me.MktMailCheckMenuStrip.TabIndex = 0
        Me.MktMailCheckMenuStrip.Text = "MailCheckMenuStrip"
        '
        'ArquivoToolStripMenuItem
        '
        Me.ArquivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SairToolStripMenuItem})
        Me.ArquivoToolStripMenuItem.Name = "ArquivoToolStripMenuItem"
        Me.ArquivoToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem.Text = "&Arquivo"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.SairToolStripMenuItem.Text = "&Sair"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailsToolStripMenuItem1, Me.SpamTrapsToolStripMenuItem1})
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem.Text = "&Editar"
        '
        'EmailsToolStripMenuItem1
        '
        Me.EmailsToolStripMenuItem1.Name = "EmailsToolStripMenuItem1"
        Me.EmailsToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.EmailsToolStripMenuItem1.Text = "&Emails"
        Me.EmailsToolStripMenuItem1.ToolTipText = "Editar a lista de endereços de e-mail"
        '
        'SpamTrapsToolStripMenuItem1
        '
        Me.SpamTrapsToolStripMenuItem1.Name = "SpamTrapsToolStripMenuItem1"
        Me.SpamTrapsToolStripMenuItem1.Size = New System.Drawing.Size(132, 22)
        Me.SpamTrapsToolStripMenuItem1.Text = "&SpamTraps"
        Me.SpamTrapsToolStripMenuItem1.ToolTipText = "Editar a lista de servidores spamtrap"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailsToolStripMenuItem, Me.SpamTrapsToolStripMenuItem})
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ImportarToolStripMenuItem.Text = "&Importar"
        '
        'EmailsToolStripMenuItem
        '
        Me.EmailsToolStripMenuItem.Name = "EmailsToolStripMenuItem"
        Me.EmailsToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EmailsToolStripMenuItem.Text = "&Emails"
        Me.EmailsToolStripMenuItem.ToolTipText = "Importar lista com endereços de e-mail"
        '
        'SpamTrapsToolStripMenuItem
        '
        Me.SpamTrapsToolStripMenuItem.Name = "SpamTrapsToolStripMenuItem"
        Me.SpamTrapsToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.SpamTrapsToolStripMenuItem.Text = "&SpamTraps"
        Me.SpamTrapsToolStripMenuItem.ToolTipText = "Importar lista com servidores armadilha"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmailsToolStripMenuItem2})
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ExportarToolStripMenuItem.Text = "E&xportar"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem.Text = "Aj&uda"
        '
        'OpenCsvFileDialog
        '
        Me.OpenCsvFileDialog.Filter = "Arquivo CSV *.csv|*.csv|Arquvos de texto *.txt|*.txt|Todos os arquivos *.*|*.*"
        Me.OpenCsvFileDialog.RestoreDirectory = True
        '
        'SaveCsvFileDialog
        '
        Me.SaveCsvFileDialog.Filter = "Arquivo CSV *.csv|*.csv|Arquvos de texto *.txt|*.txt|Todos os arquivos *.*|*.*"
        Me.SaveCsvFileDialog.RestoreDirectory = True
        '
        'BarraDeStatus
        '
        Me.BarraDeStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.ProgressoLabel})
        Me.BarraDeStatus.Location = New System.Drawing.Point(0, 239)
        Me.BarraDeStatus.Name = "BarraDeStatus"
        Me.BarraDeStatus.Size = New System.Drawing.Size(637, 22)
        Me.BarraDeStatus.TabIndex = 1
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(43, 17)
        Me.StatusLabel.Text = "Pronto"
        '
        'ProgressoLabel
        '
        Me.ProgressoLabel.Name = "ProgressoLabel"
        Me.ProgressoLabel.Size = New System.Drawing.Size(10, 17)
        Me.ProgressoLabel.Text = ":"
        '
        'EmailsToolStripMenuItem2
        '
        Me.EmailsToolStripMenuItem2.Name = "EmailsToolStripMenuItem2"
        Me.EmailsToolStripMenuItem2.Size = New System.Drawing.Size(152, 22)
        Me.EmailsToolStripMenuItem2.Text = "&Emails"
        '
        'MktMailCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(637, 261)
        Me.Controls.Add(Me.BarraDeStatus)
        Me.Controls.Add(Me.MktMailCheckMenuStrip)
        Me.MainMenuStrip = Me.MktMailCheckMenuStrip
        Me.Name = "MktMailCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mkt Mail Check"
        Me.MktMailCheckMenuStrip.ResumeLayout(False)
        Me.MktMailCheckMenuStrip.PerformLayout()
        Me.BarraDeStatus.ResumeLayout(False)
        Me.BarraDeStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MktMailCheckMenuStrip As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmailsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SpamTrapsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EmailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpamTrapsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenCsvFileDialog As OpenFileDialog
    Friend WithEvents SaveCsvFileDialog As SaveFileDialog
    Friend WithEvents BarraDeStatus As StatusStrip
    Friend WithEvents StatusLabel As ToolStripStatusLabel
    Friend WithEvents ProgressoLabel As ToolStripStatusLabel
    Friend WithEvents EmailsToolStripMenuItem2 As ToolStripMenuItem
End Class
