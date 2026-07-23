namespace PracticeAlgorithm.Framework;

public interface IPracticeProblem
{
    string Id { get; }
    string Title { get; }
    string Description { get; }
    void Run(TestReporter reporter);
}
