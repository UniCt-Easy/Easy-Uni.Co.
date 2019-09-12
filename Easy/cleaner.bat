@echo off
rem Environment variables are local only and thus forgotten when script exits
setlocal
title Build

set MSBUILD="%ProgramFiles(x86)%\MSBuild\14.0\bin\MSBuild.exe" 
if not exist %MSBUILD% goto :requirements_missing

if "%1" == "" goto :ALL
if "%~x1" == ".sln" goto :SINGLE

Set Shortcut=%1
echo set WshShell = WScript.CreateObject("WScript.Shell")>DecodeShortCut.vbs
echo set Lnk = WshShell.CreateShortcut(WScript.Arguments.Unnamed(0))>>DecodeShortCut.vbs
echo wscript.Echo Lnk.TargetPath>>DecodeShortCut.vbs
set vbscript=cscript //nologo DecodeShortCut.vbs
For /f "delims=" %%T in ( ' %vbscript% "%Shortcut%" ' ) do set WHAT=%%~nxT
del DecodeShortCut.vbs
rem Echo Shortcut %shortcut%
echo Cleaning '%WHAT%'
goto :BUILD

:SINGLE
echo Cleaning '%1'
set WHAT=%1
goto :build

:ALL
echo Cleaning everything
set WHAT=*.sln

:BUILD
set /a errors = 0

for  %%i in (%WHAT%) do (
  echo Cleaning: %%~ni [%%i]
  call %MSBUILD% %%i /m /nologo /verbosity:quiet /t:Clean /p:Configuration=Debug  /clp:ErrorsOnly
  if errorlevel 1 (set /a errors += 1)
)
if %errors% EQU 0 (goto :end)
pause
goto :end

:requirements_missing
echo ###############################################################################
echo  Ooops! You don't seem to have MSBuild or you have the wrong version.
echo  Was looking for:
echo   %MSBUILD%
echo ###############################################################################

:end
