# **MySQL Monitor Service**

![C# Badge](https://img.shields.io/badge/-C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![.NET Core Badge](https://img.shields.io/badge/-.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![MySQL Badge](https://img.shields.io/badge/-MySQL-4479A1?style=flat-square&logo=mysql&logoColor=white)

A background service built with **C#** and **.NET Core**, which monitors a MySQL database and logs new entries in real-time. The service fetches the latest entries, prints them to the console, and writes the most recent record to a `.txt` file, overwriting the previous entry. Ideal for applications where database monitoring and real-time logging are essential.

## **Features**
- Monitors new records in a MySQL database table.
- Fetches entries with an ID greater than the last processed one.
- Writes the latest entry to a `.txt` file, replacing the previous entry.
- Logs information and errors with structured logging using **Microsoft.Extensions.Logging**.

## **Technologies Used**
- **C#**
- **.NET Core** (Background Service)
- **MySQL**
- **Microsoft.Extensions.Logging** (for logging information)
- **System.IO** (for file handling)

## **Installation and Setup**

1. Clone this repository:
   ```bash
   git clone https://github.com/your-github/MySQLMonitorService.git
