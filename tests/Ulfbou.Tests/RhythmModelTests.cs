using FluentAssertions;
using Ulfbou.Site.Models;
using Xunit;

namespace Ulfbou.Tests;

public sealed class RhythmModelTests
{
    [Fact]
    public void RhythmModel_PreservesTheGeneratedContract()
    {
        var model = new RhythmModel
        {
            SchemaVersion = "1",
            GeneratedAt = DateTime.Parse("2026-10-05T09:38:29Z"),
            PeakHours = [9, 12, 14],
            AvgSessionMinutes = 16,
            FragmentationIndex = 1.3,
            DeepWorkStreakDays = 3,
            LastQuietPeriod = "2026-10-05"
        };

        model.SchemaVersion.Should().Be("1");
        model.PeakHours.Should().Equal(9, 12, 14);
        model.AvgSessionMinutes.Should().Be(16);
        model.FragmentationIndex.Should().Be(1.3);
        model.DeepWorkStreakDays.Should().Be(3);
        model.LastQuietPeriod.Should().Be("2026-10-05");
    }
}
