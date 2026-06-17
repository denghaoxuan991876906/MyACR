$ErrorActionPreference = "Stop"
Set-Location $PSScriptRoot
dotnet restore --nologo
dotnet build -c Debug --nologo
