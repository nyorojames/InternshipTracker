# InternshipTracker Client

[![React](https://img.shields.io/badge/React-18-61dafb?logo=react)](https://reactjs.org/)
[![TypeScript](https://img.shields.io/badge/TypeScript-5-3178c6?logo=typescript)](https://www.typescriptlang.org/)
[![Vite](https://img.shields.io/badge/Vite-5-646cff?logo=vite)](https://vitejs.dev/)
[![Tailwind CSS](https://img.shields.io/badge/Tailwind--CSS-3.4-38bdf8?logo=tailwind-css)](https://tailwindcss.com/)

A modern, focused web application to help students track their internship applications, manage statuses, and keep detailed notes throughout their search process.

[← Back to Root README](../README.md)

## 🚀 Features

- **📊 Dashboard Overview**: Quick summary of application counts by status (Applied, Interviewing, Offer, Rejected).
- **📝 Application Management**: Add, edit, and delete internship applications with details like company name, role, status, source, job URL, and deadline.
- **🚨 Visual Signals**: Status-coded pills and deadline badges for at-a-glance tracking.
- **📓 Notes System**: Keep specific notes for each internship application to track interview feedback or research.
- **🔐 Authentication**: Secure login and registration system with JWT-based session persistence.

## 🛠️ Tech Stack

- **Framework**: [React 18](https://reactjs.org/)
- **Language**: [TypeScript](https://www.typescriptlang.org/)
- **Build Tool**: [Vite](https://vitejs.dev/)
- **Styling**: [Tailwind CSS](https://tailwindcss.com/)
- **Icons**: [Lucide React](https://lucide.dev/)
- **Routing**: [React Router 6](https://reactrouter.com/)

## 📦 Getting Started

### Prerequisites

- [Node.js](https://nodejs.org/) (v18 or higher recommended)
- [npm](https://www.npmjs.com/)

### Installation

1. **Install dependencies**:
   ```bash
   npm install
   ```

2. **Configure environment (Optional)**:
   Create a `.env` file in the root of this folder to override the default API URL:
   ```env
   VITE_API_BASE_URL=http://localhost:5067/api
   ```

3. **Start the development server**:
   ```bash
   npm run dev
   ```

The application will be available at `http://localhost:5173`.

## 📂 Project Structure

- `src/components/`: Reusable UI components (badges, pills, layout).
- `src/lib/`: Core logic, including API services and authentication context.
- `src/pages/`: Main application views (Dashboard, Notes, Landing).
- `src/App.tsx`: Main routing configuration.
- `src/main.tsx`: Application entry point.

## 🏗️ Build

To create a production build:

```bash
npm run build
```

The optimized output will be in the `dist/` directory.
