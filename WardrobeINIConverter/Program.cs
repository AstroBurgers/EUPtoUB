using System.Diagnostics;
using static WardrobeINIConverter.INIHandling.IniParser;

namespace WardrobeINIConverter;

internal static class WardrobeIniConverter
{
    internal static void Main()
    {
        try
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Verifying needed files exist...");
            if (!VerifyFiles())
            {
                Console.WriteLine("Exiting in 5 seconds...");
                Thread.Sleep(5000);
                return;
            }
            Console.WriteLine("Reading INI...");
            LogLines = ParseIniFile();
            Console.WriteLine($"LogLines: {LogLines}");
            Console.WriteLine("Press enter to continue...");
            var stopWatch = new Stopwatch();
            Console.ReadLine();
        
            stopWatch.Start();
            Converter.Convert(Parser.ParseFile(@"plugins\EUP\Wardrobe.ini"));
            stopWatch.Stop();
        
            Console.WriteLine("Converted!");
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.TotalSeconds} seconds - {stopWatch.ElapsedMilliseconds} ms");

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();  // This ensures the console stays open until the user closes it manually
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();  // Keeps the window open if there's an exception
        }
    }
}