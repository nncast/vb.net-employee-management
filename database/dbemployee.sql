-- ============================================================================
--  EmployeeManagementSystem — database schema
--  Database: dbemployee   (matches Conn.vb / every form's Connect(...) call)
--  Engine:   InnoDB (required for the foreign keys below)
--
--  This file was reverse-engineered from the app's own CRUD code — every
--  table, column, and constraint here exists because a SELECT/INSERT/UPDATE/
--  DELETE in the VB.NET forms actually reads or writes it. Referenced from:
--    Conn.vb                                   -> Connect(..., "dbemployee", ...)
--    LoginForm.vb                               -> tbllogin
--    Admin/Sections-a/frmEmployee.vb            -> tblemployee, tbllogin,
--                                                   tbldepartment, tblposition,
--                                                   tblemployeehistory
--    Admin/Sections-a/frmDepartment.vb          -> tbldepartment
--    Admin/Sections-a/frmPosition.vb            -> tblposition, tbldepartment
--    Admin/Sections-a/frmAttendance-a.vb        -> tblattendance
--    Admin/Sections-a/frmLeave-a.vb             -> tblleaverequests, tblattendance
--    Admin/Sections-a/frmPayroll.vb             -> tblpayroll
--    Admin/Sections-a/frmHome-a.vb              -> dashboard counts/joins only
--    Admin/frmDashboard-a.vb                    -> tblemployee, tblposition
--    Employee/frmDashboard-e.vb                 -> tblemployee, tblposition
--    Employee/Section-e/frmHome-e.vb            -> tblattendance, tblleaverequests
--    Employee/Section-e/frmLeave-e.vb           -> tblleaverequests
--    Employee/Section-e/frmAttendance-e.vb      -> tblattendance
--    Employee/Section-e/frmProfile.vb           -> tbllogin
--
--  Import this before running the app (SQLYog / phpMyAdmin / mysql CLI):
--      mysql -u root -p < dbemployee.sql
-- ============================================================================

CREATE DATABASE IF NOT EXISTS dbemployee
  CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

USE dbemployee;

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- tbldepartment
--   Read/written by frmDepartment.vb (full CRUD) and used as a lookup by
--   frmEmployee.vb, frmPosition.vb, frmPayroll.vb, frmAttendance-a.vb,
--   frmHome-a.vb.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tbldepartment;
CREATE TABLE tbldepartment (
  id        INT UNSIGNED NOT NULL AUTO_INCREMENT,
  deptname  VARCHAR(100) NOT NULL,
  PRIMARY KEY (id),
  UNIQUE KEY uq_department_name (deptname)
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblposition
--   Read/written by frmPosition.vb (full CRUD). departmentid drives
--   frmEmployee.vb's cascading dept -> position combo boxes.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblposition;
CREATE TABLE tblposition (
  id             INT UNSIGNED NOT NULL AUTO_INCREMENT,
  positiontitle  VARCHAR(100) NOT NULL,
  departmentid   INT UNSIGNED NOT NULL,
  PRIMARY KEY (id),
  KEY idx_position_department (departmentid),
  CONSTRAINT fk_position_department
    FOREIGN KEY (departmentid) REFERENCES tbldepartment (id)
    ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblemployee
--   Core record, full CRUD in frmEmployee.vb. sex/maritalstatus values come
--   straight from that form's combo boxes (cmbsex: Male/Female;
--   cmbmaritalstatus: Single/Married/Widowed).
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblemployee;
CREATE TABLE tblemployee (
  id             INT UNSIGNED NOT NULL AUTO_INCREMENT,
  firstname      VARCHAR(50)  NOT NULL,
  lastname       VARCHAR(50)  NOT NULL,
  sex            ENUM('Male', 'Female') NOT NULL,
  maritalstatus  ENUM('Single', 'Married', 'Widowed') NOT NULL,
  dob            DATE NOT NULL,
  positionid     INT UNSIGNED NOT NULL,
  departmentid   INT UNSIGNED NOT NULL,
  salary         DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (id),
  KEY idx_employee_position (positionid),
  KEY idx_employee_department (departmentid),
  CONSTRAINT fk_employee_position
    FOREIGN KEY (positionid) REFERENCES tblposition (id)
    ON DELETE RESTRICT ON UPDATE CASCADE,
  CONSTRAINT fk_employee_department
    FOREIGN KEY (departmentid) REFERENCES tbldepartment (id)
    ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tbllogin
--   One login per employee (LoginForm.vb, frmEmployee.vb, frmProfile.vb).
--   employeeid is the primary key itself — the app never selects a separate
--   login id, only ever looks rows up by employeeid or username.
--
--   NOTE: passwords are stored and compared as plain text throughout the app
--   (Conn.vb defines Encrypt/Decrypt helpers, but nothing in the codebase
--   actually calls them). Schema mirrors that as-is; hashing the password
--   properly would need app-code changes too, not just the column type.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tbllogin;
CREATE TABLE tbllogin (
  employeeid  INT UNSIGNED NOT NULL,
  username    VARCHAR(50)  NOT NULL,
  password    VARCHAR(255) NOT NULL,
  role        ENUM('Admin', 'Employee') NOT NULL,
  PRIMARY KEY (employeeid),
  UNIQUE KEY uq_login_username (username),
  CONSTRAINT fk_login_employee
    FOREIGN KEY (employeeid) REFERENCES tblemployee (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblemployeehistory
--   Written whenever frmEmployee.vb adds an employee (old*=NULL) or changes
--   an employee's position/department (old* = previous values). Read by
--   frmHome-a.vb's "Recent Activity" list.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblemployeehistory;
CREATE TABLE tblemployeehistory (
  id                INT UNSIGNED NOT NULL AUTO_INCREMENT,
  employeeid        INT UNSIGNED NOT NULL,
  oldpositionid     INT UNSIGNED NULL,
  olddepartmentid   INT UNSIGNED NULL,
  newpositionid     INT UNSIGNED NULL,
  newdepartmentid   INT UNSIGNED NULL,
  datechanged       DATE NOT NULL,
  PRIMARY KEY (id),
  KEY idx_history_employee (employeeid),
  KEY idx_history_datechanged (datechanged),
  CONSTRAINT fk_history_employee
    FOREIGN KEY (employeeid) REFERENCES tblemployee (id)
    ON DELETE CASCADE ON UPDATE CASCADE,
  -- old/new position & department are SET NULL on delete (not RESTRICT) so a
  -- position/department can still be retired later without being blocked
  -- forever just because it appears in old audit history.
  CONSTRAINT fk_history_oldposition
    FOREIGN KEY (oldpositionid) REFERENCES tblposition (id)
    ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT fk_history_olddepartment
    FOREIGN KEY (olddepartmentid) REFERENCES tbldepartment (id)
    ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT fk_history_newposition
    FOREIGN KEY (newpositionid) REFERENCES tblposition (id)
    ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT fk_history_newdepartment
    FOREIGN KEY (newdepartmentid) REFERENCES tbldepartment (id)
    ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblattendance
--   Full CRUD in frmAttendance-a.vb (admin) and read-only in
--   frmAttendance-e.vb / frmHome-e.vb (employee). Also written automatically
--   by frmLeave-a.vb's approve action ('On Leave' rows, one per day of an
--   approved leave request).
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblattendance;
CREATE TABLE tblattendance (
  id          INT UNSIGNED NOT NULL AUTO_INCREMENT,
  employeeid  INT UNSIGNED NOT NULL,
  date        DATE NOT NULL,
  status      ENUM('Present', 'Absent', 'Late', 'On Leave') NOT NULL,
  timein      TIME NOT NULL DEFAULT '00:00:00',
  timeout     TIME NOT NULL DEFAULT '00:00:00',
  PRIMARY KEY (id),
  -- frmAttendance-a.vb checks for an existing (employeeid, date) row itself
  -- before inserting; this is the DB-level backstop for that same rule.
  UNIQUE KEY uq_attendance_employee_date (employeeid, date),
  KEY idx_attendance_date (date),
  CONSTRAINT fk_attendance_employee
    FOREIGN KEY (employeeid) REFERENCES tblemployee (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblleaverequests
--   Created by the employee in frmLeave-e.vb, approved/rejected by the admin
--   in frmLeave-a.vb (which also generates the matching tblattendance rows).
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblleaverequests;
CREATE TABLE tblleaverequests (
  id          INT UNSIGNED NOT NULL AUTO_INCREMENT,
  employeeid  INT UNSIGNED NOT NULL,
  datefrom    DATE NOT NULL,
  dateto      DATE NOT NULL,
  reason      VARCHAR(255) NOT NULL,
  status      ENUM('Pending', 'Approved', 'Rejected') NOT NULL DEFAULT 'Pending',
  PRIMARY KEY (id),
  KEY idx_leave_employee (employeeid),
  KEY idx_leave_status (status),
  CONSTRAINT fk_leave_employee
    FOREIGN KEY (employeeid) REFERENCES tblemployee (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

-- ----------------------------------------------------------------------------
-- tblpayroll
--   Full CRUD in frmPayroll.vb. Salary itself lives on tblemployee and is
--   joined in, not duplicated here — only the per-payslip figures are
--   stored.
-- ----------------------------------------------------------------------------
DROP TABLE IF EXISTS tblpayroll;
CREATE TABLE tblpayroll (
  id           INT UNSIGNED NOT NULL AUTO_INCREMENT,
  employeeid   INT UNSIGNED NOT NULL,
  paymentdate  DATE NOT NULL,
  allowance    DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
  tax          DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
  netsalary    DECIMAL(12, 2) NOT NULL DEFAULT 0.00,
  PRIMARY KEY (id),
  KEY idx_payroll_employee (employeeid),
  KEY idx_payroll_paymentdate (paymentdate),
  CONSTRAINT fk_payroll_employee
    FOREIGN KEY (employeeid) REFERENCES tblemployee (id)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

SET FOREIGN_KEY_CHECKS = 1;

-- ============================================================================
--  Seed data — enough to log in and use the app on a fresh install.
--  Without at least one tbllogin row, LoginForm.vb has no way to authenticate
--  anyone (there's no self-registration screen anywhere in the app).
--  Login: username "admin", password "admin123" (plain text — see tbllogin
--  note above). Change it from the Employee > Profile screen after first login.
-- ============================================================================

INSERT INTO tbldepartment (deptname) VALUES
  ('Administration'),
  ('Human Resources');

INSERT INTO tblposition (positiontitle, departmentid) VALUES
  ('System Administrator', 1),
  ('HR Officer', 2);

INSERT INTO tblemployee (firstname, lastname, sex, maritalstatus, dob, positionid, departmentid, salary) VALUES
  ('System', 'Administrator', 'Male', 'Single', '2000-01-01', 1, 1, 30000.00);

INSERT INTO tbllogin (employeeid, username, password, role) VALUES
  (LAST_INSERT_ID(), 'admin', 'admin123', 'Admin');
