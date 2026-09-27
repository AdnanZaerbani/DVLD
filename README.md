DVLD System
A desktop application for managing Driver & Vehicle Licensing Department (DVLD) workflows.
Overview
DVLD System is a database-driven desktop application developed using C# and Windows Forms. The system manages people, users, applications, driving tests, test appointments, licenses, and related licensing operations.
The project was developed as a practical application of Object-Oriented Programming, database connectivity, SQL Server, and 3-Tier Architecture.
Features
People and user management
Permission-based access control
Local driving license applications
Driving test appointments
Driving test management and results
License issuance
License renewal and replacement
International license management
License detention and release
Search and filtering
Data validation and business rules
Technologies
C#
.NET Framework 4.7.2
Windows Forms (WinForms)
ADO.NET
Microsoft SQL Server
Visual Studio
3-Tier Architecture
Architecture
The application is organized into three main layers:
Presentation Layer
        ↓
Business Logic Layer
        ↓
Data Access Layer
        ↓
SQL Server Database
Presentation Layer
Contains Windows Forms, UserControls, DataGridViews, menus, and other user-interface components.
Business Logic Layer
Contains business entities, application workflows, validation, and business rules.
Data Access Layer
Handles communication with SQL Server using ADO.NET and parameterized SQL queries.
Database
The application uses Microsoft SQL Server as its relational database.
The database contains related entities for people, users, applications, licenses, tests, appointments, license classes, and other DVLD operations.
Project Structure
DVLD System
│
├── DVLD System - PresentationLayer
├── DVLD System - BusinessLayer
├── DVLD System - DataAccessLayer
└── DVLD System.sln
Purpose
This project was developed to gain practical experience in:
C# and Object-Oriented Programming
Windows Forms development
SQL Server and relational databases
ADO.NET
3-Tier Architecture
Database-driven application development
Business logic and validation
Debugging and problem solving
Author
Adnan Bassam Zaerbani
Software Engineering Student

Syrian Virtual University
GitHub: AdnanZaerbani (https://github.com/AdnanZaerbani)
