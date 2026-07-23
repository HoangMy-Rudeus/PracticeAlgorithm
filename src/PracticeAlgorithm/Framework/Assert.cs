namespace PracticeAlgorithm.Framework;

public static class Assert
{
    public static void Equal<T>(T expected, T actual)
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
        {
            throw new InvalidOperationException($"Expected: {expected}; Actual: {actual}");
        }
    }

    public static void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual)
    {
        var expectedText = $"[{string.Join(", ", expected)}]";
        var actualText = $"[{string.Join(", ", actual)}]";

        if (!expected.SequenceEqual(actual))
        {
            throw new InvalidOperationException($"Expected: {expectedText}; Actual: {actualText}");
        }
    }
}
