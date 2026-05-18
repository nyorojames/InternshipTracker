import { createContext, ReactNode, useContext, useMemo, useState } from "react";
import type { User } from "./types";

type AuthContextValue = {
  user: User | null;
  token: string | null;
  signIn: (user: User) => void;
  signOut: () => void;
};

const AuthContext = createContext<AuthContextValue | undefined>(undefined);
const storageKey = "internship-tracker-user";

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<User | null>(() => {
    const stored = localStorage.getItem(storageKey);
    return stored ? (JSON.parse(stored) as User) : null;
  });

  const value = useMemo<AuthContextValue>(
    () => ({
      user,
      token: user?.token ?? null,
      signIn: (nextUser) => {
        localStorage.setItem(storageKey, JSON.stringify(nextUser));
        setUser(nextUser);
      },
      signOut: () => {
        localStorage.removeItem(storageKey);
        setUser(null);
      },
    }),
    [user],
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}

export function useAuth() {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within AuthProvider");
  }
  return context;
}
