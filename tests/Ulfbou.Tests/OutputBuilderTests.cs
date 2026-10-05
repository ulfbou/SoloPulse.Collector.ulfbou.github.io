using FluentAssertions;
using SoloPulse.Collector;
using Xunit;

namespace Ulfbou.Tests;

public sealed class OutputBuilderTests
{
    [Fact]
    public void Build_UsesOneTimestampAndConsistentRepositorySignals()
    {
        const string generatedAt = "2026-10-05T09:28:10Z";
        var repos = new List<RepoEntry>
        {
            new("active", "Active", "C#", 50, 7, 0, generatedAt, 0.75, 2, "Summary"),
            new("quiet", "Quiet", "C#", 0, 0, 0, generatedAt, 1, 3, "")
        };

        var output = OutputBuilder.Build(
            generatedAt,
            repos,
            [],
            [],
            new RhythmFile("1", generatedAt, [], 0, 0, 0, null));

        output.Repos.GeneratedAt.Should().Be(generatedAt);
        output.Metrics.GeneratedAt.Should().Be(generatedAt);
        output.Now.GeneratedAt.Should().Be(generatedAt);
        output.Metrics.Summary.ActiveRepos.Should().Be(1);
        output.Now.Signals.ActiveRepos.Should().Be(1);
        output.Metrics.Summary.OpenLoops.Should().Be(5);
        output.Now.Signals.OpenLoops.Should().Be(5);
        output.Now.Signals.QuietRepos.Should().Be(1);
    }
}
