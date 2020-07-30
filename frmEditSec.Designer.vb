<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditSec
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
        Me.lstSectors = New System.Windows.Forms.ListBox
        Me.gbxSecOptions = New System.Windows.Forms.GroupBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.lblUpdateDate = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.lblType = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.gbxSecOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstSectors
        '
        Me.lstSectors.FormattingEnabled = True
        Me.lstSectors.HorizontalScrollbar = True
        Me.lstSectors.ItemHeight = 16
        Me.lstSectors.Location = New System.Drawing.Point(58, 12)
        Me.lstSectors.Name = "lstSectors"
        Me.lstSectors.Size = New System.Drawing.Size(272, 148)
        Me.lstSectors.TabIndex = 4
        '
        'gbxSecOptions
        '
        Me.gbxSecOptions.Controls.Add(Me.cboYear)
        Me.gbxSecOptions.Controls.Add(Me.cboMonth)
        Me.gbxSecOptions.Controls.Add(Me.lblUpdateDate)
        Me.gbxSecOptions.Controls.Add(Me.cboType)
        Me.gbxSecOptions.Controls.Add(Me.lblType)
        Me.gbxSecOptions.Controls.Add(Me.txtName)
        Me.gbxSecOptions.Controls.Add(Me.lblName)
        Me.gbxSecOptions.Enabled = False
        Me.gbxSecOptions.Location = New System.Drawing.Point(12, 166)
        Me.gbxSecOptions.Name = "gbxSecOptions"
        Me.gbxSecOptions.Size = New System.Drawing.Size(318, 111)
        Me.gbxSecOptions.TabIndex = 5
        Me.gbxSecOptions.TabStop = False
        '
        'cboYear
        '
        Me.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(238, 81)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(74, 24)
        Me.cboYear.TabIndex = 6
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cboMonth.Location = New System.Drawing.Point(102, 81)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(130, 24)
        Me.cboMonth.TabIndex = 5
        '
        'lblUpdateDate
        '
        Me.lblUpdateDate.AutoSize = True
        Me.lblUpdateDate.Location = New System.Drawing.Point(6, 84)
        Me.lblUpdateDate.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblUpdateDate.Name = "lblUpdateDate"
        Me.lblUpdateDate.Size = New System.Drawing.Size(78, 16)
        Me.lblUpdateDate.TabIndex = 4
        Me.lblUpdateDate.Text = "Actualizado:"
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Casas", "Apartamentos"})
        Me.cboType.Location = New System.Drawing.Point(102, 51)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(130, 24)
        Me.cboType.TabIndex = 3
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(6, 54)
        Me.lblType.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(38, 16)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Tipo:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(102, 22)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(210, 23)
        Me.txtName.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(6, 25)
        Me.lblName.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(58, 16)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Nombre:"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.Territory_Manager.My.Resources.Resources.disk
        Me.btnSave.Location = New System.Drawing.Point(12, 283)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 30)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Guardar"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.Territory_Manager.My.Resources.Resources.decline
        Me.btnCancel.Location = New System.Drawing.Point(240, 283)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancelar"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'btnDown
        '
        Me.btnDown.Enabled = False
        Me.btnDown.Image = Global.Territory_Manager.My.Resources.Resources.down
        Me.btnDown.Location = New System.Drawing.Point(12, 48)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(40, 30)
        Me.btnDown.TabIndex = 1
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUp
        '
        Me.btnUp.Enabled = False
        Me.btnUp.Image = Global.Territory_Manager.My.Resources.Resources.up
        Me.btnUp.Location = New System.Drawing.Point(12, 12)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(40, 30)
        Me.btnUp.TabIndex = 0
        Me.btnUp.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.Territory_Manager.My.Resources.Resources.delete
        Me.btnDelete.Location = New System.Drawing.Point(12, 130)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(40, 30)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.Territory_Manager.My.Resources.Resources.add
        Me.btnAdd.Location = New System.Drawing.Point(12, 94)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(40, 30)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'frmEditSec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(342, 325)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbxSecOptions)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lstSectors)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditSec"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Sectores"
        Me.gbxSecOptions.ResumeLayout(False)
        Me.gbxSecOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstSectors As System.Windows.Forms.ListBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbxSecOptions As System.Windows.Forms.GroupBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblUpdateDate As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox

End Class
