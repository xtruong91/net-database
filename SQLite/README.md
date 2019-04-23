1. Create your ASP.NET web application

2. Install EnitityFramework.SQLite -> install package

Get the necessary packages
Microsoft.EntityFrameworkCore 1.0.0
Microsoft.EntityFrameworkCore.SQlite 1.0.0
    
3. Create your context
4.Create your database on startup, by adding it to the startup method

5. First migration with Enity Framework
Finally finished with our models,
let's create the database. Open with your favorite console at the root of the project and enter the following commands


dotnet ef migrations add CreateDatabase
dotnet ef database update