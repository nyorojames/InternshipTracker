import type { Internship, InternshipPayload, Note, User } from "./types";

const API_BASE_URL =
  import.meta.env.VITE_API_BASE_URL ?? "http://localhost:5067/api";

type ApiOptions = RequestInit & {
  token?: string;
};

async function apiRequest<T>(
  path: string,
  options: ApiOptions = {},
): Promise<T> {
  const headers = new Headers(options.headers);
  headers.set("Content-Type", "application/json");

  if (options.token) {
    headers.set("Authorization", `Bearer ${options.token}`);
  }

  const response = await fetch(`${API_BASE_URL}${path}`, {
    ...options,
    headers,
  });

  if (response.status === 204) {
    return undefined as T;
  }

  const text = await response.text();
  const data = text ? JSON.parse(text) : undefined;

  if (!response.ok) {
    throw new Error(typeof data === "string" ? data : "Request failed");
  }

  return data as T;
}

export function login(email: string, password: string) {
  return apiRequest<User>("/Auth/login", {
    method: "POST",
    body: JSON.stringify({ email, password }),
  });
}

export function register(
  username: string,
  email: string,
  password: string,
  phoneNumber: string,
) {
  return apiRequest<User>("/Auth/register", {
    method: "POST",
    body: JSON.stringify({ username, email, password, phoneNumber }),
  });
}

export function getInternships(token: string) {
  return apiRequest<Internship[]>("/Internships", { token });
}

export function getInternship(id: number, token: string) {
  return apiRequest<Internship>(`/Internships/${id}`, { token });
}

export function createInternship(payload: InternshipPayload, token: string) {
  return apiRequest<Internship>("/Internships", {
    method: "POST",
    body: JSON.stringify(payload),
    token,
  });
}

export function updateInternship(
  id: number,
  payload: InternshipPayload,
  token: string,
) {
  return apiRequest<Internship>(`/Internships/${id}`, {
    method: "PUT",
    body: JSON.stringify(payload),
    token,
  });
}

export function deleteInternship(id: number, token: string) {
  return apiRequest<void>(`/Internships/${id}`, {
    method: "DELETE",
    token,
  });
}

export function getNotes(internshipId: number, token: string) {
  return apiRequest<Note[]>(`/Notes/internship/${internshipId}`, { token });
}

export function createNote(
  internshipId: number,
  title: string,
  content: string,
  token: string,
) {
  return apiRequest<Note>("/Notes", {
    method: "POST",
    body: JSON.stringify({ internshipId, title, content }),
    token,
  });
}
