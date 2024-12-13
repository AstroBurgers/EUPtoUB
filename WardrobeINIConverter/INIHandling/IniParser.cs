namespace WardrobeINIConverter.INIHandling;

internal static class IniParser
{
    internal static readonly string IniFilePath = @"WardrobeINIConverter\WardrobeINIConverter.ini";
    internal static bool LogLines = false;
    internal static bool VerifyFiles()
    {
        if (!Directory.Exists(Path.GetDirectoryName(IniFilePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(IniFilePath) ?? string.Empty);
        }

        if (!File.Exists(IniFilePath))
        {
            File.Create(IniFilePath);
        }

        if (!File.Exists(@"WardrobeINIConverter\ConvertedLines.txt"))
        {
            File.Create(@"WardrobeINIConverter\ConvertedLines.txt");
        }

        if (!File.Exists(@"plugins\EUP\Wardrobe.ini"))
        {
            Console.WriteLine("ERROR, Wardrobe.ini file NOT found!");
            return false;
        }
        return true;
    }

    internal static bool ParseIniFile()
    {
        using var reader = new StreamReader(IniFilePath);
        var logLines = false;
        while (reader.EndOfStream == false)
        {
            var line = reader.ReadLine();
            // Handle Comments
            if (line!.StartsWith("/")) {
                continue;
            }
            var splitLine = line.Trim().Split('=');
            if (!splitLine[0].Contains("LogLines")) continue;
            logLines = Convert.ToBoolean(splitLine[1]);
            return logLines;
        }
        return logLines;
    }

    internal static void LogLine(string? line)
    {
        if (!LogLines) return;
        Console.WriteLine($"Current Line: {line}");
    }
}