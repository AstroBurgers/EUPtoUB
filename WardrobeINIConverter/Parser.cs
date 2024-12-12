using System.IO;

namespace WardrobeINIConverter;

internal static class Parser
{
    internal static List<Entry> ParseFile(string filePath)
    {
        List<Entry> entries = [];
        using StreamReader sr = new(filePath);
        while (sr.EndOfStream == false)
        {
            var line = sr.ReadLine();
            //Console.WriteLine($"Current Line: {line}");
            if (line != null && line.StartsWith('[') && line.EndsWith(']')) {
                entries.Add(ParseCurrentEntry(sr, line));
            }
        }

        return entries;
    }

    private static Entry ParseCurrentEntry(StreamReader sr, string? currentLine)
    {
        var parsedCombos = new Dictionary<string, CompCombo>();
        var gender = new Dictionary<string, string>();
        var entryName = string.Empty;
        
        if (currentLine != null && currentLine.StartsWith('[') && currentLine.EndsWith(']')) {
            entryName = currentLine.TrimStart('[').TrimEnd(']');
        }
        while (sr.Peek() != -1 && sr.EndOfStream == false)
        {
            var line = sr.ReadLine();
            if (string.IsNullOrWhiteSpace(line)) {
                return new Entry(entryName, parsedCombos, gender);
            }
            Console.WriteLine($"Current Line: {line}");
            var lineSplitEq = line.Split('=');
            var curCombo = new CompCombo();
            var compName = lineSplitEq[0];
            if (compName.Equals("Gender"))
            {
                gender.Add(compName, lineSplitEq[1]);
                continue;
            }
            var lineSplitCol = lineSplitEq[1].Split(':');
            curCombo.CompId = int.Parse(lineSplitCol[0]);
            curCombo.TexId = int.Parse(lineSplitCol[1]);
            parsedCombos.Add(compName, curCombo);
        }

        return new Entry(entryName, parsedCombos, gender);
    }
}