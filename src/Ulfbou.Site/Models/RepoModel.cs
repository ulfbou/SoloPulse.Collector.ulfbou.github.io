namespace Ulfbou.Site.Models;

public sealed class ReposDocument
{
    public string SchemaVersion { get; set; } = "";
    public DateTime GeneratedAt { get; set; }
    public List<RepoEntryContract> Repos { get; set; } = [];
}

public sealed class RepoEntryContract
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Language { get; set; } = "";
    public int Momentum { get; set; }
    public int FocusMinutes7d { get; set; }
    public int ContextSwitchesOut { get; set; }
    public DateTime? LastDeepWork { get; set; }
    public double ReturnRate { get; set; }
    public int OpenLoops { get; set; }
    public string Summary { get; set; } = "";
}

public sealed class RepoModel
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public string Language { get; set; } = "";
    public int Momentum { get; set; }
    public int FocusMinutes7d { get; set; }
    public int ContextSwitchesOut { get; set; }
    public DateTime? LastDeepWork { get; set; }
    public double ReturnRate { get; set; }
    public int OpenLoops { get; set; }
    public string Summary { get; set; } = "";
    public string Status { get; set; } = "";
    public string GithubUrl { get; set; } = "";
}
