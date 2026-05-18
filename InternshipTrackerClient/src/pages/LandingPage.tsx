import { FormEvent, useState } from "react";
import { ArrowRight, LogIn, UserPlus } from "lucide-react";
import { Navigate, useNavigate } from "react-router-dom";
import { login, register } from "../lib/api";
import { useAuth } from "../lib/auth";

export function LandingPage() {
  const [mode, setMode] = useState<"login" | "signup">("login");
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("student@uni.edu");
  const [password, setPassword] = useState("student@123");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [error, setError] = useState("");
  const [busy, setBusy] = useState(false);
  const { signIn, token } = useAuth();
  const navigate = useNavigate();

  if (token) {
    return <Navigate to="/internships" replace />;
  }

  async function handleSubmit(event: FormEvent) {
    event.preventDefault();
    setError("");
    setBusy(true);

    try {
      const user =
        mode === "login"
          ? await login(email, password)
          : await register(username, email, password, phoneNumber);
      signIn(user);
      navigate("/internships");
    } catch (err) {
      setError(err instanceof Error ? err.message : "Authentication failed");
    } finally {
      setBusy(false);
    }
  }

  return (
    <div className="grid gap-8 lg:grid-cols-[1.1fr_0.9fr] lg:items-center">
      <section className="space-y-6">
        <div className="inline-flex rounded-full border border-emerald-200 bg-emerald-50 px-3 py-1 text-sm font-medium text-emerald-800">
          Track applications from first click to offer
        </div>
        <div className="space-y-4">
          <h1 className="max-w-3xl text-4xl font-bold leading-tight text-stone-950 sm:text-5xl">
            Internship Tracker
          </h1>
          <p className="max-w-2xl text-lg leading-8 text-stone-600">
            Keep your internship pipeline organized with statuses, notes,
            sources, and deadline signals in one focused workspace.
          </p>
        </div>
        <div className="grid max-w-2xl grid-cols-3 gap-3">
          {["Applied", "Interviewing", "Offer"].map((label) => (
            <div
              key={label}
              className="rounded-lg border border-stone-200 bg-white p-4"
            >
              <div className="text-2xl font-bold text-stone-950">
                {label === "Applied" ? 8 : label === "Interviewing" ? 2 : 1}
              </div>
              <div className="text-sm text-stone-500">{label}</div>
            </div>
          ))}
        </div>
      </section>

      <section className="rounded-lg border border-stone-200 bg-white p-5 shadow-sm">
        <div className="mb-5 grid grid-cols-2 rounded-lg bg-stone-100 p-1">
          <button
            type="button"
            onClick={() => setMode("login")}
            className={`inline-flex items-center justify-center gap-2 rounded-md px-3 py-2 text-sm font-semibold ${mode === "login" ? "bg-white shadow-sm" : "text-stone-600"}`}
          >
            <LogIn size={16} />
            Log in
          </button>
          <button
            type="button"
            onClick={() => setMode("signup")}
            className={`inline-flex items-center justify-center gap-2 rounded-md px-3 py-2 text-sm font-semibold ${mode === "signup" ? "bg-white shadow-sm" : "text-stone-600"}`}
          >
            <UserPlus size={16} />
            Sign up
          </button>
        </div>

        <form className="space-y-4" onSubmit={handleSubmit}>
          {mode === "signup" && (
            <label className="block text-sm font-medium text-stone-700">
              Username
              <input
                className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
                value={username}
                onChange={(event) => setUsername(event.target.value)}
                required
              />
            </label>
          )}
          <label className="block text-sm font-medium text-stone-700">
            Email
            <input
              className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
              type="email"
              value={email}
              onChange={(event) => setEmail(event.target.value)}
              required
            />
          </label>
          {mode === "signup" && (
            <label className="block text-sm font-medium text-stone-700">
              Phone
              <input
                className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
                value={phoneNumber}
                onChange={(event) => setPhoneNumber(event.target.value)}
              />
            </label>
          )}
          <label className="block text-sm font-medium text-stone-700">
            Password
            <input
              className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
              type="password"
              value={password}
              onChange={(event) => setPassword(event.target.value)}
              required
            />
          </label>
          {error && (
            <p className="rounded-md bg-rose-50 px-3 py-2 text-sm text-rose-700">
              {error}
            </p>
          )}
          <button
            className="inline-flex w-full items-center justify-center gap-2 rounded-md bg-emerald-700 px-4 py-3 font-semibold text-white hover:bg-emerald-800"
            disabled={busy}
          >
            {busy
              ? "Working..."
              : mode === "login"
                ? "Log in"
                : "Create account"}
            <ArrowRight size={17} />
          </button>
        </form>
      </section>
    </div>
  );
}
