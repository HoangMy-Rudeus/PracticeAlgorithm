# PracticeAlgorithm

A lightweight .NET 10 console runner for algorithm practice. Each problem owns
its solution and its examples, so it feels close to solving a LeetCode problem
without requiring a test package or test-discovery setup.

## Run a problem

```powershell
dotnet run --project src/PracticeAlgorithm -- list
dotnet run --project src/PracticeAlgorithm -- two-sum
dotnet run --project src/PracticeAlgorithm -- all
```

The runner returns a non-zero exit code if any assertion fails.

## Add another problem

1. Copy `src/PracticeAlgorithm/Problems/TwoSumProblem.cs` and rename the class.
2. Give it a unique `Id`, then write examples in `Run` with `reporter.Test`.
3. Keep the actual algorithm in a separate `Solve` method so it can be pasted
   into an online judge easily.
4. Register the new problem in the `problems` array in `Program.cs`.

For example, `new ValidParenthesesProblem()` lets you run only that problem with:

```powershell
dotnet run --project src/PracticeAlgorithm -- valid-parentheses
```
