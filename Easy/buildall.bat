@echo off
rem Environment variables are local only and thus forgotten when script exits
setlocal
title Build

set MSBUILD="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
if not exist %MSBUILD% set MSBUILD="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" 
if not exist %MSBUILD% set MSBUILD="%ProgramFiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" 
if not exist %MSBUILD% set MSBUILD="%ProgramFiles(x86)%\MSBuild\14.0\bin\MSBuild.exe" 
if not exist %MSBUILD% set MSBUILD="%ProgramFiles(x86)%\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"

if not exist %MSBUILD% goto :requirements_missing

echo MsBuild found at %MSBUILD%

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
echo Building '%WHAT%'
goto :BUILD

:SINGLE
echo Building '%1'
set WHAT=%1
goto :build

:ALL
echo Building everything
set WHAT=*.sln

:BUILD
set /a errors = 0

for  %%i in (%WHAT%) do (
  echo Building: %%~ni [%%i]
  call %MSBUILD% %%i /m /nologo /verbosity:quiet /t:Build /p:Configuration=Debug  /clp:ErrorsOnly
  if errorlevel 1 (set /a errors += 1)
   rem dir %~dp0\mainform\bin\Debug\*.dll > "build_%%i.lst"
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
pause

:end
