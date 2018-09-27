Asp.net CORE 2.0 with ready to use customer application
To see the live demo of this application visit 

REQUIREMENTS
* Visual Studio 2017
* .NET Core 2.0
* Microsoft SQL Server 2016

INSTALLATION
1. Download the repository
2. Copy the STERLINGASSET project folder into your solution folder
3. Open your visual studio 2017 as administrator and click on file 
4. Then open the project folder click on STERLINGASSET.sln
5. From the MENU click on Build to build the project, this will add all the dependency
6. Open your Microsoft SQL Server then create database name it STERLINGASSET
7. Then restore the STERLINGASSET database

USAGE 
* Open the Startup.cs on  STERLINGASSET then change this line of code to your own database
services.AddDbContext<STERLINGASSETContext>(options => options.UseSqlServer("Server=.\\FINTRAKSQL;Database=STERLINGASSET;user id=sa; password=sqluser10$;"));
* Open the Models folder on STERLINGASSET.DATA 
* Click on STERLINGASSETContext.cs
  change this line of code to your own database
optionsBuilder.UseSqlServer(@"Server=.\FINTRAKSQL;Database=STERLINGASSET;Trusted_Connection=True; User ID=sa;Password=sqluser10$;MultipleActiveResultSets=False;");
  
BUILD AND RUN
  
 

