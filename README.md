# Internship Application Tracker API

A RESTful ASP.NET Core 8 Web API for tracking internship applications and notes.

## Architecture

The project uses a layered structure:

- Controllers handle HTTP requests and responses.
- Services contain business logic and DTO mapping.
- Repositories isolate Entity Framework Core data access.
- SQLite stores users, internships, and notes.

## Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core 8
- SQLite
- JWT bearer authentication
- BCrypt password hashing
- Swagger / OpenAPI

## Main Entities

- `User`: account profile and password hash.
- `Internship`: company, role, status, job URL, application date, and owning user.
- `Note`: updates or feedback attached to an internship.

The relationship is:

```text
User -> Internships -> Notes
```

## API Endpoints

```http
POST /api/auth/register
POST /api/auth/login

GET  /api/internships
GET  /api/internships/{id}
POST /api/internships

GET  /api/notes/internship/{internshipId}
POST /api/notes
```

Protected endpoints require:

```http
Authorization: Bearer {token}
```

## Demo User

The seed data includes a demo user:

```text
Email: student@uni.edu
Password: student@123
```

## Running Locally

Prerequisites:

- .NET 8 SDK

From the solution root:

```bash
dotnet restore
dotnet ef database update --project InternshipTrackerAPI
dotnet run --project InternshipTrackerAPI
```

Swagger is available in development mode at:

```text
https://localhost:{port}/swagger
```
