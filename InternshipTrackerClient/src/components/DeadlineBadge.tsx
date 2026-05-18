export function DeadlineBadge({ deadline }: { deadline?: string | null }) {
  if (!deadline) {
    return <span className="text-sm text-stone-400">No deadline</span>;
  }

  const today = new Date();
  today.setHours(0, 0, 0, 0);
  const due = new Date(deadline);
  due.setHours(0, 0, 0, 0);
  const days = Math.ceil((due.getTime() - today.getTime()) / 86_400_000);
  const label = due.toLocaleDateString();

  if (days < 0) {
    return (
      <span className="rounded-full bg-rose-100 px-2.5 py-1 text-xs font-semibold text-rose-800">
        Passed {label}
      </span>
    );
  }

  if (days <= 7) {
    return (
      <span className="rounded-full bg-amber-100 px-2.5 py-1 text-xs font-semibold text-amber-900">
        Due {days === 0 ? "today" : `in ${days}d`}
      </span>
    );
  }

  return <span className="text-sm text-stone-600">{label}</span>;
}
