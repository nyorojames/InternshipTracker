# InternshipTracker

A comprehensive solution for tracking and managing internship applications, consisting of a .NET Web API backend and a React frontend.

## Project Structure

- **InternshipTrackerAPI/**: .NET 8.0 Web API using Entity Framework Core and SQLite.
- **InternshipTrackerClient/**: React frontend built with TypeScript, Vite, and Tailwind CSS.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or higher)
- [npm](https://www.npmjs.com/)

### Quick Start

1. **Backend Setup:**
   ```bash
   cd InternshipTrackerAPI
   dotnet ef database update
   dotnet run
   ```
   The API will be available at `http://localhost:5067`.

2. **Frontend Setup:**
   ```bash
   cd InternshipTrackerClient
   npm install
   npm run dev
   ```
   The frontend will be available at `http://localhost:5173`.

## Documentation

- [Backend README](InternshipTrackerAPI/README.md)
- [Frontend README](InternshipTrackerClient/README.md)

## Deployment

Deploy this repository as two separate services.

### Backend: Railway

Create a Railway service from this repository and set the root directory to:

```text
InternshipTrackerAPI
```

Required Railway variables:

```text
ASPNETCORE_ENVIRONMENT=Production
Jwt__Key=<long-random-secret-at-least-32-characters>
ConnectionStrings__DefaultConnection=Data Source=/data/InternshipTrackerDB.sqlite
Cors__AllowedOrigins__0=https://your-vercel-app.vercel.app
```

If you keep SQLite for the demo database, attach a Railway volume mounted at `/data`.
The API applies EF Core migrations automatically at startup.

### Frontend: Vercel

Create a Vercel project from this repository and set the root directory to:

```text
InternshipTrackerClient
```

Use the default Vite settings:

```text
Build command: npm run build
Output directory: dist
Install command: npm install
```

Required Vercel variable:

```text
VITE_API_BASE_URL=https://your-railway-api.up.railway.app/api
```

## Features

- **Application Tracking**: Manage company names, roles, statuses, and deadlines.
- **Note Management**: Attach detailed notes and feedback to each application.
- **Dashboard**: High-level overview of application progress.
- **Authentication**: Secure JWT-based user authentication.

## License

This project is private and intended for personal use.
