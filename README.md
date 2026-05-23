The application continuously monitors important system resources like CPU usage(Random(1-100)),
RAM usage, and Disk usage in real time for every 5 seconds.

For developing this application, I used the following technologies and tools:

- C#
- .NET 8
- Visual Studio 2022 IDE
- Log4Net for application logging and error tracking
- SQL Server Management Studio (SSMS) 2019
- Entity Framework Core for database connectivity and ORM operations
- Dependency Injection using Microsoft.Extensions.DependencyInjection
- REST API integration using HttpClient
- JSON configuration using appsettings.json

The application is designed using Clean Architecture principles with separation of concerns,
making the system scalable, maintainable, and easy to extend.

A plugin-based architecture was implemented using interfaces, allowing new plugins
to be added without modifying the core application logic.

** Please Change the connection String of your DataBase" in 
appsettings.json in that

 "ConnectionStrings": {
   "DefaultConnection": "Server=RAHULS-PC\\SQLEXPRESS;Database=SystemMonitorDb;Trusted_Connection=True;TrustServerCertificate=True"
 },

 Replace My Server(RAHULS-PC\\SQLEXPRESS) With your Server for better result .

 For the Logs Please Build the Application and You can find the Logs in 
 \SystemMonitorApp\SystemMonitorApp\bin\Debug\net8.0\Logs    (In File Explorer )

 



