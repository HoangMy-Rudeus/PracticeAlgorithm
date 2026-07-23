namespace PracticeAlgorithm.Framework;

public sealed class TestReporter
{
    public int PassedCount { get; private set; }
    public int FailedCount { get; private set; }

    public void Test(string name, Action assertion)
    {
        try
        {
            assertion();
            PassedCount++;
            Console.WriteLine($"  PASS  {name}");
        }
        catch (Exception exception)
        {
            FailedCount++;
            Console.WriteLine($"  FAIL  {name}\n        {exception.Message}");
        }
    }

    public void PrintSummary() =>
        Console.WriteLine($"\nResult: {PassedCount} passed, {FailedCount} failed.");
}
