Imports System.Windows.Forms

Public Class frmEditSec

    Dim Tips As New ToolTip

    Dim TempSelectedSector As Integer = -1
    Dim Selecting As Boolean
    Dim SavingName As Boolean
    Dim SectorDeleted As Boolean

    ' SAVE
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim MsgResult As MsgBoxResult

        For i = 0 To TempMain.P4_intSectorCount - 1
            If TempSector(i).P1_strName.Trim = "" Then
                MsgBox("Todos los sectores deben tener nombre.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        Next

        ' Save by default unless the user says otherwise
        MsgResult = MsgBoxResult.Yes

        ' Ask whether to save or not if a sector was deleted
        If SectorDeleted = True Then
            MsgResult = MsgBox("Se eliminó un sector entero. Aunque lo haya vuelto a añadir se perderán todos los datos." & vbNewLine & vbNewLine & _
                               "¿Está seguro que desea guardar los cambios a los sectores?", _
                               MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton3 Or MsgBoxStyle.Exclamation)
        End If

        Select Case MsgResult

            Case MsgBoxResult.Yes
                ' Answer: YES - Save changes and close form

                SaveTEMPS()

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Case MsgBoxResult.No
                ' Answer: NO - Discard changes and close form

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

        End Select
    End Sub

    ' CANCEL
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    ' LOAD
    Private Sub frmEditSec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Create tool tips
        With Tips
            .SetToolTip(btnUp, "Mover el sector arriba")
            .SetToolTip(btnDown, "Mover el sector abajo")
            .SetToolTip(btnAdd, "Añadir un sector")
            .SetToolTip(btnDelete, "Eliminar el sector")

            .SetToolTip(lblUpdateDate, "Última actualización")
            .SetToolTip(cboMonth, "Última actualización")
            .SetToolTip(cboYear, "Última actualización")

        End With

        Dim i As Integer

        ' Populate Year list
        For i = 2010 To 2050
            cboYear.Items.Add(i.ToString)
        Next

        ' Create a copy of the DBs
        CreateTEMPS()

        ' Load each sector's name on the list
        For i = 0 To TempMain.P4_intSectorCount - 1
            lstSectors.Items.Add(TempSector(i).P1_strName)
        Next
    End Sub

    ' SECTOR SELECTED
    Private Sub lstSectors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSectors.SelectedIndexChanged

        If SavingName = True Then Exit Sub

        ' Cancel if the event is somehow triggered with the item already selected
        If lstSectors.SelectedIndex = TempSelectedSector Then Exit Sub

        ' Save new sector index
        TempSelectedSector = lstSectors.SelectedIndex

        ' Cancel and disable controls if there is no item selected
        If lstSectors.SelectedIndex = -1 Then

            ' Disable buttons
            btnUp.Enabled = False
            btnDown.Enabled = False
            btnDelete.Enabled = False

            ' Flag: ON - prevent saving while populating controls with data
            Selecting = True

            ' Clear and disable option controls
            gbxSecOptions.Enabled = False
            txtName.Text = ""
            cboType.SelectedIndex = -1
            cboMonth.SelectedIndex = -1
            cboYear.SelectedIndex = -1

            ' Flag: OFF - save prevention disabled
            Selecting = False

            Exit Sub

        End If

        ' Flag: ON - prevent saving while populating controls with data
        Selecting = True

        ' Populate controls with new sector data
        With TempSector(lstSectors.SelectedIndex)
            txtName.Text = .P1_strName
            cboType.SelectedIndex = .P2_bytIsApt
            cboMonth.SelectedIndex = .P3_bytUpdateMonth - 1
            cboYear.SelectedIndex = .P4_shrUpdateYear - 2010
        End With

        ' Flag: OFF - save prevention disabled
        Selecting = False

        ' Enable Up button if appropriate
        If lstSectors.SelectedIndex > 0 Then
            btnUp.Enabled = True
        Else
            btnUp.Enabled = False
        End If

        ' Enable Down button if appropriate
        If lstSectors.SelectedIndex < TempMain.P4_intSectorCount - 1 Then
            btnDown.Enabled = True
        Else
            btnDown.Enabled = False
        End If

        ' Enable Delete button
        btnDelete.Enabled = True

        ' Enable sector options
        gbxSecOptions.Enabled = True
    End Sub

    ' ADD SECTOR
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ' Limit the sector count to 20
        If TempMain.P4_intSectorCount = 20 Then
            MsgBox("El territorio no puede contener más de 20 sectores.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ' Update sector count on temp DB
        TempMain.P4_intSectorCount += 1

        ' Populate new sector data
        With TempSector(TempMain.P4_intSectorCount - 1)
            .P1_strName = "Nuevo sector"
            .P2_bytIsApt = 0
            .P3_bytUpdateMonth = 1
            .P4_shrUpdateYear = 2011
            .P5_intHeaderCount = 0
        End With

        ' Add new sector name to ListBox
        lstSectors.Items.Add(TempSector(TempMain.P4_intSectorCount - 1).P1_strName)

        ' Select the new sector
        lstSectors.SelectedIndex = TempMain.P4_intSectorCount - 1

        ' Enable Save button
        btnSave.Enabled = True

        ' Set focus on sector name TextBox and select all text
        txtName.Focus()
        txtName.SelectAll()
    End Sub

    ' DELETE SECTOR
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim MsgResult As MsgBoxResult
        Dim SectorIndex As Integer
        Dim i1 As Integer
        Dim i2 As Integer
        Dim i3 As Integer

        If TempMain.P4_intSectorCount = 1 Then
            MsgBox("El territorio debe contener 1 sector como mínimo.", MsgBoxStyle.Information)
            Exit Sub
        End If

        MsgResult = MsgBox("¿Está seguro que desea eliminar este sector?", _
                           MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation)

        If MsgResult = MsgBoxResult.No Then Exit Sub

        SectorIndex = lstSectors.SelectedIndex

        ' Move all data in temp DBs 1 sector index back
        For i1 = (SectorIndex + 1) To (TempMain.P4_intSectorCount - 1)

            For i2 = 0 To (TempSector(i1).P5_intHeaderCount - 1)

                For i3 = 0 To (TempHeader(i1, i2).P7_intDoorCount - 1)

                    ' Move door data back
                    With TempDoor(i1 - 1, i2, i3)
                        .P0_strDoorNum = TempDoor(i1, i2, i3).P0_strDoorNum
                        .P1_bytInfoSelection = TempDoor(i1, i2, i3).P1_bytInfoSelection
                        .P2_strRV = TempDoor(i1, i2, i3).P2_strRV
                        .P3_strRVOwner = TempDoor(i1, i2, i3).P3_strRVOwner
                        .P4_dteDoNotVisit = TempDoor(i1, i2, i3).P4_dteDoNotVisit
                        .P5_dteCaution = TempDoor(i1, i2, i3).P5_dteCaution
                        .P6_strPublisher = TempDoor(i1, i2, i3).P6_strPublisher
                        .P7_bytAfternoons = TempDoor(i1, i2, i3).P7_bytAfternoons
                        .P8_bytOtherInfo = TempDoor(i1, i2, i3).P8_bytOtherInfo
                        .P9_strOtherInfoText = TempDoor(i1, i2, i3).P9_strOtherInfoText
                    End With

                Next

                ' Move header data back
                With TempHeader(i1 - 1, i2)
                    .P1_strBuilding = TempHeader(i1, i2).P1_strBuilding
                    .P2_strStreet = TempHeader(i1, i2).P2_strStreet
                    .P3_bytCensusStatus = TempHeader(i1, i2).P3_bytCensusStatus
                    .P4_dteCensusDate = TempHeader(i1, i2).P4_dteCensusDate
                    .P5_bytOtherInfo = TempHeader(i1, i2).P5_bytOtherInfo
                    .P6_strOtherInfoText = TempHeader(i1, i2).P6_strOtherInfoText
                    .P7_intDoorCount = TempHeader(i1, i2).P7_intDoorCount
                End With

            Next

            ' Move sector data back
            With TempSector(i1 - 1)
                .P1_strName = TempSector(i1).P1_strName
                .P2_bytIsApt = TempSector(i1).P2_bytIsApt
                .P3_bytUpdateMonth = TempSector(i1).P3_bytUpdateMonth
                .P4_shrUpdateYear = TempSector(i1).P4_shrUpdateYear
                .P5_intHeaderCount = TempSector(i1).P5_intHeaderCount
            End With

        Next

        ' Decrease the sector count
        TempMain.P4_intSectorCount -= 1

        ' Remove the sector from the list
        lstSectors.Items.RemoveAt(SectorIndex)

        ' Enable Save button
        SectorDeleted = True
        btnSave.Enabled = True

        ' Select the next sector if it exists
        If TempMain.P4_intSectorCount = 0 Then Exit Sub

        If SectorIndex + 1 <= TempMain.P4_intSectorCount Then
            lstSectors.SelectedIndex = SectorIndex
        Else
            lstSectors.SelectedIndex = SectorIndex - 1
        End If

    End Sub

    ' UP
    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click
        Dim SuperTempSector As SectorInfo
        Dim SuperTempHeader As HeaderInfo
        Dim SuperTempDoor As DoorInfo

        Dim i1 As Integer
        Dim i2 As Integer

        ' Iterate through every header of the selected sector
        ' and switch the sector index with the one before
        For i1 = 0 To 99 'TempSector(lstSectors.SelectedIndex).P5_intHeaderCount - 1

            ' Iterate through every door of the current header iteration
            ' and switch the sector index with the one before
            For i2 = 0 To 99 ' TempHeader(lstSectors.SelectedIndex, i1).P7_intDoorCount - 1

                ' Make a copy of the current door
                With SuperTempDoor
                    .P0_strDoorNum = TempDoor(lstSectors.SelectedIndex, i1, i2).P0_strDoorNum
                    .P1_bytInfoSelection = TempDoor(lstSectors.SelectedIndex, i1, i2).P1_bytInfoSelection
                    .P2_strRV = TempDoor(lstSectors.SelectedIndex, i1, i2).P2_strRV
                    .P3_strRVOwner = TempDoor(lstSectors.SelectedIndex, i1, i2).P3_strRVOwner
                    .P4_dteDoNotVisit = TempDoor(lstSectors.SelectedIndex, i1, i2).P4_dteDoNotVisit
                    .P5_dteCaution = TempDoor(lstSectors.SelectedIndex, i1, i2).P5_dteCaution
                    .P6_strPublisher = TempDoor(lstSectors.SelectedIndex, i1, i2).P6_strPublisher
                    .P7_bytAfternoons = TempDoor(lstSectors.SelectedIndex, i1, i2).P7_bytAfternoons
                    .P8_bytOtherInfo = TempDoor(lstSectors.SelectedIndex, i1, i2).P8_bytOtherInfo
                    .P9_strOtherInfoText = TempDoor(lstSectors.SelectedIndex, i1, i2).P9_strOtherInfoText
                End With

                ' Move the door before to one sector index after
                With TempDoor(lstSectors.SelectedIndex, i1, i2)
                    .P0_strDoorNum = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P0_strDoorNum
                    .P1_bytInfoSelection = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P1_bytInfoSelection
                    .P2_strRV = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P2_strRV
                    .P3_strRVOwner = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P3_strRVOwner
                    .P4_dteDoNotVisit = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P4_dteDoNotVisit
                    .P5_dteCaution = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P5_dteCaution
                    .P6_strPublisher = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P6_strPublisher
                    .P7_bytAfternoons = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P7_bytAfternoons
                    .P8_bytOtherInfo = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P8_bytOtherInfo
                    .P9_strOtherInfoText = TempDoor(lstSectors.SelectedIndex - 1, i1, i2).P9_strOtherInfoText
                End With

                ' Paste the current door one index before
                With TempDoor(lstSectors.SelectedIndex - 1, i1, i2)
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

            ' Make a copy of the current header
            With SuperTempHeader
                .P1_strBuilding = TempHeader(lstSectors.SelectedIndex, i1).P1_strBuilding
                .P2_strStreet = TempHeader(lstSectors.SelectedIndex, i1).P2_strStreet
                .P3_bytCensusStatus = TempHeader(lstSectors.SelectedIndex, i1).P3_bytCensusStatus
                .P4_dteCensusDate = TempHeader(lstSectors.SelectedIndex, i1).P4_dteCensusDate
                .P5_bytOtherInfo = TempHeader(lstSectors.SelectedIndex, i1).P5_bytOtherInfo
                .P6_strOtherInfoText = TempHeader(lstSectors.SelectedIndex, i1).P6_strOtherInfoText
                .P7_intDoorCount = TempHeader(lstSectors.SelectedIndex, i1).P7_intDoorCount
            End With

            ' Move the header before to one sector index after
            With TempHeader(lstSectors.SelectedIndex, i1)
                .P1_strBuilding = TempHeader(lstSectors.SelectedIndex - 1, i1).P1_strBuilding
                .P2_strStreet = TempHeader(lstSectors.SelectedIndex - 1, i1).P2_strStreet
                .P3_bytCensusStatus = TempHeader(lstSectors.SelectedIndex - 1, i1).P3_bytCensusStatus
                .P4_dteCensusDate = TempHeader(lstSectors.SelectedIndex - 1, i1).P4_dteCensusDate
                .P5_bytOtherInfo = TempHeader(lstSectors.SelectedIndex - 1, i1).P5_bytOtherInfo
                .P6_strOtherInfoText = TempHeader(lstSectors.SelectedIndex - 1, i1).P6_strOtherInfoText
                .P7_intDoorCount = TempHeader(lstSectors.SelectedIndex - 1, i1).P7_intDoorCount
            End With

            ' Paste the current header one index before
            With TempHeader(lstSectors.SelectedIndex - 1, i1)
                .P1_strBuilding = SuperTempHeader.P1_strBuilding
                .P2_strStreet = SuperTempHeader.P2_strStreet
                .P3_bytCensusStatus = SuperTempHeader.P3_bytCensusStatus
                .P4_dteCensusDate = SuperTempHeader.P4_dteCensusDate
                .P5_bytOtherInfo = SuperTempHeader.P5_bytOtherInfo
                .P6_strOtherInfoText = SuperTempHeader.P6_strOtherInfoText
                .P7_intDoorCount = SuperTempHeader.P7_intDoorCount
            End With

        Next

        ' Make a copy of the selected sector
        With SuperTempSector
            .P1_strName = TempSector(lstSectors.SelectedIndex).P1_strName
            .P2_bytIsApt = TempSector(lstSectors.SelectedIndex).P2_bytIsApt
            .P3_bytUpdateMonth = TempSector(lstSectors.SelectedIndex).P3_bytUpdateMonth
            .P4_shrUpdateYear = TempSector(lstSectors.SelectedIndex).P4_shrUpdateYear
            .P5_intHeaderCount = TempSector(lstSectors.SelectedIndex).P5_intHeaderCount
        End With

        ' Move the sector before to one index after
        With TempSector(lstSectors.SelectedIndex)
            .P1_strName = TempSector(lstSectors.SelectedIndex - 1).P1_strName
            .P2_bytIsApt = TempSector(lstSectors.SelectedIndex - 1).P2_bytIsApt
            .P3_bytUpdateMonth = TempSector(lstSectors.SelectedIndex - 1).P3_bytUpdateMonth
            .P4_shrUpdateYear = TempSector(lstSectors.SelectedIndex - 1).P4_shrUpdateYear
            .P5_intHeaderCount = TempSector(lstSectors.SelectedIndex - 1).P5_intHeaderCount
        End With

        ' Paste the selected sector one index before
        With TempSector(lstSectors.SelectedIndex - 1)
            .P1_strName = SuperTempSector.P1_strName
            .P2_bytIsApt = SuperTempSector.P2_bytIsApt
            .P3_bytUpdateMonth = SuperTempSector.P3_bytUpdateMonth
            .P4_shrUpdateYear = SuperTempSector.P4_shrUpdateYear
            .P5_intHeaderCount = SuperTempSector.P5_intHeaderCount
        End With

        ' Update the sector list
        lstSectors.Items.Item(lstSectors.SelectedIndex) = TempSector(lstSectors.SelectedIndex).P1_strName
        lstSectors.Items.Item(lstSectors.SelectedIndex - 1) = TempSector(lstSectors.SelectedIndex - 1).P1_strName

        ' Select the moved sector
        lstSectors.SelectedIndex = lstSectors.SelectedIndex - 1

        ' Enable Save button
        btnSave.Enabled = True
    End Sub

    ' DOWN
    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        Dim SuperTempSector As SectorInfo
        Dim SuperTempHeader As HeaderInfo
        Dim SuperTempDoor As DoorInfo

        Dim i1 As Integer
        Dim i2 As Integer

        ' Iterate through every header of the selected sector
        ' and switch the sector index with the one after
        For i1 = 0 To 99 'TempSector(lstSectors.SelectedIndex).P5_intHeaderCount - 1

            ' Iterate through every door of the current header iteration
            ' and switch the sector index with the one after
            For i2 = 0 To 99 'TempHeader(lstSectors.SelectedIndex, i1).P7_intDoorCount - 1

                ' Make a copy of the current door
                With SuperTempDoor
                    .P0_strDoorNum = TempDoor(lstSectors.SelectedIndex, i1, i2).P0_strDoorNum
                    .P1_bytInfoSelection = TempDoor(lstSectors.SelectedIndex, i1, i2).P1_bytInfoSelection
                    .P2_strRV = TempDoor(lstSectors.SelectedIndex, i1, i2).P2_strRV
                    .P3_strRVOwner = TempDoor(lstSectors.SelectedIndex, i1, i2).P3_strRVOwner
                    .P4_dteDoNotVisit = TempDoor(lstSectors.SelectedIndex, i1, i2).P4_dteDoNotVisit
                    .P5_dteCaution = TempDoor(lstSectors.SelectedIndex, i1, i2).P5_dteCaution
                    .P6_strPublisher = TempDoor(lstSectors.SelectedIndex, i1, i2).P6_strPublisher
                    .P7_bytAfternoons = TempDoor(lstSectors.SelectedIndex, i1, i2).P7_bytAfternoons
                    .P8_bytOtherInfo = TempDoor(lstSectors.SelectedIndex, i1, i2).P8_bytOtherInfo
                    .P9_strOtherInfoText = TempDoor(lstSectors.SelectedIndex, i1, i2).P9_strOtherInfoText
                End With

                ' Move the door after to one sector index before
                With TempDoor(lstSectors.SelectedIndex, i1, i2)
                    .P0_strDoorNum = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P0_strDoorNum
                    .P1_bytInfoSelection = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P1_bytInfoSelection
                    .P2_strRV = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P2_strRV
                    .P3_strRVOwner = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P3_strRVOwner
                    .P4_dteDoNotVisit = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P4_dteDoNotVisit
                    .P5_dteCaution = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P5_dteCaution
                    .P6_strPublisher = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P6_strPublisher
                    .P7_bytAfternoons = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P7_bytAfternoons
                    .P8_bytOtherInfo = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P8_bytOtherInfo
                    .P9_strOtherInfoText = TempDoor(lstSectors.SelectedIndex + 1, i1, i2).P9_strOtherInfoText
                End With

                ' Paste the current door one index after
                With TempDoor(lstSectors.SelectedIndex + 1, i1, i2)
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

            ' Make a copy of the current header
            With SuperTempHeader
                .P1_strBuilding = TempHeader(lstSectors.SelectedIndex, i1).P1_strBuilding
                .P2_strStreet = TempHeader(lstSectors.SelectedIndex, i1).P2_strStreet
                .P3_bytCensusStatus = TempHeader(lstSectors.SelectedIndex, i1).P3_bytCensusStatus
                .P4_dteCensusDate = TempHeader(lstSectors.SelectedIndex, i1).P4_dteCensusDate
                .P5_bytOtherInfo = TempHeader(lstSectors.SelectedIndex, i1).P5_bytOtherInfo
                .P6_strOtherInfoText = TempHeader(lstSectors.SelectedIndex, i1).P6_strOtherInfoText
                .P7_intDoorCount = TempHeader(lstSectors.SelectedIndex, i1).P7_intDoorCount
            End With

            ' Move the header after to one sector index before
            With TempHeader(lstSectors.SelectedIndex, i1)
                .P1_strBuilding = TempHeader(lstSectors.SelectedIndex + 1, i1).P1_strBuilding
                .P2_strStreet = TempHeader(lstSectors.SelectedIndex + 1, i1).P2_strStreet
                .P3_bytCensusStatus = TempHeader(lstSectors.SelectedIndex + 1, i1).P3_bytCensusStatus
                .P4_dteCensusDate = TempHeader(lstSectors.SelectedIndex + 1, i1).P4_dteCensusDate
                .P5_bytOtherInfo = TempHeader(lstSectors.SelectedIndex + 1, i1).P5_bytOtherInfo
                .P6_strOtherInfoText = TempHeader(lstSectors.SelectedIndex + 1, i1).P6_strOtherInfoText
                .P7_intDoorCount = TempHeader(lstSectors.SelectedIndex + 1, i1).P7_intDoorCount
            End With

            ' Paste the current header one index after
            With TempHeader(lstSectors.SelectedIndex + 1, i1)
                .P1_strBuilding = SuperTempHeader.P1_strBuilding
                .P2_strStreet = SuperTempHeader.P2_strStreet
                .P3_bytCensusStatus = SuperTempHeader.P3_bytCensusStatus
                .P4_dteCensusDate = SuperTempHeader.P4_dteCensusDate
                .P5_bytOtherInfo = SuperTempHeader.P5_bytOtherInfo
                .P6_strOtherInfoText = SuperTempHeader.P6_strOtherInfoText
                .P7_intDoorCount = SuperTempHeader.P7_intDoorCount
            End With

        Next

        ' Make a copy of the selected sector
        With SuperTempSector
            .P1_strName = TempSector(lstSectors.SelectedIndex).P1_strName
            .P2_bytIsApt = TempSector(lstSectors.SelectedIndex).P2_bytIsApt
            .P3_bytUpdateMonth = TempSector(lstSectors.SelectedIndex).P3_bytUpdateMonth
            .P4_shrUpdateYear = TempSector(lstSectors.SelectedIndex).P4_shrUpdateYear
            .P5_intHeaderCount = TempSector(lstSectors.SelectedIndex).P5_intHeaderCount
        End With

        ' Move the sector after to one index before
        With TempSector(lstSectors.SelectedIndex)
            .P1_strName = TempSector(lstSectors.SelectedIndex + 1).P1_strName
            .P2_bytIsApt = TempSector(lstSectors.SelectedIndex + 1).P2_bytIsApt
            .P3_bytUpdateMonth = TempSector(lstSectors.SelectedIndex + 1).P3_bytUpdateMonth
            .P4_shrUpdateYear = TempSector(lstSectors.SelectedIndex + 1).P4_shrUpdateYear
            .P5_intHeaderCount = TempSector(lstSectors.SelectedIndex + 1).P5_intHeaderCount
        End With

        ' Paste the selected sector one index after
        With TempSector(lstSectors.SelectedIndex + 1)
            .P1_strName = SuperTempSector.P1_strName
            .P2_bytIsApt = SuperTempSector.P2_bytIsApt
            .P3_bytUpdateMonth = SuperTempSector.P3_bytUpdateMonth
            .P4_shrUpdateYear = SuperTempSector.P4_shrUpdateYear
            .P5_intHeaderCount = SuperTempSector.P5_intHeaderCount
        End With

        ' Update the sector list
        lstSectors.Items.Item(lstSectors.SelectedIndex) = TempSector(lstSectors.SelectedIndex).P1_strName
        lstSectors.Items.Item(lstSectors.SelectedIndex + 1) = TempSector(lstSectors.SelectedIndex + 1).P1_strName

        ' Select the moved sector
        lstSectors.SelectedIndex = lstSectors.SelectedIndex + 1

        ' Enable Save button
        btnSave.Enabled = True
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        If Selecting = False Then
            ' Save the sector name
            TempSector(lstSectors.SelectedIndex).P1_strName = txtName.Text

            ' Change sector name in the ListBox
            SavingName = True
            lstSectors.Items.Item(lstSectors.SelectedIndex) = txtName.Text
            SavingName = False

            ' Enable Save button
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        Dim MsgResult As MsgBoxResult

        If Selecting = False Then

            If CByte(cboType.SelectedIndex) = TempSector(lstSectors.SelectedIndex).P2_bytIsApt Then Exit Sub

            MsgResult = MsgBox("¿Está seguro que desea cambiar el tipo de sector?", MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Exclamation)

            If MsgResult = MsgBoxResult.Yes Then

                ' Use the index as a boolean and save it: 0 (false) or 1 (true)
                TempSector(lstSectors.SelectedIndex).P2_bytIsApt = CByte(cboType.SelectedIndex)

                ' Enable Save button
                btnSave.Enabled = True

            Else

                With cboType

                    Selecting = True

                    If .SelectedIndex = 0 Then
                        .SelectedIndex = 1
                    Else
                        .SelectedIndex = 0
                    End If

                    Selecting = False

                End With

            End If

        End If
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonth.SelectedIndexChanged
        If Selecting = False Then
            ' Turn the index into the month number selected and save it
            TempSector(lstSectors.SelectedIndex).P3_bytUpdateMonth = CByte(cboMonth.SelectedIndex + 1)

            ' Enable Save button
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        If Selecting = False Then
            ' Turn the index into the year selected and save it
            TempSector(lstSectors.SelectedIndex).P4_shrUpdateYear = CShort(cboYear.SelectedIndex + 2010)

            ' Enable Save button
            btnSave.Enabled = True
        End If
    End Sub

End Class
