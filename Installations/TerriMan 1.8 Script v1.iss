; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{4B1F0206-EE23-414B-9BAD-CEC77E2561AA}
AppName=Territory Manager
AppVersion=1.8.1
AppPublisher=NJT Software
DefaultDirName={pf}\Territory Manager
DefaultGroupName=Territory Manager
OutputDir=\Territory Manager\Installations
OutputBaseFilename=TerritoryManager181Setup
Compression=lzma
SolidCompression=yes
AppCopyright=Copyright � NJT Software 2011
ChangesAssociations=True
AppContact=contact@njtsoftware.com
VersionInfoVersion=1.8.1
VersionInfoCompany=NJT Software
VersionInfoCopyright=Copyright � NJT Software 2011
VersionInfoProductName=Territory Manager
VersionInfoProductVersion=1.8.1
AppPublisherURL=www.njtsoftware.com

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"; InfoBeforeFile: "Readme.rtf"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "\Territory Manager\bin\Release\Territory Manager.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "\Territory Manager\bin\Release\CarlosAg.ExcelXmlWriter.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "Resources\*"; DestDir: "{app}\Resources"; Flags: createallsubdirs recursesubdirs promptifolder
Source: "Readme.rtf"; DestDir: "{app}"

[Icons]
Name: "{group}\Territory Manager"; Filename: "{app}\Territory Manager.exe"
Name: "{group}\{cm:UninstallProgram,Territory Manager}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\Territory Manager"; Filename: "{app}\Territory Manager.exe"; Tasks: desktopicon
Name: "{group}\Resources"; Filename: "{app}\Resources"
Name: "{group}\Readme"; Filename: "{app}\Readme.rtf"

[Run]
Filename: "{app}\Territory Manager.exe"; Parameters: "/RegExt"
Filename: "{app}\Territory Manager.exe"; Flags: nowait postinstall skipifsilent; Description: "{cm:LaunchProgram,Territory Manager}"

[UninstallDelete]
Type: files; Name: "{app}\settings.config"

[UninstallRun]
Filename: "{app}\Territory Manager.exe"; Parameters: "/UnregExt"
