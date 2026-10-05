using Ulfbou.Site.Models;

namespace Ulfbou.Site.Services;

public static class RepoMapper
{
    public static RepoModel Map(RepoEntryContract source) => new()
    {
        Name = source.Name,
        DisplayName = source.DisplayName,
        Language = source.Language,
        Momentum = source.Momentum,
        FocusMinutes7d = source.FocusMinutes7d,
        ContextSwitchesOut = source.ContextSwitchesOut,
        LastDeepWork = source.LastDeepWork,
        ReturnRate = source.ReturnRate,
        OpenLoops = source.OpenLoops,
        Summary = source.Summary,
        Status = MapStatus(
            source.Momentum,
            source.FocusMinutes7d,
            source.OpenLoops,
            source.ReturnRate),
        GithubUrl =
            $"https://github.com/ulfbou/{Uri.EscapeDataString(source.Name)}",
        DocsUrl =
            $"/docs/{Uri.EscapeDataString(source.Name)}/",
        ActivityScore = source.Momentum
    };

    public static string MapStatus(
        int momentum,
        int focusMinutes7d,
        int openLoops,
        double returnRate)
    {
        if (momentum >= 15 || focusMinutes7d >= 30)
        {
            return "active";
        }

        if (openLoops >= 10)
        {
            return "needs-attention";
        }

        if (momentum == 0 && focusMinutes7d == 0)
        {
            return "quiet";
        }

        if (returnRate < 0.6 && momentum < 5)
        {
            return "needs-attention";
        }

        return "active";
    }
}
