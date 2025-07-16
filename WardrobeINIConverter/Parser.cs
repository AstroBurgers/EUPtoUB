namespace WardrobeINIConverter;

internal static class Parser
{
    internal static Entry[] ParseFile(string filePath)
    {
        Console.WriteLine("Initializing parser...");
        using var reader = new StreamReader(filePath);
        var sections = ChunkSections(reader);
        Console.WriteLine("Chunked file...");

        var parsedEntries = sections
            .AsParallel()
            .WithDegreeOfParallelism(Environment.ProcessorCount)
            .Select(ParseEntry)
            .ToArray();

        Console.WriteLine("Finished parsing file...");
        return parsedEntries;
    }

    private static List<List<string?>> ChunkSections(StreamReader reader)
    {
        var sections = new List<List<string?>>();
        var currentSection = new List<string?>();

        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var span = line.Trim();

            if (span.Length > 1 && span[0] == '[' && span[span.Length - 1] == ']' && currentSection.Count > 0)
            {
                sections.Add(currentSection);
                currentSection = new List<string?>();
            }

            currentSection.Add(line);
        }

        if (currentSection.Count > 0)
            sections.Add(currentSection);

        return sections;
    }

    private static readonly Dictionary<string, string> KnownCompNames = new Dictionary<string, string>
    {
        ["Hat"] = "Hat",
        ["Shoes"] = "Shoes",
        ["Top"] = "Top",
        ["Pants"] = "Pants",
        ["Armor"] = "Armor",
        ["UnderCoat"] = "UnderCoat",
        ["Accessories"] = "Accessories",
        ["Mask"] = "Mask",
        ["UpperSkin"] = "UpperSkin",
        ["Parachute"] = "Parachute",
        ["Decal"] = "Decal",
        ["Ear"] = "Ear",
        ["Glasses"] = "Glasses"
    };

    private static string InternCompName(string name)
    {
        return KnownCompNames.TryGetValue(name, out var known) ? known : name;
    }

    private static Entry ParseEntry(List<string?> lines)
    {
        // Use a pre-allocated heap array instead of stackalloc
        var comboBuffer = RentComboBuffer();
        int comboCount = 0;

        string gender = string.Empty;
        string entryName = string.Empty;

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var raw in lines)
        {
            if (string.IsNullOrWhiteSpace(raw)) continue;

            var line = raw?.Trim();

            if (line is { Length: > 2 } && line[0] == '[' && line[line.Length - 1] == ']')
            {
                entryName = line.Substring(1, line.Length - 2);
                continue;
            }

            if (line != null)
            {
                int eq = line.IndexOf('=');
                if (eq == -1) continue;

                string compNameStr = line.Substring(0, eq);
                string valueStr = line.Substring(eq + 1);

                if (string.Equals(compNameStr, "Gender", StringComparison.OrdinalIgnoreCase))
                {
                    gender = valueStr.Trim();
                    continue;
                }

                int colon = valueStr.IndexOf(':');
                if (colon == -1) continue;

                string idStr = valueStr.Substring(0, colon);
                string texStr = valueStr.Substring(colon + 1);

                if (!TryParseInt(idStr, out int compId)) continue;
                if (!TryParseInt(texStr, out int texId)) continue;

                comboBuffer[comboCount++] = new CompComboTemp
                {
                    CompName = compNameStr,
                    CompId = compId,
                    TexId = texId
                };
            }
        }

        var finalList = GetSharedComboList();
        for (int i = 0; i < comboCount; i++)
        {
            var temp = comboBuffer[i];
            finalList.Add(new CompCombo(
                InternCompName(temp.CompName),
                temp.CompId,
                temp.TexId
            ));
        }

        return new Entry(entryName, [..finalList], gender);
    }

    [ThreadStatic] private static CompComboTemp[]? _buffer;

    private static CompComboTemp[] RentComboBuffer()
    {
        return _buffer ??= new CompComboTemp[20];
    }

    [ThreadStatic] private static List<CompCombo>? _sharedComboList;

    private static List<CompCombo> GetSharedComboList()
    {
        var list = _sharedComboList ??= new List<CompCombo>(20);
        list.Clear(); // reset between uses
        return list;
    }

    
    private static bool TryParseInt(string str, out int value)
    {
        value = 0;
        if (string.IsNullOrEmpty(str)) return false;

        int i = 0;
        bool neg = false;

        if (str[0] == '-')
        {
            neg = true;
            i = 1;
            if (str.Length == 1) return false;
        }

        for (; i < str.Length; i++)
        {
            char c = str[i];
            if (c < '0' || c > '9') return false;
            value = value * 10 + (c - '0');
        }

        if (neg) value = -value;
        return true;
    }

    private struct CompComboTemp
    {
        public string CompName;
        public int CompId;
        public int TexId;
    }
}