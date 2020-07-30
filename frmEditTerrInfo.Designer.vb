<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditTerrInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTerrNote = New System.Windows.Forms.TextBox
        Me.lblTerrNote = New System.Windows.Forms.Label
        Me.txtTerrZip = New System.Windows.Forms.TextBox
        Me.lblZipCode = New System.Windows.Forms.Label
        Me.txtTerrName = New System.Windows.Forms.TextBox
        Me.lblTerrName = New System.Windows.Forms.Label
        Me.lblTerrNum = New System.Windows.Forms.Label
        Me.txtTerrNum = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gbxTerritory = New System.Windows.Forms.GroupBox
        Me.gbxTerritory.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTerrNote
        '
        Me.txtTerrNote.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrNote.Location = New System.Drawing.Point(92, 54)
        Me.txtTerrNote.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTerrNote.Name = "txtTerrNote"
        Me.txtTerrNote.Size = New System.Drawing.Size(260, 23)
        Me.txtTerrNote.TabIndex = 3
        '
        'lblTerrNote
        '
        Me.lblTerrNote.AutoSize = True
        Me.lblTerrNote.Location = New System.Drawing.Point(6, 57)
        Me.lblTerrNote.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTerrNote.Name = "lblTerrNote"
        Me.lblTerrNote.Size = New System.Drawing.Size(39, 16)
        Me.lblTerrNote.TabIndex = 2
        Me.lblTerrNote.Text = "Nota:"
        '
        'txtTerrZip
        '
        Me.txtTerrZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrZip.Location = New System.Drawing.Point(292, 85)
        Me.txtTerrZip.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTerrZip.MaxLength = 5
        Me.txtTerrZip.Name = "txtTerrZip"
        Me.txtTerrZip.Size = New System.Drawing.Size(60, 23)
        Me.txtTerrZip.TabIndex = 7
        Me.txtTerrZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblZipCode
        '
        Me.lblZipCode.AutoSize = True
        Me.lblZipCode.Location = New System.Drawing.Point(227, 88)
        Me.lblZipCode.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(61, 16)
        Me.lblZipCode.TabIndex = 6
        Me.lblZipCode.Text = "Zip code:"
        '
        'txtTerrName
        '
        Me.txtTerrName.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrName.Location = New System.Drawing.Point(92, 23)
        Me.txtTerrName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTerrName.Name = "txtTerrName"
        Me.txtTerrName.Size = New System.Drawing.Size(260, 23)
        Me.txtTerrName.TabIndex = 1
        '
        'lblTerrName
        '
        Me.lblTerrName.AutoSize = True
        Me.lblTerrName.Location = New System.Drawing.Point(6, 26)
        Me.lblTerrName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTerrName.Name = "lblTerrName"
        Me.lblTerrName.Size = New System.Drawing.Size(58, 16)
        Me.lblTerrName.TabIndex = 0
        Me.lblTerrName.Text = "Nombre:"
        '
        'lblTerrNum
        '
        Me.lblTerrNum.AutoSize = True
        Me.lblTerrNum.Location = New System.Drawing.Point(6, 88)
        Me.lblTerrNum.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTerrNum.Name = "lblTerrNum"
        Me.lblTerrNum.Size = New System.Drawing.Size(82, 16)
        Me.lblTerrNum.TabIndex = 4
        Me.lblTerrNum.Text = "Núm de terr:"
        '
        'txtTerrNum
        '
        Me.txtTerrNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrNum.Location = New System.Drawing.Point(92, 85)
        Me.txtTerrNum.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTerrNum.MaxLength = 5
        Me.txtTerrNum.Name = "txtTerrNum"
        Me.txtTerrNum.Size = New System.Drawing.Size(60, 23)
        Me.txtTerrNum.TabIndex = 5
        Me.txtTerrNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Territory_Manager.My.Resources.Resources.decline
        Me.btnCancel.Location = New System.Drawing.Point(281, 125)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.Territory_Manager.My.Resources.Resources.disk
        Me.btnSave.Location = New System.Drawing.Point(12, 125)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 30)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gbxTerritory
        '
        Me.gbxTerritory.Controls.Add(Me.txtTerrName)
        Me.gbxTerritory.Controls.Add(Me.lblTerrName)
        Me.gbxTerritory.Controls.Add(Me.lblZipCode)
        Me.gbxTerritory.Controls.Add(Me.txtTerrNote)
        Me.gbxTerritory.Controls.Add(Me.lblTerrNum)
        Me.gbxTerritory.Controls.Add(Me.lblTerrNote)
        Me.gbxTerritory.Controls.Add(Me.txtTerrZip)
        Me.gbxTerritory.Controls.Add(Me.txtTerrNum)
        Me.gbxTerritory.Location = New System.Drawing.Point(12, 4)
        Me.gbxTerritory.Name = "gbxTerritory"
        Me.gbxTerritory.Size = New System.Drawing.Size(359, 115)
        Me.gbxTerritory.TabIndex = 0
        Me.gbxTerritory.TabStop = False
        '
        'frmEditTerrInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(383, 167)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbxTerritory)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditTerrInfo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Territorio"
        Me.gbxTerritory.ResumeLayout(False)
        Me.gbxTerritory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTerrNote As System.Windows.Forms.TextBox
    Friend WithEvents lblTerrNote As System.Windows.Forms.Label
    Friend WithEvents txtTerrZip As System.Windows.Forms.TextBox
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents txtTerrName As System.Windows.Forms.TextBox
    Friend WithEvents lblTerrName As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblTerrNum As System.Windows.Forms.Label
    Friend WithEvents txtTerrNum As System.Windows.Forms.TextBox
    Friend WithEvents gbxTerritory As System.Windows.Forms.GroupBox

End Class
