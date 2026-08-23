/*
 * Author: Nikolay Dvurechensky
 * Site: https://dvurechensky.pro/
 * Gmail: dvurechenskysoft@gmail.com
 * Last Updated: 23 августа 2026 07:15:58
 * Version: 1.0.297
 */

using FileSyncSentinel.Components;
using FileSyncSentinel.Services;

var tests = new (string Name, Action Run)[]
{
    ("LookChangesFiles reports files that exist only in Out", LookChangesFilesReportsNewOutFiles),
    ("Merge copies new files from Out to In", MergeCopiesNewOutFiles),
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

    public void Dispose()
    {
        if (Directory.Exists(RootPath))
        {
            Directory.Delete(RootPath, recursive: true);
        }
    }
}
