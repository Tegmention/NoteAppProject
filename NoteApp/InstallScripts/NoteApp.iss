#define AppName = "NoteApp"
#define Version = "1.0"
#define NoteAppExeName = "NoteApp.exe"
#define Publisher = "Леонов Сергей"
#define AppURL = "http://www.example.com"

[Setup]
AppId ={{260CDF49-5B73-490F-BEA1-BF1B296379C7}
AppName = {#AppName}
AppVersion = {#Version}
AppPublisher = {#Publisher}
AppPublisherURL = {#AppURL}
AppSupportURL = {#AppURL}
AppUpdatesURL = {#AppURL}
DefaultDirName = {pf}\{#AppName}
DisableProgramGroupPage = yes
SetupIconFile = Release\icon.ico 
OutputBaseFilename = setup NoteApp
Compression = lzma
SolidCompression = yes
AllowNoIcons = yes


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: desktopicon; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Files]
Source:"Release\*.exe" ;DestDir:"{app}"; Flags:ignoreversion
Source:"Release\*.dll" ;DestDir:"{app}\Libraries"; Flags:ignoreversion
Source:"Release\*.ico" ;DestDir:"{app}\icon"; Flags:ignoreversion
Source:"Release\*.config" ;DestDir:"{app}"; Flags:ignoreversion
[Icons]
Name:"{commonprograms}\{#AppName}";Filename:"{app}\{#NoteAppExeName}";
Name:"{commondesktop}\{#AppName}";Filename:"{app}\{#NoteAppExeName}"; Tasks: desktopicon; IconFilename:"{app}\icon\icon.ico"
[UninstallDelete]
Name:"{userdocs}\NoteApp.notes"; Type:filesandordirs
