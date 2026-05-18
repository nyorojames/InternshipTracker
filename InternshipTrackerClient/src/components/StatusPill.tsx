import type { Status } from "../lib/types";

const statusClasses: Record<Status, string> = {
  Applied: "bg-sky-100 text-sky-800 border-sky-200",
  Interviewing: "bg-amber-100 text-amber-900 border-amber-200",
  Offer: "bg-emerald-100 text-emerald-800 border-emerald-200",
  Rejected: "bg-rose-100 text-rose-800 border-rose-200",
};

export function StatusPill({ status }: { status: Status }) {
  return (
    <span
      className={`inline-flex rounded-full border px-2.5 py-1 text-xs font-semibold ${statusClasses[status]}`}
    >
      {status}
    </span>
  );
}
