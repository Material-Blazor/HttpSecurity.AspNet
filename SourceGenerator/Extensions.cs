using System.Collections.Generic;
using System.Linq;

namespace System.Text;

public static class Extensions
{
    private const string SingleIndent = "    ";
    private static readonly  string[] SplitStrings = { "\r\n", "\n" };
    public static int LinesGenerated { get; set; }
    
    /// <inheritdoc cref="StringBuilder.AppendLine(string)"/>
    /// <remarks>Indents the provided value by the specified number of four space indents. splits <see cref="value"/> by newlines and adds each line in turn.</remarks>
    public static StringBuilder AppendLinesIndented(this StringBuilder source, int numIndents, string value, bool removeBlanks = false)
    {
        var indent = new StringBuilder(SingleIndent.Length * numIndents).Insert(0, SingleIndent, numIndents).ToString();
        
        if (string.IsNullOrWhiteSpace(value) && ! removeBlanks)
        {
            source.AppendLine(indent);
            return source;
        }

        IEnumerable<string> lines = value.Split(SplitStrings, StringSplitOptions.RemoveEmptyEntries);
        
        if (removeBlanks)
        {
            lines = lines.Where(line => !string.IsNullOrWhiteSpace(line));
        }

        foreach (var line in lines)
        {
            source.AppendLine(indent + line.Trim());
        }

        LinesGenerated++;

        return source;
    }
}