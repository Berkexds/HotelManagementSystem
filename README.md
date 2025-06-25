## Database Connection Configuration

To connect the application to your local SQL Server database, please update the connection strings in the `App.config` file inside the **WindowsFormsApp1** project.

Below is the example connection string configuration used in this project:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="HotelManagementSystemEntities"
         connectionString="metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=localhost\MSSQLSERVER02;initial catalog=HotelManagementSystem;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
         providerName="System.Data.EntityClient" />
    <add name="HotelManagementSystemEntities1"
         connectionString="metadata=res://*/HotelModel.csdl|res://*/HotelModel.ssdl|res://*/HotelModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=localhost\MSSQLSERVER02;initial catalog=HotelManagementSystem;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
         providerName="System.Data.EntityClient" />
  </connectionStrings>
</configuration>


# Hotel Management System

A Windows Forms application for managing hotel operations including customer reservations, room tracking, and employee management. Built using C# and Entity Framework.

## Features

- ✅ Add, edit, delete customers
- ✅ Manage rooms and availability
- ✅ Employee login and staff management
- ✅ Database integration via SQL Server and Entity Framework

## Technologies Used

- C# (.NET Framework)
- Windows Forms
- SQL Server
- Entity Framework 6

## How to Run

1. Download and extract the zip file

2. Open the '.sln' file in **Visual Studio**.

3.Prepare the database connection:

-Open the App.config file inside the WindowsFormsApp1 project.

-Modify the connection string’s data source to match your SQL Server instance, for example:

"data source=localhost\MSSQLSERVER02;"

-Make sure it points to the SQL Server instance where the database is hosted (check in SQL Server Management Studio).

-If the project references a .pfx signing key file that is missing or causes build errors:

-Open WindowsFormsApp1.csproj and remove or comment out the lines referencing the .pfx file.

4.Make sure SQL Server is running:(THERE IS SQL FILE FOR ALL THE ENTITIES)

-Start SQL Server and confirm the HotelManagementSystem database is attached.

-Ensure your Windows user has permissions to access the database (typically assigned the db_owner role).

5.Build and run the application:

-Build the solution in Visual Studio.

-Run the application; it should connect to the database and work correctly.


## Authors

- 💻 **Berke Akman** – Project lead, core architecture, and initial development  
- 🧩 **Umut Paklacı** –  Feature enhancements, bug fixes, and additional improvements  

---

