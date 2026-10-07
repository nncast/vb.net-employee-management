# Contributing to PeopleSphere

Thanks for helping out. Bug reports, fixes and small improvements are all welcome.

## Reporting bugs and ideas

Open an [issue](https://github.com/nncast/vb.net-employee-management/issues) with:

- what you did, what you expected, and what happened instead
- the version (see [Releases](https://github.com/nncast/vb.net-employee-management/releases)) and whether you ran the Windows build or built from source
- your MySQL/MariaDB setup (XAMPP, WAMP, other) if the problem involves the database

Security problems do not go in issues; see [SECURITY.md](SECURITY.md).

## Setting up

Follow **From source** in the [README](README.md#setup-and-run-instructions): import `database/dbemployee.sql`, open `EmployeeManagementSystem/EmployeeManagementSystem.sln` in Visual Studio, and set the `EmployeeDb` connection string in `App.config` if your MySQL settings differ from the defaults.

## Making a change

1. Fork the repository and create a branch from `main` (for example `fix-payroll-rounding`).
2. Keep each pull request to one fix or feature.
3. Build and try your change as both an **admin** and an **employee** account.
4. Open a pull request that says what changed and how you tested it. Screenshots help for form changes.

## Code guidelines

- **Database access** goes through the helpers in `Conn.vb` (`GetQuery`, `SetQuery`, `GetValue`, `Execute`). Pass every value with `P("@name", value)`; never build SQL by joining strings with user input.
- **Multi-step writes** (for example payroll or leave updates that touch several tables) go inside `BeginTransaction` / `CommitTransaction`, with `RollbackTransaction` on failure.
- **Passwords** are stored only through `PasswordHasher.HashPassword` and checked with `VerifyPassword`. Never store, log or display a plain-text password, except the one-time temporary password shown when an account is created.
- **Connection settings** stay in `App.config`. Do not hard-code server names, users or passwords.
- **Schema changes** go into `database/dbemployee.sql` so a fresh import matches the code. Mention in the pull request whether existing databases need a manual change.
- Match the style of the surrounding code: form names like `frmPayroll`, admin screens under `Admin/`, employee screens under `Employee/`.
- Do not commit `bin/`, `obj/` or personal `App.config` changes such as your local database password.
