Imports System.Xml

Public Class Settings

    ' LOCAL FIELDS
    Dim settings As New Hashtable()
    Dim settingsDefault As New Hashtable()
    Dim filename As String = System.IO.Path.Combine(My.Application.Info.DirectoryPath, "settings.config")

    ' SETTINGS
    Public Const LastOpenDir As String = "LastOpenDir"
    Public Const LastSaveDir As String = "LastSaveDir"
    Public Const LastExportDir As String = "LastExportDir"
    Public Const UseXmlExtension As String = "UseXmlExtension"
    Public Const ExportLatinDateFormat As String = "ExportLatinDateFormat"
    Public Const Format2CompactHeader As String = "Format2CompactHeader"
    Public Const Format2ExportDoorCount As String = "Format2ExportDoorCount"
    Public Const Format2LowerPrintQuality As String = "Format2LowerPrintQuality"
    Public Const Format2Label1 As String = "Format2Label1"
    Public Const Format2Label2 As String = "Format2Label2"
    Public Const Format2Label3 As String = "Format2Label3"
    Public Const Format2Label4 As String = "Format2Label4"
    Public Const Format2Label5 As String = "Format2Label5"
    Public Const Format2Label6 As String = "Format2Label6"
    Public Const Format2Label7 As String = "Format2Label7"
    Public Const Format2Label8 As String = "Format2Label8"

    ' RESET SETTINGS TO DEFUALT VALUES
    Public Sub LoadDefaults()

        settingsDefault.Clear()
        settings.Clear()

        ' Set default settings
        Dim myDocsFolder As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        With settingsDefault
            .Add(LastOpenDir, myDocsFolder)
            .Add(LastSaveDir, myDocsFolder)
            .Add(LastExportDir, myDocsFolder)
            .Add(UseXmlExtension, False)
            .Add(ExportLatinDateFormat, False)
            .Add(Format2CompactHeader, True)
            .Add(Format2ExportDoorCount, True)
            .Add(Format2LowerPrintQuality, False)
            .Add(Format2Label1, "Puerta")
            .Add(Format2Label2, "A.M.")
            .Add(Format2Label3, "A.M.")
            .Add(Format2Label4, "A.M.")
            .Add(Format2Label5, "P.M.")
            .Add(Format2Label6, "P.M.")
            .Add(Format2Label7, "Tel / Carta")
            .Add(Format2Label8, "Notas")
        End With

        ' Load default settings
        For Each setting As String In settingsDefault.Keys
            settings.Add(setting, settingsDefault.Item(setting))
        Next
    End Sub

    ' LOAD SETTINGS FROM XML FILE INTO HASHTABLE
    Public Sub LoadSettings()
        Dim setting, value As String

        ' Load default configuration
        LoadDefaults()

        ' Create settings file if it does not exist
        If Not My.Computer.FileSystem.FileExists(filename) Then
            SaveSettings()
            Exit Sub
        End If

        ' Read settings file
        Dim xmlDoc As XmlReader = Nothing
        Try
            xmlDoc = XmlReader.Create(filename)
            Do While xmlDoc.Read()
                If xmlDoc.NodeType = XmlNodeType.Element AndAlso xmlDoc.Name = "setting" Then
                    setting = xmlDoc.GetAttribute("name")
                    value = xmlDoc.ReadElementString
                    ChangeSetting(setting, value)
                End If
            Loop

        Catch ex As Exception
        Finally
            If Not xmlDoc Is Nothing Then xmlDoc.Close()
        End Try
    End Sub

    ' SAVE SETTINGS TO XML FILE
    Public Sub SaveSettings()
        ' Configure the XML file
        Dim docSettings As New XmlWriterSettings
        docSettings.Indent = True
        docSettings.CloseOutput = True

        On Error Resume Next

        ' Create the XML file and write the XML Declaration node
        Dim xmlDoc As XmlWriter = XmlWriter.Create(filename, docSettings)
        xmlDoc.WriteStartDocument()

        ' Write the settings container with app info
        xmlDoc.WriteStartElement("Settings")
        xmlDoc.WriteAttributeString("app", My.Application.Info.ProductName)
        xmlDoc.WriteAttributeString("version", My.Application.Info.Version.ToString)

        ' Write every setting to file
        For Each setting As String In settings.Keys
            xmlDoc.WriteStartElement("setting")
            xmlDoc.WriteAttributeString("name", setting)
            xmlDoc.WriteString(settings.Item(setting).ToString)
            xmlDoc.WriteEndElement()
        Next

        ' Finish and close file
        xmlDoc.WriteEndElement()
        xmlDoc.WriteEndDocument()
        xmlDoc.Flush()
        xmlDoc.Close()
    End Sub

    ' CHANGE THE VALUE OF A SETTING
    Public Sub ChangeSetting(ByVal setting As String, ByVal value As Object)
        If settings.ContainsKey(setting) Then
            settings.Item(setting) = value
        End If
    End Sub

    ' RETURN THE VALUE OF A SETTING AS STRING
    Public Function GetSettingAsStr(ByVal setting As String) As String
        If settings.ContainsKey(setting) Then
            Return CStr(settings.Item(setting))
        Else
            Return Nothing
        End If
    End Function

    ' RETURN THE VALUE OF A SETTING AS BOOLEAN
    Public Function GetSettingAsBool(ByVal setting As String) As Boolean
        If settings.ContainsKey(setting) Then
            Return CBool(settings.Item(setting))
        Else
            Return Nothing
        End If
    End Function

End Class
