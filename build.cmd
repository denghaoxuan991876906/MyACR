@echo off
cd /d "%~dp0"
dotnet restore --nologo
if %ERRORLEVEL% NEQ 0 exit /b %ERRORLEVEL%
dotnet build -c Debug --nologo
