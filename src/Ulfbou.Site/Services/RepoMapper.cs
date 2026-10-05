using Ulfbou.Site.Models;
namespace Ulfbou.Site.Services;
public static class RepoMapper
{
    public static RepoModel Map(RepoEntryContract x) => new()
    {
        Name=x.Name, DisplayName=x.DisplayName, Language=x.Language, Momentum=x.Momentum,
        FocusMinutes7d=x.FocusMinutes7d, ContextSwitchesOut=x.ContextSwitchesOut,
        LastDeepWork=x.LastDeepWork, ReturnRate=x.ReturnRate, OpenLoops=x.OpenLoops,
        Summary=x.Summary, Status=MapStatus(x.Momentum,x.OpenLoops),
        GithubUrl=$"https://github.com/ulfbou/{Uri.EscapeDataString(x.Name)}"
    };
    public static string MapStatus(int momentum, int openLoops) => momentum >= 50 ? "active" : openLoops >= 10 ? "needs-attention" : momentum > 0 ? "stable" : "quiet";
}
