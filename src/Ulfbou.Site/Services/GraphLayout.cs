using Ulfbou.Site.Models;

namespace Ulfbou.Site.Services;

public readonly record struct GraphPoint(double X, double Y);

public static class GraphLayout
{
    public static IReadOnlyDictionary<string, GraphPoint> Create(
        IEnumerable<GraphNode> nodes)
    {
        var ordered = nodes
            .OrderBy(node => node.Id, StringComparer.Ordinal)
            .ToList();
        var result = new Dictionary<string, GraphPoint>(StringComparer.Ordinal);

        if (ordered.Count == 0)
        {
            return result;
        }

        if (ordered.Count == 1)
        {
            result[ordered[0].Id] = new GraphPoint(160, 70);
            return result;
        }

        for (var index = 0; index < ordered.Count; index++)
        {
            var angle = -Math.PI / 2 + 2 * Math.PI * index / ordered.Count;
            result[ordered[index].Id] = new GraphPoint(
                Math.Round(160 + 110 * Math.Cos(angle), 2),
                Math.Round(70 + 45 * Math.Sin(angle), 2));
        }

        return result;
    }
}
