#define MyPackageName "ZapU"
#define MyClientAppName "ZapUclient"
#define MyServerAppName "ZapUserver"
#define MyAppVersion "0.7"
#define MyAppPublisher "culturespy"
#define MyClientAppExeName "ZapUclient.exe"
#define MyServerAppExeName "ZapUserver.exe"
#define TargetOS "win"

[Setup]
AppId={{784FCDA5-3F82-4058-9EF1-63E40AC008F0}
AppName={#MyPackageName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf64}\{#MyPackageName}
DefaultGroupName={#MyPackageName}
OutputDir=.
OutputBaseFilename={#MyPackageName}{#TargetOS}-{#MyAppVersion}
Compression=lzma
SolidCompression=yes
WizardStyle=modern
LicenseFile=COPYING

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "ZapUclient\bin\x64\Release\Microsoft.Bcl.AsyncInterfaces.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\runtime.osx.10.10-x64.CoreCompat.System.Drawing.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\ScottPlot.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\ScottPlot.WinForms.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Buffers.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Drawing.Common.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Memory.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Numerics.Vectors.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Text.Encodings.Web.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Text.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.Threading.Tasks.Extensions.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\System.ValueTuple.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\ZapUclient.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\XInput.Wrapper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUclient\bin\x64\Release\ZapUcommon.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "ZapUserver\bin\x64\Release\ZapUserver.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "COPYING"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyClientAppName}"; Filename: "{app}\{#MyClientAppExeName}"
Name: "{group}\{#MyServerAppName}"; Filename: "{app}\{#MyServerAppExeName}"
