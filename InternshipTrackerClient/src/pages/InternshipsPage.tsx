import { FormEvent, useEffect, useMemo, useState } from "react";
import { Link } from "react-router-dom";
import { ExternalLink, FileText, Pencil, Plus, Trash2 } from "lucide-react";
import {
  createInternship,
  deleteInternship,
  getInternships,
  updateInternship,
} from "../lib/api";
import { useAuth } from "../lib/auth";
import type { Internship, InternshipPayload, Status } from "../lib/types";
import { DeadlineBadge } from "../components/DeadlineBadge";
import { StatusPill } from "../components/StatusPill";

const statuses: Status[] = ["Applied", "Interviewing", "Offer", "Rejected"];

const initialForm: InternshipPayload = {
  companyName: "",
  roleTitle: "",
  status: "Applied",
  jobUrl: "",
  source: "",
  deadline: "",
};

export function InternshipsPage() {
  const { token } = useAuth();
  const [internships, setInternships] = useState<Internship[]>([]);
  const [form, setForm] = useState<InternshipPayload>(initialForm);
  const [editingId, setEditingId] = useState<number | null>(null);
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!token) return;
    getInternships(token)
      .then(setInternships)
      .catch((err) =>
        setError(
          err instanceof Error ? err.message : "Could not load internships",
        ),
      )
      .finally(() => setLoading(false));
  }, [token]);

  const summary = useMemo(
    () =>
      statuses.map((status) => ({
        status,
        count: internships.filter((internship) => internship.status === status)
          .length,
      })),
    [internships],
  );

  async function handleSubmit(event: FormEvent) {
    event.preventDefault();
    if (!token) return;

    const payload = normalizePayload(form);
    const saved = editingId
      ? await updateInternship(editingId, payload, token)
      : await createInternship(payload, token);

    setInternships((current) =>
      editingId
        ? current.map((item) => (item.id === editingId ? saved : item))
        : [saved, ...current],
    );
    setEditingId(null);
    setForm(initialForm);
  }

  async function remove(id: number) {
    if (!token) return;
    await deleteInternship(id, token);
    setInternships((current) => current.filter((item) => item.id !== id));
  }

  function edit(internship: Internship) {
    setEditingId(internship.id);
    setForm({
      companyName: internship.companyName,
      roleTitle: internship.roleTitle,
      status: internship.status,
      jobUrl: internship.jobUrl ?? "",
      source: internship.source ?? "",
      deadline: internship.deadline ? internship.deadline.slice(0, 10) : "",
    });
  }

  return (
    <div className="space-y-6">
      <section className="grid gap-3 sm:grid-cols-4">
        {summary.map(({ status, count }) => (
          <div
            key={status}
            className="rounded-lg border border-stone-200 bg-white p-4"
          >
            <div className="text-3xl font-bold text-stone-950">{count}</div>
            <div className="mt-2">
              <StatusPill status={status} />
            </div>
          </div>
        ))}
      </section>

      <section className="grid gap-6 lg:grid-cols-[360px_1fr]">
        <form
          className="rounded-lg border border-stone-200 bg-white p-5 shadow-sm"
          onSubmit={handleSubmit}
        >
          <div className="mb-4 flex items-center justify-between">
            <h2 className="text-lg font-semibold">
              {editingId ? "Edit internship" : "Add internship"}
            </h2>
            <Plus size={18} className="text-emerald-700" />
          </div>
          <div className="space-y-3">
            <Field
              label="Company"
              value={form.companyName}
              onChange={(value) => setForm({ ...form, companyName: value })}
              required
            />
            <Field
              label="Role"
              value={form.roleTitle}
              onChange={(value) => setForm({ ...form, roleTitle: value })}
              required
            />
            <label className="block text-sm font-medium text-stone-700">
              Status
              <select
                className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
                value={form.status}
                onChange={(event) =>
                  setForm({ ...form, status: event.target.value as Status })
                }
              >
                {statuses.map((status) => (
                  <option key={status}>{status}</option>
                ))}
              </select>
            </label>
            <Field
              label="Source"
              value={form.source ?? ""}
              onChange={(value) => setForm({ ...form, source: value })}
              placeholder="LinkedIn, Kariyer.net, university"
            />
            <Field
              label="Job URL"
              value={form.jobUrl ?? ""}
              onChange={(value) => setForm({ ...form, jobUrl: value })}
              placeholder="https://..."
            />
            <Field
              label="Deadline"
              type="date"
              value={form.deadline ?? ""}
              onChange={(value) => setForm({ ...form, deadline: value })}
            />
          </div>
          <div className="mt-5 flex gap-2">
            <button className="inline-flex flex-1 items-center justify-center gap-2 rounded-md bg-emerald-700 px-4 py-2 font-semibold text-white hover:bg-emerald-800">
              {editingId ? "Save changes" : "Add"}
            </button>
            {editingId && (
              <button
                type="button"
                className="rounded-md border border-stone-300 px-4 py-2"
                onClick={() => {
                  setEditingId(null);
                  setForm(initialForm);
                }}
              >
                Cancel
              </button>
            )}
          </div>
        </form>

        <div className="rounded-lg border border-stone-200 bg-white shadow-sm">
          <div className="border-b border-stone-200 p-5">
            <h1 className="text-2xl font-bold text-stone-950">Internships</h1>
            <p className="mt-1 text-sm text-stone-500">
              Update status, sources, deadlines, and notes as your search
              changes.
            </p>
          </div>
          {error && (
            <p className="m-5 rounded-md bg-rose-50 px-3 py-2 text-sm text-rose-700">
              {error}
            </p>
          )}
          {loading ? (
            <p className="p-5 text-stone-500">Loading...</p>
          ) : internships.length === 0 ? (
            <p className="p-5 text-stone-500">No internships yet.</p>
          ) : (
            <div className="divide-y divide-stone-100">
              {internships.map((internship) => (
                <article
                  key={internship.id}
                  className="grid gap-4 p-5 xl:grid-cols-[1fr_auto]"
                >
                  <div className="min-w-0 space-y-3">
                    <div>
                      <h2 className="truncate text-lg font-semibold text-stone-950">
                        {internship.companyName}
                      </h2>
                      <p className="text-stone-600">{internship.roleTitle}</p>
                    </div>
                    <div className="flex flex-wrap items-center gap-2">
                      <StatusPill status={internship.status} />
                      <DeadlineBadge deadline={internship.deadline} />
                      {internship.source && (
                        <span className="rounded-full bg-stone-100 px-2.5 py-1 text-xs font-semibold text-stone-700">
                          {internship.source}
                        </span>
                      )}
                    </div>
                  </div>
                  <div className="flex flex-wrap items-center gap-2">
                    {internship.jobUrl && (
                      <a
                        className="inline-flex items-center gap-2 rounded-md border border-stone-200 px-3 py-2 text-sm hover:bg-stone-50"
                        href={internship.jobUrl}
                        target="_blank"
                        rel="noreferrer"
                      >
                        <ExternalLink size={16} />
                        Job
                      </a>
                    )}
                    <Link
                      className="inline-flex items-center gap-2 rounded-md border border-stone-200 px-3 py-2 text-sm hover:bg-stone-50"
                      to={`/internships/${internship.id}/notes`}
                    >
                      <FileText size={16} />
                      Notes
                    </Link>
                    <button
                      className="rounded-md border border-stone-200 p-2 hover:bg-stone-50"
                      type="button"
                      onClick={() => edit(internship)}
                      aria-label="Edit internship"
                    >
                      <Pencil size={16} />
                    </button>
                    <button
                      className="rounded-md border border-stone-200 p-2 text-rose-700 hover:bg-rose-50"
                      type="button"
                      onClick={() => remove(internship.id)}
                      aria-label="Delete internship"
                    >
                      <Trash2 size={16} />
                    </button>
                  </div>
                </article>
              ))}
            </div>
          )}
        </div>
      </section>
    </div>
  );
}

function Field({
  label,
  value,
  onChange,
  type = "text",
  required = false,
  placeholder,
}: {
  label: string;
  value: string;
  onChange: (value: string) => void;
  type?: string;
  required?: boolean;
  placeholder?: string;
}) {
  return (
    <label className="block text-sm font-medium text-stone-700">
      {label}
      <input
        className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
        type={type}
        value={value}
        onChange={(event) => onChange(event.target.value)}
        required={required}
        placeholder={placeholder}
      />
    </label>
  );
}

function normalizePayload(form: InternshipPayload): InternshipPayload {
  return {
    companyName: form.companyName,
    roleTitle: form.roleTitle,
    status: form.status,
    jobUrl: form.jobUrl || null,
    source: form.source || null,
    deadline: form.deadline || null,
  };
}
