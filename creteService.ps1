param(
    [Parameter(Mandatory=$true)]
    [string]$solutionName
)

function copyAndApplyTempaltes($projectName)
{
    Copy-Item -Path "../../Templates/$projectName/*" -Destination . -ErrorAction SilentlyContinue
    replacePlaceholder "##SolutionName##" $solutionName
    replacePlaceholder "##SolutionAndProjectName##" ($solutionName + "." + $projectName)
}

function replacePlaceholder($placeholder, $replacement)
{
    Get-ChildItem *.cs | ForEach-Object { ((Get-Content $_ -Raw) -replace "$placeholder","$replacement" ) | Set-Content $_ }
}

# Create solution folder
mkdir $solutionName
Set-Location $solutionName

$solutionFolder = $pwd.Path + "\"

Copy-Item ../.gitignore .
Copy-Item ../.gitattributes .


# Create folders
New-Item -Type Directory ($solutionName + ".Api")
New-Item -Type Directory ($solutionName + ".Application")
New-Item -Type Directory ($solutionName + ".Contracts")
New-Item -Type Directory ($solutionName + ".Infrastructure")
New-Item -Type Directory ($solutionName + ".NServiceBusHost")

#create projects
Set-Location -Path ($solutionFolder + $solutionName + ".Api")
dotnet new webapi
copyAndApplyTempaltes "Api"

Set-Location -Path ($solutionFolder + $solutionName + ".Application")
dotnet new classlib

Set-Location -Path ($solutionFolder + $solutionName + ".Contracts")
dotnet new classlib
copyAndApplyTempaltes "Contracts"


Set-Location -Path ($solutionFolder + $solutionName + ".Infrastructure")
dotnet new classlib

Set-Location -Path ($solutionFolder + $solutionName + ".NServiceBusHost")
dotnet new console
copyAndApplyTempaltes "NServiceBusHost"


# add references
Set-Location -Path ($solutionFolder + $solutionName + ".Api")
dotnet add reference $($solutionFolder + $solutionName + ".Application/" + $solutionName + ".Application.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".Contracts/" + $solutionName + ".Contracts.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".Infrastructure/" + $solutionName + ".Infrastructure.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".NServiceBusHost/" + $solutionName + ".NServiceBusHost.csproj")

Set-Location -Path ($solutionFolder + $solutionName + ".Application")
dotnet add reference $($solutionFolder + $solutionName + ".Contracts/" + $solutionName + ".Contracts.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".Infrastructure/" + $solutionName + ".Infrastructure.csproj")

Set-Location -Path ($solutionFolder + $solutionName + ".NServiceBusHost")
dotnet add reference $($solutionFolder + $solutionName + ".Application/" + $solutionName + ".Application.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".Contracts/" + $solutionName + ".Contracts.csproj")
dotnet add reference $($solutionFolder + $solutionName + ".Infrastructure/" + $solutionName + ".Infrastructure.csproj")

# add common packages 
Set-Location -Path ($solutionFolder + $solutionName + ".Api")
dotnet add package AutoMapper
dotnet add package Swashbuckle.AspNetCore
dotnet add package NServiceBus
dotnet add package NServiceBus.Extensions.Hosting
dotnet restore

Set-Location -Path ($solutionFolder + $solutionName + ".Application")
dotnet add package NServiceBus
dotnet add package AutoMapper
dotnet restore

Set-Location -Path ($solutionFolder + $solutionName + ".Infrastructure")
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet restore

Set-Location -Path ($solutionFolder + $solutionName + ".NServiceBusHost")
dotnet add package NServiceBus
dotnet add package NServiceBus.SqlServer
dotnet add package NServiceBus.Persistence.Sql
dotnet add package NServiceBus.FluentConfiguration.WebApi
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Autofac.Extensions.DependencyInjection
dotnet add package NServiceBus.Extensions.DependencyInjection
dotnet restore

