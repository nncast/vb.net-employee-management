# Security Policy

## Supported versions

| Version | Supported |
| --- | --- |
| 0.1.1 | Yes |
| 0.1.0 | No (stores plain-text passwords; upgrade to 0.1.1) |

## Reporting a vulnerability

Please **do not** open a public issue for security problems.

Report it privately through GitHub: go to the repository's **Security** tab and click **Report a vulnerability** ([direct link](https://github.com/nncast/vb.net-employee-management/security/advisories/new)).

Include:

- the version and whether you used the Windows build or built from source
- the steps to reproduce, and which screen or file is affected
- what an attacker could do with it (for example read other employees' records, sign in as admin, change payroll)

You should get a reply within 7 days. Once the problem is confirmed, a fix is released as a new version and you are credited in the release notes unless you prefer not to be.

## Deployment notes

PeopleSphere is a desktop app that talks directly to MySQL, so the database is the main thing to protect:

- Change the default `admin` / `admin123` password right after the first sign-in.
- Do not use the MySQL `root` account with an empty password outside a local test machine. Create a dedicated MySQL user with access only to `dbemployee` and put it in the `EmployeeDb` connection string.
- Do not expose the MySQL port (3306) to the internet. Anyone who can reach the database with the credentials in `EmployeeManagementSystem.exe.config` can read and change all records.
- Keep `EmployeeManagementSystem.exe.config` readable only by the people who run the app, since it holds the database password.
