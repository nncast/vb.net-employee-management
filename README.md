<h1 align="center">EmployeeManagementSystem</h1>

<p align="center">
  <img src="https://img.shields.io/badge/version-0.1.0-8038C5?style=flat-square" alt="version">
  <img src="https://img.shields.io/badge/status-complete-2772BD?style=flat-square" alt="status">
  <img src="https://img.shields.io/badge/VB.NET-Windows_Forms-512BD4?style=flat-square&logo=dotnet&logoColor=white" alt="VB.NET">
  <img src="https://img.shields.io/badge/.NET_Framework-4.8.1-5C2D91?style=flat-square&logo=dotnet&logoColor=white" alt=".NET Framework">
  <img src="https://img.shields.io/badge/MySQL-XAMPP-4479A1?style=flat-square&logo=mysql&logoColor=white" alt="MySQL">
</p>

<p align="center">
  <b>Download v0.1.0:</b>
  <a href="https://github.com/nncast/vb.net-employee-management/archive/refs/tags/v0.1.0.zip">Source (.zip)</a> |
  <a href="https://github.com/nncast/vb.net-employee-management/releases">All releases</a>
</p>

**EmployeeManagementSystem** is a desktop-based application built with **VB.NET** for managing employee records, attendance, department assignments, and payroll.
The system supports role-based access for admins and employees, providing a centralized platform for day-to-day HR operations.

> **Current version: v0.1.0** — first tagged release. See [Releases](https://github.com/nncast/vb.net-employee-management/releases) for the project timeline.

## Screenshots

<p align="center">
  <img width="400" alt="Login form." src="https://github.com/user-attachments/assets/13cdf984-6f63-4d7c-ac41-e82849ad4e6d" />
  <img width="400" alt="Dashboard form for admin." src="https://github.com/user-attachments/assets/309c94f9-9318-4f23-9006-afb019269b60" />
  <img width="400" alt="Employee management form." src="https://github.com/user-attachments/assets/c4c6b101-b229-4497-8fa8-add216a87fe0" />
  <img width="400" alt="Attendance form." src="https://github.com/user-attachments/assets/31ed770f-a1e3-4fcc-a2bb-0fbd47b83f36" />
</p>

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

## Development environment

| Category | Details |
| --- | --- |
| Language | Visual Basic .NET |
| UI | Windows Forms |
| Framework | .NET Framework 4.8.1 |
| Database | MySQL / MariaDB (XAMPP or WAMP) — database `dbemployee` |
| Driver | MySql.Data (MySQL Connector/NET) |
| IDE | Visual Studio 2012 or later |

## Requirements

| Tool | Download |
| --- | --- |
| Visual Studio 2012 or later | [visualstudio.microsoft.com](https://visualstudio.microsoft.com/downloads/) |
| .NET Framework 4.8.1 or later | [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net481) |
| XAMPP or WAMP (for MySQL) | [XAMPP](https://www.apachefriends.org/index.html) · [WAMP](https://www.wampserver.com/en/) |
| SQLYog or any MySQL client | [SQLYog](https://github.com/webyog/sqlyog-community/wiki/Downloads) |
| MySQL .NET Connector (`MySql.Data.dll`) | [Connector/NET](https://dev.mysql.com/downloads/connector/net/) |

## Setup and run instructions

1. Clone the repository, or download the [source .zip](https://github.com/nncast/vb.net-employee-management/archive/refs/tags/v0.1.0.zip).
   ```bash
   git clone https://github.com/nncast/vb.net-employee-management.git
   ```
2. Start MySQL using XAMPP, WAMP, or another server stack.
3. Import `database/dbemployee.sql` with SQLYog or another MySQL client, or from the CLI:
   ```bash
   mysql -u root -p < database/dbemployee.sql
   ```
4. Open `EmployeeManagementSystem/EmployeeManagementSystem.sln` in Visual Studio.
5. Make sure the project targets .NET Framework 4.8.1 or later and that `MySql.Data.dll` is referenced.
6. Build and run the project.

Sign in with `admin` / `admin123`. Change the password from the Employee → Profile screen after the first login.

## Developer

Janelle Ann Castillo ([nncast](https://github.com/nncast))

---

*EmployeeManagementSystem · 2025 · VB.NET · Windows Forms · .NET Framework 4.8.1 · MySQL*
