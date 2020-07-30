
Imports CarlosAg.ExcelXmlWriter

Public Class frmExport

    Dim DateFormat As String

    Private Sub frmExport_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        ' Start worker to create file
        wkrExport.RunWorkerAsync()

    End Sub

    Private Sub wkrExport_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles wkrExport.DoWork

        If appSettings.GetSettingAsBool(Settings.ExportLatinDateFormat) = True Then
            DateFormat = "dd-MM-yy"
        Else
            DateFormat = "MM-dd-yy"
        End If

        Try

            Select Case ExportFormat
                Case 1 : ExportFormat1() ' 3.75 x 5.75
                Case 2 : ExportFormat2() ' 5 x 8
            End Select

        Catch ex As Exception

            LogErr(Err.Number, ex.Message)

            Select Case Err.Number

                Case 53
                    ' Could not load file or assembly 'CarlosAg.ExcelXmlWriter, 
                    ' Version=1.0.0.6, Culture=neutral, PublicKeyToken=null' or 
                    ' one of its dependencies. The system cannot find the file specified.
                    MsgBox("No se encontró un componente requerido. Reinstale la aplicación.", MsgBoxStyle.Critical)

                Case Else
                    MsgBox("Se generó el siguiente error:" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)

            End Select

        End Try

    End Sub

    Private Sub wkrExport_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles wkrExport.RunWorkerCompleted

        Me.Close()

    End Sub

    Private Sub ExportFormat1() ' 3.75 x 5.75

        ' ========================================================================
        ' FORMAT INFORMATION
        ' A block is 2 columns wide.
        ' There are 2 blocks side to side allowing 4 to fit on a page.
        ' The 2 blocks are separated by 1 column making the total width 5 columns.

        ' Each block has 26 rows and is separated from a block below by 1 more row.
        ' The first 2 rows of a block contain the territory and sector info.
        ' This leaves 24 rows for header and door data.

        ' Following those rules, a block will start every 27 rows.
        ' =========================================================================

        ' Declarations ------------------------------------------------------------------------

        Dim oWorkbook As Workbook = New Workbook
        Dim oStyles As WorksheetStyleCollection = oWorkbook.Styles
        Dim oStyle As WorksheetStyle
        Dim oWorksheet As Worksheet = oWorkbook.Worksheets.Add("Territorio # " & _
                                                               MainInfo.P0_intTerrNum)
        Dim oColumns As WorksheetColumnCollection = oWorksheet.Table.Columns
        Dim oRows As WorksheetRowCollection = oWorksheet.Table.Rows
        Dim oCell As WorksheetCell

        Dim oPageNumCells(0) As WorksheetCell
        Dim CurRow As Integer = -27             ' Negative block
        Dim CurBlock As Integer = 2             ' Block on right
        Dim BlockStartRow As Integer = -27      ' Negative block
        Dim AllBlockCount As Integer
        Dim DoorCount As Integer

        Dim Txt As String

        Dim i1, i2, i3 As Integer

        ' Define cell styles ------------------------------------------------------------------

        oStyle = oStyles.Add("Default")
        With oStyle
            .Name = "Normal"

            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .NumberFormat = "@"

            .Alignment.Horizontal = StyleHorizontalAlignment.Left
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Interior.Pattern = StyleInteriorPattern.None
        End With

        oStyle = oStyles.Add("TerrInfo")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black
            .Font.Bold = True

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Header")
        With oStyle
            .Interior.Pattern = StyleInteriorPattern.Solid
            .Interior.Color = "#BFBFBF" ' 25% gray

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Door")
        With oStyle
            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Data")
        With oStyle
            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        ' Define worksheet properties ---------------------------------------------------------

        With oWorksheet.Options
            .Print.PaperSizeIndex = 0
            .Print.Scale = 100
        End With

        With oWorksheet.Options.PageSetup
            .Layout.Orientation = Orientation.Portrait
            .Layout.CenterHorizontal = False
            .Layout.CenterVertical = False

            .Header.Margin = 0
            .Footer.Margin = 0
            .Footer.Data = "Territorio # " & MainInfo.P0_intTerrNum & " (&P / &N)"

            .PageMargins.Left = 0.5
            .PageMargins.Right = 0.25
            .PageMargins.Top = 0.25
            .PageMargins.Bottom = 0.25
        End With

        oWorksheet.Table.DefaultRowHeight = 14

        ' Define columns ----------------------------------------------------------------------

        With oColumns
            .Add(45)
            .Add(208)
            .Add(9)
            .Add(45)
            .Add(208)
        End With

        ' SECTORS LOOP ------------------------------------------------------------------------
        For i1 = 0 To MainInfo.P4_intSectorCount - 1

            AddNewBlock1(oStyles, _
                         oWorksheet, _
                         oRows, _
                         oPageNumCells, _
                         i1, _
                         CurRow, _
                         CurBlock, _
                         BlockStartRow, _
                         AllBlockCount)

            ' HEADERS LOOP --------------------------------------------------------------------
            For i2 = 0 To Sector(i1).P5_intHeaderCount - 1

                ' Add new block if needed _____________________________________________________

                ' Get door count +2 door spaces
                DoorCount = Header(i1, i2).P7_intDoorCount + 2

                ' Add +1 door space if no other doors exist
                If Header(i1, i2).P7_intDoorCount = 0 Then DoorCount += 1

                ' Will the Header + Doors exceed the 26 rows of the block?
                If (CurRow + DoorCount) > (BlockStartRow + 25) Then
                    ' Yes, it will
                    ' Will the Header + Doors + Door Space all fit in 1 block?
                    If 1 + Header(i1, i2).P7_intDoorCount + 2 <= 24 Then
                        ' Yes, it fits: create a new block
                        AddNewBlock1(oStyles, _
                                     oWorksheet, _
                                     oRows, _
                                     oPageNumCells, _
                                     i1, _
                                     CurRow, _
                                     CurBlock, _
                                     BlockStartRow, _
                                     AllBlockCount)
                    Else
                        ' No, it does not fit: use whatever space is left on current block
                        ' Is there at least 2 spaces open for the Header + 1 door?
                        If CurRow > (BlockStartRow + 24) Then
                            ' No, there is not enough space: create a new block
                            AddNewBlock1(oStyles, _
                                         oWorksheet, _
                                         oRows, _
                                         oPageNumCells, _
                                         i1, _
                                         CurRow, _
                                         CurBlock, _
                                         BlockStartRow, _
                                         AllBlockCount)
                        End If
                    End If
                End If
                ' _____________________________________________________________________________

                ' <!BBB!></!BBB!>
                ' Prepare header string
                If Sector(i1).P2_bytIsApt = 0 Then
                    Txt = "<!BBB!><!III!>Calle:</!III!></!BBB!> " _
                    & Header(i1, i2).P2_strStreet
                Else
                    Txt = "<!BBB!><!III!>Edificio:</!III!></!BBB!> " _
                    & Header(i1, i2).P1_strBuilding & " " _
                    & Header(i1, i2).P2_strStreet
                End If

                If Header(i1, i2).P5_bytOtherInfo = 1 _
                And Header(i1, i2).P6_strOtherInfoText <> "" Then
                    Txt = Txt & " (" & Header(i1, i2).P6_strOtherInfoText & ")"
                End If

                Select Case Header(i1, i2).P3_bytCensusStatus
                    Case 1
                        Txt = Txt & " [<!BBB!><!III!>Censar</!III!></!BBB!>]"
                    Case 2
                        Txt = Txt & " [<!III!>Censado " _
                        & Header(i1, i2).P4_dteCensusDate.ToString(DateFormat) _
                        & "</!III!>]"
                End Select

                ' Add block spacer
                If CurBlock = 2 Then AddCell(oRows, CurRow)

                ' Write the header string
                oCell = AddCell(oRows, CurRow, "Header")
                With oCell
                    .Data.Text = Txt
                    .MergeAcross = 1 ' Merge with next cell
                End With

                ' DOORS LOOP ------------------------------------------------------------------
                For i3 = 0 To Header(i1, i2).P7_intDoorCount - 1

                    CurRow += 1

                    ' Add a new block if the current block is full
                    If CurRow > BlockStartRow + 25 Then
                        AddNewBlock1(oStyles, _
                                     oWorksheet, _
                                     oRows, _
                                     oPageNumCells, _
                                     i1, _
                                     CurRow, _
                                     CurBlock, _
                                     BlockStartRow, _
                                     AllBlockCount)
                    End If

                    ' Add block spacer
                    If CurBlock = 2 Then AddCell(oRows, CurRow)

                    ' Write the door number
                    oCell = AddCell(oRows, CurRow, "Door")
                    oCell.Data.Text = Door(i1, i2, i3).P0_strDoorNum

                    ' Prepare the string with the door data
                    Txt = ""

                    If Door(i1, i2, i3).P7_bytAfternoons = 1 Then
                        Txt = "[<!BBB!>TARDES</!BBB!>]"
                    End If

                    If Door(i1, i2, i3).P8_bytOtherInfo = 1 _
                    And Door(i1, i2, i3).P9_strOtherInfoText <> "" Then
                        If Txt <> "" Then Txt = Txt & " "
                        Txt = Txt & "[" & Door(i1, i2, i3).P9_strOtherInfoText & "]"
                    End If

                    Select Case Door(i1, i2, i3).P1_bytInfoSelection

                        Case 2 ' RV

                            If Door(i1, i2, i3).P2_strRV <> "" Then
                                If Txt <> "" Then Txt = Txt & " "
                                Txt = Txt & "(" & Door(i1, i2, i3).P2_strRV & ")"
                            End If

                            If Txt <> "" Then Txt = Txt & " "
                            Txt = Txt & "RV"

                            If Door(i1, i2, i3).P3_strRVOwner <> "" Then
                                Txt = Txt & ": " & Door(i1, i2, i3).P3_strRVOwner
                            End If

                            If Txt.Substring(Txt.Length - 2) = "RV" Then
                                Txt = Txt.Substring(0, Txt.Length - 2) & "Revisita"
                            End If

                        Case 3 ' Study

                            If Door(i1, i2, i3).P2_strRV <> "" Then
                                If Txt <> "" Then Txt = Txt & " "
                                Txt = Txt & "(" & Door(i1, i2, i3).P2_strRV & ")"
                            End If

                            If Txt <> "" Then Txt = Txt & " "
                            Txt = Txt & "EST"

                            If Door(i1, i2, i3).P3_strRVOwner <> "" Then
                                Txt = Txt & ": " & Door(i1, i2, i3).P3_strRVOwner
                            End If

                            If Txt.Substring(Txt.Length - 3) = "EST" Then
                                Txt = Txt.Substring(0, Txt.Length - 3) & "Estudio"
                            End If

                        Case 4 ' Do not visit

                            If Txt <> "" Then Txt = Txt & " "

                            Txt = Txt & "[<!BBB!>NO VISITE</!BBB!> " _
                            & Door(i1, i2, i3).P4_dteDoNotVisit.ToString(DateFormat) _
                            & "]"

                        Case 5 ' Caution

                            If Txt <> "" Then Txt = Txt & " "

                            Txt = Txt & "[<!BBB!>CAUTELA</!BBB!> " _
                            & Door(i1, i2, i3).P5_dteCaution.ToString(DateFormat) _
                            & "]"

                        Case 6 ' Publisher

                            If Txt <> "" Then Txt = Txt & " "

                            If Door(i1, i2, i3).P6_strPublisher <> "" Then
                                Txt = Txt & "[<!BBB!>Pub</!BBB!>: " _
                                & Door(i1, i2, i3).P6_strPublisher & "]"
                            Else
                                Txt = Txt & "[<!BBB!>Pub</!BBB!>]"
                            End If

                    End Select

                    ' Write the door data
                    oCell = AddCell(oRows, CurRow, "Data")
                    oCell.Data.Text = Txt

                Next

                ' Add 2 spaces
                For i = 1 To 2
                    CurRow += 1
                    If CurRow < BlockStartRow + 26 Then
                        If CurBlock = 2 Then AddCell(oRows, CurRow)
                        AddCell(oRows, CurRow, "Door")
                        AddCell(oRows, CurRow, "Data")
                    End If
                Next

                ' Add 1 more if there are no doors
                If Header(i1, i2).P7_intDoorCount = 0 Then
                    CurRow += 1
                    If CurBlock = 2 Then AddCell(oRows, CurRow)
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Data")
                End If

                CurRow += 1

            Next

        Next

        ' ADD MISSING CELLS ON LAST BLOCK -----------------------------------------------------

        For i = CurRow To BlockStartRow + 25
            If CurBlock = 2 Then AddCell(oRows, i)
            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Data")
        Next

        ' ADD PAGE NUMBERS --------------------------------------------------------------------

        For i1 = 1 To AllBlockCount

            oPageNumCells(i1).Data.Text = "Pág " & i1 & "/" & AllBlockCount

        Next

        ' ADD FORMATTING AND PAGE BREAKS ------------------------------------------------------

        Try

            ' Save XML file
            oWorkbook.Save(ExportFileName)

            '  Get data from XML file
            Dim oRead As System.IO.StreamReader
            Dim oWrite As System.IO.StreamWriter
            Dim sData As String

            oRead = My.Computer.FileSystem.OpenTextFileReader(ExportFileName)
            sData = oRead.ReadToEnd
            oRead.Close()

            Dim SB As New System.Text.StringBuilder(sData)

            ' Enable rich-text formatting
            SB.Replace("<s:Data", "<s:Data xmlns=""http://www.w3.org/TR/REC-html40""")
            SB.Replace("&lt;!BBB!&gt;", "<B>")
            SB.Replace("&lt;/!BBB!&gt;", "</B>")
            SB.Replace("&lt;!III!&gt;", "<I>")
            SB.Replace("&lt;/!III!&gt;", "</I>")

            ' Add page breaks
            sData = "</x:WorksheetOptions>" & vbNewLine & _
                    "    <PageBreaks xmlns=""urn:schemas-microsoft-com:office:excel"">" & vbNewLine & _
                    "      <RowBreaks>" & vbNewLine

            For i = 4 To AllBlockCount Step 4
                sData = sData & _
                        "        <RowBreak>" & vbNewLine & _
                        "          <Row>" & (54 * (i / 4)) & "</Row>" & vbNewLine & _
                        "        </RowBreak>" & vbNewLine
            Next

            sData = sData & _
                    "      </RowBreaks>" & vbNewLine & _
                    "    </PageBreaks>"

            If AllBlockCount > 3 Then
                SB.Replace("</x:WorksheetOptions>", sData)
            End If

            ' Write and close XML file
            oWrite = My.Computer.FileSystem.OpenTextFileWriter(ExportFileName, False)
            oWrite.Write(SB)
            oWrite.Close()

            ExportSuccess = True

        Catch ex As Exception

            LogErr(Err.Number, ex.Message)
            MsgBox("Se generó el siguiente error:" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)

        End Try

    End Sub

    Private Sub ExportFormat2() ' 5 x 8

        '    ' ========================================================================
        '    ' FORMAT INFORMATION
        '    ' A block is 8 columns wide.
        '    ' There are 2 blocks side to side per page.
        '    ' The 2 blocks are separated by 1 column making the total width 17 columns.

        '    ' Each block has 32 rows and is separated from a block below by 1 more row.
        '    ' The first 3 rows of a block contain the territory info.
        '    ' This leaves 29 rows for header and door data.

        '    ' Following those rules, a block will start every 33 rows.
        '    ' =========================================================================

        ' Declarations ------------------------------------------------------------------------

        Dim oWorkbook As Workbook = New Workbook
        Dim oStyles As WorksheetStyleCollection = oWorkbook.Styles
        Dim oStyle As WorksheetStyle
        Dim oWorksheet As Worksheet = oWorkbook.Worksheets.Add("Territorio # " & _
                                                               MainInfo.P0_intTerrNum)
        Dim oColumns As WorksheetColumnCollection = oWorksheet.Table.Columns
        Dim oRows As WorksheetRowCollection = oWorksheet.Table.Rows
        Dim oCell As WorksheetCell

        Dim oPageNumCells(0) As WorksheetCell
        Dim CurRow As Integer = -33             ' Negative block
        Dim CurBlock As Integer = 2             ' Block on right
        Dim BlockStartRow As Integer = -33      ' Negative block
        Dim AllBlockCount As Integer

        'Dim TempBlockSpaces As Integer
        Dim Txt As String

        Dim i1, i2, i3 As Integer

        ' Define cell styles ------------------------------------------------------------------

        oStyle = oStyles.Add("Default")
        With oStyle
            .Name = "Normal"

            .Font.FontName = "Arial"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .NumberFormat = "@"

            .Alignment.Horizontal = StyleHorizontalAlignment.Left
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Interior.Pattern = StyleInteriorPattern.None
        End With

        oStyle = oStyles.Add("TerrInfo1")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 11
            .Font.Color = "#000000" ' Black
            .Font.Bold = True

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("TerrInfo2")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 11
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Desc")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 8
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("DescSmall")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 6
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True
            .Alignment.WrapText = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Header")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Interior.Pattern = StyleInteriorPattern.Solid
            .Interior.Color = "#BFBFBF" ' 25% gray

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Header2")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Left
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Interior.Pattern = StyleInteriorPattern.Solid
            .Interior.Color = "#BFBFBF" ' 25% gray

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Date")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Left
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Interior.Pattern = StyleInteriorPattern.Solid
            .Interior.Color = "#D8D8D8" ' 15% gray

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Door")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Center
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        oStyle = oStyles.Add("Data")
        With oStyle
            .Font.FontName = "Arial Narrow"
            .Font.Size = 10
            .Font.Color = "#000000" ' Black

            .Alignment.Horizontal = StyleHorizontalAlignment.Left
            .Alignment.Vertical = StyleVerticalAlignment.Center
            .Alignment.ShrinkToFit = True

            .Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1)
            .Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1)
        End With

        ' Define worksheet properties ---------------------------------------------------------

        With oWorksheet.Options
            .Print.PaperSizeIndex = 0
            .Print.Scale = 100

            If appSettings.GetSettingAsBool(Settings.Format2LowerPrintQuality) = True Then
                .Print.HorizontalResolution = 300
                .Print.VerticalResolution = 300
            Else
                .Print.HorizontalResolution = 600
                .Print.VerticalResolution = 600
            End If
        End With

        With oWorksheet.Options.PageSetup
            .Layout.Orientation = Orientation.Landscape
            .Layout.CenterHorizontal = False
            .Layout.CenterVertical = False

            .Header.Margin = 0
            .Footer.Margin = 0
            .Footer.Data = "Territorio # " & MainInfo.P0_intTerrNum & " (&P / &N)"

            .PageMargins.Left = 0.5
            .PageMargins.Right = 0.25
            .PageMargins.Top = 0.25
            .PageMargins.Bottom = 0.25
        End With

        oWorksheet.Table.DefaultRowHeight = 18

        ' Define columns ----------------------------------------------------------------------

        With oColumns
            .Add(40)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(129)

            .Add(9)

            .Add(40)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(26)
            .Add(129)
        End With

        ' SECTORS LOOP ------------------------------------------------------------------------
        For i1 = 0 To MainInfo.P4_intSectorCount - 1

            i2 = 0
            i3 = 0

            AddNewBlock2(oStyles, oWorksheet, oRows, oPageNumCells, i1, CurRow, CurBlock, _
                         BlockStartRow, AllBlockCount, i2, i3)

            ' HEADERS LOOP --------------------------------------------------------------------
            For i2 = 0 To Sector(i1).P5_intHeaderCount - 1

                i3 = 0

                AddHeaderFormat2(oStyles, oWorksheet, oRows, oPageNumCells, i1, CurRow, CurBlock, _
                                 BlockStartRow, AllBlockCount, i2, i3)

                ' DOORS LOOP ------------------------------------------------------------------
                For i3 = 0 To Header(i1, i2).P7_intDoorCount - 1

                    ' NEXT ROW
                    CurRow += 1

                    ' Add a new block if the current block is full
                    If CurRow > BlockStartRow + 31 Then
                        AddNewBlock2(oStyles, oWorksheet, oRows, oPageNumCells, i1, CurRow, CurBlock, _
                                     BlockStartRow, AllBlockCount, i2, i3)
                    End If

                    ' Add block spacer
                    If CurBlock = 2 Then AddCell(oRows, CurRow)

                    ' Write the door number
                    oCell = AddCell(oRows, CurRow, "Door")
                    oCell.Data.Text = Door(i1, i2, i3).P0_strDoorNum

                    ' Create annotation cells
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")

                    ' Prepare the string with the door data
                    Txt = ""

                    ' Add afternoon note
                    If Door(i1, i2, i3).P7_bytAfternoons = 1 Then
                        Txt = "[<!BBB!>TARDES</!BBB!>]"
                    End If

                    ' Add extra info
                    If Door(i1, i2, i3).P8_bytOtherInfo = 1 _
                    And Door(i1, i2, i3).P9_strOtherInfoText <> "" Then
                        If Txt <> "" Then Txt = Txt & " "
                        Txt = Txt & "[" & Door(i1, i2, i3).P9_strOtherInfoText & "]"
                    End If

                    Select Case Door(i1, i2, i3).P1_bytInfoSelection

                        Case 2 ' RV

                            ' Add RV name
                            If Door(i1, i2, i3).P2_strRV <> "" Then
                                If Txt <> "" Then Txt = Txt & " "
                                Txt = Txt & "(" & Door(i1, i2, i3).P2_strRV & ")"
                            End If

                            ' Add short RV description
                            If Txt <> "" Then Txt = Txt & " "
                            Txt = Txt & "RV"

                            ' Add RV owner name
                            If Door(i1, i2, i3).P3_strRVOwner <> "" Then
                                Txt = Txt & ": " & Door(i1, i2, i3).P3_strRVOwner
                            End If

                            ' Change description if both names were inexistent
                            If Txt.Substring(Txt.Length - 2) = "RV" Then
                                Txt = Txt.Substring(0, Txt.Length - 2) & "Revisita"
                            End If

                        Case 3 ' Study

                            ' Add Study name
                            If Door(i1, i2, i3).P2_strRV <> "" Then
                                If Txt <> "" Then Txt = Txt & " "
                                Txt = Txt & "(" & Door(i1, i2, i3).P2_strRV & ")"
                            End If

                            ' Add short Study description
                            If Txt <> "" Then Txt = Txt & " "
                            Txt = Txt & "EST"

                            ' Add Study owner name
                            If Door(i1, i2, i3).P3_strRVOwner <> "" Then
                                Txt = Txt & ": " & Door(i1, i2, i3).P3_strRVOwner
                            End If

                            ' Change description if both names were inexistent
                            If Txt.Substring(Txt.Length - 3) = "EST" Then
                                Txt = Txt.Substring(0, Txt.Length - 3) & "Estudio"
                            End If
                        Case 4 ' Do not visit

                            If Txt <> "" Then Txt = Txt & " "

                            Txt = Txt & "[<!BBB!>NO VISITE</!BBB!> " _
                            & Door(i1, i2, i3).P4_dteDoNotVisit.ToString(DateFormat) _
                            & "]"

                        Case 5 ' Caution

                            If Txt <> "" Then Txt = Txt & " "

                            Txt = Txt & "[<!BBB!>CAUTELA</!BBB!> " _
                            & Door(i1, i2, i3).P5_dteCaution.ToString(DateFormat) _
                            & "]"

                        Case 6 ' Publisher

                            If Txt <> "" Then Txt = Txt & " "

                            If Door(i1, i2, i3).P6_strPublisher <> "" Then
                                Txt = Txt & "[<!BBB!>Pub</!BBB!>: " _
                                & Door(i1, i2, i3).P6_strPublisher & "]"
                            Else
                                Txt = Txt & "[<!BBB!>Pub</!BBB!>]"
                            End If

                    End Select

                    ' Write the door data
                    oCell = AddCell(oRows, CurRow, "Data")
                    oCell.Data.Text = Txt

                Next

                ' Add empty spaces if necessary
                Dim iCount As Integer = 0

                If appSettings.GetSettingAsBool(Settings.Format2CompactHeader) = False Then
                    If Header(i1, i2).P7_intDoorCount = 0 Then iCount = 1
                Else
                    If Header(i1, i2).P7_intDoorCount = 0 Then iCount = 2
                    If Header(i1, i2).P7_intDoorCount = 1 Then iCount = 1

                    ' Add a space if only last door of split street is on a new block
                    If Header(i1, i2).P7_intDoorCount > 1 And CurRow = BlockStartRow + 5 Then iCount = 1
                End If

                For i = 1 To iCount
                    CurRow += 1
                    If CurBlock = 2 Then AddCell(oRows, CurRow)
                    AddCell(oRows, CurRow, "Door")

                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")
                    AddCell(oRows, CurRow, "Door")

                    AddCell(oRows, CurRow, "Data")
                Next

                CurRow += 1

            Next

        Next

        ' ADD MISSING CELLS ON LAST BLOCK -----------------------------------------------------

        For i = CurRow To BlockStartRow + 31
            If CurBlock = 2 Then AddCell(oRows, i)
            AddCell(oRows, i, "Door")

            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Door")
            AddCell(oRows, i, "Door")

            AddCell(oRows, i, "Data")
        Next

        ' ADD PAGE NUMBERS --------------------------------------------------------------------

        For i1 = 1 To AllBlockCount

            oPageNumCells(i1).Data.Text = "P. " & i1 & "/" & AllBlockCount

        Next

        ' ADD FORMATTING AND PAGE BREAKS ------------------------------------------------------

        Try

            ' Save XML file
            oWorkbook.Save(ExportFileName)

            '  Get data from XML file
            Dim oRead As System.IO.StreamReader
            Dim oWrite As System.IO.StreamWriter
            Dim sData As String

            oRead = My.Computer.FileSystem.OpenTextFileReader(ExportFileName)
            sData = oRead.ReadToEnd
            oRead.Close()

            Dim SB As New System.Text.StringBuilder(sData)

            ' Enable rich-text formatting
            SB.Replace("<s:Data", "<s:Data xmlns=""http://www.w3.org/TR/REC-html40""")
            SB.Replace("&lt;!BBB!&gt;", "<B>")
            SB.Replace("&lt;/!BBB!&gt;", "</B>")
            SB.Replace("&lt;!III!&gt;", "<I>")
            SB.Replace("&lt;/!III!&gt;", "</I>")

            ' Add page breaks
            sData = "</x:WorksheetOptions>" & vbNewLine & _
                    "    <PageBreaks xmlns=""urn:schemas-microsoft-com:office:excel"">" & vbNewLine & _
                    "      <RowBreaks>" & vbNewLine

            For i = 2 To AllBlockCount Step 2
                sData = sData & _
                        "        <RowBreak>" & vbNewLine & _
                        "          <Row>" & (33 * (i / 2)) & "</Row>" & vbNewLine & _
                        "        </RowBreak>" & vbNewLine
            Next

            sData = sData & _
                    "      </RowBreaks>" & vbNewLine & _
                    "    </PageBreaks>"

            If AllBlockCount > 1 Then
                SB.Replace("</x:WorksheetOptions>", sData)
            End If

            ' Write and close XML file
            oWrite = My.Computer.FileSystem.OpenTextFileWriter(ExportFileName, False)
            oWrite.Write(SB)
            oWrite.Close()

            ExportSuccess = True

        Catch ex As Exception

            LogErr(Err.Number, ex.Message)
            MsgBox("Se generó el siguiente error:" & vbNewLine & vbNewLine & _
                   ex.Message, MsgBoxStyle.Critical)

            Exit Sub

        End Try

    End Sub

    ' AddNewBlock1
    ' FORMAT 1: 3.75 x 5.75
    Private Sub AddNewBlock1(ByRef oStyles As WorksheetStyleCollection, _
                             ByRef oWorksheet As Worksheet, _
                             ByRef oRows As WorksheetRowCollection, _
                             ByRef oPageNumCells() As WorksheetCell, _
                             ByRef CurSector As Integer, _
                             ByRef CurRow As Integer, _
                             ByRef CurBlock As Integer, _
                             ByRef BlockStartRow As Integer, _
                             ByRef AllBlockCount As Integer)

        ' Temporary cell reference
        Dim oCell As WorksheetCell

        ' Increase block count
        AllBlockCount += 1

        ' Create missing cells for current block if necessary
        If CurRow >= 0 Then
            For i = CurRow To BlockStartRow + 25
                If CurBlock = 2 Then AddCell(oRows, i)
                AddCell(oRows, i, "Door")
                AddCell(oRows, i, "Data")
            Next
        End If

        If CurBlock = 1 Then
            ' New block on right
            CurBlock = 2
        Else
            ' New block below
            CurBlock = 1
            BlockStartRow += 27

            ' Create 26 block rows
            For i = BlockStartRow To BlockStartRow + 25
                oRows.Add()
            Next

            ' Create blank row
            oRows.Add()
            oRows(oRows.Count - 1).Height = 9

        End If

        ' BLOCK START
        CurRow = BlockStartRow

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Add territory number cell
        oCell = AddCell(oRows, CurRow, "TerrInfo")
        oCell.Data.Text = "Terr. # " & MainInfo.P0_intTerrNum.ToString

        ' Add territory name cell
        oCell = AddCell(oRows, CurRow, "TerrInfo")
        oCell.Data.Text = Sector(CurSector).P1_strName

        ' NEXT ROW
        CurRow += 1

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Add page number cell and save a reference to it
        ReDim Preserve oPageNumCells(oPageNumCells.GetUpperBound(0) + 1)
        oPageNumCells(oPageNumCells.GetUpperBound(0)) = AddCell(oRows, CurRow, "TerrInfo")
        oPageNumCells(oPageNumCells.GetUpperBound(0)).Data.Text = "[Página]"

        ' Add revision date cell
        oCell = AddCell(oRows, CurRow, "TerrInfo")
        oCell.Data.Text = "Revisión: " _
        & GetMonthString(Sector(CurSector).P3_bytUpdateMonth) & " " _
        & Sector(CurSector).P4_shrUpdateYear.ToString

        ' NEXT ROW
        CurRow += 1

    End Sub

    ' AddNewBlock2
    ' FORMAT 2: 5 x 8
    Private Sub AddNewBlock2(ByRef oStyles As WorksheetStyleCollection, _
                             ByRef oWorksheet As Worksheet, _
                             ByRef oRows As WorksheetRowCollection, _
                             ByRef oPageNumCells() As WorksheetCell, _
                             ByVal CurSector As Integer, _
                             ByRef CurRow As Integer, _
                             ByRef CurBlock As Integer, _
                             ByRef BlockStartRow As Integer, _
                             ByRef AllBlockCount As Integer, _
                             ByVal CurHeader As Integer, _
                             ByVal CurDoor As Integer)

        ' Temporary cell reference
        Dim oCell As WorksheetCell

        ' Increase block count
        AllBlockCount += 1

        ' Create missing cells for current block if necessary
        If CurRow >= 0 Then
            For i = CurRow To BlockStartRow + 31
                If CurBlock = 2 Then AddCell(oRows, i)
                AddCell(oRows, i, "Door")

                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
                AddCell(oRows, i, "Data")
            Next
        End If

        If CurBlock = 1 Then
            ' New block on right
            CurBlock = 2
        Else
            ' New block below
            CurBlock = 1
            BlockStartRow += 33

            ' Create 32 block rows
            For i = BlockStartRow To BlockStartRow + 31
                oRows.Add()
            Next

            ' Create blank row
            oRows.Add()
            oRows(oRows.Count - 1).Height = 9

        End If

        ' BLOCK START
        CurRow = BlockStartRow

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Add territory number cell
        oCell = AddCell(oRows, CurRow, "TerrInfo1")
        oCell.Data.Text = "T - " & MainInfo.P0_intTerrNum.ToString

        ' Add territory name cell
        oCell = AddCell(oRows, CurRow, "TerrInfo1")
        oCell.Data.Text = Sector(CurSector).P1_strName.ToUpper
        oCell.MergeAcross = 6

        ' NEXT ROW
        CurRow += 1

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Add page number cell and save a reference to it
        ReDim Preserve oPageNumCells(oPageNumCells.GetUpperBound(0) + 1)
        oPageNumCells(oPageNumCells.GetUpperBound(0)) = AddCell(oRows, CurRow, "TerrInfo2")

        ' Add revision date cell
        oCell = AddCell(oRows, CurRow, "TerrInfo2")
        oCell.Data.Text = GetMonthString(Sector(CurSector).P3_bytUpdateMonth) & " " _
                & Sector(CurSector).P4_shrUpdateYear.ToString

        ' Add door count if enabled
        If appSettings.GetSettingAsBool(Settings.Format2ExportDoorCount) = True Then
            oCell.MergeAcross = 3

            oCell = AddCell(oRows, CurRow, "TerrInfo2")
            oCell.Data.Text = "Total: " & GetDoorCount.ToString
            oCell.MergeAcross = 1

            oCell = AddCell(oRows, CurRow, "TerrInfo2")
        Else
            oCell.MergeAcross = 6
        End If

        ' NEXT ROW
        CurRow += 1

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Add column descriptions
        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label1) ' "Puerta"

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label2) ' "A.M."

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label3) ' "A.M."

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label4) ' "A.M."

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label5) ' "P.M."

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label6) ' "P.M."

        oCell = AddCell(oRows, CurRow, "Desc") ' "DescSmall"
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label7) ' "Tel / Carta"

        oCell = AddCell(oRows, CurRow, "Desc")
        oCell.Data.Text = appSettings.GetSettingAsStr(Settings.Format2Label8) ' "Notas"

        If appSettings.GetSettingAsBool(Settings.Format2CompactHeader) = True Then

            ' NEXT ROW
            CurRow += 1

            ' Add block spacer
            If CurBlock = 2 Then AddCell(oRows, CurRow)

            ' Write date header
            oCell = AddCell(oRows, CurRow, "Date")
            oCell.Data.Text = "<!III!>Fecha:</!III!>"

            ' Create empty date cells
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")

            If CurDoor > 0 Then

                ' NEXT ROW
                CurRow += 1

                ' Add continuing street header
                AddHeaderFormat2(oStyles, oWorksheet, oRows, oPageNumCells, CurSector, CurRow, CurBlock, _
                                 BlockStartRow, AllBlockCount, CurHeader, CurDoor, True)

            End If

        End If

        ' NEXT ROW
        CurRow += 1

    End Sub

    Private Sub AddHeaderFormat2(ByRef oStyles As WorksheetStyleCollection, _
                                 ByRef oWorksheet As Worksheet, _
                                 ByRef oRows As WorksheetRowCollection, _
                                 ByRef oPageNumCells() As WorksheetCell, _
                                 ByVal CurSector As Integer, _
                                 ByRef CurRow As Integer, _
                                 ByRef CurBlock As Integer, _
                                 ByRef BlockStartRow As Integer, _
                                 ByRef AllBlockCount As Integer, _
                                 ByVal CurHeader As Integer, _
                                 ByVal CurDoor As Integer, _
                                 Optional ByVal Continued As Boolean = False)

        Dim TempBlockSpaces As Integer
        Dim Txt As String
        Dim oCell As WorksheetCell

        ' Check spaces that must be reserved
        If appSettings.GetSettingAsBool(Settings.Format2CompactHeader) = False Then
            ' Header needs 2 rows + 1 door row
            TempBlockSpaces = 30
        Else
            ' Header needs 1 rows + 1 door row
            TempBlockSpaces = 31

            If Header(CurSector, CurHeader).P5_bytOtherInfo = 1 And _
                    Header(CurSector, CurHeader).P6_strOtherInfoText <> "" Then
                ' 1 more space needed for extra info
                TempBlockSpaces -= 1
            End If

            ' Add 1 more space for low door count
            If Header(CurSector, CurHeader).P7_intDoorCount < 2 Then TempBlockSpaces -= 1
        End If

        ' Add new block if space is needed
        If CurRow >= BlockStartRow + TempBlockSpaces Then
            AddNewBlock2(oStyles, oWorksheet, oRows, oPageNumCells, CurSector, CurRow, CurBlock, _
                 BlockStartRow, AllBlockCount, CurHeader, CurDoor)
        End If

        ' <!BBB!></!BBB!>

        ' Add block spacer
        If CurBlock = 2 Then AddCell(oRows, CurRow)

        ' Prepare header string
        Txt = "<!BBB!>"
        If Sector(CurSector).P2_bytIsApt = 0 Then
            Txt = Txt & Header(CurSector, CurHeader).P2_strStreet
        Else
            Txt = Txt & Header(CurSector, CurHeader).P1_strBuilding & " " & _
                Header(CurSector, CurHeader).P2_strStreet
        End If
        Txt = Txt & "</!BBB!>"

        If appSettings.GetSettingAsBool(Settings.Format2CompactHeader) = False Then ' Not compact

            ' Add extra info to header if existent
            If Header(CurSector, CurHeader).P5_bytOtherInfo = 1 _
                    And Header(CurSector, CurHeader).P6_strOtherInfoText <> "" Then
                Txt = Txt & " (" & Header(CurSector, CurHeader).P6_strOtherInfoText & ")"
            End If

            ' Add a note if the data will be split in 2 blocks
            If Continued = True Then
                Txt = "<!III!>[...cont]</!III!> " & Txt
            Else
                If CurRow + 1 + Header(CurSector, CurHeader).P7_intDoorCount > BlockStartRow + 31 Then
                    Txt = Txt & " <!III!>[Cont...]</!III!>"
                End If
            End If

            ' Write the header string
            oCell = AddCell(oRows, CurRow, "Header")
            With oCell
                .Data.Text = Txt
                .MergeAcross = 7 ' Merge across cells on block
            End With

            ' NEXT ROW
            CurRow += 1

            ' Add block spacer
            If CurBlock = 2 Then AddCell(oRows, CurRow)

            ' Write date header
            oCell = AddCell(oRows, CurRow, "Date")
            oCell.Data.Text = "<!III!>Fecha:</!III!>"

            ' Create empty date cells
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")
            AddCell(oRows, CurRow, "Date")

            ' Prepare census info
            Select Case Header(CurSector, CurHeader).P3_bytCensusStatus
                Case 1
                    Txt = "<!BBB!>Censar:</!BBB!>"
                Case 2
                    Txt = "<!III!>Censado: " _
                    & Header(CurSector, CurHeader).P4_dteCensusDate.ToString(DateFormat) _
                    & "</!III!>"
            End Select

            ' Write the census string
            oCell = AddCell(oRows, CurRow, "Date")
            oCell.Data.Text = Txt

        Else ' Compact

            ' Add a note if the data will be split in 2 blocks
            If Header(CurSector, CurHeader).P5_bytOtherInfo = 1 And _
                    Header(CurSector, CurHeader).P6_strOtherInfoText <> "" Then

                ' Header needs 1 space
                If Continued = True Then
                    Txt = "<!III!>[...cont]</!III!> " & Txt
                Else
                    If CurRow + 1 + Header(CurSector, CurHeader).P7_intDoorCount > BlockStartRow + 31 Then
                        Txt = Txt & " <!III!>[Cont...]</!III!>"
                    End If
                End If

            Else
                ' Header needs 1 space
                If Continued = True Then
                    Txt = "<!III!>[...cont]</!III!> " & Txt
                Else
                    If CurRow + Header(CurSector, CurHeader).P7_intDoorCount > BlockStartRow + 31 Then
                        Txt = Txt & " <!III!>[Cont...]</!III!>"
                    End If
                End If

            End If

            ' Write the header string
            oCell = AddCell(oRows, CurRow, "Header")
            With oCell
                .Data.Text = Txt
                .MergeAcross = 6 ' Merge across cells on block
            End With

            ' Prepare census info
            Select Case Header(CurSector, CurHeader).P3_bytCensusStatus
                Case 1
                    Txt = "<!BBB!>Censar:</!BBB!>"
                Case 2
                    Txt = "<!III!>Censado: " _
                    & Header(CurSector, CurHeader).P4_dteCensusDate.ToString(DateFormat) _
                    & "</!III!>"
            End Select

            ' Write the census string
            oCell = AddCell(oRows, CurRow, "Header2")
            oCell.Data.Text = Txt

            ' Add extra info to header if existent
            If Header(CurSector, CurHeader).P5_bytOtherInfo = 1 And _
                    Header(CurSector, CurHeader).P6_strOtherInfoText <> "" Then

                ' NEXT ROW
                CurRow += 1

                ' Add block spacer
                If CurBlock = 2 Then AddCell(oRows, CurRow)

                ' Add cell with info
                oCell = AddCell(oRows, CurRow, "Door")
                Txt = "(" & Header(CurSector, CurHeader).P6_strOtherInfoText & ")"
                oCell.Data.Text = Txt
                oCell.MergeAcross = 7

            End If

        End If

    End Sub

    Private Function AddCell(ByRef oRows As WorksheetRowCollection, _
                             ByVal iRow As Integer, _
                             Optional ByVal StyleID As String = "") As WorksheetCell

        AddCell = oRows(iRow).Cells.Add()
        AddCell.Data.Type = DataType.String
        If StyleID <> "" Then AddCell.StyleID = StyleID

    End Function

End Class
