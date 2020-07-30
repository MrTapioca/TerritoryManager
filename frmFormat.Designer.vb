<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFormat
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.gbxFormat1 = New System.Windows.Forms.GroupBox
        Me.btnFormat1 = New System.Windows.Forms.Button
        Me.btnFormat2 = New System.Windows.Forms.Button
        Me.gbxFormat2 = New System.Windows.Forms.GroupBox
        Me.gbxFormat1.SuspendLayout()
        Me.gbxFormat2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Territory_Manager.My.Resources.Resources.decline
        Me.btnCancel.Location = New System.Drawing.Point(102, 76)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gbxFormat1
        '
        Me.gbxFormat1.Controls.Add(Me.btnFormat1)
        Me.gbxFormat1.Location = New System.Drawing.Point(12, 12)
        Me.gbxFormat1.Name = "gbxFormat1"
        Me.gbxFormat1.Size = New System.Drawing.Size(132, 58)
        Me.gbxFormat1.TabIndex = 0
        Me.gbxFormat1.TabStop = False
        Me.gbxFormat1.Text = "Formato 1"
        '
        'btnFormat1
        '
        Me.btnFormat1.Image = Global.Territory_Manager.My.Resources.Resources.page_excel
        Me.btnFormat1.Location = New System.Drawing.Point(6, 22)
        Me.btnFormat1.Name = "btnFormat1"
        Me.btnFormat1.Size = New System.Drawing.Size(120, 30)
        Me.btnFormat1.TabIndex = 0
        Me.btnFormat1.Text = "3.75"" x 5.75"""
        Me.btnFormat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFormat1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFormat1.UseVisualStyleBackColor = True
        '
        'btnFormat2
        '
        Me.btnFormat2.Image = Global.Territory_Manager.My.Resources.Resources.page_excel
        Me.btnFormat2.Location = New System.Drawing.Point(6, 22)
        Me.btnFormat2.Name = "btnFormat2"
        Me.btnFormat2.Size = New System.Drawing.Size(120, 30)
        Me.btnFormat2.TabIndex = 0
        Me.btnFormat2.Text = "5"" x 8"""
        Me.btnFormat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFormat2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFormat2.UseVisualStyleBackColor = True
        '
        'gbxFormat2
        '
        Me.gbxFormat2.Controls.Add(Me.btnFormat2)
        Me.gbxFormat2.Location = New System.Drawing.Point(150, 12)
        Me.gbxFormat2.Name = "gbxFormat2"
        Me.gbxFormat2.Size = New System.Drawing.Size(132, 58)
        Me.gbxFormat2.TabIndex = 1
        Me.gbxFormat2.TabStop = False
        Me.gbxFormat2.Text = "Formato 2"
        '
        'frmFormat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(294, 118)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbxFormat2)
        Me.Controls.Add(Me.gbxFormat1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFormat"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Formato"
        Me.gbxFormat1.ResumeLayout(False)
        Me.gbxFormat2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbxFormat1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnFormat2 As System.Windows.Forms.Button
    Friend WithEvents btnFormat1 As System.Windows.Forms.Button
    Friend WithEvents gbxFormat2 As System.Windows.Forms.GroupBox
End Class
