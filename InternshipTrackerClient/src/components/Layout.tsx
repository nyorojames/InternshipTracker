import { BriefcaseBusiness, LogOut } from "lucide-react";
import { Link, NavLink, Outlet, useNavigate } from "react-router-dom";
import { useAuth } from "../lib/auth";

export function Layout() {
  const { user, signOut } = useAuth();
  const navigate = useNavigate();

  return (
    <div className="min-h-screen bg-[#f6f5f1] text-stone-900">
      <header className="border-b border-stone-200 bg-white">
        <div className="mx-auto flex max-w-6xl items-center justify-between px-4 py-4">
          <Link
            to={user ? "/internships" : "/"}
            className="flex items-center gap-2 font-semibold"
          >
            <span className="grid h-9 w-9 place-items-center rounded-lg bg-emerald-700 text-white">
              <BriefcaseBusiness size={19} />
            </span>
            Internship Tracker
          </Link>
          {user && (
            <nav className="flex items-center gap-3 text-sm">
              <NavLink
                to="/internships"
                className={({ isActive }) =>
                  `rounded-md px-3 py-2 ${isActive ? "bg-stone-900 text-white" : "text-stone-600 hover:bg-stone-100"}`
                }
              >
                Internships
              </NavLink>
              <button
                type="button"
                onClick={() => {
                  signOut();
                  navigate("/");
                }}
                className="inline-flex items-center gap-2 rounded-md border border-stone-200 px-3 py-2 text-stone-700 hover:bg-stone-100"
              >
                <LogOut size={16} />
                Sign out
              </button>
            </nav>
          )}
        </div>
      </header>
      <main className="mx-auto max-w-6xl px-4 py-8">
        <Outlet />
      </main>
    </div>
  );
}
