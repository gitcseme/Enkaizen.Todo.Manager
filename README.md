# Enkaizen.Todo.Manager
## Help note to run
* Please change the **connection string** in the appsettings.json file.
* I configured automatic migration and seeding.
* The app will apply migration & seed data while preparing to run.
* The app has 3 users **one admin and two normal users** you can also create new by registration.
* To see the credential please have a look at the **Enkaizen.Todo.Web.Seeds.ApplicationDataSeed** class
* Create some TodoTask to see full operations.

## Used technologies
* ASP.NET Core 3.1
* Entity Framework Core as ORM
* Microsoft SQL Server
* Autofac for DI
* Serilog for logging
* JavaScript & Ajax
