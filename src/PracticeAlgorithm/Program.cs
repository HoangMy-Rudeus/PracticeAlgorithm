using PracticeAlgorithm.Framework;
using PracticeAlgorithm.Problems;

var problems = new IPracticeProblem[]
{
    new TwoSumProblem(),
};

var command = args.FirstOrDefault()?.ToLowerInvariant();

if (command is null or "list")
{
    PrintProblems(problems);
    return;
}

var selected = command == "all"
    ? problems
    : problems.Where(problem => problem.Id.Equals(command, StringComparison.OrdinalIgnoreCase)).ToArray();

if (selected.Length == 0)
{
    Console.Error.WriteLine($"Unknown problem: {command}");
    PrintProblems(problems);
    Environment.ExitCode = 1;
    return;
}

var reporter = new TestReporter();
foreach (var problem in selected)
{
    Console.WriteLine($"\n{problem.Id}: {problem.Title}");
    Console.WriteLine(problem.Description);
    problem.Run(reporter);
}

reporter.PrintSummary();
Environment.ExitCode = reporter.FailedCount == 0 ? 0 : 1;

static void PrintProblems(IEnumerable<IPracticeProblem> problems)
{
    Console.WriteLine("Algorithm practice runner\n");
    Console.WriteLine("Available problems:");

    foreach (var problem in problems)
    {
        Console.WriteLine($"  {problem.Id,-16} {problem.Title}");
    }

    Console.WriteLine("\nCommands:");
    Console.WriteLine("  dotnet run --project src/PracticeAlgorithm -- list");
    Console.WriteLine("  dotnet run --project src/PracticeAlgorithm -- <problem-id>");
    Console.WriteLine("  dotnet run --project src/PracticeAlgorithm -- all");
}
