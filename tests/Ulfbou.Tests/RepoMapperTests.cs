using FluentAssertions;
using Ulfbou.Site.Services;
using Xunit;

namespace Ulfbou.Tests;

public sealed class RepoMapperTests
{
    [Theory]
    [InlineData(50, 0, "active")]
    [InlineData(49, 10, "needs-attention")]
    [InlineData(1, 9, "stable")]
    [InlineData(0, 9, "quiet")]
    public void MapStatus_UsesDefinedBoundaries(
        int momentum,
        int openLoops,
        string expected) =>
        RepoMapper.MapStatus(momentum, openLoops).Should().Be(expected);
}
