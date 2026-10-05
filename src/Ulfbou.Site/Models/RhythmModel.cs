namespace Ulfbou.Site.Models;

public sealed class RhythmModel
{
    public string SchemaVersion { get; set; } = "1";
    public DateTime GeneratedAt { get; set; }
    public List<int> PeakHours { get; set; } = [];
    public int AvgSessionMinutes { get; set; }
    public double FragmentationIndex { get; set; }
    public int DeepWorkStreakDays { get; set; }
    public string? LastQuietPeriod { get; set; }
}
