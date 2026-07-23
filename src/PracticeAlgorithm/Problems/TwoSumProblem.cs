using PracticeAlgorithm.Framework;

namespace PracticeAlgorithm.Problems;

public sealed class TwoSumProblem : IPracticeProblem
{
    public string Id => "two-sum";
    public string Title => "Two Sum";
    public string Description => "Return the indices of two values whose sum equals the target.";

    public void Run(TestReporter reporter)
    {
        reporter.Test("example 1", () =>
            Assert.SequenceEqual([0, 1], Solve([2, 7, 11, 15], 9)));

        reporter.Test("example 2", () =>
            Assert.SequenceEqual([1, 2], Solve([3, 2, 4], 6)));

        reporter.Test("duplicate values", () =>
            Assert.SequenceEqual([0, 1], Solve([3, 3], 6)));
    }

    // Keep the solution method independent, like a LeetCode submission.
    public static int[] Solve(int[] numbers, int target)
    {
        var seen = new Dictionary<int, int>();

        for (var index = 0; index < numbers.Length; index++)
        {
            var complement = target - numbers[index];
            if (seen.TryGetValue(complement, out var complementIndex))
            {
                return [complementIndex, index];
            }

            seen[numbers[index]] = index;
        }

        return [];
    }
}
