# InternshipTracker API

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![SQLite](https://img.shields.io/badge/SQLite-3-003b57?logo=sqlite)](https://www.sqlite.org/index.html)

A RESTful ASP.NET Core 8 Web API providing the backend services for the InternshipTracker application. It manages user authentication, internship applications, and associated notes.

[← Back to Root README](../README.md)

## 🏗️ Architecture

The API follows a layered architectural pattern:

- **Controllers**: Handle HTTP requests, manage routing, and return appropriate status codes.
- **Services**: Implement business logic, handle DTO mapping, and orchestrate repository calls.
- **Repositories**: Encapsulate data access logic using Entity Framework Core.
- **Data Transfer Objects (DTOs)**: Define the contract for data exchanged between the client and server.
- **Models**: Represent the database schema and core domain entities.

## 🛠️ Tech Stack

- **ASP.NET Core 8**: High-performance web framework.
- **Entity Framework Core 8**: Modern object-database mapper.
- **SQLite**: Lightweight, file-based relational database.
- **JWT Bearer Authentication**: Secure, stateless session management.
- **BCrypt.Net-Next**: Strong password hashing.
- **Swashbuckle (Swagger)**: API documentation and interactive testing.

## 🗄️ Database Schema

- **User**: Stores profile information and credentials.
- **Internship**: Tracks company, role, status, source, job URL, and deadlines.
- **Note**: Stores updates and feedback linked to specific internships.

Relationship: `User` (1) → (N) `Internship` (1) → (N) `Note`

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Running Locally

1. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

2. **Apply migrations**:
   ```bash
   dotnet ef database update
   ```

3. **Start the API**:
   ```bash
   dotnet run
   ```

The API will be accessible at `http://localhost:5067`. Swagger UI is available at `http://localhost:5067/swagger` in Development mode.

## 🔐 Authentication

Most endpoints require a JWT token in the Authorization header:
`Authorization: Bearer {your_token}`

### Demo Credentials
- **Email**: `student@uni.edu`
- **Password**: `student@123`
