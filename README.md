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

## Features

- **Application Tracking**: Manage company names, roles, statuses, and deadlines.
- **Note Management**: Attach detailed notes and feedback to each application.
- **Dashboard**: High-level overview of application progress.
- **Authentication**: Secure JWT-based user authentication.

## License

This project is private and intended for personal use.
