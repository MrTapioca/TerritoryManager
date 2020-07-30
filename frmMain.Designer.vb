<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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

    Friend WithEvents btnSaveSector As System.Windows.Forms.Button
    Friend WithEvents gbxTerrInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditTerr As System.Windows.Forms.Button
    Friend WithEvents gbxSectors As System.Windows.Forms.GroupBox
    Friend WithEvents cboSectors As System.Windows.Forms.ComboBox
    Friend WithEvents btnEditSec As System.Windows.Forms.Button
    Friend WithEvents gbxHeaders As System.Windows.Forms.GroupBox
    Friend WithEvents lstHeaders As System.Windows.Forms.ListBox
    Friend WithEvents btnAddHeader As System.Windows.Forms.Button
    Friend WithEvents btnDelHeader As System.Windows.Forms.Button
    Friend WithEvents btnEditHeader As System.Windows.Forms.Button
    Friend WithEvents btnNewTerr As System.Windows.Forms.Button
    Friend WithEvents btnOpenTerr As System.Windows.Forms.Button
    Friend WithEvents txtTerrFile As System.Windows.Forms.TextBox
    Friend WithEvents lblZipCodeDesc As System.Windows.Forms.Label
    Friend WithEvents lblTerrNoteDesc As System.Windows.Forms.Label
    Friend WithEvents txtTerrNote As System.Windows.Forms.TextBox
    Friend WithEvents dtpCensus As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdb2CensusDone As System.Windows.Forms.RadioButton
    Friend WithEvents rdb1DoCensus As System.Windows.Forms.RadioButton
    Friend WithEvents chkHeaderOther As System.Windows.Forms.CheckBox
    Friend WithEvents txtHeaderOther As System.Windows.Forms.TextBox
    Friend WithEvents btnHeaderUp As System.Windows.Forms.Button
    Friend WithEvents btnHeaderDown As System.Windows.Forms.Button
    Friend WithEvents gbxDoors As System.Windows.Forms.GroupBox
    Friend WithEvents txtRV As System.Windows.Forms.TextBox
    Friend WithEvents chkAfternoons As System.Windows.Forms.CheckBox
    Friend WithEvents chkNumOther As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumOther As System.Windows.Forms.TextBox
    Friend WithEvents rdb2RV As System.Windows.Forms.RadioButton
    Friend WithEvents btnEditNum As System.Windows.Forms.Button
    Friend WithEvents btnDelNum As System.Windows.Forms.Button
    Friend WithEvents btnAddNum As System.Windows.Forms.Button
    Friend WithEvents lstDoors As System.Windows.Forms.ListBox
    Friend WithEvents txtRVOwner As System.Windows.Forms.TextBox
    Friend WithEvents lblRVOwner As System.Windows.Forms.Label
    Friend WithEvents rdb3Study As System.Windows.Forms.RadioButton
    Friend WithEvents rdb4DoNotVisit As System.Windows.Forms.RadioButton
    Friend WithEvents dtpDoNotVisit As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCaution As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdb5Caution As System.Windows.Forms.RadioButton
    Friend WithEvents rdb6Publisher As System.Windows.Forms.RadioButton
    Friend WithEvents txtPublisher As System.Windows.Forms.TextBox
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblSecDateDesc As System.Windows.Forms.Label
    Friend WithEvents txtTerrName As System.Windows.Forms.TextBox
    Friend WithEvents txtTerrNum As System.Windows.Forms.TextBox
    Friend WithEvents txtTerrZip As System.Windows.Forms.TextBox
    Friend WithEvents btnExport As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.gbxHeaders = New System.Windows.Forms.GroupBox()
        Me.pnlHeaderOptions = New System.Windows.Forms.Panel()
        Me.rdb1DoCensus = New System.Windows.Forms.RadioButton()
        Me.txtHeaderOther = New System.Windows.Forms.TextBox()
        Me.dtpCensus = New System.Windows.Forms.DateTimePicker()
        Me.mnuDateClipboard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDateClipboardItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDateClipboardItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.rdb2CensusDone = New System.Windows.Forms.RadioButton()
        Me.chkHeaderOther = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnHeaderDown = New System.Windows.Forms.Button()
        Me.btnHeaderUp = New System.Windows.Forms.Button()
        Me.btnEditHeader = New System.Windows.Forms.Button()
        Me.btnDelHeader = New System.Windows.Forms.Button()
        Me.btnAddHeader = New System.Windows.Forms.Button()
        Me.lstHeaders = New System.Windows.Forms.ListBox()
        Me.gbxSaveRevert = New System.Windows.Forms.GroupBox()
        Me.btnRevertSector = New System.Windows.Forms.Button()
        Me.btnSaveSector = New System.Windows.Forms.Button()
        Me.gbxDoors = New System.Windows.Forms.GroupBox()
        Me.pnlDoorOptions = New System.Windows.Forms.Panel()
        Me.rdb1None = New System.Windows.Forms.RadioButton()
        Me.lblRVOwnerPic = New System.Windows.Forms.Label()
        Me.lblRVPic = New System.Windows.Forms.Label()
        Me.rdb2RV = New System.Windows.Forms.RadioButton()
        Me.rdb4DoNotVisit = New System.Windows.Forms.RadioButton()
        Me.rdb6Publisher = New System.Windows.Forms.RadioButton()
        Me.rdb5Caution = New System.Windows.Forms.RadioButton()
        Me.dtpCaution = New System.Windows.Forms.DateTimePicker()
        Me.txtNumOther = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDoNotVisit = New System.Windows.Forms.DateTimePicker()
        Me.chkNumOther = New System.Windows.Forms.CheckBox()
        Me.rdb3Study = New System.Windows.Forms.RadioButton()
        Me.chkAfternoons = New System.Windows.Forms.CheckBox()
        Me.lblRV = New System.Windows.Forms.Label()
        Me.txtRV = New System.Windows.Forms.TextBox()
        Me.lblRVOwner = New System.Windows.Forms.Label()
        Me.txtRVOwner = New System.Windows.Forms.TextBox()
        Me.txtPublisher = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSortDoors = New System.Windows.Forms.Button()
        Me.btnDoorDown = New System.Windows.Forms.Button()
        Me.btnDoorUp = New System.Windows.Forms.Button()
        Me.btnEditNum = New System.Windows.Forms.Button()
        Me.btnDelNum = New System.Windows.Forms.Button()
        Me.btnAddNum = New System.Windows.Forms.Button()
        Me.lstDoors = New System.Windows.Forms.ListBox()
        Me.lblSortStatus = New System.Windows.Forms.Label()
        Me.gbxTerrInfo = New System.Windows.Forms.GroupBox()
        Me.txtTerrZip = New System.Windows.Forms.TextBox()
        Me.txtTerrNum = New System.Windows.Forms.TextBox()
        Me.txtTerrNote = New System.Windows.Forms.TextBox()
        Me.lblTerrNoteDesc = New System.Windows.Forms.Label()
        Me.lblZipCodeDesc = New System.Windows.Forms.Label()
        Me.btnEditTerr = New System.Windows.Forms.Button()
        Me.txtTerrName = New System.Windows.Forms.TextBox()
        Me.gbxSectors = New System.Windows.Forms.GroupBox()
        Me.txtSectorDate = New System.Windows.Forms.TextBox()
        Me.txtSectorType = New System.Windows.Forms.TextBox()
        Me.lblSecTypeDesc = New System.Windows.Forms.Label()
        Me.lblSecDateDesc = New System.Windows.Forms.Label()
        Me.btnEditSec = New System.Windows.Forms.Button()
        Me.cboSectors = New System.Windows.Forms.ComboBox()
        Me.txtTerrFile = New System.Windows.Forms.TextBox()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog()
        Me.gbxFile = New System.Windows.Forms.GroupBox()
        Me.btnNewTerr = New System.Windows.Forms.Button()
        Me.btnOpenTerr = New System.Windows.Forms.Button()
        Me.gbxMisc = New System.Windows.Forms.GroupBox()
        Me.btnDoorCount = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.gbxHeaders.SuspendLayout()
        Me.pnlHeaderOptions.SuspendLayout()
        Me.mnuDateClipboard.SuspendLayout()
        Me.gbxSaveRevert.SuspendLayout()
        Me.gbxDoors.SuspendLayout()
        Me.pnlDoorOptions.SuspendLayout()
        Me.gbxTerrInfo.SuspendLayout()
        Me.gbxSectors.SuspendLayout()
        Me.gbxFile.SuspendLayout()
        Me.gbxMisc.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxHeaders
        '
        Me.gbxHeaders.Controls.Add(Me.pnlHeaderOptions)
        Me.gbxHeaders.Controls.Add(Me.btnHeaderDown)
        Me.gbxHeaders.Controls.Add(Me.btnHeaderUp)
        Me.gbxHeaders.Controls.Add(Me.btnEditHeader)
        Me.gbxHeaders.Controls.Add(Me.btnDelHeader)
        Me.gbxHeaders.Controls.Add(Me.btnAddHeader)
        Me.gbxHeaders.Controls.Add(Me.lstHeaders)
        Me.gbxHeaders.Enabled = False
        Me.gbxHeaders.Location = New System.Drawing.Point(12, 204)
        Me.gbxHeaders.Name = "gbxHeaders"
        Me.gbxHeaders.Size = New System.Drawing.Size(375, 256)
        Me.gbxHeaders.TabIndex = 4
        Me.gbxHeaders.TabStop = False
        Me.gbxHeaders.Text = "Calles"
        '
        'pnlHeaderOptions
        '
        Me.pnlHeaderOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeaderOptions.Controls.Add(Me.rdb1DoCensus)
        Me.pnlHeaderOptions.Controls.Add(Me.txtHeaderOther)
        Me.pnlHeaderOptions.Controls.Add(Me.dtpCensus)
        Me.pnlHeaderOptions.Controls.Add(Me.rdb2CensusDone)
        Me.pnlHeaderOptions.Controls.Add(Me.chkHeaderOther)
        Me.pnlHeaderOptions.Controls.Add(Me.Label1)
        Me.pnlHeaderOptions.Controls.Add(Me.Label2)
        Me.pnlHeaderOptions.Location = New System.Drawing.Point(223, 22)
        Me.pnlHeaderOptions.Name = "pnlHeaderOptions"
        Me.pnlHeaderOptions.Size = New System.Drawing.Size(146, 228)
        Me.pnlHeaderOptions.TabIndex = 6
        '
        'rdb1DoCensus
        '
        Me.rdb1DoCensus.Enabled = False
        Me.rdb1DoCensus.Image = Global.Territory_Manager.My.Resources.Resources.find
        Me.rdb1DoCensus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb1DoCensus.Location = New System.Drawing.Point(6, 6)
        Me.rdb1DoCensus.Name = "rdb1DoCensus"
        Me.rdb1DoCensus.Size = New System.Drawing.Size(132, 24)
        Me.rdb1DoCensus.TabIndex = 0
        Me.rdb1DoCensus.TabStop = True
        Me.rdb1DoCensus.Text = "Censar"
        Me.rdb1DoCensus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb1DoCensus.UseVisualStyleBackColor = True
        '
        'txtHeaderOther
        '
        Me.txtHeaderOther.Location = New System.Drawing.Point(6, 187)
        Me.txtHeaderOther.Name = "txtHeaderOther"
        Me.txtHeaderOther.Size = New System.Drawing.Size(132, 23)
        Me.txtHeaderOther.TabIndex = 4
        Me.txtHeaderOther.Visible = False
        '
        'dtpCensus
        '
        Me.dtpCensus.ContextMenuStrip = Me.mnuDateClipboard
        Me.dtpCensus.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCensus.Location = New System.Drawing.Point(6, 67)
        Me.dtpCensus.Name = "dtpCensus"
        Me.dtpCensus.Size = New System.Drawing.Size(132, 23)
        Me.dtpCensus.TabIndex = 2
        Me.dtpCensus.Value = New Date(2011, 1, 1, 1, 0, 0, 0)
        Me.dtpCensus.Visible = False
        '
        'mnuDateClipboard
        '
        Me.mnuDateClipboard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDateClipboardItem1, Me.mnuDateClipboardItem2})
        Me.mnuDateClipboard.Name = "mnuDateCopyPaste"
        Me.mnuDateClipboard.Size = New System.Drawing.Size(142, 48)
        '
        'mnuDateClipboardItem1
        '
        Me.mnuDateClipboardItem1.Image = Global.Territory_Manager.My.Resources.Resources.page_white_copy
        Me.mnuDateClipboardItem1.Name = "mnuDateClipboardItem1"
        Me.mnuDateClipboardItem1.Size = New System.Drawing.Size(141, 22)
        Me.mnuDateClipboardItem1.Text = "Copiar fecha"
        '
        'mnuDateClipboardItem2
        '
        Me.mnuDateClipboardItem2.Image = Global.Territory_Manager.My.Resources.Resources.page_white_paste
        Me.mnuDateClipboardItem2.Name = "mnuDateClipboardItem2"
        Me.mnuDateClipboardItem2.Size = New System.Drawing.Size(141, 22)
        Me.mnuDateClipboardItem2.Text = "Pegar fecha"
        '
        'rdb2CensusDone
        '
        Me.rdb2CensusDone.Enabled = False
        Me.rdb2CensusDone.Image = Global.Territory_Manager.My.Resources.Resources.tick
        Me.rdb2CensusDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb2CensusDone.Location = New System.Drawing.Point(6, 36)
        Me.rdb2CensusDone.Name = "rdb2CensusDone"
        Me.rdb2CensusDone.Size = New System.Drawing.Size(132, 24)
        Me.rdb2CensusDone.TabIndex = 1
        Me.rdb2CensusDone.TabStop = True
        Me.rdb2CensusDone.Text = "Censado:"
        Me.rdb2CensusDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb2CensusDone.UseVisualStyleBackColor = True
        '
        'chkHeaderOther
        '
        Me.chkHeaderOther.Enabled = False
        Me.chkHeaderOther.Image = CType(resources.GetObject("chkHeaderOther.Image"), System.Drawing.Image)
        Me.chkHeaderOther.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkHeaderOther.Location = New System.Drawing.Point(9, 156)
        Me.chkHeaderOther.Name = "chkHeaderOther"
        Me.chkHeaderOther.Size = New System.Drawing.Size(132, 24)
        Me.chkHeaderOther.TabIndex = 3
        Me.chkHeaderOther.Text = "Nota:"
        Me.chkHeaderOther.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkHeaderOther.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 22)
        Me.Label1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 22)
        Me.Label2.TabIndex = 6
        '
        'btnHeaderDown
        '
        Me.btnHeaderDown.Enabled = False
        Me.btnHeaderDown.Image = Global.Territory_Manager.My.Resources.Resources.down
        Me.btnHeaderDown.Location = New System.Drawing.Point(6, 58)
        Me.btnHeaderDown.Name = "btnHeaderDown"
        Me.btnHeaderDown.Size = New System.Drawing.Size(40, 30)
        Me.btnHeaderDown.TabIndex = 1
        Me.btnHeaderDown.UseVisualStyleBackColor = True
        '
        'btnHeaderUp
        '
        Me.btnHeaderUp.Enabled = False
        Me.btnHeaderUp.Image = Global.Territory_Manager.My.Resources.Resources.up
        Me.btnHeaderUp.Location = New System.Drawing.Point(6, 22)
        Me.btnHeaderUp.Name = "btnHeaderUp"
        Me.btnHeaderUp.Size = New System.Drawing.Size(40, 30)
        Me.btnHeaderUp.TabIndex = 0
        Me.btnHeaderUp.UseVisualStyleBackColor = True
        '
        'btnEditHeader
        '
        Me.btnEditHeader.Enabled = False
        Me.btnEditHeader.Image = Global.Territory_Manager.My.Resources.Resources.pencil
        Me.btnEditHeader.Location = New System.Drawing.Point(6, 220)
        Me.btnEditHeader.Name = "btnEditHeader"
        Me.btnEditHeader.Size = New System.Drawing.Size(40, 30)
        Me.btnEditHeader.TabIndex = 4
        Me.btnEditHeader.UseVisualStyleBackColor = True
        '
        'btnDelHeader
        '
        Me.btnDelHeader.Enabled = False
        Me.btnDelHeader.Image = Global.Territory_Manager.My.Resources.Resources.delete
        Me.btnDelHeader.Location = New System.Drawing.Point(6, 184)
        Me.btnDelHeader.Name = "btnDelHeader"
        Me.btnDelHeader.Size = New System.Drawing.Size(40, 30)
        Me.btnDelHeader.TabIndex = 3
        Me.btnDelHeader.UseVisualStyleBackColor = True
        '
        'btnAddHeader
        '
        Me.btnAddHeader.Image = Global.Territory_Manager.My.Resources.Resources.add
        Me.btnAddHeader.Location = New System.Drawing.Point(6, 148)
        Me.btnAddHeader.Name = "btnAddHeader"
        Me.btnAddHeader.Size = New System.Drawing.Size(40, 30)
        Me.btnAddHeader.TabIndex = 2
        Me.btnAddHeader.UseVisualStyleBackColor = True
        '
        'lstHeaders
        '
        Me.lstHeaders.FormattingEnabled = True
        Me.lstHeaders.HorizontalScrollbar = True
        Me.lstHeaders.ItemHeight = 16
        Me.lstHeaders.Location = New System.Drawing.Point(52, 22)
        Me.lstHeaders.Name = "lstHeaders"
        Me.lstHeaders.Size = New System.Drawing.Size(165, 228)
        Me.lstHeaders.TabIndex = 5
        '
        'gbxSaveRevert
        '
        Me.gbxSaveRevert.Controls.Add(Me.btnRevertSector)
        Me.gbxSaveRevert.Controls.Add(Me.btnSaveSector)
        Me.gbxSaveRevert.Enabled = False
        Me.gbxSaveRevert.Location = New System.Drawing.Point(12, 459)
        Me.gbxSaveRevert.Name = "gbxSaveRevert"
        Me.gbxSaveRevert.Size = New System.Drawing.Size(375, 49)
        Me.gbxSaveRevert.TabIndex = 6
        Me.gbxSaveRevert.TabStop = False
        '
        'btnRevertSector
        '
        Me.btnRevertSector.Image = Global.Territory_Manager.My.Resources.Resources.reload_red
        Me.btnRevertSector.Location = New System.Drawing.Point(223, 13)
        Me.btnRevertSector.Name = "btnRevertSector"
        Me.btnRevertSector.Size = New System.Drawing.Size(146, 30)
        Me.btnRevertSector.TabIndex = 1
        Me.btnRevertSector.Text = "Cancelar"
        Me.btnRevertSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRevertSector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRevertSector.UseVisualStyleBackColor = True
        '
        'btnSaveSector
        '
        Me.btnSaveSector.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSector.Image = Global.Territory_Manager.My.Resources.Resources.disk
        Me.btnSaveSector.Location = New System.Drawing.Point(6, 13)
        Me.btnSaveSector.Name = "btnSaveSector"
        Me.btnSaveSector.Size = New System.Drawing.Size(211, 30)
        Me.btnSaveSector.TabIndex = 0
        Me.btnSaveSector.Text = "Guardar"
        Me.btnSaveSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveSector.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveSector.UseVisualStyleBackColor = True
        '
        'gbxDoors
        '
        Me.gbxDoors.Controls.Add(Me.pnlDoorOptions)
        Me.gbxDoors.Controls.Add(Me.btnSortDoors)
        Me.gbxDoors.Controls.Add(Me.btnDoorDown)
        Me.gbxDoors.Controls.Add(Me.btnDoorUp)
        Me.gbxDoors.Controls.Add(Me.btnEditNum)
        Me.gbxDoors.Controls.Add(Me.btnDelNum)
        Me.gbxDoors.Controls.Add(Me.btnAddNum)
        Me.gbxDoors.Controls.Add(Me.lstDoors)
        Me.gbxDoors.Controls.Add(Me.lblSortStatus)
        Me.gbxDoors.Enabled = False
        Me.gbxDoors.Location = New System.Drawing.Point(393, 204)
        Me.gbxDoors.Name = "gbxDoors"
        Me.gbxDoors.Size = New System.Drawing.Size(438, 304)
        Me.gbxDoors.TabIndex = 5
        Me.gbxDoors.TabStop = False
        Me.gbxDoors.Text = "Puertas"
        '
        'pnlDoorOptions
        '
        Me.pnlDoorOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDoorOptions.Controls.Add(Me.rdb1None)
        Me.pnlDoorOptions.Controls.Add(Me.lblRVOwnerPic)
        Me.pnlDoorOptions.Controls.Add(Me.lblRVPic)
        Me.pnlDoorOptions.Controls.Add(Me.rdb2RV)
        Me.pnlDoorOptions.Controls.Add(Me.rdb4DoNotVisit)
        Me.pnlDoorOptions.Controls.Add(Me.rdb6Publisher)
        Me.pnlDoorOptions.Controls.Add(Me.rdb5Caution)
        Me.pnlDoorOptions.Controls.Add(Me.dtpCaution)
        Me.pnlDoorOptions.Controls.Add(Me.txtNumOther)
        Me.pnlDoorOptions.Controls.Add(Me.Label6)
        Me.pnlDoorOptions.Controls.Add(Me.dtpDoNotVisit)
        Me.pnlDoorOptions.Controls.Add(Me.chkNumOther)
        Me.pnlDoorOptions.Controls.Add(Me.rdb3Study)
        Me.pnlDoorOptions.Controls.Add(Me.chkAfternoons)
        Me.pnlDoorOptions.Controls.Add(Me.lblRV)
        Me.pnlDoorOptions.Controls.Add(Me.txtRV)
        Me.pnlDoorOptions.Controls.Add(Me.lblRVOwner)
        Me.pnlDoorOptions.Controls.Add(Me.txtRVOwner)
        Me.pnlDoorOptions.Controls.Add(Me.txtPublisher)
        Me.pnlDoorOptions.Controls.Add(Me.Label3)
        Me.pnlDoorOptions.Controls.Add(Me.Label4)
        Me.pnlDoorOptions.Controls.Add(Me.Label5)
        Me.pnlDoorOptions.Controls.Add(Me.Label7)
        Me.pnlDoorOptions.Controls.Add(Me.Label8)
        Me.pnlDoorOptions.Location = New System.Drawing.Point(148, 22)
        Me.pnlDoorOptions.Name = "pnlDoorOptions"
        Me.pnlDoorOptions.Size = New System.Drawing.Size(284, 276)
        Me.pnlDoorOptions.TabIndex = 7
        '
        'rdb1None
        '
        Me.rdb1None.Enabled = False
        Me.rdb1None.Image = Global.Territory_Manager.My.Resources.Resources.page_white
        Me.rdb1None.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb1None.Location = New System.Drawing.Point(6, 6)
        Me.rdb1None.Name = "rdb1None"
        Me.rdb1None.Size = New System.Drawing.Size(132, 24)
        Me.rdb1None.TabIndex = 0
        Me.rdb1None.TabStop = True
        Me.rdb1None.Text = "Ningún dato"
        Me.rdb1None.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb1None.UseVisualStyleBackColor = True
        '
        'lblRVOwnerPic
        '
        Me.lblRVOwnerPic.Enabled = False
        Me.lblRVOwnerPic.Image = Global.Territory_Manager.My.Resources.Resources.user_suit_black
        Me.lblRVOwnerPic.Location = New System.Drawing.Point(32, 100)
        Me.lblRVOwnerPic.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRVOwnerPic.Name = "lblRVOwnerPic"
        Me.lblRVOwnerPic.Size = New System.Drawing.Size(16, 16)
        Me.lblRVOwnerPic.TabIndex = 7
        '
        'lblRVPic
        '
        Me.lblRVPic.Enabled = False
        Me.lblRVPic.Image = Global.Territory_Manager.My.Resources.Resources.user_home
        Me.lblRVPic.Location = New System.Drawing.Point(32, 70)
        Me.lblRVPic.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRVPic.Name = "lblRVPic"
        Me.lblRVPic.Size = New System.Drawing.Size(16, 16)
        Me.lblRVPic.TabIndex = 3
        '
        'rdb2RV
        '
        Me.rdb2RV.Enabled = False
        Me.rdb2RV.Image = Global.Territory_Manager.My.Resources.Resources.book
        Me.rdb2RV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb2RV.Location = New System.Drawing.Point(6, 36)
        Me.rdb2RV.Name = "rdb2RV"
        Me.rdb2RV.Size = New System.Drawing.Size(132, 24)
        Me.rdb2RV.TabIndex = 1
        Me.rdb2RV.TabStop = True
        Me.rdb2RV.Text = "Revisita"
        Me.rdb2RV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb2RV.UseVisualStyleBackColor = True
        '
        'rdb4DoNotVisit
        '
        Me.rdb4DoNotVisit.Enabled = False
        Me.rdb4DoNotVisit.Image = Global.Territory_Manager.My.Resources.Resources.cross
        Me.rdb4DoNotVisit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb4DoNotVisit.Location = New System.Drawing.Point(6, 126)
        Me.rdb4DoNotVisit.Name = "rdb4DoNotVisit"
        Me.rdb4DoNotVisit.Size = New System.Drawing.Size(132, 24)
        Me.rdb4DoNotVisit.TabIndex = 11
        Me.rdb4DoNotVisit.TabStop = True
        Me.rdb4DoNotVisit.Text = "No visite:"
        Me.rdb4DoNotVisit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb4DoNotVisit.UseVisualStyleBackColor = True
        '
        'rdb6Publisher
        '
        Me.rdb6Publisher.Enabled = False
        Me.rdb6Publisher.Image = Global.Territory_Manager.My.Resources.Resources.user_suit
        Me.rdb6Publisher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb6Publisher.Location = New System.Drawing.Point(6, 186)
        Me.rdb6Publisher.Name = "rdb6Publisher"
        Me.rdb6Publisher.Size = New System.Drawing.Size(132, 24)
        Me.rdb6Publisher.TabIndex = 15
        Me.rdb6Publisher.TabStop = True
        Me.rdb6Publisher.Text = "Publicador:"
        Me.rdb6Publisher.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb6Publisher.UseVisualStyleBackColor = True
        '
        'rdb5Caution
        '
        Me.rdb5Caution.Enabled = False
        Me.rdb5Caution.Image = Global.Territory_Manager.My.Resources.Resources.exclamation
        Me.rdb5Caution.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb5Caution.Location = New System.Drawing.Point(6, 156)
        Me.rdb5Caution.Name = "rdb5Caution"
        Me.rdb5Caution.Size = New System.Drawing.Size(132, 24)
        Me.rdb5Caution.TabIndex = 13
        Me.rdb5Caution.TabStop = True
        Me.rdb5Caution.Text = "Cautela:"
        Me.rdb5Caution.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb5Caution.UseVisualStyleBackColor = True
        '
        'dtpCaution
        '
        Me.dtpCaution.ContextMenuStrip = Me.mnuDateClipboard
        Me.dtpCaution.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCaution.Location = New System.Drawing.Point(144, 155)
        Me.dtpCaution.Name = "dtpCaution"
        Me.dtpCaution.Size = New System.Drawing.Size(132, 23)
        Me.dtpCaution.TabIndex = 14
        Me.dtpCaution.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpCaution.Visible = False
        '
        'txtNumOther
        '
        Me.txtNumOther.Location = New System.Drawing.Point(144, 246)
        Me.txtNumOther.Name = "txtNumOther"
        Me.txtNumOther.Size = New System.Drawing.Size(132, 23)
        Me.txtNumOther.TabIndex = 19
        Me.txtNumOther.Visible = False
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(144, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 22)
        Me.Label6.TabIndex = 21
        '
        'dtpDoNotVisit
        '
        Me.dtpDoNotVisit.ContextMenuStrip = Me.mnuDateClipboard
        Me.dtpDoNotVisit.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDoNotVisit.Location = New System.Drawing.Point(144, 125)
        Me.dtpDoNotVisit.Name = "dtpDoNotVisit"
        Me.dtpDoNotVisit.Size = New System.Drawing.Size(132, 23)
        Me.dtpDoNotVisit.TabIndex = 12
        Me.dtpDoNotVisit.Value = New Date(2011, 1, 1, 0, 0, 0, 0)
        Me.dtpDoNotVisit.Visible = False
        '
        'chkNumOther
        '
        Me.chkNumOther.Enabled = False
        Me.chkNumOther.Image = CType(resources.GetObject("chkNumOther.Image"), System.Drawing.Image)
        Me.chkNumOther.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkNumOther.Location = New System.Drawing.Point(6, 246)
        Me.chkNumOther.Name = "chkNumOther"
        Me.chkNumOther.Size = New System.Drawing.Size(132, 24)
        Me.chkNumOther.TabIndex = 18
        Me.chkNumOther.Text = "Nota:"
        Me.chkNumOther.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkNumOther.UseVisualStyleBackColor = True
        '
        'rdb3Study
        '
        Me.rdb3Study.Enabled = False
        Me.rdb3Study.Image = Global.Territory_Manager.My.Resources.Resources.book_open
        Me.rdb3Study.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.rdb3Study.Location = New System.Drawing.Point(144, 36)
        Me.rdb3Study.Name = "rdb3Study"
        Me.rdb3Study.Size = New System.Drawing.Size(132, 24)
        Me.rdb3Study.TabIndex = 2
        Me.rdb3Study.TabStop = True
        Me.rdb3Study.Text = "Estudio"
        Me.rdb3Study.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rdb3Study.UseVisualStyleBackColor = True
        '
        'chkAfternoons
        '
        Me.chkAfternoons.Enabled = False
        Me.chkAfternoons.Image = Global.Territory_Manager.My.Resources.Resources.time
        Me.chkAfternoons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkAfternoons.Location = New System.Drawing.Point(6, 216)
        Me.chkAfternoons.Name = "chkAfternoons"
        Me.chkAfternoons.Size = New System.Drawing.Size(132, 24)
        Me.chkAfternoons.TabIndex = 17
        Me.chkAfternoons.Text = "Tardes"
        Me.chkAfternoons.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chkAfternoons.UseVisualStyleBackColor = True
        '
        'lblRV
        '
        Me.lblRV.Enabled = False
        Me.lblRV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRV.Location = New System.Drawing.Point(51, 70)
        Me.lblRV.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRV.Name = "lblRV"
        Me.lblRV.Size = New System.Drawing.Size(90, 16)
        Me.lblRV.TabIndex = 4
        Me.lblRV.Text = "Interesado:"
        '
        'txtRV
        '
        Me.txtRV.Location = New System.Drawing.Point(144, 67)
        Me.txtRV.Name = "txtRV"
        Me.txtRV.Size = New System.Drawing.Size(132, 23)
        Me.txtRV.TabIndex = 5
        Me.txtRV.Visible = False
        '
        'lblRVOwner
        '
        Me.lblRVOwner.Enabled = False
        Me.lblRVOwner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblRVOwner.Location = New System.Drawing.Point(51, 100)
        Me.lblRVOwner.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblRVOwner.Name = "lblRVOwner"
        Me.lblRVOwner.Size = New System.Drawing.Size(90, 16)
        Me.lblRVOwner.TabIndex = 8
        Me.lblRVOwner.Text = "Publicador:"
        '
        'txtRVOwner
        '
        Me.txtRVOwner.Location = New System.Drawing.Point(144, 97)
        Me.txtRVOwner.Name = "txtRVOwner"
        Me.txtRVOwner.Size = New System.Drawing.Size(132, 23)
        Me.txtRVOwner.TabIndex = 9
        Me.txtRVOwner.Visible = False
        '
        'txtPublisher
        '
        Me.txtPublisher.Location = New System.Drawing.Point(144, 187)
        Me.txtPublisher.Name = "txtPublisher"
        Me.txtPublisher.Size = New System.Drawing.Size(132, 23)
        Me.txtPublisher.TabIndex = 16
        Me.txtPublisher.Visible = False
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(144, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 22)
        Me.Label3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(144, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 22)
        Me.Label4.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(144, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 22)
        Me.Label5.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Enabled = False
        Me.Label7.Location = New System.Drawing.Point(144, 187)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(132, 22)
        Me.Label7.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(144, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 22)
        Me.Label8.TabIndex = 23
        '
        'btnSortDoors
        '
        Me.btnSortDoors.Enabled = False
        Me.btnSortDoors.Image = Global.Territory_Manager.My.Resources.Resources.sort_ascending
        Me.btnSortDoors.Location = New System.Drawing.Point(6, 268)
        Me.btnSortDoors.Name = "btnSortDoors"
        Me.btnSortDoors.Size = New System.Drawing.Size(40, 30)
        Me.btnSortDoors.TabIndex = 5
        Me.btnSortDoors.UseVisualStyleBackColor = True
        '
        'btnDoorDown
        '
        Me.btnDoorDown.Enabled = False
        Me.btnDoorDown.Image = Global.Territory_Manager.My.Resources.Resources.down
        Me.btnDoorDown.Location = New System.Drawing.Point(6, 58)
        Me.btnDoorDown.Name = "btnDoorDown"
        Me.btnDoorDown.Size = New System.Drawing.Size(40, 30)
        Me.btnDoorDown.TabIndex = 1
        Me.btnDoorDown.UseVisualStyleBackColor = True
        '
        'btnDoorUp
        '
        Me.btnDoorUp.Enabled = False
        Me.btnDoorUp.Image = Global.Territory_Manager.My.Resources.Resources.up
        Me.btnDoorUp.Location = New System.Drawing.Point(6, 22)
        Me.btnDoorUp.Name = "btnDoorUp"
        Me.btnDoorUp.Size = New System.Drawing.Size(40, 30)
        Me.btnDoorUp.TabIndex = 0
        Me.btnDoorUp.UseVisualStyleBackColor = True
        '
        'btnEditNum
        '
        Me.btnEditNum.Enabled = False
        Me.btnEditNum.Image = Global.Territory_Manager.My.Resources.Resources.pencil
        Me.btnEditNum.Location = New System.Drawing.Point(6, 220)
        Me.btnEditNum.Name = "btnEditNum"
        Me.btnEditNum.Size = New System.Drawing.Size(40, 30)
        Me.btnEditNum.TabIndex = 4
        Me.btnEditNum.UseVisualStyleBackColor = True
        '
        'btnDelNum
        '
        Me.btnDelNum.Enabled = False
        Me.btnDelNum.Image = Global.Territory_Manager.My.Resources.Resources.delete
        Me.btnDelNum.Location = New System.Drawing.Point(6, 184)
        Me.btnDelNum.Name = "btnDelNum"
        Me.btnDelNum.Size = New System.Drawing.Size(40, 30)
        Me.btnDelNum.TabIndex = 3
        Me.btnDelNum.UseVisualStyleBackColor = True
        '
        'btnAddNum
        '
        Me.btnAddNum.Image = Global.Territory_Manager.My.Resources.Resources.add
        Me.btnAddNum.Location = New System.Drawing.Point(6, 148)
        Me.btnAddNum.Name = "btnAddNum"
        Me.btnAddNum.Size = New System.Drawing.Size(40, 30)
        Me.btnAddNum.TabIndex = 2
        Me.btnAddNum.UseVisualStyleBackColor = True
        '
        'lstDoors
        '
        Me.lstDoors.FormattingEnabled = True
        Me.lstDoors.HorizontalScrollbar = True
        Me.lstDoors.ItemHeight = 16
        Me.lstDoors.Location = New System.Drawing.Point(52, 22)
        Me.lstDoors.Name = "lstDoors"
        Me.lstDoors.Size = New System.Drawing.Size(90, 276)
        Me.lstDoors.TabIndex = 6
        '
        'lblSortStatus
        '
        Me.lblSortStatus.BackColor = System.Drawing.Color.LightCoral
        Me.lblSortStatus.Location = New System.Drawing.Point(50, 20)
        Me.lblSortStatus.Name = "lblSortStatus"
        Me.lblSortStatus.Size = New System.Drawing.Size(94, 280)
        Me.lblSortStatus.TabIndex = 8
        Me.lblSortStatus.Visible = False
        '
        'gbxTerrInfo
        '
        Me.gbxTerrInfo.Controls.Add(Me.txtTerrZip)
        Me.gbxTerrInfo.Controls.Add(Me.txtTerrNum)
        Me.gbxTerrInfo.Controls.Add(Me.txtTerrNote)
        Me.gbxTerrInfo.Controls.Add(Me.lblTerrNoteDesc)
        Me.gbxTerrInfo.Controls.Add(Me.lblZipCodeDesc)
        Me.gbxTerrInfo.Controls.Add(Me.btnEditTerr)
        Me.gbxTerrInfo.Controls.Add(Me.txtTerrName)
        Me.gbxTerrInfo.Enabled = False
        Me.gbxTerrInfo.Location = New System.Drawing.Point(12, 76)
        Me.gbxTerrInfo.Name = "gbxTerrInfo"
        Me.gbxTerrInfo.Size = New System.Drawing.Size(819, 58)
        Me.gbxTerrInfo.TabIndex = 2
        Me.gbxTerrInfo.TabStop = False
        Me.gbxTerrInfo.Text = "Territorio"
        '
        'txtTerrZip
        '
        Me.txtTerrZip.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrZip.Location = New System.Drawing.Point(717, 26)
        Me.txtTerrZip.Name = "txtTerrZip"
        Me.txtTerrZip.ReadOnly = True
        Me.txtTerrZip.Size = New System.Drawing.Size(50, 23)
        Me.txtTerrZip.TabIndex = 5
        Me.txtTerrZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTerrNum
        '
        Me.txtTerrNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrNum.Location = New System.Drawing.Point(6, 26)
        Me.txtTerrNum.Name = "txtTerrNum"
        Me.txtTerrNum.ReadOnly = True
        Me.txtTerrNum.Size = New System.Drawing.Size(50, 23)
        Me.txtTerrNum.TabIndex = 0
        Me.txtTerrNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTerrNote
        '
        Me.txtTerrNote.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrNote.Location = New System.Drawing.Point(391, 26)
        Me.txtTerrNote.Name = "txtTerrNote"
        Me.txtTerrNote.ReadOnly = True
        Me.txtTerrNote.Size = New System.Drawing.Size(260, 23)
        Me.txtTerrNote.TabIndex = 3
        '
        'lblTerrNoteDesc
        '
        Me.lblTerrNoteDesc.AutoSize = True
        Me.lblTerrNoteDesc.Location = New System.Drawing.Point(349, 29)
        Me.lblTerrNoteDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblTerrNoteDesc.Name = "lblTerrNoteDesc"
        Me.lblTerrNoteDesc.Size = New System.Drawing.Size(39, 16)
        Me.lblTerrNoteDesc.TabIndex = 2
        Me.lblTerrNoteDesc.Text = "Nota:"
        '
        'lblZipCodeDesc
        '
        Me.lblZipCodeDesc.AutoSize = True
        Me.lblZipCodeDesc.Location = New System.Drawing.Point(684, 29)
        Me.lblZipCodeDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblZipCodeDesc.Name = "lblZipCodeDesc"
        Me.lblZipCodeDesc.Size = New System.Drawing.Size(30, 16)
        Me.lblZipCodeDesc.TabIndex = 4
        Me.lblZipCodeDesc.Text = "Zip:"
        '
        'btnEditTerr
        '
        Me.btnEditTerr.Image = Global.Territory_Manager.My.Resources.Resources.pencil
        Me.btnEditTerr.Location = New System.Drawing.Point(773, 22)
        Me.btnEditTerr.Name = "btnEditTerr"
        Me.btnEditTerr.Size = New System.Drawing.Size(40, 30)
        Me.btnEditTerr.TabIndex = 6
        Me.btnEditTerr.UseVisualStyleBackColor = True
        '
        'txtTerrName
        '
        Me.txtTerrName.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrName.Location = New System.Drawing.Point(62, 26)
        Me.txtTerrName.Name = "txtTerrName"
        Me.txtTerrName.ReadOnly = True
        Me.txtTerrName.Size = New System.Drawing.Size(260, 23)
        Me.txtTerrName.TabIndex = 1
        '
        'gbxSectors
        '
        Me.gbxSectors.Controls.Add(Me.txtSectorDate)
        Me.gbxSectors.Controls.Add(Me.txtSectorType)
        Me.gbxSectors.Controls.Add(Me.lblSecTypeDesc)
        Me.gbxSectors.Controls.Add(Me.lblSecDateDesc)
        Me.gbxSectors.Controls.Add(Me.btnEditSec)
        Me.gbxSectors.Controls.Add(Me.cboSectors)
        Me.gbxSectors.Enabled = False
        Me.gbxSectors.Location = New System.Drawing.Point(12, 140)
        Me.gbxSectors.Name = "gbxSectors"
        Me.gbxSectors.Size = New System.Drawing.Size(819, 58)
        Me.gbxSectors.TabIndex = 3
        Me.gbxSectors.TabStop = False
        Me.gbxSectors.Text = "Sectores"
        '
        'txtSectorDate
        '
        Me.txtSectorDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtSectorDate.Location = New System.Drawing.Point(635, 26)
        Me.txtSectorDate.Name = "txtSectorDate"
        Me.txtSectorDate.ReadOnly = True
        Me.txtSectorDate.Size = New System.Drawing.Size(132, 23)
        Me.txtSectorDate.TabIndex = 4
        Me.txtSectorDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSectorType
        '
        Me.txtSectorType.BackColor = System.Drawing.SystemColors.Window
        Me.txtSectorType.Location = New System.Drawing.Point(391, 26)
        Me.txtSectorType.Name = "txtSectorType"
        Me.txtSectorType.ReadOnly = True
        Me.txtSectorType.Size = New System.Drawing.Size(132, 23)
        Me.txtSectorType.TabIndex = 2
        Me.txtSectorType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSecTypeDesc
        '
        Me.lblSecTypeDesc.AutoSize = True
        Me.lblSecTypeDesc.Location = New System.Drawing.Point(350, 29)
        Me.lblSecTypeDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSecTypeDesc.Name = "lblSecTypeDesc"
        Me.lblSecTypeDesc.Size = New System.Drawing.Size(38, 16)
        Me.lblSecTypeDesc.TabIndex = 1
        Me.lblSecTypeDesc.Text = "Tipo:"
        '
        'lblSecDateDesc
        '
        Me.lblSecDateDesc.AutoSize = True
        Me.lblSecDateDesc.Location = New System.Drawing.Point(585, 29)
        Me.lblSecDateDesc.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.lblSecDateDesc.Name = "lblSecDateDesc"
        Me.lblSecDateDesc.Size = New System.Drawing.Size(47, 16)
        Me.lblSecDateDesc.TabIndex = 3
        Me.lblSecDateDesc.Text = "Fecha:"
        '
        'btnEditSec
        '
        Me.btnEditSec.Image = Global.Territory_Manager.My.Resources.Resources.pencil
        Me.btnEditSec.Location = New System.Drawing.Point(773, 22)
        Me.btnEditSec.Name = "btnEditSec"
        Me.btnEditSec.Size = New System.Drawing.Size(40, 30)
        Me.btnEditSec.TabIndex = 5
        Me.btnEditSec.UseVisualStyleBackColor = True
        '
        'cboSectors
        '
        Me.cboSectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSectors.FormattingEnabled = True
        Me.cboSectors.Location = New System.Drawing.Point(6, 26)
        Me.cboSectors.Name = "cboSectors"
        Me.cboSectors.Size = New System.Drawing.Size(316, 24)
        Me.cboSectors.TabIndex = 0
        '
        'txtTerrFile
        '
        Me.txtTerrFile.BackColor = System.Drawing.SystemColors.Window
        Me.txtTerrFile.Location = New System.Drawing.Point(99, 26)
        Me.txtTerrFile.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTerrFile.Name = "txtTerrFile"
        Me.txtTerrFile.ReadOnly = True
        Me.txtTerrFile.Size = New System.Drawing.Size(513, 23)
        Me.txtTerrFile.TabIndex = 2
        '
        'dlgSave
        '
        Me.dlgSave.DefaultExt = "*.terr"
        Me.dlgSave.Filter = "Territory Manager File|*.terr"
        Me.dlgSave.Title = "Crear Nuevo"
        '
        'dlgOpen
        '
        Me.dlgOpen.DefaultExt = "*.terr"
        Me.dlgOpen.Filter = "Territory Manager File|*.terr"
        Me.dlgOpen.Title = "Abrir"
        '
        'gbxFile
        '
        Me.gbxFile.Controls.Add(Me.txtTerrFile)
        Me.gbxFile.Controls.Add(Me.btnNewTerr)
        Me.gbxFile.Controls.Add(Me.btnOpenTerr)
        Me.gbxFile.Location = New System.Drawing.Point(12, 12)
        Me.gbxFile.Name = "gbxFile"
        Me.gbxFile.Size = New System.Drawing.Size(619, 58)
        Me.gbxFile.TabIndex = 0
        Me.gbxFile.TabStop = False
        Me.gbxFile.Text = "Archivo"
        '
        'btnNewTerr
        '
        Me.btnNewTerr.Image = Global.Territory_Manager.My.Resources.Resources.page
        Me.btnNewTerr.Location = New System.Drawing.Point(6, 22)
        Me.btnNewTerr.Name = "btnNewTerr"
        Me.btnNewTerr.Size = New System.Drawing.Size(40, 30)
        Me.btnNewTerr.TabIndex = 0
        Me.btnNewTerr.UseVisualStyleBackColor = True
        '
        'btnOpenTerr
        '
        Me.btnOpenTerr.Image = Global.Territory_Manager.My.Resources.Resources.folder
        Me.btnOpenTerr.Location = New System.Drawing.Point(52, 22)
        Me.btnOpenTerr.Name = "btnOpenTerr"
        Me.btnOpenTerr.Size = New System.Drawing.Size(40, 30)
        Me.btnOpenTerr.TabIndex = 1
        Me.btnOpenTerr.UseVisualStyleBackColor = True
        '
        'gbxMisc
        '
        Me.gbxMisc.Controls.Add(Me.btnDoorCount)
        Me.gbxMisc.Controls.Add(Me.btnAbout)
        Me.gbxMisc.Controls.Add(Me.btnExport)
        Me.gbxMisc.Location = New System.Drawing.Point(637, 12)
        Me.gbxMisc.Name = "gbxMisc"
        Me.gbxMisc.Size = New System.Drawing.Size(194, 58)
        Me.gbxMisc.TabIndex = 1
        Me.gbxMisc.TabStop = False
        '
        'btnDoorCount
        '
        Me.btnDoorCount.Enabled = False
        Me.btnDoorCount.Image = Global.Territory_Manager.My.Resources.Resources.calculator
        Me.btnDoorCount.Location = New System.Drawing.Point(102, 22)
        Me.btnDoorCount.Name = "btnDoorCount"
        Me.btnDoorCount.Size = New System.Drawing.Size(40, 30)
        Me.btnDoorCount.TabIndex = 1
        Me.btnDoorCount.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Image = Global.Territory_Manager.My.Resources.Resources.information
        Me.btnAbout.Location = New System.Drawing.Point(148, 22)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(40, 30)
        Me.btnAbout.TabIndex = 2
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Enabled = False
        Me.btnExport.Image = Global.Territory_Manager.My.Resources.Resources.page_excel
        Me.btnExport.Location = New System.Drawing.Point(6, 22)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(90, 30)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "Exportar"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(843, 520)
        Me.Controls.Add(Me.gbxHeaders)
        Me.Controls.Add(Me.gbxSectors)
        Me.Controls.Add(Me.gbxMisc)
        Me.Controls.Add(Me.gbxFile)
        Me.Controls.Add(Me.gbxTerrInfo)
        Me.Controls.Add(Me.gbxSaveRevert)
        Me.Controls.Add(Me.gbxDoors)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Territory Manager"
        Me.gbxHeaders.ResumeLayout(False)
        Me.pnlHeaderOptions.ResumeLayout(False)
        Me.pnlHeaderOptions.PerformLayout()
        Me.mnuDateClipboard.ResumeLayout(False)
        Me.gbxSaveRevert.ResumeLayout(False)
        Me.gbxDoors.ResumeLayout(False)
        Me.pnlDoorOptions.ResumeLayout(False)
        Me.pnlDoorOptions.PerformLayout()
        Me.gbxTerrInfo.ResumeLayout(False)
        Me.gbxTerrInfo.PerformLayout()
        Me.gbxSectors.ResumeLayout(False)
        Me.gbxSectors.PerformLayout()
        Me.gbxFile.ResumeLayout(False)
        Me.gbxFile.PerformLayout()
        Me.gbxMisc.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdb1None As System.Windows.Forms.RadioButton
    Friend WithEvents btnRevertSector As System.Windows.Forms.Button
    Friend WithEvents btnDoorDown As System.Windows.Forms.Button
    Friend WithEvents btnDoorUp As System.Windows.Forms.Button
    Friend WithEvents gbxSaveRevert As System.Windows.Forms.GroupBox
    Friend WithEvents btnAbout As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSortDoors As System.Windows.Forms.Button
    Friend WithEvents lblRVPic As System.Windows.Forms.Label
    Friend WithEvents lblRV As System.Windows.Forms.Label
    Friend WithEvents lblRVOwnerPic As System.Windows.Forms.Label
    Friend WithEvents mnuDateClipboard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDateClipboardItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDateClipboardItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gbxFile As System.Windows.Forms.GroupBox
    Friend WithEvents gbxMisc As System.Windows.Forms.GroupBox
    Friend WithEvents pnlHeaderOptions As System.Windows.Forms.Panel
    Friend WithEvents pnlDoorOptions As System.Windows.Forms.Panel
    Friend WithEvents lblSecTypeDesc As System.Windows.Forms.Label
    Friend WithEvents txtSectorType As System.Windows.Forms.TextBox
    Friend WithEvents txtSectorDate As System.Windows.Forms.TextBox
    Friend WithEvents lblSortStatus As System.Windows.Forms.Label
    Friend WithEvents btnDoorCount As System.Windows.Forms.Button

End Class
