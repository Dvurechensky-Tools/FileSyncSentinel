/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 29 августа 2026 07:14:12
 * Version: 1.0.303
 */

using FileSyncSentinel.Components;
using FileSyncSentinel.Services;

var tests = new (string Name, Action Run)[]
{
    ("LookChangesFiles reports files that exist only in Out", LookChangesFilesReportsNewOutFiles),
    ("LookChangesFiles reports files that exist only in In as deleted", LookChangesFilesReportsDeletedInFiles),
    ("LookChangesFiles reports changed files as modified", LookChangesFilesReportsModifiedFiles),
    ("Merge copies new files from Out to In", MergeCopiesNewOutFiles),
    ("ApplyChange deletes files that were removed from Out", ApplyChangeDeletesRemovedOutFiles),
    ("ApplyChanges applies mixed add modify and delete changes", ApplyChangesAppliesMixedChanges),
    ("ChangeListFilter filters by search text and exclusions", ChangeListFilterFiltersBySearchTextAndExclusions),
};

var failed = 0;

foreach (var test in tests)
{
    try
    {
        test.Run();
        Console.WriteLine($"PASS {test.Name}");
    }
    catch (Exception ex)
    {
        failed++;
        Console.Error.WriteLine($"FAIL {test.Name}");
        Console.Error.WriteLine(ex.Message);
    }
}

if (failed > 0)
{
    Environment.Exit(1);
}

static void LookChangesFilesReportsNewOutFiles()
{
    using var fixture = MergeFixture.Create();
    var outFile = fixture.WriteOutFile(Path.Combine("Nested", "new.ini"), "value=42");

    var service = new MergeFolderService(fixture.Config);
    var changes = service.LookChangesFiles();

    AssertEqual(1, changes.Count, "New Out-only file should be listed as a pending change.");
    AssertEqual(Path.Combine("Nested", "new.ini"), changes[0].Relative, "Relative path should preserve subdirectories.");
    AssertEqual(outFile, changes[0].Full, "Full path should point to the Out file.");
    AssertEqual(Path.Combine(fixture.InPath, "Nested", "new.ini"), changes[0].BeforeItemPath, "BeforeItemPath should be the target In path.");
}

static void MergeCopiesNewOutFiles()
{
    using var fixture = MergeFixture.Create();
    fixture.WriteOutFile(Path.Combine("Nested", "new.ini"), "value=42");

    var service = new MergeFolderService(fixture.Config);
    service.Merge();

    var inFile = Path.Combine(fixture.InPath, "Nested", "new.ini");
    AssertTrue(File.Exists(inFile), "Merge should create missing In files.");
    AssertEqual("value=42", File.ReadAllText(inFile), "Merge should copy new file contents.");
}

static void LookChangesFilesReportsDeletedInFiles()
{
    using var fixture = MergeFixture.Create();
    var inFile = fixture.WriteInFile(Path.Combine("Nested", "removed.ini"), "value=old");

    var service = new MergeFolderService(fixture.Config);
    var changes = service.LookChangesFiles();

    AssertEqual(1, changes.Count, "In-only file should be listed as a pending delete.");
    AssertEqual(Path.Combine("Nested", "removed.ini"), changes[0].Relative, "Relative path should preserve subdirectories.");
    AssertEqual(Path.Combine(fixture.OutPath, "Nested", "removed.ini"), changes[0].Full, "Full path should point to the missing Out path.");
    AssertEqual(inFile, changes[0].BeforeItemPath, "BeforeItemPath should point to the existing In file.");
    AssertEqual(MergeChangeType.Deleted, changes[0].ChangeType, "Change type should mark removed files as deleted.");
    AssertTrue(changes[0].IsDeleted, "Deleted compatibility flag should be true.");
}

static void LookChangesFilesReportsModifiedFiles()
{
    using var fixture = MergeFixture.Create();
    fixture.WriteInFile("changed.ini", "value=old");
    fixture.WriteOutFile("changed.ini", "value=new");

    var service = new MergeFolderService(fixture.Config);
    var changes = service.LookChangesFiles();

    AssertEqual(1, changes.Count, "Different files with the same relative path should be listed.");
    AssertEqual("changed.ini", changes[0].Relative, "Relative path should identify the modified file.");
    AssertEqual(MergeChangeType.Modified, changes[0].ChangeType, "Change type should mark changed files as modified.");
    AssertTrue(!changes[0].IsNew, "Modified files should not be marked as new.");
    AssertTrue(!changes[0].IsDeleted, "Modified files should not be marked as deleted.");
}

static void ApplyChangeDeletesRemovedOutFiles()
{
    using var fixture = MergeFixture.Create();
    var inFile = fixture.WriteInFile(Path.Combine("Nested", "removed.ini"), "value=old");

    var service = new MergeFolderService(fixture.Config);
    var item = service.LookChangesFiles().Single();

    var applied = service.ApplyChange(item);

    AssertTrue(applied, "ApplyChange should report that the delete was applied.");
    AssertTrue(!File.Exists(inFile), "Deleted change should remove the In file.");
}

static void ApplyChangesAppliesMixedChanges()
{
    using var fixture = MergeFixture.Create();
    fixture.WriteOutFile("added.ini", "value=added");
    fixture.WriteInFile("modified.ini", "value=old");
    fixture.WriteOutFile("modified.ini", "value=new");
    fixture.WriteInFile("deleted.ini", "value=removed");

    var service = new MergeFolderService(fixture.Config);
    var changes = service.LookChangesFiles();

    var applied = service.ApplyChanges(changes);

    AssertEqual(3, applied, "ApplyChanges should apply each pending change.");
    AssertEqual("value=added", File.ReadAllText(Path.Combine(fixture.InPath, "added.ini")), "Added file should be copied to In.");
    AssertEqual("value=new", File.ReadAllText(Path.Combine(fixture.InPath, "modified.ini")), "Modified file should be overwritten in In.");
    AssertTrue(!File.Exists(Path.Combine(fixture.InPath, "deleted.ini")), "Deleted file should be removed from In.");
}

static void ChangeListFilterFiltersBySearchTextAndExclusions()
{
    var items = new[]
    {
        new MergeItem(Path.Combine("Scripts", "keep.ini"), "out") { BeforeItemPath = "in" },
        new MergeItem(Path.Combine("Scripts", "Skip", "hidden.ini"), "out") { BeforeItemPath = "in" },
        new MergeItem(Path.Combine("Data", "other.txt"), "out") { BeforeItemPath = "in" },
    };

    var visible = ChangeListFilter.Filter(items, "KEEP", "Scripts/Skip").ToList();

    AssertEqual(1, visible.Count, "Filter should keep matching paths and remove excluded subfolders.");
    AssertEqual(Path.Combine("Scripts", "keep.ini"), visible[0].Relative, "Search should be case-insensitive and exclusions should accept slash-separated paths.");
}

static void AssertTrue(bool condition, string message)
{
    if (!condition)
    {
        throw new InvalidOperationException(message);
    }
}

static void AssertEqual<T>(T expected, T actual, string message)
{
    if (!EqualityComparer<T>.Default.Equals(expected, actual))
    {
        throw new InvalidOperationException($"{message} Expected: {expected}. Actual: {actual}.");
    }
}

internal sealed class MergeFixture : IDisposable
{
    private MergeFixture(string rootPath)
    {
        RootPath = rootPath;
        InPath = Path.Combine(rootPath, "In");
        OutPath = Path.Combine(rootPath, "Out");
        Directory.CreateDirectory(InPath);
        Directory.CreateDirectory(OutPath);

        Config = new MergeConfigData
        {
            PathIn = InPath,
            PathOut = OutPath,
            TypeFiles = "*.ini",
        };
    }

    public string RootPath { get; }
    public string InPath { get; }
    public string OutPath { get; }
    public MergeConfigData Config { get; }

    public static MergeFixture Create()
    {
        var root = Path.Combine(Path.GetTempPath(), "FileSyncSentinel.Tests", Guid.NewGuid().ToString("N"));
        return new MergeFixture(root);
    }

    public string WriteOutFile(string relativePath, string content)
    {
        var fullPath = Path.Combine(OutPath, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
        return fullPath;
    }

    public string WriteInFile(string relativePath, string content)
    {
        var fullPath = Path.Combine(InPath, relativePath);
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, content);
        return fullPath;
    }

    public void Dispose()
    {
        if (Directory.Exists(RootPath))
        {
            Directory.Delete(RootPath, recursive: true);
        }
    }
}
