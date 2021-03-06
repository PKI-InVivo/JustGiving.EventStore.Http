﻿param(
	[string]$task = "local",
	[string]$PublicNugetApiKey
)

$ApplicationName = "JustGiving.EventStore.HttpClient"

Write-Host "------"
Write-Host $task
Write-Host "------"
Write-Host "Key: $PublicNugetApiKey"
Write-Host "------"

Import-Module ".\psake.psm1"
Invoke-psake .\jg-build-psake.ps1 -t $task -parameters @{"PublicNugetApiKey"=$PublicNugetApiKey;}