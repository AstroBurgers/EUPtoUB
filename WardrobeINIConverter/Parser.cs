namespace WardrobeINIConverter;

internal static class Parser
{
    internal static List<Entry> ParseFile(string filePath)
    {
        Console.WriteLine("Initializing parser...");
        // Read all lines at once to minimize I/O
        var allLines = File.ReadAllLines(filePath);
        Console.WriteLine("Read file...");

        // Split lines into sections
        var sections = SplitIntoSections(allLines);
        Console.WriteLine("Chunked file...");
        
        var parsedEntries = sections.Select(section => ParseEntry(section)).ToList();
        
        Console.WriteLine("Finished parsing file...");
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

    private static Entry ParseEntry(List<string> lines)
    {
        Console.WriteLine($"Entry has {lines.Count} lines...");
        var parsedCombos = new List<CompCombo>();
        var gender = string.Empty;
        var entryName = string.Empty;

        foreach (var line in lines.Where(line => !string.IsNullOrWhiteSpace(line)))
        {
            Console.WriteLine($"Parsing line: {line}");
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                entryName = line.TrimStart('[').TrimEnd(']');
                continue;
            }
            
            var lineSplitEq = line.Split('=');
            if (lineSplitEq.Length < 2) continue;

            var compName = lineSplitEq[0];
            if (compName.Equals("Gender"))
            {
                gender = lineSplitEq[1].Trim();
                continue;
            }

            var lineSplitCol = lineSplitEq[1].Split(':');
            var curCombo = new CompCombo()
            {
                CompName = compName,
                CompId = int.Parse(lineSplitCol[0]),
                TexId = int.Parse(lineSplitCol[1])
            };
            Console.WriteLine($"Parsed combo: {compName} - {curCombo.CompId}:{curCombo.TexId}");
            parsedCombos.Add(curCombo);
        }

        return new Entry(entryName, parsedCombos, gender);
    }
}