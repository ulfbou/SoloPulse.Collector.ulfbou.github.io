using FluentAssertions;
using Ulfbou.Site.Models;
using Ulfbou.Site.Services;
using Xunit;

namespace Ulfbou.Tests;

public sealed class GraphLayoutTests
{
    [Fact]
    public void ComputeViewBox_UsesDefaultForZeroNodes()
    {
        GraphLayout.ComputeViewBox(0).Should().Be("0 0 300 120");
    }

    [Fact]
    public void ComputePosition_IsDeterministicForOneNode()
    {
        GraphLayout.ComputePosition(0).Should().Be(new GraphPoint(24, 24));
        GraphLayout.ComputePosition(0)
            .Should().Be(GraphLayout.ComputePosition(0));
    }

    [Fact]
    public void FiveNodes_FitInOneRow()
    {
        var positions = Enumerable.Range(0, 5)
            .Select(GraphLayout.ComputePosition)
            .ToList();

        positions.Should().OnlyContain(point => point.Y == 24);
        positions[0].X.Should().Be(24);
        positions[4].X.Should().Be(264);
        GraphLayout.ComputeViewBox(5).Should().Be("0 0 340 120");
    }

    [Fact]
    public void MoreThanFiveNodes_WrapToAnotherRow()
    {
        GraphLayout.ComputePosition(5).Should().Be(new GraphPoint(24, 58));
    }

    [Fact]
    public void FifteenNodes_GrowTheViewBox()
    {
        GraphLayout.ComputeViewBox(15).Should().Be("0 0 340 152");
    }

    [Fact]
    public void Create_IsIndependentOfInputOrder()
    {
        var nodes = Enumerable.Range(0, 15)
            .Select(index => new GraphNode { Id = $"repo-{index:D2}" })
            .ToList();

        GraphLayout.Create(nodes)
            .Should()
            .BeEquivalentTo(
                GraphLayout.Create(nodes.AsEnumerable().Reverse()));
    }
}
