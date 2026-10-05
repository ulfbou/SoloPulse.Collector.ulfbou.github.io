using System.Net;
using System.Text;
using FluentAssertions;
using Ulfbou.Site.Services;
using Xunit;

namespace Ulfbou.Tests;

public sealed class SiteDataClientTests
{
    [Fact]
    public async Task GetReposAsync_DeserializesWrappedContractAndMapsEveryField()
    {
        const string json = """
            {"schemaVersion":"1","generatedAt":"2026-10-05T09:28:10Z","repos":[{"name":"repo","displayName":"Repo","language":"C#","momentum":49,"focusMinutes7d":7,"contextSwitchesOut":2,"lastDeepWork":"2026-10-05T08:00:00Z","returnRate":0.75,"openLoops":3,"summary":"Summary"}]}
            """;
        var client = CreateClient(HttpStatusCode.OK, json);

        var repo = (await client.GetReposAsync()).Should().ContainSingle().Subject;

        repo.Should().BeEquivalentTo(new
        {
            Name = "repo",
            DisplayName = "Repo",
            Language = "C#",
            Momentum = 49,
            FocusMinutes7d = 7,
            ContextSwitchesOut = 2,
            ReturnRate = 0.75,
            OpenLoops = 3,
            Summary = "Summary",
            Status = "stable",
            GithubUrl = "https://github.com/ulfbou/repo"
        }, options => options.ExcludingMissingMembers());
        repo.LastDeepWork.Should().Be(DateTime.Parse("2026-10-05T08:00:00Z").ToUniversalTime());
    }

    [Fact]
    public async Task GetReposAsync_DistinguishesEmptyDataFromFailure()
    {
        const string empty = """
            {"schemaVersion":"1","generatedAt":"2026-10-05T09:28:10Z","repos":[]}
            """;

        (await CreateClient(HttpStatusCode.OK, empty).GetReposAsync()).Should().BeEmpty();
        (await CreateClient(HttpStatusCode.ServiceUnavailable, "").GetReposAsync()).Should().BeNull();
    }

    private static SiteDataClient CreateClient(HttpStatusCode status, string body) =>
        new(new HttpClient(new StubHandler(status, body))
        {
            BaseAddress = new Uri("https://example.test/")
        });

    private sealed class StubHandler(HttpStatusCode status, string body) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken) =>
            Task.FromResult(new HttpResponseMessage(status)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });
    }
}
