Imports System.IO

Public Class frmMain

    Dim Tips As New ToolTip
    Dim dDateClipboard As Date = Nothing

    Dim FW As System.IO.StreamWriter
    Dim FR As System.IO.StreamReader

    Dim DisableHeaderSave As Boolean
    Dim DisableDoorSave As Boolean

    Dim SavingHeaderName As Boolean
    Dim SavingDoorName As Boolean

    ' Color to apply to options selected
    Dim SELCOLOR As Color = Color.Red

    Private Sub ClearDataAndForm()
        Dim i1 As Byte
        Dim i2 As Byte
        Dim i3 As Byte

        ' Clear main Territory info
        With MainInfo
            .P0_intTerrNum = 0
            .P1_strName = "Nuevo Territorio"
            .P2_strNote = ""
            .P3_strZipCode = "00000"
            .P4_intSectorCount = 1                              ' Add 1 sector
        End With

        ' Loop through each Sector slot (20 total)
        For i1 = 0 To 19

            ' Clear the Sector info of the current iteration
            With Sector(i1)
                .P1_strName = ""                                ' Blank
                .P2_bytIsApt = 0                                ' False
                .P3_bytUpdateMonth = 1                          ' Default month
                .P4_shrUpdateYear = 2011                        ' Default year
                .P5_intHeaderCount = 0                          ' No headers
            End With

            ' Loop through each Header slot (100 total) of the current Sector iteration
            For i2 = 0 To 99

                ' Clear the Header info
                With Header(i1, i2)
                    .P1_strBuilding = ""                        ' Blank
                    .P2_strStreet = ""                          ' Blank
                    .P3_bytCensusStatus = 1                     ' Do census
                    .P4_dteCensusDate = #1/1/2011#              ' Default
                    .P5_bytOtherInfo = 0                        ' False
                    .P6_strOtherInfoText = ""                   ' Blank
                    .P7_intDoorCount = 0                        ' No doors
                End With

                ' Clear the temporary Header info
                With TempHeader(i1, i2)
                    .P1_strBuilding = ""                        ' Blank
                    .P2_strStreet = ""                          ' Blank
                    .P3_bytCensusStatus = 1                     ' Do census
                    .P4_dteCensusDate = #1/1/2011#                ' Default
                    .P5_bytOtherInfo = 0                        ' False
                    .P6_strOtherInfoText = ""                   ' Blank
                    .P7_intDoorCount = 0                        ' No doors
                End With

                ' Loop through each Door slot (100 total) of the current Header iteration
                For i3 = 0 To 99

                    ' Clear the Door info
                    With Door(i1, i2, i3)
                        .P0_strDoorNum = ""                     ' Blank
                        .P1_bytInfoSelection = 1                ' First selection
                        .P2_strRV = ""                          ' Blank
                        .P3_strRVOwner = ""                     ' Blank
                        .P4_dteDoNotVisit = #1/1/2011#            ' Default
                        .P5_dteCaution = #1/1/2011#      ' Default
                        .P6_strPublisher = ""                     ' Blank
                        .P7_bytAfternoons = 0                   ' False
                        .P8_bytOtherInfo = 0                    ' False
                        .P9_strOtherInfoText = ""               ' Blank
                    End With

                    ' Clear the temporary Door info
                    With TempDoor(i1, i2, i3)
                        .P0_strDoorNum = ""                     ' Blank
                        .P1_bytInfoSelection = 1                ' First selection
                        .P2_strRV = ""                          ' Blank
                        .P3_strRVOwner = ""                     ' Blank
                        .P4_dteDoNotVisit = #1/1/2011#            ' Default
                        .P5_dteCaution = #1/1/2011#      ' Default
                        .P6_strPublisher = ""                     ' Blank
                        .P7_bytAfternoons = 0                   ' False
                        .P8_bytOtherInfo = 0                    ' False
                        .P9_strOtherInfoText = ""               ' Blank
                    End With
                Next
            Next
        Next

        ' Clear the Header and Door controls
        gbxHeaders.Text = "Calles"
        'gbxDoors.Text = "Puertas"

        ClearHeadersDoors()

        txtTerrFile.Text = ""
        cboSectors.Items.Clear()

    End Sub

    Private Sub ClearHeadersDoors(Optional ByVal OnlyClearOptions As Boolean = False)
        ' Clear the controls in the Headers groupbox
        If OnlyClearOptions = False Then
            lstHeaders.Items.Clear()
            SelectedHeader = -1
        End If

        DisableHeaderSave = True

        btnHeaderUp.Enabled = False
        btnHeaderDown.Enabled = False
        btnEditHeader.Enabled = False
        btnDelHeader.Enabled = False

        rdb1DoCensus.Checked = False
        rdb1DoCensus.Enabled = False

        rdb2CensusDone.Checked = False
        rdb2CensusDone.Enabled = False

        dtpCensus.Value = #1/1/2011#
        dtpCensus.Visible = False

        chkHeaderOther.Checked = False
        chkHeaderOther.Enabled = False
        txtHeaderOther.Text = ""
        txtHeaderOther.Visible = False

        DisableHeaderSave = False

        ClearDoors()
    End Sub

    Private Sub ClearDoors(Optional ByVal OnlyClearOptions As Boolean = False)
        ' Clear the controls in the Doors groupbox
        If OnlyClearOptions = False Then
            lstDoors.Items.Clear()
            SelectedDoor = -1
        End If

        DisableDoorSave = True

        btnDoorUp.Enabled = False
        btnDoorDown.Enabled = False
        btnAddNum.Enabled = False
        btnEditNum.Enabled = False
        btnDelNum.Enabled = False
        btnSortDoors.Enabled = False

        rdb1None.Checked = False
        rdb1None.Enabled = False

        rdb2RV.Checked = False
        rdb2RV.Enabled = False

        'lblOr.Enabled = False

        rdb3Study.Checked = False
        rdb3Study.Enabled = False

        lblRVPic.Enabled = False
        lblRV.Enabled = False
        txtRV.Text = ""
        txtRV.Visible = False

        lblRVOwnerPic.Enabled = False
        lblRVOwner.Enabled = False
        txtRVOwner.Text = ""
        txtRVOwner.Visible = False

        rdb4DoNotVisit.Checked = False
        rdb4DoNotVisit.Enabled = False
        dtpDoNotVisit.Value = #1/1/2011#
        dtpDoNotVisit.Visible = False

        rdb5Caution.Checked = False
        rdb5Caution.Enabled = False
        dtpCaution.Value = #1/1/2011#
        dtpCaution.Visible = False

        rdb6Publisher.Checked = False
        rdb6Publisher.Enabled = False

        txtPublisher.Text = ""
        txtPublisher.Visible = False

        chkAfternoons.Checked = False
        chkAfternoons.Enabled = False

        chkNumOther.Checked = False
        chkNumOther.Enabled = False
        txtNumOther.Text = ""
        txtNumOther.Visible = False

        DisableDoorSave = False
    End Sub

    Private Function LoadData() As Boolean
        Dim i1, i2, i3 As Integer

        Try

            FR = My.Computer.FileSystem.OpenTextFileReader(txtTerrFile.Text)

            ' Load the main territory info from lines 1 to 5
            With MainInfo
                .P0_intTerrNum = CInt(FR.ReadLine)
                .P1_strName = FR.ReadLine
                .P2_strNote = FR.ReadLine
                .P3_strZipCode = FR.ReadLine
                .P4_intSectorCount = CInt(FR.ReadLine)
            End With

            ' Loop through and load the data for each sector in the territory
            For i1 = 0 To MainInfo.P4_intSectorCount - 1

                ' Load the sector data of the current iteration
                With Sector(i1)
                    .P1_strName = FR.ReadLine
                    .P2_bytIsApt = CByte(FR.ReadLine)
                    .P3_bytUpdateMonth = CByte(FR.ReadLine)
                    .P4_shrUpdateYear = CShort(FR.ReadLine)
                    .P5_intHeaderCount = CInt(FR.ReadLine)
                End With

                ' Loop through and load the data for each header in the sector
                For i2 = 0 To Sector(i1).P5_intHeaderCount - 1

                    ' Load the header data of the current iteration
                    With Header(i1, i2)
                        .P1_strBuilding = FR.ReadLine
                        .P2_strStreet = FR.ReadLine
                        .P3_bytCensusStatus = CByte(FR.ReadLine)
                        .P4_dteCensusDate = CDate(FR.ReadLine)
                        .P5_bytOtherInfo = CByte(FR.ReadLine)
                        .P6_strOtherInfoText = FR.ReadLine
                        .P7_intDoorCount = CInt(FR.ReadLine)
                    End With

                    ' Loop through and load the data for each door in the header
                    For i3 = 0 To Header(i1, i2).P7_intDoorCount - 1

                        ' Load the door data of the curren iteration
                        With Door(i1, i2, i3)
                            .P0_strDoorNum = FR.ReadLine
                            .P1_bytInfoSelection = CByte(FR.ReadLine)
                            .P2_strRV = FR.ReadLine
                            .P3_strRVOwner = FR.ReadLine
                            .P4_dteDoNotVisit = CDate(FR.ReadLine)
                            .P5_dteCaution = CDate(FR.ReadLine)
                            .P6_strPublisher = FR.ReadLine
                            .P7_bytAfternoons = CByte(FR.ReadLine)
                            .P8_bytOtherInfo = CByte(FR.ReadLine)
                            .P9_strOtherInfoText = FR.ReadLine
                        End With
                    Next
                Next
            Next

            FR.Close()
            FR = Nothing

            LoadData = True

        Catch ex As Exception

            FR.Close()
            FR = Nothing

            ClearDataAndForm()
            txtTerrNum.Text = ""
            txtTerrName.Text = ""
            txtTerrNote.Text = ""
            txtTerrZip.Text = ""

            gbxTerrInfo.Enabled = False
            gbxSectors.Enabled = False
            'gbxSectorData.Enabled = False
            gbxHeaders.Enabled = False
            gbxDoors.Enabled = False
            gbxSaveRevert.Enabled = False
            btnExport.Enabled = False
            btnDoorCount.Enabled = False

            MsgBox("Se ha encontrado un error en el archivo.", MsgBoxStyle.Critical)

            LoadData = False

        End Try

    End Function

    Private Sub SaveData()
        Dim i1 As Integer
        Dim i2 As Integer
        Dim i3 As Integer

        FW = My.Computer.FileSystem.OpenTextFileWriter(txtTerrFile.Text, False)

        ' Write the main territory info on lines 1 to 5
        With MainInfo
            FW.WriteLine(.P0_intTerrNum.ToString)
            FW.WriteLine(.P1_strName)
            FW.WriteLine(.P2_strNote)
            FW.WriteLine(.P3_strZipCode)
            FW.WriteLine(.P4_intSectorCount.ToString)
        End With

        ' Loop through each Sector that has data
        For i1 = 0 To MainInfo.P4_intSectorCount - 1

            ' Write the Sector info of the current iteration
            With Sector(i1)
                FW.WriteLine(.P1_strName)
                FW.WriteLine(.P2_bytIsApt.ToString)
                FW.WriteLine(.P3_bytUpdateMonth.ToString)
                FW.WriteLine(.P4_shrUpdateYear.ToString)
                FW.WriteLine(.P5_intHeaderCount.ToString)
            End With

            ' Loop through each Header that has data
            For i2 = 0 To Sector(i1).P5_intHeaderCount - 1

                ' Write the Header info of the current iteration
                With Header(i1, i2)
                    FW.WriteLine(.P1_strBuilding)
                    FW.WriteLine(.P2_strStreet)
                    FW.WriteLine(.P3_bytCensusStatus.ToString)
                    FW.WriteLine(.P4_dteCensusDate.Month.ToString & "/" &
                                 .P4_dteCensusDate.Day.ToString & "/" &
                                 .P4_dteCensusDate.Year.ToString)
                    FW.WriteLine(.P5_bytOtherInfo.ToString)
                    FW.WriteLine(.P6_strOtherInfoText)
                    FW.WriteLine(.P7_intDoorCount.ToString)
                End With

                ' Loop through each Door that has data
                For i3 = 0 To Header(i1, i2).P7_intDoorCount - 1

                    ' Write the Door info of the current iteration
                    With Door(i1, i2, i3)
                        FW.WriteLine(.P0_strDoorNum)
                        FW.WriteLine(.P1_bytInfoSelection.ToString)
                        FW.WriteLine(.P2_strRV)
                        FW.WriteLine(.P3_strRVOwner)
                        FW.WriteLine(.P4_dteDoNotVisit.Month.ToString & "/" &
                                     .P4_dteDoNotVisit.Day.ToString & "/" &
                                     .P4_dteDoNotVisit.Year.ToString)
                        FW.WriteLine(.P5_dteCaution.Month.ToString & "/" &
                                     .P5_dteCaution.Day.ToString & "/" &
                                     .P5_dteCaution.Year.ToString)
                        FW.WriteLine(.P6_strPublisher)
                        FW.WriteLine(.P7_bytAfternoons.ToString)
                        FW.WriteLine(.P8_bytOtherInfo.ToString)
                        FW.WriteLine(.P9_strOtherInfoText)
                    End With
                Next
            Next
        Next

        FW.Close()
        FW = Nothing
    End Sub

    Public Sub OpenTerr(ByVal strFileName As String)
        Dim i As Integer

        ' Clear everything
        ClearDataAndForm()

        ' Display the territory file & path
        txtTerrFile.Text = strFileName

        ' Load the territory data
        If LoadData() = False Then Exit Sub

        ' Populate data
        txtTerrNum.Text = MainInfo.P0_intTerrNum.ToString
        txtTerrName.Text = MainInfo.P1_strName
        txtTerrNote.Text = MainInfo.P2_strNote
        txtTerrZip.Text = MainInfo.P3_strZipCode

        cboSectors.Items.Clear()
        SelectedSector = -1

        For i = 0 To MainInfo.P4_intSectorCount - 1
            cboSectors.Items.Add(Sector(i).P1_strName)
        Next

        cboSectors.SelectedIndex = 0

        ' Clear the temp DBs as well
        CreateTEMPS()

        ' Enable the controls
        btnExport.Enabled = True
        btnDoorCount.Enabled = True

        gbxTerrInfo.Enabled = True
        gbxSectors.Enabled = True
    End Sub

    Private Sub EnableDisableDoorSort()

        ' Disable button and set image if there are no doors
        If TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount = 0 Then

            btnSortDoors.Image = My.Resources.sort_ascending
            btnSortDoors.Enabled = False
            btnSortDoors.Visible = True

            Exit Sub

        End If

        Dim SortedLetterDoors(TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1) As String
        Dim SortedNumberDoors(TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1) As Long

        Dim Sorted As Boolean

        ' Check whether the list is numbers or letters only
        Dim NumbersOnly As Boolean = True
        Dim LettersOnly As Boolean = True

        ' --- Loop through each list item
        For i1 = 0 To TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1

            ' --- Loop through each character in the item
            For i2 = 0 To TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Length - 1
                If Char.IsNumber(TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Chars(i2)) = False Then
                    NumbersOnly = False
                End If
                If Char.IsLetter(TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Chars(i2)) = False Then
                    LettersOnly = False
                End If
            Next

        Next

        ' Disable sort button and change its picture if the list is unsortable
        If NumbersOnly = False And LettersOnly = False Then

            btnSortDoors.Image = Nothing
            btnSortDoors.Enabled = False
            btnSortDoors.Visible = False

            Exit Sub

        End If

        ' Sort the list numerically
        If NumbersOnly = True Then

            ' --- Make a numerical copy of the door list
            For i = 0 To SortedNumberDoors.GetUpperBound(0)
                SortedNumberDoors(i) = CLng(TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum)
            Next

            ' --- Sort the copy
            Array.Sort(SortedNumberDoors)

            ' --- Compare the order of the lists
            Sorted = True

            For i = 0 To SortedNumberDoors.GetUpperBound(0)
                If SortedNumberDoors(i) <> CLng(TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum) Then
                    Sorted = False
                    Exit For
                End If
            Next

        End If

        ' Sort the list alphabetically
        If LettersOnly = True Then

            ' --- Make a copy of the door list
            For i = 0 To SortedLetterDoors.GetUpperBound(0)
                SortedLetterDoors(i) = TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum
            Next

            ' --- Sort the copy
            Array.Sort(SortedLetterDoors)

            ' --- Compare the order of the lists
            Sorted = True

            For i = 0 To SortedLetterDoors.GetUpperBound(0)
                If SortedLetterDoors(i) <> TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum Then
                    Sorted = False
                    Exit For
                End If
            Next

        End If

        ' Enable/Disable sort button and set image
        btnSortDoors.Image = My.Resources.sort_ascending
        btnSortDoors.Enabled = Not Sorted
        btnSortDoors.Visible = True

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Process command-line arguments
        ProcessCmdLineArgs()

        ' Set tool tips
        With Tips

            .SetToolTip(btnOpenTerr, "Abrir")
            .SetToolTip(btnNewTerr, "Nuevo")
            .SetToolTip(txtTerrFile, "Archivo del territorio")
            .SetToolTip(btnExport, "Exportar a XML Spreadsheet")
            .SetToolTip(btnDoorCount, "Cuenta total de puertas")
            .SetToolTip(btnAbout, "Acerca de " & My.Application.Info.Title)

            .SetToolTip(txtTerrNum, "Número de territorio")
            .SetToolTip(txtTerrName, "Nombre")
            .SetToolTip(lblTerrNoteDesc, "Información adicional")
            .SetToolTip(txtTerrNote, "Información adicional")
            .SetToolTip(lblZipCodeDesc, "Código postal")
            .SetToolTip(txtTerrZip, "Código postal")
            .SetToolTip(btnEditTerr, "Editar información general")

            .SetToolTip(cboSectors, "Sector seleccionado")
            .SetToolTip(lblSecTypeDesc, "Casas o Apartamentos")
            .SetToolTip(txtSectorType, "Casas o Apartamentos")
            .SetToolTip(lblSecDateDesc, "Última actualización")
            .SetToolTip(txtSectorDate, "Última actualización")
            .SetToolTip(btnEditSec, "Editar sectores")

            .SetToolTip(lstHeaders, "Calles o Edificios")
            .SetToolTip(btnHeaderUp, "Mover arriba")
            .SetToolTip(btnHeaderDown, "Mover abajo")
            .SetToolTip(btnAddHeader, "Nuevo")
            .SetToolTip(btnDelHeader, "Eliminar")
            .SetToolTip(btnEditHeader, "Editar")

            .SetToolTip(lstDoors, "Puertas")
            .SetToolTip(btnDoorUp, "Mover la puerta arriba")
            .SetToolTip(btnDoorDown, "Mover la puerta abajo")
            .SetToolTip(btnAddNum, "Añadir una puerta")
            .SetToolTip(btnDelNum, "Eliminar la puerta")
            .SetToolTip(btnEditNum, "Editar la puerta")
            .SetToolTip(btnSortDoors, "Ordenar las puertas")

        End With

        ' Load configuration
        appSettings.LoadSettings()

    End Sub

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' <<< HOTKEYS >>>

        ' Check the CONTROL key status
        If e.Control = True Then

            ' Check the combination pressed
            Select Case e.KeyCode
                Case Keys.O
                    btnOpenTerr.PerformClick()                  ' Ctrl+O            - Open territory
                Case Keys.N
                    btnNewTerr.PerformClick()                   ' Ctrl+N            - New territory
                Case Keys.S
                    btnSaveSector.PerformClick()                ' Ctrl+S            - Save
                Case Keys.E
                    btnExport.PerformClick()                    ' Ctrl+E            - Export
            End Select

        End If

    End Sub

    Private Sub frmMain_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter

        ' Verify that the current territory is not being editted
        If gbxSaveRevert.Enabled = False Then

            ' Check that the user is dragging a file
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then

                ' Get the list of filenames being dragged
                Dim strFiles() As String
                strFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())

                ' Check that there is only 1 file being dragged
                If strFiles.Length = 1 Then

                    ' Check that the file being dragged is a territory file
                    If strFiles(0).Substring(strFiles(0).Length - 5) = ".terr" Then

                        ' Allow the drop if all the checks are successful
                        e.Effect = DragDropEffects.All

                    End If

                End If

            End If

        End If
    End Sub

    Private Sub frmMain_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            ' Get the filename being dropped
            Dim strFiles() As String
            strFiles = CType(e.Data.GetData(DataFormats.FileDrop), String())

            ' Open the territory
            OpenTerr(strFiles(0))

        End If

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' Prevent closing if changes are pending
        If gbxSaveRevert.Enabled = True Then
            e.Cancel = True
            MsgBox("Debe guardar o revertir los cambios antes de salir.", MsgBoxStyle.Exclamation)
        End If

        ' Save configuration
        If e.Cancel = False Then
            'SaveConfig()
            appSettings.SaveSettings()
        End If

    End Sub

    Private Sub btnOpenTerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenTerr.Click

        ' Clear the file name
        dlgOpen.FileName = ""
        ' Display the last used directory
        dlgOpen.InitialDirectory = appSettings.GetSettingAsStr(Settings.LastOpenDir)

        ' Execute if the dialog was accepted
        If dlgOpen.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Save the directory
            appSettings.ChangeSetting(Settings.LastOpenDir, Path.GetDirectoryName(dlgOpen.FileName))

            ' Open the territory
            OpenTerr(dlgOpen.FileName)

        End If

    End Sub

    Private Sub btnNewTerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTerr.Click
        ' Set a default territory name
        dlgSave.FileName = "Nuevo Territorio"

        ' Set dialog options
        dlgSave.DefaultExt = "terr"
        dlgSave.Filter = "Territory Manager File|*.terr"
        dlgSave.Title = "Nuevo"
        'dlgSave.InitialDirectory = cConfig.lastSaveDir
        dlgSave.InitialDirectory = appSettings.GetSettingAsStr(Settings.LastSaveDir)

        ' Execute if the dialog box was accepted
        If dlgSave.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Save directory
            'cConfig.lastSaveDir = dlgSave.FileName.Substring(0, dlgSave.FileName.LastIndexOf("\"))
            appSettings.ChangeSetting(Settings.LastSaveDir, Path.GetDirectoryName(dlgSave.FileName))

            ' Clear everything
            ClearDataAndForm()

            txtTerrNum.Text = MainInfo.P0_intTerrNum.ToString
            txtTerrName.Text = MainInfo.P1_strName
            txtTerrNote.Text = MainInfo.P2_strNote
            txtTerrZip.Text = MainInfo.P3_strZipCode

            ' Prepare 1 sector
            Sector(0).P1_strName = "Nuevo sector"

            SelectedSector = -1

            cboSectors.Items.Add(Sector(0).P1_strName)
            cboSectors.SelectedIndex = 0

            ' Clear the temp DBs as well
            CreateTEMPS()

            ' Display the territory file & path
            txtTerrFile.Text = dlgSave.FileName

            ' Create the new territory file
            SaveData()

            ' Enable the controls
            btnExport.Enabled = True
            btnDoorCount.Enabled = True

            gbxTerrInfo.Enabled = True
            gbxSectors.Enabled = True
        End If
    End Sub

    Private Sub btnEditTerr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTerr.Click
        If frmEditTerrInfo.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            SaveData()

            txtTerrNum.Text = MainInfo.P0_intTerrNum.ToString
            txtTerrName.Text = MainInfo.P1_strName
            txtTerrNote.Text = MainInfo.P2_strNote
            txtTerrZip.Text = MainInfo.P3_strZipCode
        End If

        frmEditTerrInfo.Close()
    End Sub

    Private Sub btnEditSec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditSec.Click
        Dim SectorIndex As Integer = SelectedSector

        cboSectors.SelectedIndex = -1

        If frmEditSec.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim i As Integer

            SaveData()

            ' Load each sector's name on the list
            cboSectors.Items.Clear()
            SelectedSector = -1

            For i = 0 To MainInfo.P4_intSectorCount - 1
                cboSectors.Items.Add(Sector(i).P1_strName)
            Next

            cboSectors.SelectedIndex = 0
        Else
            cboSectors.SelectedIndex = SectorIndex
        End If

        frmEditSec.Close()
    End Sub

    Private Sub cboSectors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSectors.SelectedIndexChanged
        Dim i As Integer

        If cboSectors.SelectedIndex = SelectedSector Then Exit Sub
        SelectedSector = cboSectors.SelectedIndex

        ClearHeadersDoors()

        If SelectedSector = -1 Then
            txtSectorType.Text = ""
            txtSectorDate.Text = ""
            'gbxSectorData.Enabled = False
            gbxHeaders.Enabled = False
            gbxDoors.Enabled = False
            gbxSaveRevert.Enabled = False
            Exit Sub
        End If

        CreateTEMPS(False, True, True, True)

        ' Display the sector type
        Select Case TempSector(SelectedSector).P2_bytIsApt
            Case 0 : txtSectorType.Text = "Casas"
            Case 1 : txtSectorType.Text = "Apartamentos"
        End Select

        ' Display the sector date of update
        txtSectorDate.Text = GetMonthString(TempSector(SelectedSector).P3_bytUpdateMonth) & " " &
                            TempSector(SelectedSector).P4_shrUpdateYear

        ' Populate Header data
        'gbxSectorData.Enabled = True
        gbxHeaders.Enabled = True
        gbxDoors.Enabled = False
        gbxSaveRevert.Enabled = False

        If TempSector(SelectedSector).P2_bytIsApt = 0 Then
            gbxHeaders.Text = "Calles"
            With Tips
                .SetToolTip(lstHeaders, "Calles")
                .SetToolTip(btnHeaderUp, "Mover la calle arriba")
                .SetToolTip(btnHeaderDown, "Mover la calle abajo")
                .SetToolTip(btnAddHeader, "Añadir una calle")
                .SetToolTip(btnDelHeader, "Eliminar la calle")
                .SetToolTip(btnEditHeader, "Editar la calle")
            End With

            For i = 0 To TempSector(SelectedSector).P5_intHeaderCount - 1
                lstHeaders.Items.Add(TempHeader(SelectedSector, i).P2_strStreet)
            Next
        Else
            gbxHeaders.Text = "Edificios"
            With Tips
                .SetToolTip(lstHeaders, "Edificios")
                .SetToolTip(btnHeaderUp, "Mover el edificio arriba")
                .SetToolTip(btnHeaderDown, "Mover el edificio abajo")
                .SetToolTip(btnAddHeader, "Añadir un edificio")
                .SetToolTip(btnDelHeader, "Eliminar el edificio")
                .SetToolTip(btnEditHeader, "Editar el edificio")
            End With

            For i = 0 To TempSector(SelectedSector).P5_intHeaderCount - 1
                lstHeaders.Items.Add(TempHeader(SelectedSector, i).P1_strBuilding & " " &
                                     TempHeader(SelectedSector, i).P2_strStreet)
            Next
        End If

    End Sub

    Private Sub lstHeaders_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstHeaders.DoubleClick
        If SelectedHeader = -1 Then Exit Sub
        btnEditHeader.PerformClick()
    End Sub

    Private Sub lstHeaders_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstHeaders.KeyDown

        ' Exit sub if there are no headers
        If SelectedHeader = -1 Then Exit Sub

        ' DELETE Key: Delete the header
        If e.KeyCode = Keys.Delete Then btnDelHeader.PerformClick()

    End Sub

    Private Sub lstHeaders_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstHeaders.SelectedIndexChanged
        Dim i As Integer

        If SavingHeaderName = True Then Exit Sub

        If lstHeaders.SelectedIndex = SelectedHeader Then Exit Sub
        SelectedHeader = lstHeaders.SelectedIndex

        If SelectedHeader = -1 Then
            ClearHeadersDoors(True)

            btnEditHeader.Enabled = False
            btnDelHeader.Enabled = False
            btnHeaderUp.Enabled = False
            btnHeaderDown.Enabled = False

            gbxDoors.Enabled = False
            Exit Sub
        End If

        DisableHeaderSave = True

        Select Case TempHeader(SelectedSector, SelectedHeader).P3_bytCensusStatus
            Case 1 : rdb1DoCensus.Checked = True
            Case 2 : rdb2CensusDone.Checked = True
        End Select

        dtpCensus.Value = TempHeader(SelectedSector, SelectedHeader).P4_dteCensusDate
        chkHeaderOther.Checked = CBool(TempHeader(SelectedSector, SelectedHeader).P5_bytOtherInfo)
        txtHeaderOther.Text = TempHeader(SelectedSector, SelectedHeader).P6_strOtherInfoText

        ' Enable options
        rdb1DoCensus.Enabled = True

        rdb2CensusDone.Enabled = True
        dtpCensus.Visible = rdb2CensusDone.Checked

        chkHeaderOther.Enabled = True
        txtHeaderOther.Visible = chkHeaderOther.Checked

        DisableHeaderSave = False

        ' Enable UP button if appropriate
        If SelectedHeader > 0 Then
            btnHeaderUp.Enabled = True
        Else
            btnHeaderUp.Enabled = False
        End If

        ' Enable DOWN button if appropriate
        If SelectedHeader < TempSector(SelectedSector).P5_intHeaderCount - 1 Then
            btnHeaderDown.Enabled = True
        Else
            btnHeaderDown.Enabled = False
        End If

        ' Enable header DELETE button
        btnDelHeader.Enabled = True

        ' Enable header EDIT button
        btnEditHeader.Enabled = True

        ' Enable Door options
        ClearDoors()
        gbxDoors.Enabled = True
        btnAddNum.Enabled = True
        EnableDisableDoorSort()

        ' Populate Door data
        For i = 0 To TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1
            lstDoors.Items.Add(TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum)
        Next
    End Sub

    Private Sub btnEditHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditHeader.Click

        HeaderDoorChange = 2

        If frmEditHeaderDoor.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            SavingHeaderName = True

            ' Force item text refresh
            lstHeaders.Items.Item(SelectedHeader) = ""

            If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            Else
                lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding &
                " " & TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            End If

            SavingHeaderName = False

            gbxSaveRevert.Enabled = True
        End If

        frmEditHeaderDoor.Close()

    End Sub

    Private Sub btnAddHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddHeader.Click
        ' Limit the header count to 100
        If TempSector(SelectedSector).P5_intHeaderCount = 100 Then
            If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                MsgBox("El sector no puede contener más de 100 calles.", MsgBoxStyle.Information)
            Else
                MsgBox("El sector no puede contener más de 100 edificios.", MsgBoxStyle.Information)
            End If

            Exit Sub
        End If

        HeaderDoorChange = 1

        If frmEditHeaderDoor.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                lstHeaders.Items.Add(TempHeader(SelectedSector, TempSector(SelectedSector).P5_intHeaderCount - 1).P2_strStreet)
            Else
                lstHeaders.Items.Add(TempHeader(SelectedSector, TempSector(SelectedSector).P5_intHeaderCount - 1).P1_strBuilding & " " &
                                     TempHeader(SelectedSector, TempSector(SelectedSector).P5_intHeaderCount - 1).P2_strStreet)
            End If

            lstHeaders.SelectedIndex = TempSector(SelectedSector).P5_intHeaderCount - 1

            gbxSaveRevert.Enabled = True
        End If

        frmEditHeaderDoor.Close()

    End Sub

    Private Sub btnDelHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelHeader.Click
        Dim MsgResult As MsgBoxResult
        Dim HeaderIndex As Integer
        Dim i1, i2 As Integer

        If TempSector(SelectedSector).P2_bytIsApt = 0 Then
            MsgResult = MsgBox("¿Está seguro que desea eliminar esta calle?" & vbNewLine & vbNewLine &
                             "(Se perderán todos los datos de la calle)",
                             MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Exclamation,
                             "Eliminar calle")
        Else
            MsgResult = MsgBox("¿Está seguro que desea eliminar este edificio?" & vbNewLine & vbNewLine &
                               "(Se perderán todos los datos del edificio)",
                               MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Exclamation,
                               "Eliminar calle")
        End If

        If MsgResult = MsgBoxResult.Yes Then

            HeaderIndex = SelectedHeader

            For i1 = (HeaderIndex + 1) To (TempSector(SelectedSector).P5_intHeaderCount - 1)

                For i2 = 0 To (TempHeader(SelectedSector, i1).P7_intDoorCount - 1)

                    ' Move door data back
                    With TempDoor(SelectedSector, i1 - 1, i2)
                        .P0_strDoorNum = TempDoor(SelectedSector, i1, i2).P0_strDoorNum
                        .P1_bytInfoSelection = TempDoor(SelectedSector, i1, i2).P1_bytInfoSelection
                        .P2_strRV = TempDoor(SelectedSector, i1, i2).P2_strRV
                        .P3_strRVOwner = TempDoor(SelectedSector, i1, i2).P3_strRVOwner
                        .P4_dteDoNotVisit = TempDoor(SelectedSector, i1, i2).P4_dteDoNotVisit
                        .P5_dteCaution = TempDoor(SelectedSector, i1, i2).P5_dteCaution
                        .P6_strPublisher = TempDoor(SelectedSector, i1, i2).P6_strPublisher
                        .P7_bytAfternoons = TempDoor(SelectedSector, i1, i2).P7_bytAfternoons
                        .P8_bytOtherInfo = TempDoor(SelectedSector, i1, i2).P8_bytOtherInfo
                        .P9_strOtherInfoText = TempDoor(SelectedSector, i1, i2).P9_strOtherInfoText
                    End With

                Next

                ' Move header data back
                With TempHeader(SelectedSector, i1 - 1)
                    .P1_strBuilding = TempHeader(SelectedSector, i1).P1_strBuilding
                    .P2_strStreet = TempHeader(SelectedSector, i1).P2_strStreet
                    .P3_bytCensusStatus = TempHeader(SelectedSector, i1).P3_bytCensusStatus
                    .P4_dteCensusDate = TempHeader(SelectedSector, i1).P4_dteCensusDate
                    .P5_bytOtherInfo = TempHeader(SelectedSector, i1).P5_bytOtherInfo
                    .P6_strOtherInfoText = TempHeader(SelectedSector, i1).P6_strOtherInfoText
                    .P7_intDoorCount = TempHeader(SelectedSector, i1).P7_intDoorCount
                End With

            Next

            ' Decrease the header count
            TempSector(SelectedSector).P5_intHeaderCount -= 1

            ' Remove the header from the list
            lstHeaders.Items.RemoveAt(HeaderIndex)

            gbxSaveRevert.Enabled = True

            lstHeaders.Focus()

            ' Select the next header if it exists
            If TempSector(SelectedSector).P5_intHeaderCount = 0 Then Exit Sub

            If HeaderIndex + 1 <= TempSector(SelectedSector).P5_intHeaderCount Then
                lstHeaders.SelectedIndex = HeaderIndex
            Else
                lstHeaders.SelectedIndex = HeaderIndex - 1
            End If

        End If

    End Sub

    Private Sub btnHeaderUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeaderUp.Click
        Dim SuperTempHeader As HeaderInfo
        Dim SuperTempDoor As DoorInfo

        Dim i1 As Integer

        For i1 = 0 To 99 'TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1

            ' Make a copy of the current door
            With SuperTempDoor
                .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum
                .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, i1).P1_bytInfoSelection
                .P2_strRV = TempDoor(SelectedSector, SelectedHeader, i1).P2_strRV
                .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, i1).P3_strRVOwner
                .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, i1).P4_dteDoNotVisit
                .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, i1).P5_dteCaution
                .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, i1).P6_strPublisher
                .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, i1).P7_bytAfternoons
                .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, i1).P8_bytOtherInfo
                .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, i1).P9_strOtherInfoText
            End With

            ' Move the door before to one header index after
            With TempDoor(SelectedSector, SelectedHeader, i1)
                .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader - 1, i1).P0_strDoorNum
                .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader - 1, i1).P1_bytInfoSelection
                .P2_strRV = TempDoor(SelectedSector, SelectedHeader - 1, i1).P2_strRV
                .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader - 1, i1).P3_strRVOwner
                .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader - 1, i1).P4_dteDoNotVisit
                .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader - 1, i1).P5_dteCaution
                .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader - 1, i1).P6_strPublisher
                .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader - 1, i1).P7_bytAfternoons
                .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader - 1, i1).P8_bytOtherInfo
                .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader - 1, i1).P9_strOtherInfoText
            End With

            ' Paste the current door one index before
            With TempDoor(SelectedSector, SelectedHeader - 1, i1)
                .P0_strDoorNum = SuperTempDoor.P0_strDoorNum
                .P1_bytInfoSelection = SuperTempDoor.P1_bytInfoSelection
                .P2_strRV = SuperTempDoor.P2_strRV
                .P3_strRVOwner = SuperTempDoor.P3_strRVOwner
                .P4_dteDoNotVisit = SuperTempDoor.P4_dteDoNotVisit
                .P5_dteCaution = SuperTempDoor.P5_dteCaution
                .P6_strPublisher = SuperTempDoor.P6_strPublisher
                .P7_bytAfternoons = SuperTempDoor.P7_bytAfternoons
                .P8_bytOtherInfo = SuperTempDoor.P8_bytOtherInfo
                .P9_strOtherInfoText = SuperTempDoor.P9_strOtherInfoText
            End With

        Next

        ' Make a copy of the selected header
        With SuperTempHeader
            .P1_strBuilding = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding
            .P2_strStreet = TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            .P3_bytCensusStatus = TempHeader(SelectedSector, SelectedHeader).P3_bytCensusStatus
            .P4_dteCensusDate = TempHeader(SelectedSector, SelectedHeader).P4_dteCensusDate
            .P5_bytOtherInfo = TempHeader(SelectedSector, SelectedHeader).P5_bytOtherInfo
            .P6_strOtherInfoText = TempHeader(SelectedSector, SelectedHeader).P6_strOtherInfoText
            .P7_intDoorCount = TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount
        End With

        ' Move the header before to one index after
        With TempHeader(SelectedSector, SelectedHeader)
            .P1_strBuilding = TempHeader(SelectedSector, SelectedHeader - 1).P1_strBuilding
            .P2_strStreet = TempHeader(SelectedSector, SelectedHeader - 1).P2_strStreet
            .P3_bytCensusStatus = TempHeader(SelectedSector, SelectedHeader - 1).P3_bytCensusStatus
            .P4_dteCensusDate = TempHeader(SelectedSector, SelectedHeader - 1).P4_dteCensusDate
            .P5_bytOtherInfo = TempHeader(SelectedSector, SelectedHeader - 1).P5_bytOtherInfo
            .P6_strOtherInfoText = TempHeader(SelectedSector, SelectedHeader - 1).P6_strOtherInfoText
            .P7_intDoorCount = TempHeader(SelectedSector, SelectedHeader - 1).P7_intDoorCount
        End With

        ' Paste the selected header one index before
        With TempHeader(SelectedSector, SelectedHeader - 1)
            .P1_strBuilding = SuperTempHeader.P1_strBuilding
            .P2_strStreet = SuperTempHeader.P2_strStreet
            .P3_bytCensusStatus = SuperTempHeader.P3_bytCensusStatus
            .P4_dteCensusDate = SuperTempHeader.P4_dteCensusDate
            .P5_bytOtherInfo = SuperTempHeader.P5_bytOtherInfo
            .P6_strOtherInfoText = SuperTempHeader.P6_strOtherInfoText
            .P7_intDoorCount = SuperTempHeader.P7_intDoorCount
        End With

        ' Update the header list
        SavingHeaderName = True

        If TempSector(SelectedSector).P2_bytIsApt = 0 Then
            lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            lstHeaders.Items.Item(SelectedHeader - 1) = TempHeader(SelectedSector, SelectedHeader - 1).P2_strStreet
        Else
            lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding & " " &
                                                    TempHeader(SelectedSector, SelectedHeader).P2_strStreet

            lstHeaders.Items.Item(SelectedHeader - 1) = TempHeader(SelectedSector, SelectedHeader - 1).P1_strBuilding & " " &
                                                        TempHeader(SelectedSector, SelectedHeader - 1).P2_strStreet
        End If

        SavingHeaderName = False

        lstHeaders.SelectedIndex = SelectedHeader - 1

        gbxSaveRevert.Enabled = True
    End Sub

    Private Sub btnHeaderDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHeaderDown.Click
        Dim SuperTempHeader As HeaderInfo
        Dim SuperTempDoor As DoorInfo

        Dim i1 As Integer

        For i1 = 0 To 99 'TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1

            ' Make a copy of the current door
            With SuperTempDoor
                .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum
                .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, i1).P1_bytInfoSelection
                .P2_strRV = TempDoor(SelectedSector, SelectedHeader, i1).P2_strRV
                .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, i1).P3_strRVOwner
                .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, i1).P4_dteDoNotVisit
                .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, i1).P5_dteCaution
                .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, i1).P6_strPublisher
                .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, i1).P7_bytAfternoons
                .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, i1).P8_bytOtherInfo
                .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, i1).P9_strOtherInfoText
            End With

            ' Move the door after to one header index before
            With TempDoor(SelectedSector, SelectedHeader, i1)
                .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader + 1, i1).P0_strDoorNum
                .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader + 1, i1).P1_bytInfoSelection
                .P2_strRV = TempDoor(SelectedSector, SelectedHeader + 1, i1).P2_strRV
                .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader + 1, i1).P3_strRVOwner
                .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader + 1, i1).P4_dteDoNotVisit
                .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader + 1, i1).P5_dteCaution
                .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader + 1, i1).P6_strPublisher
                .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader + 1, i1).P7_bytAfternoons
                .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader + 1, i1).P8_bytOtherInfo
                .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader + 1, i1).P9_strOtherInfoText
            End With

            ' Paste the current door one index after
            With TempDoor(SelectedSector, SelectedHeader + 1, i1)
                .P0_strDoorNum = SuperTempDoor.P0_strDoorNum
                .P1_bytInfoSelection = SuperTempDoor.P1_bytInfoSelection
                .P2_strRV = SuperTempDoor.P2_strRV
                .P3_strRVOwner = SuperTempDoor.P3_strRVOwner
                .P4_dteDoNotVisit = SuperTempDoor.P4_dteDoNotVisit
                .P5_dteCaution = SuperTempDoor.P5_dteCaution
                .P6_strPublisher = SuperTempDoor.P6_strPublisher
                .P7_bytAfternoons = SuperTempDoor.P7_bytAfternoons
                .P8_bytOtherInfo = SuperTempDoor.P8_bytOtherInfo
                .P9_strOtherInfoText = SuperTempDoor.P9_strOtherInfoText
            End With

        Next

        ' Make a copy of the selected header
        With SuperTempHeader
            .P1_strBuilding = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding
            .P2_strStreet = TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            .P3_bytCensusStatus = TempHeader(SelectedSector, SelectedHeader).P3_bytCensusStatus
            .P4_dteCensusDate = TempHeader(SelectedSector, SelectedHeader).P4_dteCensusDate
            .P5_bytOtherInfo = TempHeader(SelectedSector, SelectedHeader).P5_bytOtherInfo
            .P6_strOtherInfoText = TempHeader(SelectedSector, SelectedHeader).P6_strOtherInfoText
            .P7_intDoorCount = TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount
        End With

        ' Move the header after to one index before
        With TempHeader(SelectedSector, SelectedHeader)
            .P1_strBuilding = TempHeader(SelectedSector, SelectedHeader + 1).P1_strBuilding
            .P2_strStreet = TempHeader(SelectedSector, SelectedHeader + 1).P2_strStreet
            .P3_bytCensusStatus = TempHeader(SelectedSector, SelectedHeader + 1).P3_bytCensusStatus
            .P4_dteCensusDate = TempHeader(SelectedSector, SelectedHeader + 1).P4_dteCensusDate
            .P5_bytOtherInfo = TempHeader(SelectedSector, SelectedHeader + 1).P5_bytOtherInfo
            .P6_strOtherInfoText = TempHeader(SelectedSector, SelectedHeader + 1).P6_strOtherInfoText
            .P7_intDoorCount = TempHeader(SelectedSector, SelectedHeader + 1).P7_intDoorCount
        End With

        ' Paste the selected header one index after
        With TempHeader(SelectedSector, SelectedHeader + 1)
            .P1_strBuilding = SuperTempHeader.P1_strBuilding
            .P2_strStreet = SuperTempHeader.P2_strStreet
            .P3_bytCensusStatus = SuperTempHeader.P3_bytCensusStatus
            .P4_dteCensusDate = SuperTempHeader.P4_dteCensusDate
            .P5_bytOtherInfo = SuperTempHeader.P5_bytOtherInfo
            .P6_strOtherInfoText = SuperTempHeader.P6_strOtherInfoText
            .P7_intDoorCount = SuperTempHeader.P7_intDoorCount
        End With

        ' Update the header list
        SavingHeaderName = True

        If TempSector(SelectedSector).P2_bytIsApt = 0 Then
            lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P2_strStreet
            lstHeaders.Items.Item(SelectedHeader + 1) = TempHeader(SelectedSector, SelectedHeader + 1).P2_strStreet
        Else
            lstHeaders.Items.Item(SelectedHeader) = TempHeader(SelectedSector, SelectedHeader).P1_strBuilding & " " &
                                                    TempHeader(SelectedSector, SelectedHeader).P2_strStreet

            lstHeaders.Items.Item(SelectedHeader + 1) = TempHeader(SelectedSector, SelectedHeader + 1).P1_strBuilding & " " &
                                                        TempHeader(SelectedSector, SelectedHeader + 1).P2_strStreet
        End If

        SavingHeaderName = False

        lstHeaders.SelectedIndex = SelectedHeader + 1

        gbxSaveRevert.Enabled = True
    End Sub

    Private Sub rdb1DoCensus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb1DoCensus.CheckedChanged
        If rdb1DoCensus.Checked = True Then

            If DisableHeaderSave = False Then
                ' Save the census status
                TempHeader(SelectedSector, SelectedHeader).P3_bytCensusStatus = 1
                gbxSaveRevert.Enabled = True
            End If

            rdb1DoCensus.Font = New Font(rdb1DoCensus.Font, FontStyle.Bold)
            rdb1DoCensus.ForeColor = SELCOLOR

        Else

            rdb1DoCensus.Font = New Font(rdb1DoCensus.Font, FontStyle.Regular)
            rdb1DoCensus.ForeColor = SystemColors.ControlText

        End If
    End Sub

    Private Sub rdb2CensusDone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb2CensusDone.CheckedChanged
        If rdb2CensusDone.Checked = True Then
            ' Census done: enable the census date field
            dtpCensus.Visible = True

            If dtpCensus.Value = #1/1/2011# Then dtpCensus.Value = Now.Date

            If DisableHeaderSave = False Then
                ' Save the census status
                TempHeader(SelectedSector, SelectedHeader).P3_bytCensusStatus = 2
                gbxSaveRevert.Enabled = True
            End If

            rdb2CensusDone.Font = New Font(rdb2CensusDone.Font, FontStyle.Bold)
            rdb2CensusDone.ForeColor = SELCOLOR
        Else
            ' Census not done: disable the census date field
            dtpCensus.Visible = False

            rdb2CensusDone.Font = New Font(rdb2CensusDone.Font, FontStyle.Regular)
            rdb2CensusDone.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub dtpCensus_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCensus.ValueChanged
        ' Prevent execution at control startup
        If SelectedHeader = -1 Then Exit Sub

        If DisableHeaderSave = False Then
            ' Save the census date
            TempHeader(SelectedSector, SelectedHeader).P4_dteCensusDate = dtpCensus.Value
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub chkHeaderOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHeaderOther.CheckedChanged
        ' Enable/disable the text box depending on Checked value
        txtHeaderOther.Visible = chkHeaderOther.Checked

        ' Save the Other Checked value
        If chkHeaderOther.Checked = True Then
            If DisableHeaderSave = False Then
                TempHeader(SelectedSector, SelectedHeader).P5_bytOtherInfo = 1
                gbxSaveRevert.Enabled = True
            End If

            chkHeaderOther.Font = New Font(chkHeaderOther.Font, FontStyle.Bold)
            chkHeaderOther.ForeColor = SELCOLOR
        Else
            If DisableHeaderSave = False Then
                TempHeader(SelectedSector, SelectedHeader).P5_bytOtherInfo = 0
                gbxSaveRevert.Enabled = True
            End If

            chkHeaderOther.Font = New Font(chkHeaderOther.Font, FontStyle.Regular)
            chkHeaderOther.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtHeaderOther_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHeaderOther.TextChanged
        If DisableHeaderSave = False Then
            ' Save the Other information
            TempHeader(SelectedSector, SelectedHeader).P6_strOtherInfoText = txtHeaderOther.Text
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub lstDoors_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDoors.DoubleClick
        If SelectedDoor = -1 Then Exit Sub
        btnEditNum.PerformClick()
    End Sub

    Private Sub lstDoors_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstDoors.KeyDown

        ' Exit sub if there are no doors
        If SelectedDoor = -1 Then Exit Sub

        ' DELETE key: delete door
        If e.KeyCode = Keys.Delete Then btnDelNum.PerformClick()
    End Sub

    Private Sub lstDoors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDoors.SelectedIndexChanged
        ' Exit sub if an item's text is being changed
        If SavingDoorName = True Then Exit Sub

        ' Exit sub if it is triggered with no actual selection change
        If lstDoors.SelectedIndex = SelectedDoor Then Exit Sub

        ' Save the new selection
        SelectedDoor = lstDoors.SelectedIndex

        ' Clean controls and exit sub if no item is selected
        If SelectedDoor = -1 Then
            ClearDoors(True)

            btnEditNum.Enabled = False
            btnDelNum.Enabled = False
            btnDoorUp.Enabled = False
            btnDoorDown.Enabled = False

            Exit Sub
        End If

        ' Prevent triggering data change sub
        DisableDoorSave = True

        ' Load data for selected door
        Select Case TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection
            Case 1 : rdb1None.Checked = True
            Case 2 : rdb2RV.Checked = True
            Case 3 : rdb3Study.Checked = True
            Case 4 : rdb4DoNotVisit.Checked = True
            Case 5 : rdb5Caution.Checked = True
            Case 6 : rdb6Publisher.Checked = True
        End Select

        txtRV.Text = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P2_strRV
        txtRVOwner.Text = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P3_strRVOwner
        dtpDoNotVisit.Value = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P4_dteDoNotVisit
        dtpCaution.Value = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P5_dteCaution
        txtPublisher.Text = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P6_strPublisher
        chkAfternoons.Checked = CBool(TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P7_bytAfternoons)
        chkNumOther.Checked = CBool(TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P8_bytOtherInfo)
        txtNumOther.Text = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P9_strOtherInfoText

        ' Enable options
        rdb1None.Enabled = True

        rdb2RV.Enabled = True
        'lblOr.Enabled = True
        rdb3Study.Enabled = True

        If rdb2RV.Checked = True Or rdb3Study.Checked = True Then
            lblRVPic.Enabled = True
            lblRV.Enabled = True
            txtRV.Visible = True

            lblRVOwnerPic.Enabled = True
            lblRVOwner.Enabled = True
            txtRVOwner.Visible = True
        Else
            lblRVPic.Enabled = False
            lblRV.Enabled = False
            txtRV.Visible = False

            lblRVOwnerPic.Enabled = False
            lblRVOwner.Enabled = False
            txtRVOwner.Visible = False
        End If

        rdb4DoNotVisit.Enabled = True
        dtpDoNotVisit.Visible = rdb4DoNotVisit.Checked

        rdb5Caution.Enabled = True
        dtpCaution.Visible = rdb5Caution.Checked

        rdb6Publisher.Enabled = True
        txtPublisher.Visible = rdb6Publisher.Checked

        chkAfternoons.Enabled = True

        chkNumOther.Enabled = True
        txtNumOther.Visible = chkNumOther.Checked

        DisableDoorSave = False

        ' Enable buttons
        btnDelNum.Enabled = True
        btnEditNum.Enabled = True

        If SelectedDoor > 0 Then
            btnDoorUp.Enabled = True
        Else
            btnDoorUp.Enabled = False
        End If

        If SelectedDoor < TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1 Then
            btnDoorDown.Enabled = True
        Else
            btnDoorDown.Enabled = False
        End If
    End Sub

    Private Sub btnAddNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNum.Click
        ' Limit the door count to 100
        If TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount = 100 Then
            If TempSector(SelectedSector).P2_bytIsApt = 0 Then
                MsgBox("La calle no puede contener más de 100 puertas.", MsgBoxStyle.Information)
            Else
                MsgBox("El edificio no puede contener más de 100 puertas.", MsgBoxStyle.Information)
            End If

            Exit Sub
        End If

        HeaderDoorChange = 3

        If frmEditHeaderDoor.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            lstDoors.Items.Add(TempDoor(SelectedSector, SelectedHeader,
                                        TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1).P0_strDoorNum)

            lstDoors.SelectedIndex = TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1
            EnableDisableDoorSort()

            gbxSaveRevert.Enabled = True
        End If

        frmEditHeaderDoor.Close()
    End Sub

    Private Sub btnEditNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditNum.Click

        HeaderDoorChange = 4

        If frmEditHeaderDoor.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            SavingDoorName = True

            ' Force item text refresh
            lstDoors.Items.Item(SelectedDoor) = ""

            lstDoors.Items.Item(SelectedDoor) = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum
            SavingDoorName = False

            EnableDisableDoorSort()

            gbxSaveRevert.Enabled = True
        End If

        frmEditHeaderDoor.Close()
    End Sub

    Private Sub btnDelNum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelNum.Click
        Dim MsgResult As MsgBoxResult
        Dim DoorIndex As Integer
        Dim i As Integer

        MsgResult = MsgBox("¿Está seguro que desea eliminar esta puerta?",
                           MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Exclamation,
                           "Eliminar puerta")

        If MsgResult = MsgBoxResult.Yes Then
            DoorIndex = SelectedDoor

            For i = (DoorIndex + 1) To (TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1)

                ' Move door data back
                With TempDoor(SelectedSector, SelectedHeader, i - 1)
                    .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum
                    .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, i).P1_bytInfoSelection
                    .P2_strRV = TempDoor(SelectedSector, SelectedHeader, i).P2_strRV
                    .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, i).P3_strRVOwner
                    .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, i).P4_dteDoNotVisit
                    .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, i).P5_dteCaution
                    .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, i).P6_strPublisher
                    .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, i).P7_bytAfternoons
                    .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, i).P8_bytOtherInfo
                    .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, i).P9_strOtherInfoText
                End With

            Next

            ' Decrease the door count
            TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount -= 1

            ' Remove the door from the list
            lstDoors.Items.RemoveAt(DoorIndex)

            ' Ensures the Add button is available
            btnAddNum.Enabled = True

            EnableDisableDoorSort()

            ' Enable Save/Revert
            gbxSaveRevert.Enabled = True

            ' Set focus on door list
            lstDoors.Focus()

            ' Select the next door if it exists
            If TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount = 0 Then Exit Sub

            If DoorIndex + 1 <= TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount Then
                lstDoors.SelectedIndex = DoorIndex
            Else
                lstDoors.SelectedIndex = DoorIndex - 1
            End If

        End If
    End Sub

    Private Sub btnDoorUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoorUp.Click
        Dim SuperTempDoor As DoorInfo

        ' Make a copy of the selected door
        With SuperTempDoor
            .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum
            .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection
            .P2_strRV = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P2_strRV
            .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P3_strRVOwner
            .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P4_dteDoNotVisit
            .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P5_dteCaution
            .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P6_strPublisher
            .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P7_bytAfternoons
            .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P8_bytOtherInfo
            .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P9_strOtherInfoText
        End With

        ' Move the door before to one index after
        With TempDoor(SelectedSector, SelectedHeader, SelectedDoor)
            .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P0_strDoorNum
            .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P1_bytInfoSelection
            .P2_strRV = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P2_strRV
            .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P3_strRVOwner
            .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P4_dteDoNotVisit
            .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P5_dteCaution
            .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P6_strPublisher
            .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P7_bytAfternoons
            .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P8_bytOtherInfo
            .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P9_strOtherInfoText
        End With

        ' Paste the selected door one index before
        With TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1)
            .P0_strDoorNum = SuperTempDoor.P0_strDoorNum
            .P1_bytInfoSelection = SuperTempDoor.P1_bytInfoSelection
            .P2_strRV = SuperTempDoor.P2_strRV
            .P3_strRVOwner = SuperTempDoor.P3_strRVOwner
            .P4_dteDoNotVisit = SuperTempDoor.P4_dteDoNotVisit
            .P5_dteCaution = SuperTempDoor.P5_dteCaution
            .P6_strPublisher = SuperTempDoor.P6_strPublisher
            .P7_bytAfternoons = SuperTempDoor.P7_bytAfternoons
            .P8_bytOtherInfo = SuperTempDoor.P8_bytOtherInfo
            .P9_strOtherInfoText = SuperTempDoor.P9_strOtherInfoText
        End With

        ' Update the door list
        SavingDoorName = True

        lstDoors.Items.Item(SelectedDoor) = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum
        lstDoors.Items.Item(SelectedDoor - 1) = TempDoor(SelectedSector, SelectedHeader, SelectedDoor - 1).P0_strDoorNum

        SavingDoorName = False

        lstDoors.SelectedIndex = SelectedDoor - 1
        EnableDisableDoorSort()

        gbxSaveRevert.Enabled = True
    End Sub

    Private Sub btnDoorDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoorDown.Click
        Dim SuperTempDoor As DoorInfo

        ' Make a copy of the selected door
        With SuperTempDoor
            .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum
            .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection
            .P2_strRV = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P2_strRV
            .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P3_strRVOwner
            .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P4_dteDoNotVisit
            .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P5_dteCaution
            .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P6_strPublisher
            .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P7_bytAfternoons
            .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P8_bytOtherInfo
            .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P9_strOtherInfoText
        End With

        ' Move the door before to one index after
        With TempDoor(SelectedSector, SelectedHeader, SelectedDoor)
            .P0_strDoorNum = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P0_strDoorNum
            .P1_bytInfoSelection = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P1_bytInfoSelection
            .P2_strRV = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P2_strRV
            .P3_strRVOwner = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P3_strRVOwner
            .P4_dteDoNotVisit = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P4_dteDoNotVisit
            .P5_dteCaution = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P5_dteCaution
            .P6_strPublisher = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P6_strPublisher
            .P7_bytAfternoons = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P7_bytAfternoons
            .P8_bytOtherInfo = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P8_bytOtherInfo
            .P9_strOtherInfoText = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P9_strOtherInfoText
        End With

        ' Paste the selected door one index before
        With TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1)
            .P0_strDoorNum = SuperTempDoor.P0_strDoorNum
            .P1_bytInfoSelection = SuperTempDoor.P1_bytInfoSelection
            .P2_strRV = SuperTempDoor.P2_strRV
            .P3_strRVOwner = SuperTempDoor.P3_strRVOwner
            .P4_dteDoNotVisit = SuperTempDoor.P4_dteDoNotVisit
            .P5_dteCaution = SuperTempDoor.P5_dteCaution
            .P6_strPublisher = SuperTempDoor.P6_strPublisher
            .P7_bytAfternoons = SuperTempDoor.P7_bytAfternoons
            .P8_bytOtherInfo = SuperTempDoor.P8_bytOtherInfo
            .P9_strOtherInfoText = SuperTempDoor.P9_strOtherInfoText
        End With

        ' Update the door list
        SavingDoorName = True

        lstDoors.Items.Item(SelectedDoor) = TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P0_strDoorNum
        lstDoors.Items.Item(SelectedDoor + 1) = TempDoor(SelectedSector, SelectedHeader, SelectedDoor + 1).P0_strDoorNum

        SavingDoorName = False

        lstDoors.SelectedIndex = SelectedDoor + 1
        EnableDisableDoorSort()

        gbxSaveRevert.Enabled = True
    End Sub

    Private Sub rdb1None_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb1None.CheckedChanged
        If rdb1None.Checked = True Then
            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 1
                gbxSaveRevert.Enabled = True
            End If

            rdb1None.Font = New Font(rdb1None.Font, FontStyle.Bold)
            rdb1None.ForeColor = SELCOLOR
        Else
            rdb1None.Font = New Font(rdb1None.Font, FontStyle.Regular)
            rdb1None.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub rdb2RV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb2RV.CheckedChanged
        If rdb2RV.Checked = True Then

            lblRVPic.Enabled = True
            lblRV.Enabled = True
            txtRV.Visible = True

            lblRVOwnerPic.Enabled = True
            lblRVOwner.Enabled = True
            txtRVOwner.Visible = True

            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 2
                gbxSaveRevert.Enabled = True
            End If

            rdb2RV.Font = New Font(rdb2RV.Font, FontStyle.Bold)
            rdb2RV.ForeColor = SELCOLOR

            'lblRV.Font = New Font(lblRV.Font, FontStyle.Bold)
            'lblRV.ForeColor = SELCOLOR

            'lblRVOwner.Font = New Font(lblRVOwner.Font, FontStyle.Bold)
            'lblRVOwner.ForeColor = SELCOLOR

        Else

            If rdb3Study.Checked = False Then
                lblRVPic.Enabled = False
                lblRV.Enabled = False
                txtRV.Visible = False

                lblRVOwnerPic.Enabled = False
                lblRVOwner.Enabled = False
                txtRVOwner.Visible = False

                'lblRV.Font = New Font(lblRV.Font, FontStyle.Regular)
                'lblRV.ForeColor = SystemColors.ControlText

                'lblRVOwner.Font = New Font(lblRVOwner.Font, FontStyle.Regular)
                'lblRVOwner.ForeColor = SystemColors.ControlText
            End If

            rdb2RV.Font = New Font(rdb2RV.Font, FontStyle.Regular)
            rdb2RV.ForeColor = SystemColors.ControlText

        End If
    End Sub

    Private Sub rdb3Study_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb3Study.CheckedChanged
        If rdb3Study.Checked = True Then

            lblRVPic.Enabled = True
            lblRV.Enabled = True
            txtRV.Visible = True

            lblRVOwnerPic.Enabled = True
            lblRVOwner.Enabled = True
            txtRVOwner.Visible = True

            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 3
                gbxSaveRevert.Enabled = True
            End If

            rdb3Study.Font = New Font(rdb3Study.Font, FontStyle.Bold)
            rdb3Study.ForeColor = SELCOLOR

            'lblRV.Font = New Font(lblRV.Font, FontStyle.Bold)
            'lblRV.ForeColor = SELCOLOR

            'lblRVOwner.Font = New Font(lblRVOwner.Font, FontStyle.Bold)
            'lblRVOwner.ForeColor = SELCOLOR

        Else

            If rdb2RV.Checked = False Then
                lblRVPic.Enabled = False
                lblRV.Enabled = False
                txtRV.Visible = False

                lblRVOwnerPic.Enabled = False
                lblRVOwner.Enabled = False
                txtRVOwner.Visible = False

                'lblRV.Font = New Font(lblRV.Font, FontStyle.Regular)
                'lblRV.ForeColor = SystemColors.ControlText

                'lblRVOwner.Font = New Font(lblRVOwner.Font, FontStyle.Regular)
                'lblRVOwner.ForeColor = SystemColors.ControlText

            End If

            rdb3Study.Font = New Font(rdb3Study.Font, FontStyle.Regular)
            rdb3Study.ForeColor = SystemColors.ControlText

        End If
    End Sub

    Private Sub txtRV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRV.TextChanged
        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P2_strRV = txtRV.Text
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub txtRVOwner_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRVOwner.TextChanged
        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P3_strRVOwner = txtRVOwner.Text
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub rdb4DoNotVisit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb4DoNotVisit.CheckedChanged
        If rdb4DoNotVisit.Checked = True Then
            dtpDoNotVisit.Visible = True

            If dtpDoNotVisit.Value = #1/1/2011# Then dtpDoNotVisit.Value = Now.Date

            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 4
                gbxSaveRevert.Enabled = True
            End If

            rdb4DoNotVisit.Font = New Font(rdb4DoNotVisit.Font, FontStyle.Bold)
            rdb4DoNotVisit.ForeColor = SELCOLOR
        Else
            dtpDoNotVisit.Visible = False

            rdb4DoNotVisit.Font = New Font(rdb4DoNotVisit.Font, FontStyle.Regular)
            rdb4DoNotVisit.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub dtpDoNotVisit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDoNotVisit.ValueChanged
        If SelectedDoor = -1 Then Exit Sub

        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P4_dteDoNotVisit = dtpDoNotVisit.Value
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub rdb5Caution_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb5Caution.CheckedChanged
        If rdb5Caution.Checked = True Then
            dtpCaution.Visible = True

            If dtpCaution.Value = #1/1/2011# Then dtpCaution.Value = Now.Date

            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 5
                gbxSaveRevert.Enabled = True
            End If

            rdb5Caution.Font = New Font(rdb5Caution.Font, FontStyle.Bold)
            rdb5Caution.ForeColor = SELCOLOR
        Else
            dtpCaution.Visible = False

            rdb5Caution.Font = New Font(rdb5Caution.Font, FontStyle.Regular)
            rdb5Caution.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub dtpCaution_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpCaution.ValueChanged
        If SelectedDoor = -1 Then Exit Sub

        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P5_dteCaution = dtpCaution.Value
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub rdb6Publisher_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb6Publisher.CheckedChanged
        If rdb6Publisher.Checked = True Then
            txtPublisher.Visible = True

            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P1_bytInfoSelection = 6
                gbxSaveRevert.Enabled = True
            End If

            rdb6Publisher.Font = New Font(rdb6Publisher.Font, FontStyle.Bold)
            rdb6Publisher.ForeColor = SELCOLOR
        Else
            txtPublisher.Visible = False

            rdb6Publisher.Font = New Font(rdb6Publisher.Font, FontStyle.Regular)
            rdb6Publisher.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtPublisher_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPublisher.TextChanged
        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P6_strPublisher = txtPublisher.Text
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub chkAfternoons_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAfternoons.CheckedChanged
        If chkAfternoons.Checked = True Then
            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P7_bytAfternoons = 1
                gbxSaveRevert.Enabled = True
            End If

            chkAfternoons.Font = New Font(chkAfternoons.Font, FontStyle.Bold)
            chkAfternoons.ForeColor = SELCOLOR
        Else
            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P7_bytAfternoons = 0
                gbxSaveRevert.Enabled = True
            End If

            chkAfternoons.Font = New Font(chkAfternoons.Font, FontStyle.Regular)
            chkAfternoons.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub chkNumOther_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNumOther.CheckedChanged
        txtNumOther.Visible = chkNumOther.Checked

        If chkNumOther.Checked = True Then
            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P8_bytOtherInfo = 1
                gbxSaveRevert.Enabled = True
            End If

            chkNumOther.Font = New Font(chkNumOther.Font, FontStyle.Bold)
            chkNumOther.ForeColor = SELCOLOR
        Else
            If DisableDoorSave = False Then
                TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P8_bytOtherInfo = 0
                gbxSaveRevert.Enabled = True
            End If

            chkNumOther.Font = New Font(chkNumOther.Font, FontStyle.Regular)
            chkNumOther.ForeColor = SystemColors.ControlText
        End If
    End Sub

    Private Sub txtNumOther_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumOther.TextChanged
        If DisableDoorSave = False Then
            TempDoor(SelectedSector, SelectedHeader, SelectedDoor).P9_strOtherInfoText = txtNumOther.Text
            gbxSaveRevert.Enabled = True
        End If
    End Sub

    Private Sub btnSaveSector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSector.Click

        SaveTEMPS(False, True, True, True)
        SaveData()

        gbxSaveRevert.Enabled = False

    End Sub

    Private Sub btnRevertSector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRevertSector.Click
        Dim MsgResult As MsgBoxResult

        MsgResult = MsgBox("¿Está seguro que desea cancelar los cambios?",
                           MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question)

        If MsgResult = MsgBoxResult.Yes Then

            Dim CurrentSector As Integer

            ' Deselect and reselect the sector to reload the data
            CurrentSector = SelectedSector
            cboSectors.SelectedIndex = -1
            cboSectors.SelectedIndex = CurrentSector

        End If

    End Sub

    Private Sub gbxSaveRevert_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbxSaveRevert.EnabledChanged

        btnOpenTerr.Enabled = Not gbxSaveRevert.Enabled
        btnNewTerr.Enabled = Not gbxSaveRevert.Enabled
        btnExport.Enabled = Not gbxSaveRevert.Enabled
        btnDoorCount.Enabled = Not gbxSaveRevert.Enabled

        btnEditTerr.Enabled = Not gbxSaveRevert.Enabled
        btnEditSec.Enabled = Not gbxSaveRevert.Enabled

        cboSectors.Enabled = Not gbxSaveRevert.Enabled

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If frmFormat.ShowDialog() = Windows.Forms.DialogResult.OK Then

            ' Reset result flag
            ExportSuccess = False

            ' Suggest file name
            dlgSave.FileName = System.IO.Path.GetFileNameWithoutExtension(txtTerrFile.Text)
            'With dlgSave
            '    .FileName = txtTerrFile.Text.Substring(txtTerrFile.Text.LastIndexOf("\") + 1)
            '    .FileName = .FileName.Substring(0, .FileName.LastIndexOf("."))
            'End With

            ' Set dialog options
            If appSettings.GetSettingAsBool(Settings.UseXmlExtension) = True Then
                dlgSave.DefaultExt = "xml"
                dlgSave.Filter = "XML Spreadsheet|*.xml"
            Else
                dlgSave.DefaultExt = "xls"
                dlgSave.Filter = "XML Spreadsheet|*.xls"
            End If
            'If cConfig.useXmlExtension = True Then

            'Else

            'End If

            dlgSave.Title = "Exportar"
            'dlgSave.InitialDirectory = cConfig.lastExportDir
            dlgSave.InitialDirectory = appSettings.GetSettingAsStr(Settings.LastExportDir)

            If dlgSave.ShowDialog = Windows.Forms.DialogResult.OK Then

                ' Save directory
                'cConfig.lastExportDir = dlgSave.FileName.Substring(0, dlgSave.FileName.LastIndexOf("\"))
                appSettings.ChangeSetting(Settings.LastExportDir, Path.GetDirectoryName(dlgSave.FileName))

                ' Save file name
                ExportFileName = dlgSave.FileName

                ' Show export form
                frmExport.ShowDialog()
                frmExport.Close()

                ' Check that the export was successful
                If ExportSuccess = True Then

                    ' Ask to open exported file
                    If MsgBox("¿Quiere abrir el territorio exportado?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then

                        ' Open exported file with default application
                        Dim oProcess As New System.Diagnostics.Process
                        Dim oStartInfo As New System.Diagnostics.ProcessStartInfo(dlgSave.FileName)

                        oStartInfo.UseShellExecute = True
                        oStartInfo.WindowStyle = ProcessWindowStyle.Normal

                        oProcess.StartInfo = oStartInfo
                        oProcess.Start()

                    End If

                End If

            End If

        End If

        frmFormat.Close()

    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        Dim Info As String

        With My.Application.Info

            Info = .Title & " v" & .Version.Major & "." & .Version.Minor & "." & .Version.Build & vbNewLine &
                    .Copyright & vbNewLine &
                    "Website: www.njtsoftware.com" & vbNewLine &
                    "Email: contact@njtsoftware.com" & vbNewLine & vbNewLine &
                    "Gráficas:" & vbNewLine &
                    "www.famfamfam.com/lab/icons/silk/" & vbNewLine &
                    "www.everaldo.com/crystal/"
        End With

        MsgBox(Info, MsgBoxStyle.Information, "Acerca de...")

    End Sub

    Private Sub btnSortDoors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSortDoors.Click

        Dim MsgResult As MsgBoxResult

        MsgResult = MsgBox("¿Está seguro que desea ordernar la lista de puertas?",
                           MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Exclamation,
                           "Ordenar puertas")

        If MsgResult = MsgBoxResult.No Then Exit Sub

        Dim SortedLetterDoors(TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1) As String
        Dim SortedNumberDoors(TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1) As Long
        Dim UnsortedIndex As Byte
        Dim SuperTempDoors(TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1) As DoorInfo
        Dim CurrentHeader As Integer = SelectedHeader

        ' Check whether the list is numbers or letters only
        Dim NumbersOnly As Boolean = True
        Dim LettersOnly As Boolean = True

        ' --- Loop through each list item
        For i1 = 0 To TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1

            ' --- Loop through each character in the item
            For i2 = 0 To TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Length - 1
                If Char.IsNumber(TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Chars(i2)) = False Then
                    NumbersOnly = False
                End If
                If Char.IsLetter(TempDoor(SelectedSector, SelectedHeader, i1).P0_strDoorNum.Chars(i2)) = False Then
                    LettersOnly = False
                End If
            Next

        Next

        ' Sort the list numerically
        If NumbersOnly = True Then

            ' --- Make a numerical copy of the door list with index positions
            For i = 0 To SortedNumberDoors.GetUpperBound(0)
                SortedNumberDoors(i) = CLng(TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum & i.ToString("00"))
            Next

            ' --- Sort the copy
            Array.Sort(SortedNumberDoors)

            ' Copy all data to a sorted door array
            For i = 0 To SortedNumberDoors.GetUpperBound(0)

                ' --- Get the unsorted index of the item
                UnsortedIndex = CByte(SortedNumberDoors(i).ToString.Substring(SortedNumberDoors(i).ToString.Length - 2))

                ' --- Copy data
                With TempDoor(SelectedSector, SelectedHeader, UnsortedIndex)
                    SuperTempDoors(i).P0_strDoorNum = .P0_strDoorNum
                    SuperTempDoors(i).P1_bytInfoSelection = .P1_bytInfoSelection
                    SuperTempDoors(i).P2_strRV = .P2_strRV
                    SuperTempDoors(i).P3_strRVOwner = .P3_strRVOwner
                    SuperTempDoors(i).P4_dteDoNotVisit = .P4_dteDoNotVisit
                    SuperTempDoors(i).P5_dteCaution = .P5_dteCaution
                    SuperTempDoors(i).P6_strPublisher = .P6_strPublisher
                    SuperTempDoors(i).P7_bytAfternoons = .P7_bytAfternoons
                    SuperTempDoors(i).P8_bytOtherInfo = .P8_bytOtherInfo
                    SuperTempDoors(i).P9_strOtherInfoText = .P9_strOtherInfoText
                End With

            Next

        End If

        ' Sort the list alphabetically with index position
        If LettersOnly = True Then

            ' --- Make a copy of the door list with index positions
            For i = 0 To SortedLetterDoors.GetUpperBound(0)
                SortedLetterDoors(i) = TempDoor(SelectedSector, SelectedHeader, i).P0_strDoorNum & i.ToString("00")
            Next

            ' --- Sort the copy
            Array.Sort(SortedLetterDoors)

            ' Copy all data to a sorted door array
            For i = 0 To SortedLetterDoors.GetUpperBound(0)

                ' --- Get the unsorted index of the item
                UnsortedIndex = CByte(SortedLetterDoors(i).Substring(SortedLetterDoors(i).Length - 2))

                ' --- Copy data
                With TempDoor(SelectedSector, SelectedHeader, UnsortedIndex)
                    SuperTempDoors(i).P0_strDoorNum = .P0_strDoorNum
                    SuperTempDoors(i).P1_bytInfoSelection = .P1_bytInfoSelection
                    SuperTempDoors(i).P2_strRV = .P2_strRV
                    SuperTempDoors(i).P3_strRVOwner = .P3_strRVOwner
                    SuperTempDoors(i).P4_dteDoNotVisit = .P4_dteDoNotVisit
                    SuperTempDoors(i).P5_dteCaution = .P5_dteCaution
                    SuperTempDoors(i).P6_strPublisher = .P6_strPublisher
                    SuperTempDoors(i).P7_bytAfternoons = .P7_bytAfternoons
                    SuperTempDoors(i).P8_bytOtherInfo = .P8_bytOtherInfo
                    SuperTempDoors(i).P9_strOtherInfoText = .P9_strOtherInfoText
                End With

            Next

        End If

        ' Replace the unsorted data with the sorted array
        For i = 0 To TempHeader(SelectedSector, SelectedHeader).P7_intDoorCount - 1

            With TempDoor(SelectedSector, SelectedHeader, i)
                .P0_strDoorNum = SuperTempDoors(i).P0_strDoorNum
                .P1_bytInfoSelection = SuperTempDoors(i).P1_bytInfoSelection
                .P2_strRV = SuperTempDoors(i).P2_strRV
                .P3_strRVOwner = SuperTempDoors(i).P3_strRVOwner
                .P4_dteDoNotVisit = SuperTempDoors(i).P4_dteDoNotVisit
                .P5_dteCaution = SuperTempDoors(i).P5_dteCaution
                .P6_strPublisher = SuperTempDoors(i).P6_strPublisher
                .P7_bytAfternoons = SuperTempDoors(i).P7_bytAfternoons
                .P8_bytOtherInfo = SuperTempDoors(i).P8_bytOtherInfo
                .P9_strOtherInfoText = SuperTempDoors(i).P9_strOtherInfoText
            End With

        Next

        ' Refresh the doors list
        lstHeaders.SelectedIndex = -1
        lstHeaders.SelectedIndex = CurrentHeader

        gbxSaveRevert.Enabled = True

    End Sub

    Private Sub txtTerrFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTerrFile.TextChanged
        txtTerrFile.SelectionStart = txtTerrFile.TextLength
        txtTerrFile.ScrollToCaret()
    End Sub

    Private Sub mnuDateClipboard_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mnuDateClipboard.Opening

        If dDateClipboard = Nothing Then
            mnuDateClipboardItem2.Enabled = False
        Else
            mnuDateClipboardItem2.Enabled = True
        End If

    End Sub

    Private Sub mnuDateClipboardItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDateClipboardItem1.Click

        Try

            ' Get the calling control
            Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            Dim myMenu As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
            Dim myDateControl As DateTimePicker = CType(myMenu.SourceControl, DateTimePicker)

            ' Get the selected date
            dDateClipboard = myDateControl.Value

            ' Enable paste
            mnuDateClipboardItem2.Enabled = True

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnuDateClipboardItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDateClipboardItem2.Click

        Try

            ' Get the calling control
            Dim myItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
            Dim myMenu As ContextMenuStrip = CType(myItem.Owner, ContextMenuStrip)
            Dim myDateControl As DateTimePicker = CType(myMenu.SourceControl, DateTimePicker)

            ' Paste the date
            myDateControl.Value = dDateClipboard

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDoorCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoorCount.Click

        Dim Msg As String
        Msg = "Total de puertas: " & GetDoorCount.ToString
        MsgBox(Msg, MsgBoxStyle.Information, "Territorio #" & MainInfo.P0_intTerrNum)

    End Sub
End Class
