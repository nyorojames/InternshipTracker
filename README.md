# 🚀 Internship Application Tracker API

A robust, secure **RESTful Web API** built with **.NET 8** to help students track their internship applications, interview stages, and recruiter feedback. 

This project demonstrates **Clean Architecture**, **JWT Authentication**, and **Data Security**.

---

## 🏗️ Architecture & Design
This API follows a layered architecture to ensure separation of concerns and maintainability:
* **Controller Layer:** Handles HTTP requests and input validation.
* **Service Layer:** Contains business logic and DTO mapping.
* **Repository Layer:** Abstraction over Entity Framework Core for data access.
* **Database:** Sqlite with One-to-Many relationships (User → Internships → Notes).

### Database Schema
* **Users:** Secure identity management with hashed passwords.
* **Internships:** Main entity tracking company, role, and status (Enum).
* **Notes:** Sub-resource for tracking interview feedback and specific updates per application.

---

## 🛠️ Tech Stack
* **Framework:** ASP.NET Core 8.0 (Web API)
* **Language:** C#
* **Database:** MS Sqlite / Entity Framework Core
* **Authentication:** JWT (JSON Web Tokens)
* **Security:** BCrypt.Net for password hashing
* **Documentation:** Swagger / OpenAPI

---

## ⚡ Key Features
* **🔐 Secure Authentication:** Full Registration & Login flow using JWT Bearer tokens. Passwords are never stored in plain text (BCrypt hashing).
* **🛡️ Multi-Tenancy (Data Privacy):** Users can strictly access *only* their own data. A middleware-enforced `UserId` check ensures data isolation.
* **📄 CRUD Operations:** Complete management of Internship Applications and related Notes.
* **📝 Repository Pattern:** Decoupled data access logic for better testing and cleaner code.
* **🔄 DTOs (Data Transfer Objects):** Prevents over-exposure of internal database entities to the public API.

---

## 🚀 Getting Started

### Prerequisites
* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* SQL Server (LocalDB is fine)

### Clone the Repository
```bash
https://github.com/nyorojames/InternshipTrackerAPI.git
```

<img width="1341" height="631" alt="Screenshot 2026-01-31 100526" src="https://github.com/user-attachments/assets/bbdb0fc5-54a2-4e5a-baec-fbde5478a714" />
