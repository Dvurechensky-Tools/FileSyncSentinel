## 21.08.2026

### Added

- Added detection for new files in the `Out` directory, including nested folders.
- Added new files to the change list.
- Added the **Add** action label for new files in the changes grid.
- Added automatic creation of missing `In` subdirectories when adding new files.
- Added `FileSystemWatcher` handling for file creation and rename events.
- Added the `FileSyncSentinel.Tests` regression runner for new-file discovery and copy behavior.

### Changed

- Bulk apply now uses the configured file mask instead of a hard-coded `*.ini` mask.
- Bulk apply now copies new files from `Out` to `In` instead of skipping them.
- Diff viewing now handles missing reference files without failing.
- Rewrote the Russian README in a more professional first-person style with fewer emoji.
- Rewrote the English README in a more professional first-person style with fewer emoji.
