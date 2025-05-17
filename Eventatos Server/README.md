# Eventatos - Backend API

This is the backend API for **Eventatos**, a full-stack event booking system built with ASP.NET Core.  
It handles authentication, role-based access, event management, and user bookings.

---

## 📦 Tech Stack

- ASP.NET Core 8 / .NET 8
- Entity Framework Core
- SQL Server
- JWT Authentication
- Role-based Authorization
- RESTful API

---

## ⚙️ Setup Instructions

### 1. Clone the repository

### 2. Configure the database connection

Open appsettings.json and update the connection string:
```
"ConnectionStrings": {
  "Default": "Server=localhost;Database=EventatosDB;Trusted_Connection=True;"
}
```
Use Trusted_Connection=True; for Windows Auth, or set User ID=...;Password=...; for SQL login.

### 3. Configure JWT Settings

Inside appsettings.json:

```
"Jwt": {
  "Key": "eventatos_secret_superlong_more_than_16_chars_key",
  "Issuer": "Eventatos",
  "Audience": "Eventatos"
}
```
Make sure the Key is long and consistent across the app.

### 4. Run Migrations & Seed Roles

In the terminal:
 
dotnet ef database update

or in the package manager console:

update-database

### 5. Run the server
In the terminal:
dotnet run

The server should start on port: 

https://localhost:7243

or 

http://localhost:5281



# 📝 Note from the Developer

This project was developed during a very busy academic period — overlapping with practical exams, final project submissions, and discussions.
Because of that, testing and polishing were limited, and some features like image upload are not implemented.

However, I’ve focused on building a solid backend foundation with working authentication, authorization, event management, and role-based access. I would truly appreciate your consideration of the implementation quality and the context above.

Thank you for reviewing my submission. Your feedback means a lot.