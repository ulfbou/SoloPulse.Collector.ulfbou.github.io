using Ulfbou.Site.Models;

namespace Ulfbou.Site.Services;

public readonly record struct GraphPoint(double X, double Y);

public static class GraphLayout
{
    private const int Columns = 5;
    private const int ColumnWidth = 60;
    private const int RowHeight = 34;
    private const int OffsetX = 24;
    private const int OffsetY = 24;

    public static IReadOnlyDictionary<string, GraphPoint> Create(
        IEnumerable<GraphNode> nodes)
    {
        var ordered = nodes
            .OrderBy(node => node.Id, StringComparer.Ordinal)
            .ToList();

        return ordered
            .Select((node, index) => (node.Id, Point: ComputePosition(index)))
            .ToDictionary(
                item => item.Id,
                item => item.Point,
                StringComparer.Ordinal);
    }

    public static GraphPoint ComputePosition(int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return new GraphPoint(
            OffsetX + index % Columns * ColumnWidth,
            OffsetY + index / Columns * RowHeight);
    }

    public static string ComputeViewBox(int nodeCount)
    {
        if (nodeCount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nodeCount));
        }

        if (nodeCount == 0)
        {
            return "0 0 300 120";
        }

        var rows = (nodeCount + Columns - 1) / Columns;
        var height = Math.Max(120, 30 + rows * RowHeight + 20);
        return $"0 0 340 {height}";
    }
}
