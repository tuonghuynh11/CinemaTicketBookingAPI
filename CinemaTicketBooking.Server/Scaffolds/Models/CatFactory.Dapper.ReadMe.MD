# CatFactory ==^^==: Scaffolding Made Easy

How to use this code on your ASP.NET Core Application:

1. Install SqlClient and Dapper packages
2. Register the Repositories in ConfigureServices method (Startup class)

## Install packages

You can install the NuGet packages in Visual Studio or Windows Command Line, for more info:

[`Install and manage packages with the Package Manager Console in Visual Studio (PowerShell)`](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-powershell)

[`.NET Core CLI`](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package)

## Register Repositories

Add the following code lines in **ConfigureServices** method (Startup class):

  services.AddScope<IDboRepository, DboRepository>()

Happy scaffolding!

You can check the guide for this package in: [`Scaffolding Dapper with CatFactory`](https://www.codeproject.com/Articles/1213355/Scaffolding-Dapper-with-CatFactory)

Also you can check the source code on [`GitHub repository`](https://github.com/hherzl/CatFactory.Dapper)

Special Thanks for [`Edson Ferreira`](https://github.com/EdsonF) to let me help to Dapper community

CatFactory Development Team ==^^==
