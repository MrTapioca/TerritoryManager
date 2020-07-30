Module GlobalSubs

    Public Sub CreateTEMPS(Optional ByVal CopyMain As Boolean = True, Optional ByVal CopySector As Boolean = True, _
                        Optional ByVal CopyHeader As Boolean = True, Optional ByVal CopyDoor As Boolean = True)

        Dim i1, i2, i3 As Integer

        If CopyMain = True Then
            With TempMain
                .P0_intTerrNum = MainInfo.P0_intTerrNum
                .P1_strName = MainInfo.P1_strName
                .P2_strNote = MainInfo.P2_strNote
                .P3_strZipCode = MainInfo.P3_strZipCode
                .P4_intSectorCount = MainInfo.P4_intSectorCount
            End With
        End If

        For i1 = 0 To 19
            If CopySector = True Then
                With TempSector(i1)
                    .P1_strName = Sector(i1).P1_strName
                    .P2_bytIsApt = Sector(i1).P2_bytIsApt
                    .P3_bytUpdateMonth = Sector(i1).P3_bytUpdateMonth
                    .P4_shrUpdateYear = Sector(i1).P4_shrUpdateYear
                    .P5_intHeaderCount = Sector(i1).P5_intHeaderCount
                End With
            End If

            For i2 = 0 To 99
                If CopyHeader = True Then
                    With TempHeader(i1, i2)
                        .P1_strBuilding = Header(i1, i2).P1_strBuilding
                        .P2_strStreet = Header(i1, i2).P2_strStreet
                        .P3_bytCensusStatus = Header(i1, i2).P3_bytCensusStatus
                        .P4_dteCensusDate = Header(i1, i2).P4_dteCensusDate
                        .P5_bytOtherInfo = Header(i1, i2).P5_bytOtherInfo
                        .P6_strOtherInfoText = Header(i1, i2).P6_strOtherInfoText
                        .P7_intDoorCount = Header(i1, i2).P7_intDoorCount
                    End With
                End If

                For i3 = 0 To 99
                    If CopyDoor = True Then
                        With TempDoor(i1, i2, i3)
                            .P0_strDoorNum = Door(i1, i2, i3).P0_strDoorNum
                            .P1_bytInfoSelection = Door(i1, i2, i3).P1_bytInfoSelection
                            .P2_strRV = Door(i1, i2, i3).P2_strRV
                            .P3_strRVOwner = Door(i1, i2, i3).P3_strRVOwner
                            .P4_dteDoNotVisit = Door(i1, i2, i3).P4_dteDoNotVisit
                            .P5_dteCaution = Door(i1, i2, i3).P5_dteCaution
                            .P6_strPublisher = Door(i1, i2, i3).P6_strPublisher
                            .P7_bytAfternoons = Door(i1, i2, i3).P7_bytAfternoons
                            .P8_bytOtherInfo = Door(i1, i2, i3).P8_bytOtherInfo
                            .P9_strOtherInfoText = Door(i1, i2, i3).P9_strOtherInfoText
                        End With
                    End If
                Next
            Next
        Next

    End Sub

    Public Sub SaveTEMPS(Optional ByVal SaveMain As Boolean = True, Optional ByVal SaveSector As Boolean = True, _
                        Optional ByVal SaveHeader As Boolean = True, Optional ByVal SaveDoor As Boolean = True)

        Dim i1, i2, i3 As Integer

        If SaveMain = True Then
            With MainInfo
                .P0_intTerrNum = TempMain.P0_intTerrNum
                .P1_strName = TempMain.P1_strName
                .P2_strNote = TempMain.P2_strNote
                .P3_strZipCode = TempMain.P3_strZipCode
                .P4_intSectorCount = TempMain.P4_intSectorCount
            End With
        End If

        For i1 = 0 To 19
            If SaveSector = True Then
                With Sector(i1)
                    .P1_strName = TempSector(i1).P1_strName
                    .P2_bytIsApt = TempSector(i1).P2_bytIsApt
                    .P3_bytUpdateMonth = TempSector(i1).P3_bytUpdateMonth
                    .P4_shrUpdateYear = TempSector(i1).P4_shrUpdateYear
                    .P5_intHeaderCount = TempSector(i1).P5_intHeaderCount
                End With
            End If

            For i2 = 0 To 99
                If SaveHeader = True Then
                    With Header(i1, i2)
                        .P1_strBuilding = TempHeader(i1, i2).P1_strBuilding
                        .P2_strStreet = TempHeader(i1, i2).P2_strStreet
                        .P3_bytCensusStatus = TempHeader(i1, i2).P3_bytCensusStatus
                        .P4_dteCensusDate = TempHeader(i1, i2).P4_dteCensusDate
                        .P5_bytOtherInfo = TempHeader(i1, i2).P5_bytOtherInfo
                        .P6_strOtherInfoText = TempHeader(i1, i2).P6_strOtherInfoText
                        .P7_intDoorCount = TempHeader(i1, i2).P7_intDoorCount
                    End With
                End If

                For i3 = 0 To 99
                    If SaveDoor = True Then
                        With Door(i1, i2, i3)
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
                    End If
                Next
            Next
        Next

    End Sub

    Public Function GetMonthString(ByVal MonthNumber As Byte) As String
        GetMonthString = ""
        Select Case MonthNumber
            Case 1 : GetMonthString = "Enero"
            Case 2 : GetMonthString = "Febrero"
            Case 3 : GetMonthString = "Marzo"
            Case 4 : GetMonthString = "Abril"
            Case 5 : GetMonthString = "Mayo"
            Case 6 : GetMonthString = "Junio"
            Case 7 : GetMonthString = "Julio"
            Case 8 : GetMonthString = "Agosto"
            Case 9 : GetMonthString = "Septiembre"
            Case 10 : GetMonthString = "Octubre"
            Case 11 : GetMonthString = "Noviembre"
            Case 12 : GetMonthString = "Diciembre"
        End Select
    End Function

    Public Sub LogErr(ByVal ErrNum As Integer, ByVal ErrMessage As String)
        Try
            Dim FileName As String = My.Application.Info.DirectoryPath & "\ErrorLog.txt"

            ' Delete the Error Log if it is too large
            If My.Computer.FileSystem.FileExists(FileName) Then
                Dim LogFileInfo As System.IO.FileInfo
                LogFileInfo = My.Computer.FileSystem.GetFileInfo(FileName)

                If LogFileInfo.Length > 1048576 Then '1048576
                    LogFileInfo.Delete()
                End If
            End If

            Dim oWrite As System.IO.StreamWriter
            oWrite = My.Computer.FileSystem.OpenTextFileWriter(FileName, True)

            With oWrite
                .WriteLine(Now.ToString)
                .WriteLine("Error #" & ErrNum.ToString)
                .WriteLine(ErrMessage)
                .WriteLine()
            End With

            oWrite.Close()

        Catch ex As Exception
        End Try
    End Sub

    Public Function GetDoorCount() As Integer
        Dim i1, i2 As Integer
        Dim DoorCount As Integer = 0

        For i1 = 0 To MainInfo.P4_intSectorCount - 1
            For i2 = 0 To Sector(i1).P5_intHeaderCount - 1
                DoorCount += Header(i1, i2).P7_intDoorCount
            Next
        Next

        Return DoorCount
    End Function

End Module
