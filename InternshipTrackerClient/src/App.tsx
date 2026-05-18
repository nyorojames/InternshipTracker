import { Navigate, Route, Routes } from 'react-router-dom';
import { Layout } from './components/Layout';
import { ProtectedRoute } from './components/ProtectedRoute';
import { InternshipsPage } from './pages/InternshipsPage';
import { LandingPage } from './pages/LandingPage';
import { NotesPage } from './pages/NotesPage';

export function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route path="/" element={<LandingPage />} />
        <Route element={<ProtectedRoute />}>
          <Route path="/internships" element={<InternshipsPage />} />
          <Route path="/internships/:id/notes" element={<NotesPage />} />
        </Route>
        <Route path="*" element={<Navigate to="/" replace />} />
      </Route>
    </Routes>
  );
}
