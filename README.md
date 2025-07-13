# EmployeeManagementSystem  
(2025)

**EmployeeManagementSystem** is a desktop-based application built with **VB.NET** for managing employee records, attendance, department assignments, and payroll.  
The system supports role-based access for admins and employees, providing a centralized platform for day-to-day HR operations.

## Features

**Admin Functions**
- Manage employee records and department assignments
- Track daily attendance and leave status
- Automate attendance for employees on leave
- Generate and manage payroll
- View system-wide attendance and employee status

**Employee Functions**
- Secure login and password change
- View personal attendance records
- Submit leave requests (optional)
- View department and payroll details (optional)

## Requirements
- Visual Studio 2012 or later  
  [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)
- .NET Framework 4.8.1 or later  
  [Download .NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481)
- XAMPP or WAMP (for MySQL)  
  [Download XAMPP](https://www.apachefriends.org/index.html)  
  [Download WAMP](https://www.wampserver.com/en/)
- SQLYog or any MySQL client  
  [Download SQLYog](https://github.com/webyog/sqlyog-community/wiki/Downloads)
- MySQL .NET Connector (`MySql.Data.dll`)  
  [Download Connector/NET](https://dev.mysql.com/downloads/connector/net/)

## Installation
1. Download and extract the project `.zip` file.
2. Start MySQL using XAMPP, WAMP, or your preferred method.
3. Open SQLYog and import the `.sql` file from the `sql` folder to set up the database.
4. Open `EmployeeManagementSystem.sln` in Visual Studio.
5. Ensure the following before running:  
   - The project targets .NET Framework 4.8.1 or later.  
   - `MySql.Data.dll` is added and referenced in the project.
6. Build and run the project.

---

**Developer:** Janelle Ann Castillo ([nncast](https://github.com/nncast))
