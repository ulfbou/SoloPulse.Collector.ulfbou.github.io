using FluentAssertions;
using Ulfbou.Site.Models;
using Ulfbou.Site.Services;
using Xunit;

namespace Ulfbou.Tests;

public sealed class GraphLayoutTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(8)]
    public void Create_IsDeterministicAndInsideTheViewBox(int count)
    {
        var nodes = Enumerable.Range(0, count)
            .Select(index => new GraphNode { Id = $"repo-{index}" })
            .ToList();

        var forward = GraphLayout.Create(nodes);
        var reversed = GraphLayout.Create(nodes.AsEnumerable().Reverse());

        forward.Should().BeEquivalentTo(reversed);
        forward.Should().HaveCount(count);
        forward.Values.Should().OnlyContain(point =>
            point.X >= 50 && point.X <= 270
            && point.Y >= 25 && point.Y <= 115);
    }
}
