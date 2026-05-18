import { FormEvent, useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { ArrowLeft, Plus } from "lucide-react";
import { createNote, getInternship, getNotes } from "../lib/api";
import { useAuth } from "../lib/auth";
import type { Internship, Note } from "../lib/types";
import { StatusPill } from "../components/StatusPill";
import { DeadlineBadge } from "../components/DeadlineBadge";

export function NotesPage() {
  const { id } = useParams();
  const internshipId = Number(id);
  const { token } = useAuth();
  const [internship, setInternship] = useState<Internship | null>(null);
  const [notes, setNotes] = useState<Note[]>([]);
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");
  const [error, setError] = useState("");

  useEffect(() => {
    if (!token || Number.isNaN(internshipId)) return;
    Promise.all([
      getInternship(internshipId, token),
      getNotes(internshipId, token),
    ])
      .then(([nextInternship, nextNotes]) => {
        setInternship(nextInternship);
        setNotes(nextNotes);
      })
      .catch((err) =>
        setError(err instanceof Error ? err.message : "Could not load notes"),
      );
  }, [internshipId, token]);

  async function handleSubmit(event: FormEvent) {
    event.preventDefault();
    if (!token) return;

    const note = await createNote(internshipId, title, content, token);
    setNotes((current) => [note, ...current]);
    setTitle("");
    setContent("");
  }

  return (
    <div className="space-y-6">
      <Link
        to="/internships"
        className="inline-flex items-center gap-2 text-sm font-semibold text-stone-600 hover:text-stone-950"
      >
        <ArrowLeft size={16} />
        Back to internships
      </Link>

      {internship && (
        <section className="rounded-lg border border-stone-200 bg-white p-5 shadow-sm">
          <div className="flex flex-wrap items-start justify-between gap-4">
            <div>
              <h1 className="text-2xl font-bold text-stone-950">
                {internship.companyName}
              </h1>
              <p className="text-stone-600">{internship.roleTitle}</p>
            </div>
            <div className="flex flex-wrap gap-2">
              <StatusPill status={internship.status} />
              <DeadlineBadge deadline={internship.deadline} />
            </div>
          </div>
        </section>
      )}

      <section className="grid gap-6 lg:grid-cols-[360px_1fr]">
        <form
          className="rounded-lg border border-stone-200 bg-white p-5 shadow-sm"
          onSubmit={handleSubmit}
        >
          <div className="mb-4 flex items-center justify-between">
            <h2 className="text-lg font-semibold">Add note</h2>
            <Plus size={18} className="text-emerald-700" />
          </div>
          <label className="block text-sm font-medium text-stone-700">
            Title
            <input
              className="mt-1 w-full rounded-md border border-stone-300 px-3 py-2"
              value={title}
              onChange={(event) => setTitle(event.target.value)}
              required
            />
          </label>
          <label className="mt-3 block text-sm font-medium text-stone-700">
            Content
            <textarea
              className="mt-1 min-h-36 w-full rounded-md border border-stone-300 px-3 py-2"
              value={content}
              onChange={(event) => setContent(event.target.value)}
              required
            />
          </label>
          <button className="mt-4 inline-flex w-full items-center justify-center rounded-md bg-emerald-700 px-4 py-2 font-semibold text-white hover:bg-emerald-800">
            Save note
          </button>
        </form>

        <div className="rounded-lg border border-stone-200 bg-white shadow-sm">
          <div className="border-b border-stone-200 p-5">
            <h2 className="text-xl font-bold text-stone-950">Notes</h2>
          </div>
          {error && (
            <p className="m-5 rounded-md bg-rose-50 px-3 py-2 text-sm text-rose-700">
              {error}
            </p>
          )}
          {notes.length === 0 ? (
            <p className="p-5 text-stone-500">
              No notes for this internship yet.
            </p>
          ) : (
            <div className="divide-y divide-stone-100">
              {notes.map((note) => (
                <article key={note.id} className="p-5">
                  <div className="flex flex-wrap items-baseline justify-between gap-3">
                    <h3 className="font-semibold text-stone-950">
                      {note.title}
                    </h3>
                    <time className="text-sm text-stone-500">
                      {new Date(note.dateCreated).toLocaleDateString()}
                    </time>
                  </div>
                  <p className="mt-2 whitespace-pre-wrap leading-7 text-stone-700">
                    {note.content}
                  </p>
                </article>
              ))}
            </div>
          )}
        </div>
      </section>
    </div>
  );
}
