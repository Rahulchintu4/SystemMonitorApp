## How to Build and Run the Application

### Prerequisites

Before running the application, make sure the following software is installed:

- Visual Studio 2022
- .NET 8 SDK
- SQL Server
- SQL Server Management Studio (SSMS) 2019

---

## Steps to Run the Application

1. Open Visual Studio 2022.

2. Clone the GitHub repository:

git clone https://github.com/Rahulchintu4/SystemMonitorApp.git

Or directly open the project from Visual Studio using:
File → Clone Repository

3. After cloning, open the solution file in Visual Studio 2022.

4. Open the appsettings.json file and update the SQL Server connection string.

Current Connection String:

"ConnectionStrings": {
  "DefaultConnection": "Server=RAHULS-PC\\SQLEXPRESS;Database=SystemMonitorDb;Trusted_Connection=True;TrustServerCertificate=True"
}

Replace:
RAHULS-PC\\SQLEXPRESS

with your own SQL Server instance name.

Example:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SystemMonitorDb;Trusted_Connection=True;TrustServerCertificate=True"
}

5. Build the application using:

Build → Build Solution

Or press:

Ctrl + Shift + B

6. Run the application using:

F5

or click Start button in Visual Studio.

---

## Output

After running the application, the console displays:

- CPU Usage
- RAM Usage
- Disk Usage

The application updates the monitoring data every 5 seconds.

---

## Logs

The application uses Log4Net for logging.

After building and running the application, log files can be found at:

SystemMonitorApp\SystemMonitorApp\bin\Debug\net8.0\Logs

The logs contain:
- Monitoring information
- Application events
- Error details
- Exception logs

---

## Additional Information
The application monitors CPU, RAM, and Disk usage continuously in real time.
Currently, the monitoring data refreshes every 5 seconds using Task.Delay() inside the monitoring loop.

At present, the interval value is hardcoded in the application.

