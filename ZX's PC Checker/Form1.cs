using System.Diagnostics;
using System.Windows.Forms; // Ensure this is present
using System.IO; // Needed for file operations

namespace ZX_s_PC_Checker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button3.Click += button3_Click; // Attach the event handler
            button2.Click += button2_Click; // Attach the new event handler
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "zxchecks")
            {
                MessageBox.Show("Correct code", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button1.Visible = true;
                button2.Visible = true;
                label6.Visible = true;
            }
            else
            {
                MessageBox.Show("Incorrect code", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Define batch script content
                string batchScript = @"@echo off
setlocal EnableDelayedExpansion

:: Display banner
echo.
echo ============================
echo    ZX's PC CHECKER
echo ============================
timeout /t 3 >nul

:: Admin check
>nul 2>&1 ""%SYSTEMROOT%\system32\cacls.exe"" ""%SYSTEMROOT%\system32\config\system""
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    powershell -Command ""Start-Process '%~f0' -Verb runAs""
    exit /b
)

:: Set up folder
set ""TARGETDIR=C:\ZXPCCHECK""
if not exist ""%TARGETDIR%"" (
    mkdir ""%TARGETDIR%""
)
cd /d ""%TARGETDIR%""

:: Download tools
call :Download ""https://www.voidtools.com/Everything-1.4.1.1026.x64.Lite-Setup.exe"" ""Everything-Setup.exe""
call :Download ""https://www.nirsoft.net/utils/executedprogramslist.zip"" ""executedprogramslist.zip""
call :Download ""https://github.com/ponei/JournalTrace/releases/download/1.0/JournalTrace.exe"" ""JournalTrace.exe""
call :Download ""https://www.nirsoft.net/utils/usbdeview.zip"" ""usbdeview.zip""
call :Download ""https://www.nirsoft.net/utils/windefthreatsview-x64.zip"" ""windefthreatsview-x64.zip""
call :Download ""https://github.com/kacos2000/Win10LiveInfo/releases/download/v.1.0.23.0/WinLiveInfo.exe"" ""WinLiveInfo.exe""
call :Download ""https://www.nirsoft.net/utils/winprefetchview-x64.zip"" ""winprefetchview-x64.zip""
call :Download ""https://www.nirsoft.net/utils/browserdownloadsview-x64.zip"" ""browserdownloadsview-x64.zip""
call :Download ""https://www.nirsoft.net/utils/appreadwritecounter-x64.zip"" ""appreadwritecounter-x64.zip""
call :Download ""https://www.nirsoft.net/utils/alternatestreamview-x64.zip"" ""alternatestreamview-x64.zip""
call :Download ""https://ixpeering.dl.sourceforge.net/project/processhacker/processhacker2/processhacker-2.37-setup.exe?viasf=1"" ""ProcessHacker-2.37-setup.exe""
call :Download ""https://win.cleverfiles.com/disk-drill-win.exe"" ""disk-drill-win.exe""

:: Extract ZIPs
echo.
echo Extracting ZIP files...
for %%f in (*.zip) do (
    echo Extracting %%f...
    powershell -Command ""Expand-Archive -Force '%%f' '.'""
)

:: Collect user input
set /p ""GAMENAME=Enter the name of the game you're checking for: ""
set /p ""CHECKER=Enter the PC Checker or admins name: ""
set /p ""CLIENTNAME=Enter your name (roblox and discord users): ""

:: Gather system info
for /f ""tokens=*"" %%u in ('net user ^| findstr /R /C:""^*""') do (
    set ""USERS=!USERS!%%u\n""
)

for /f ""tokens=*"" %%i in ('systeminfo ^| findstr /C:""Original Install Date""') do set INSTALL_DATE=%%i
for /f ""tokens=*"" %%j in ('net statistics workstation ^| findstr /C:""Statistics since""') do set LAST_BOOT=%%j

:: Write to local report file
set ""REPORT=%TARGETDIR%\PC_Report.txt""
(
    echo ZX PC Checker Report
    echo ---------------------
    echo Game Name: %GAMENAME%
    echo Checked By: %CHECKER%
    echo Clients username: %CLIENTNAME%
    echo.
    echo Users:
    net user
    echo.
    echo %INSTALL_DATE%
    echo %LAST_BOOT%
) > ""%REPORT%""

:: Write PowerShell script for sending to Discord
set ""PSFILE=%TEMP%\send_to_discord.ps1""
(
    echo $report = Get-Content -Path ""%REPORT%"" -Raw
    echo $payload = @{
    echo     username = ""ZX Manual PC Checker""
    echo     content = ""``````n$report`n``````""
    echo } ^| ConvertTo-Json -Compress
    echo Invoke-RestMethod -Uri ""https://discord.com/api/webhooks/1377253802582999040/QXFr0UznYoD1wySPmaMKC5qxonSEoE9Nk9LVuAT9RF3fFr6lpVt_qgQZM1OWcxmUYcId"" -Method Post -Body $payload -ContentType ""application/json""
) > ""%PSFILE%""

powershell -ExecutionPolicy Bypass -File ""%PSFILE%""
del ""%PSFILE%""
echo.
echo Report complete. Info saved to PC_Report.txt and sent to Discord.
pause
exit /b

:Download
:: %1 = URL, %2 = Output Filename
echo Downloading %2...
powershell -Command ""Invoke-WebRequest -Uri '%~1' -OutFile '%~2'"" >nul 2>&1
if exist ""%~2"" (
    echo Downloaded: %2
) else (
    echo Failed to download: %2
)
exit /b
";

                // Save to temporary file
                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCChecker.bat");
                File.WriteAllText(tempFile, batchScript);

                // Start it with admin rights
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run batch script: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string batchScript = @"@echo off
title ZX's AUTOMATIC PC CHECKER
color 0A
echo ZX's AUTOMATIC PC CHECKER
timeout /t 3 >nul

:: --- Check if running as admin ---
net session >nul 2>&1
if %errorLevel% NEQ 0 (
    echo Requesting administrator access...
    powershell -Command ""Start-Process '%~f0' -Verb RunAs""
    exit /b
)

:: --- Create folder ---
set ""output=C:\autocheck""
if not exist ""%output%"" mkdir ""%output%""

set ""result=%output%\results.txt""
echo Checking system... > ""%result%""

:: --- Prompt for Username ---
set /p checkuser=Enter the name of the person being checked: 
echo Username Being Checked: %checkuser% >> ""%result%""

:: --- Check if prefetching is enabled ---
reg query ""HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters"" /v EnablePrefetcher >nul 2>&1
if %errorlevel%==0 (
    for /f ""tokens=3"" %%a in ('reg query ""HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Memory Management\PrefetchParameters"" /v EnablePrefetcher 2^>nul') do (
        echo Prefetcher Enabled: %%a >> ""%result%""
    )
) else (
    echo Prefetcher setting not found >> ""%result%""
)

:: --- Get Windows install date ---
for /f ""tokens=1,*"" %%a in ('""systeminfo | findstr /C:""Original Install Date""""') do (
    echo Windows Install Date: %%b >> ""%result%""
)

:: --- Get last reboot time using PowerShell ---
for /f ""delims="" %%i in ('powershell -command ""(Get-CimInstance -ClassName win32_operatingsystem).LastBootUpTime""') do (
    echo Last Reboot Time: %%i >> ""%result%""
)

:: --- Search for suspicious strings ---
echo.
echo Searching Strings...
echo.
echo --- Suspicious Files/Folders Found --- >> ""%result%""

setlocal enabledelayedexpansion
set ""keywords=Matrix Aimmy Cheat Hack linkvertise adfocus aimbot tracers xeno silentaim Dx9 Cultof intellect awp.gg blatant jjsploit wave solara nezur seliware delta""

for %%k in (%keywords%) do (
    echo Searching for ""%%k""...
    for /r ""C:\"" %%f in (*%%k*) do (
        echo Found: %%f >> ""%result%""
    )
)

:: --- Download and Extract EchoAC Executable ---
echo.
echo Downloading EchoAC tool...

set ""zipfile=%output%\ac.zip""
set ""exedir=%output%""
curl -L ""https://raw.githubusercontent.com/zxbot3/echoac-free/refs/heads/main/ac.zip"" -o ""%zipfile%""

if exist ""%zipfile%"" (
    echo Extracting EchoAC...
    powershell -Command ""Expand-Archive -Path '%zipfile%' -DestinationPath '%exedir%' -Force""

    :: Search recursively for ac.exe
    for /r ""%exedir%"" %%x in (ac.exe) do (
        set ""echopath=%%x""
        goto :found_exe
    )

    echo ERROR: Could not find ac.exe after extracting.
    pause
    exit /b

:found_exe
    echo Found EchoAC at: %echopath%
    echo Launching EchoAC...
    start """" ""%echopath%""
    echo Please follow the prompts in EchoAC.
    echo When it opens choose ""Roblox""
    echo Accept the Licence agreement and Privacy Policy
    echo Click on ""or try for free"" below the code input
    echo Then press begin scan
    echo When complete, it will show your link.
    pause
    goto skip_download_error
) else (
    echo ERROR: Failed to download EchoAC ZIP.
    pause
    exit /b
)

:skip_download_error

:: --- Ask for EchoAC link from user ---
set /p echolink=Please enter your EchoAC link (shown at the end of EchoAC tool): 
echo. >> ""%result%""
echo --- EchoAC Link --- >> ""%result%""
echo %echolink% >> ""%result%""

:: --- Log recent antivirus detections (Windows Defender only) ---
echo. >> ""%result%""
echo --- Recent Antivirus Detections (Windows Defender) --- >> ""%result%""
powershell -Command ""try { Get-MpThreatDetection | Sort-Object -Property InitialDetectionTime -Descending | Select-Object ThreatName,ActionSuccess,InitialDetectionTime -First 5 | Format-Table -AutoSize | Out-String } catch { 'No detections or access denied.' }"" >> ""%result%""

:: --- Send to Discord webhook ---
echo.
echo Sending report to webhook...

curl -H ""Content-Type: multipart/form-data"" ^
     -F ""payload_json={\""content\"": \""New PC check result for %checkuser%. See attached file.\""}"" ^
     -F ""file=@%result%"" ^
     ""https://discord.com/api/webhooks/1377252207606497310/SWFjVj0Mdukrb_ah5IRN6Jy3-isNbQg8-NxgBlnX5An7-Ht_1YQ5wY7t-kvP0tzeiQJb""

echo.
echo Done. Output saved to %result%
pause
exit
";

                string tempFile = Path.Combine(Path.GetTempPath(), "ZXPCAutoChecker.bat");
                File.WriteAllText(tempFile, batchScript);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = tempFile,
                    UseShellExecute = true,
                    Verb = "runas" // Run as administrator
                };

                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run automatic batch script: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
