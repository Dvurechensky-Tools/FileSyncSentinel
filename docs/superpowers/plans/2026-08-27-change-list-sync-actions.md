# Change List Sync Actions Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add deleted-file analytics, visible-list bulk apply, colored change rows, file search, and path exclusions to FileSync Sentinel.

**Architecture:** Keep the existing WinForms MVC shape. `MergeFolderService` owns filesystem comparison and sync actions, `MainPresenter` coordinates operations, and `MainForm` owns local filtering/display state.

**Tech Stack:** .NET 8 WinForms, existing console regression runner in `FileSyncSentinel.Tests`, existing `DataGridView` UI.

## Global Constraints

- Preserve existing `PathIn` as the reference/target folder and `PathOut` as the observed/source folder.
- Do not add new NuGet dependencies.
- Use relative paths as the stable identity for changed files.
- Filtering and exclusions affect the visible list and bulk apply from the UI.

---

### Task 1: Model Deleted, Added, and Modified Files

**Files:**
- Modify: `FileSyncSentinel/Components/Merge/MergeItem.cs`
- Modify: `FileSyncSentinel/Services/Merge/Implements/MergeFolderService.cs`
- Modify: `FileSyncSentinel.Tests/Program.cs`

**Interfaces:**
- Produces: `MergeChangeType` enum with `Added`, `Modified`, `Deleted`.
- Produces: `MergeItem.ChangeType`, `MergeItem.IsNew`, and `MergeItem.IsDeleted`.

- [ ] Write failing tests for deleted-file discovery and modified-file classification.
- [ ] Run `dotnet run --project FileSyncSentinel.Tests/FileSyncSentinel.Tests.csproj` and confirm the new tests fail.
- [ ] Add `MergeChangeType` and update `LookChangesFiles()` to scan both `OutFiles` and `InFiles`.
- [ ] Run the same test command and confirm it passes.

### Task 2: Apply Single and Visible Bulk Changes

**Files:**
- Modify: `FileSyncSentinel/Services/Merge/IMergeService.cs`
- Modify: `FileSyncSentinel/Services/Merge/Implements/MergeFolderService.cs`
- Modify: `FileSyncSentinel/Presenter/MainPresenter.cs`
- Modify: `FileSyncSentinel.Tests/Program.cs`

**Interfaces:**
- Produces: `bool ApplyChange(MergeItem item)`.
- Produces: `int ApplyChanges(IEnumerable<MergeItem> items)`.

- [ ] Write failing tests showing `ApplyChange()` deletes an `In` file for a deleted item and applies mixed add/modify/delete lists.
- [ ] Run `dotnet run --project FileSyncSentinel.Tests/FileSyncSentinel.Tests.csproj` and confirm the new tests fail.
- [ ] Implement `ApplyChange()` and `ApplyChanges()` in the service, then route presenter single and bulk actions through them.
- [ ] Run the same test command and confirm it passes.

### Task 3: Search, Exclusions, and Colored Rows

**Files:**
- Modify: `FileSyncSentinel/Views/MainForm.Designer.cs`
- Modify: `FileSyncSentinel/Views/MainForm.cs`

**Interfaces:**
- Consumes: `MergeItem.ChangeType`, `MergeItem.IsDeleted`.
- Produces: local visible list filtering by search text and semicolon/newline/comma-separated exclusions.

- [ ] Add a top filter panel with search textbox and exclusions textbox.
- [ ] Store the latest full change list in the form and bind only visible filtered rows to the grid.
- [ ] Make row colors green for added files, yellow for modified files, and red for deleted files.
- [ ] Disable unavailable actions for deleted rows where opening or diffing the missing `Out` file would fail.
- [ ] Make the existing “Применить все” menu item apply the currently visible rows.

### Task 4: Verification

**Files:**
- No production edits unless verification reveals a defect.

- [ ] Run `dotnet run --project FileSyncSentinel.Tests/FileSyncSentinel.Tests.csproj`.
- [ ] Run `dotnet build FileSyncSentinel.sln -v:m`.
- [ ] Inspect `git diff --stat` and key diffs for accidental unrelated changes.
