using FluentAssertions;
using Ulfbou.Site.Services;
using Xunit;

namespace Ulfbou.Tests;

public sealed class RepoMapperTests
{
    [Theory]
    [InlineData(0, 0, 0, 1.0, "quiet")]
    [InlineData(14, 0, 0, 1.0, "active")]
    [InlineData(15, 0, 0, 1.0, "active")]
    [InlineData(0, 30, 0, 1.0, "active")]
    [InlineData(0, 0, 10, 1.0, "needs-attention")]
    [InlineData(0, 0, 9, 1.0, "quiet")]
    [InlineData(4, 0, 0, 0.5, "needs-attention")]
    [InlineData(4, 0, 0, 0.6, "active")]
    public void MapStatus_UsesDefinedBoundaries(
        int momentum,
        int focusMinutes7d,
        int openLoops,
        double returnRate,
        string expected) =>
        RepoMapper.MapStatus(
            momentum,
            focusMinutes7d,
            openLoops,
            returnRate).Should().Be(expected);
}
