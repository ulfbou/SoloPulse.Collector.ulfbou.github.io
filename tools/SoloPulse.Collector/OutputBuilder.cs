using System.Globalization;
using System.Text;
namespace SoloPulse.Collector;
static class OutputBuilder
{
    public static CollectorOutput Build(string generatedAt,List<RepoEntry> repos,List<GraphNode> nodes,List<GraphEdge> edges,RhythmFile rhythm)
    {
        var generated=DateTime.Parse(generatedAt,CultureInfo.InvariantCulture,DateTimeStyles.RoundtripKind);
        var isoWeek=$"{ISOWeek.GetYear(generated)}-W{ISOWeek.GetWeekOfYear(generated):00}";
        var monday=generated.Date.AddDays(-(((int)generated.DayOfWeek+6)%7));
        var primary=repos.OrderByDescending(r=>r.Momentum).ThenByDescending(r=>r.FocusMinutes7d).FirstOrDefault();
        var active=repos.Count(r=>r.Momentum>0); var loops=repos.Sum(r=>r.OpenLoops); var primaryName=primary?.Name??"";
        var log=repos.OrderByDescending(r=>r.Momentum).ThenByDescending(r=>r.OpenLoops).Take(5).Select(r=>new BuildLogEntry(r.Name,r.DisplayName,r.Name,Summary(r),null,$"https://github.com/ulfbou/{Uri.EscapeDataString(r.Name)}",Status(r))).ToList();
        var attention=repos.Where(r=>Status(r)=="needs-attention").Select(r=>new AttentionEntry("open-loops",r.Name,$"{r.OpenLoops} open loops need a look.","medium")).ToList();
        var metrics=new MetricsFile("1",generatedAt,new("week",isoWeek,$"{monday:yyyy-MM-dd}",$"{monday.AddDays(6):yyyy-MM-dd}"),new(primaryName,active,loops,0),log,attention);
        var now=new NowFile("1",generatedAt,new("Ulf Bourelius","ulfbou","Stockholm"),new("ulfbou.github.io","living-logbook"),new(primary is null?"No repository activity was collected this week.":$"Current work is gathering around {primary.DisplayName}.",primaryName,repos.Where(r=>r.Name!=primaryName).Take(2).Select(r=>r.Name).ToList()),new(isoWeek,"/pulse/weekly-friendly.md","/data/metrics.json"),new(active,loops,0,repos.Count-active));
        return new(new("1",generatedAt,repos),new("1",generatedAt,nodes,edges),rhythm,metrics,now,Markdown(isoWeek,repos,primary));
    }
    internal static string Status(RepoEntry repo)
    {
        if (repo.Momentum >= 15 || repo.FocusMinutes7d >= 30)
        {
            return "active";
        }

        if (repo.OpenLoops >= 10)
        {
            return "needs-attention";
        }

        if (repo.Momentum == 0 && repo.FocusMinutes7d == 0)
        {
            return "quiet";
        }

        if (repo.ReturnRate < 0.6 && repo.Momentum < 5)
        {
            return "needs-attention";
        }

        return "active";
    }
    static string Summary(RepoEntry r)=>Status(r) switch{"active"=>string.IsNullOrWhiteSpace(r.Summary)?"Active work is visible here this week.":r.Summary,"needs-attention"=>$"{r.OpenLoops} open loops are waiting for attention.","stable"=>"Steady background work is visible here.",_=>"Quiet this week."};
    static string Markdown(string week,List<RepoEntry> repos,RepoEntry? primary)
    {
        var b=new StringBuilder().AppendLine("## This week").AppendLine();
        if(primary is null)return b.AppendLine("No public repository activity was collected this week. The logbook remains available while the next update takes shape.").ToString();
        b.AppendLine($"The clearest thread in {week} is [{primary.DisplayName}](https://github.com/ulfbou/{Uri.EscapeDataString(primary.Name)}). {(string.IsNullOrWhiteSpace(primary.Summary)?"That is where the most visible recent activity gathered.":primary.Summary)}");
        var moving=repos.Where(r=>r.Name!=primary.Name&&r.Momentum>0).Take(2).ToList(); if(moving.Count>0)b.AppendLine().AppendLine("Also moving: "+string.Join(", ",moving.Select(r=>$"[{r.DisplayName}](https://github.com/ulfbou/{Uri.EscapeDataString(r.Name)})"))+".");
        var attention=repos.Where(r=>r.OpenLoops>=10).Take(2).ToList(); if(attention.Count>0)b.AppendLine().AppendLine("Worth revisiting next: "+string.Join(", ",attention.Select(r=>r.DisplayName))+".");
        return b.ToString();
    }
}
