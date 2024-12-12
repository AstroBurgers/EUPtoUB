using System.Diagnostics;

namespace WardrobeINIConverter;

internal static class WardrobeIniConverter
{
    internal static void Main()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("Press enter to continue...");
        var stopWatch = new Stopwatch();
        Console.ReadLine();
        stopWatch.Start();
        Converter.Convert(Parser.ParseFile(@"plugins\EUP\Wardrobe.ini"));
        Console.WriteLine("Converted!");
        stopWatch.Stop();
        Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.TotalSeconds}seconds - {stopWatch.ElapsedMilliseconds}ms");
        Console.WriteLine("Press enter to close...");
        Console.ReadLine();
    }
}