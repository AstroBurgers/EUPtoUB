using System.IO;
using System.Threading.Tasks;

namespace WardrobeINIConverter;

internal static class Parser
{
    internal static List<Entry> ParseFile(string filePath)
    {
        // Read all lines at once to minimize I/O
        var allLines = File.ReadAllLines(filePath);

        // Split lines into sections
        var sections = SplitIntoSections(allLines);

        // Parse sections in parallel
        var parsedEntries = new List<Entry>();
        Parallel.ForEach(sections, section =>
        {
            var entry = ParseCurrentEntry(section);
            lock (parsedEntries) // Avoid race conditions
            {
                parsedEntries.Add(entry);
            }
        });

        return parsedEntries;
    }

    private static List<List<string>> SplitIntoSections(string[] allLines)
    {
        var sections = new List<List<string>>();
        var currentSection = new List<string>();

        foreach (var line in allLines)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                if (currentSection.Count > 0)
                {
                    sections.Add(currentSection);
                    currentSection = new List<string>();
                }
            }
            currentSection.Add(line);
        }

        if (currentSection.Count > 0)
        {
            sections.Add(currentSection);
        }

        return sections;
    }

    private static Entry ParseCurrentEntry(List<string> lines)
    {
        var parsedCombos = new Dictionary<string, CompCombo>();
        var gender = new Dictionary<string, string>();
        var entryName = string.Empty;

        foreach (var line in lines)
        {
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                entryName = line.TrimStart('[').TrimEnd(']');
                continue;
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                var lineSplitEq = line.Split('=');
                if (lineSplitEq.Length < 2) continue;

                var compName = lineSplitEq[0];
                if (compName.Equals("Gender"))
                {
                    gender.Add(compName, lineSplitEq[1]);
                    continue;
                }

                var lineSplitCol = lineSplitEq[1].Split(':');
                if (lineSplitCol.Length == 2)
                {
                    var curCombo = new CompCombo
                    {
                        CompId = int.Parse(lineSplitCol[0]),
                        TexId = int.Parse(lineSplitCol[1])
                    };
                    parsedCombos.Add(compName, curCombo);
                }
            }
        }

        return new Entry(entryName, parsedCombos, gender);
    }
}