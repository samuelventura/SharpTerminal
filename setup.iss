; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppId "SharpTerminal"
#define MyAppName "Sharp Terminal"
#define MyAppVersion "1.0.10"
#define MyAppPublisher "Samuel Ventura"
#define MyAppURL "https://github.com/samuelventura/SharpTerminal"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8AC03115-5F0C-47F8-9F8D-83530600D5FB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppPublisher}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename={#MyAppId}-{#MyAppVersion}.Setup
SetupIconFile=icon.ico
Compression=lzma
SolidCompression=yes   
UninstallDisplayIcon={app}\{#MyAppId}.exe          
ChangesAssociations = yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "{#MyAppId}\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName} {#MyAppVersion}"; Filename: "{app}\{#MyAppId}.exe";
Name: "{commondesktop}\{#MyAppName} {#MyAppVersion}"; Filename: "{app}\{#MyAppId}.exe";

[Registry]
Root: HKCR; Subkey: ".SharpTerminal";                   ValueData: "{#MyAppName}";                     Flags: uninsdeletevalue; ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#MyAppName}";                     ValueData: "{#MyAppName} {#MyAppVersion}";     Flags: uninsdeletekey;   ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#MyAppName}\DefaultIcon";         ValueData: "{app}\{#MyAppId}.exe,0";                                  ValueType: string;  ValueName: ""
Root: HKCR; Subkey: "{#MyAppName}\shell\open\command";  ValueData: """{app}\{#MyAppId}"" ""%1""";                             ValueType: string;  ValueName: ""



