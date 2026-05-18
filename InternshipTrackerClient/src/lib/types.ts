export type Status = "Applied" | "Interviewing" | "Rejected" | "Offer";

export type Internship = {
  id: number;
  companyName: string;
  roleTitle: string;
  status: Status;
  dateApplied: string;
  jobUrl?: string | null;
  source?: string | null;
  deadline?: string | null;
};

export type InternshipPayload = {
  companyName: string;
  roleTitle: string;
  status: Status;
  jobUrl?: string | null;
  source?: string | null;
  deadline?: string | null;
};

export type Note = {
  id: number;
  internshipId: number;
  title: string;
  content: string;
  dateCreated: string;
};

export type User = {
  id: number;
  username: string;
  email: string;
  token: string;
};
