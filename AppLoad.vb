
' Data structures
Public Structure TerritoryInfo
    Dim P0_intTerrNum As Integer
    Dim P1_strName As String
    Dim P2_strNote As String
    Dim P3_strZipCode As String
    Dim P4_intSectorCount As Integer
End Structure

Public Structure SectorInfo
    Dim P1_strName As String
    Dim P2_bytIsApt As Byte
    Dim P3_bytUpdateMonth As Byte
    Dim P4_shrUpdateYear As Short
    Dim P5_intHeaderCount As Integer
End Structure

Public Structure HeaderInfo
    Dim P1_strBuilding As String
    Dim P2_strStreet As String
    Dim P3_bytCensusStatus As Byte
    Dim P4_dteCensusDate As Date
    Dim P5_bytOtherInfo As Byte
    Dim P6_strOtherInfoText As String
    Dim P7_intDoorCount As Integer
End Structure

Public Structure DoorInfo
    Dim P0_strDoorNum As String
    Dim P1_bytInfoSelection As Byte
    Dim P2_strRV As String
    Dim P3_strRVOwner As String
    Dim P4_dteDoNotVisit As Date
    Dim P5_dteCaution As Date
    Dim P6_strPublisher As String
    Dim P7_bytAfternoons As Byte
    Dim P8_bytOtherInfo As Byte
    Dim P9_strOtherInfoText As String
End Structure

Module AppLoad

    ' Public variables
    Public MainInfo As TerritoryInfo
    Public Sector(19) As SectorInfo
    Public Header(19, 99) As HeaderInfo
    Public Door(19, 99, 99) As DoorInfo

    Public TempMain As TerritoryInfo
    Public TempSector(19) As SectorInfo
    Public TempHeader(19, 99) As HeaderInfo
    Public TempDoor(19, 99, 99) As DoorInfo

    Public SelectedSector As Integer = -1
    Public SelectedHeader As Integer = -1
    Public SelectedDoor As Integer = -1

    ' Used to load the Edit form for Headers/Doors
    ' Values: 1 = Add Header | 2 = Edit Header | 3 = Add Door | 4 = Edit Door
    Public HeaderDoorChange As Byte

    ' Export format selection
    ' Values: 1 = Original | 2 = 5 x 8
    Public ExportFormat As Byte = 1
    Public ExportSuccess As Boolean
    Public ExportFileName As String

    ' Create settings object
    Public appSettings As New Settings


    Public Sub ProcessCmdLineArgs()
        Dim sArgCheck As String

        ' Check each argument
        For Each sArgument As String In My.Application.CommandLineArgs

            ' Argument 1: Register extension and exit
            sArgCheck = "/RegExt"
            If sArgument.ToLower.StartsWith(sArgCheck.ToLower) Then

                Try

                    Dim oRegKey As Microsoft.Win32.RegistryKey
                    Dim oExplorerRefresh As New ExplorerRefresh

                    With My.Computer.Registry.ClassesRoot

                        ' Delete current keys if existent
                        oRegKey = .OpenSubKey(".terr")
                        If Not oRegKey Is Nothing Then .DeleteSubKeyTree(".terr")
                        oRegKey = .OpenSubKey("TerriManFile")
                        If Not oRegKey Is Nothing Then .DeleteSubKeyTree("TerriManFile")

                        ' Create extension key
                        oRegKey = .CreateSubKey(".terr")
                        oRegKey.SetValue(Nothing, "TerriManFile", _
                                         Microsoft.Win32.RegistryValueKind.String)

                        ' Create extension reference key
                        oRegKey = .CreateSubKey("TerriManFile")
                        oRegKey.SetValue(Nothing, "Territory Manager File", _
                                         Microsoft.Win32.RegistryValueKind.String)

                        ' Create Open command
                        oRegKey = .CreateSubKey("TerriManFile\shell\open\command")
                        oRegKey.SetValue(Nothing, """" & Application.ExecutablePath & """ ""%1""", _
                                         Microsoft.Win32.RegistryValueKind.String)

                    End With

                    ' Refresh Explorer
                    oExplorerRefresh.Refresh()

                Catch ex As Exception

                    LogErr(Err.Number, ex.Message)
                    MessageBox.Show("Error al asociar la extensión "".terr"" con Territory Manager.")

                End Try

                frmMain.Close()

            End If

            ' Argument 2: Unregister extension and exit
            sArgCheck = "/UnregExt"
            If sArgument.ToLower.StartsWith(sArgCheck.ToLower) Then

                Try

                    Dim oRegKey As Microsoft.Win32.RegistryKey
                    Dim oExplorerRefresh As New ExplorerRefresh

                    With My.Computer.Registry.ClassesRoot

                        ' Delete current keys if existent
                        oRegKey = .OpenSubKey(".terr")
                        If Not oRegKey Is Nothing Then .DeleteSubKeyTree(".terr")
                        oRegKey = .OpenSubKey("TerriManFile")
                        If Not oRegKey Is Nothing Then .DeleteSubKeyTree("TerriManFile")

                    End With

                    ' Refresh Explorer
                    oExplorerRefresh.Refresh()

                Catch ex As Exception

                    LogErr(Err.Number, ex.Message)
                    MessageBox.Show("Error al desasociar la extensión "".terr"" con Territory Manager.")

                End Try

                frmMain.Close()

            End If

            ' Argument 3: Territory path
            If My.Computer.FileSystem.FileExists(sArgument) Then

                ' Check the file extension
                If sArgument.Substring(sArgument.Length - 5) = ".terr" Then
                    frmMain.OpenTerr(sArgument)
                End If

            End If

        Next
    End Sub

End Module
