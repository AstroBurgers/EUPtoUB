using System.Diagnostics;
using static System.Diagnostics.Stopwatch;

namespace WardrobeINIConverter;

internal static class WardrobeIniConverter
{
    private const string MainFilePath = @"WardrobeINIConverter\ConvertedLines.txt";
    private const string InputFilePath = @"plugins\EUP\Wardrobe.ini";
    private const string LogFilePath = @"performance_log.txt";

    internal static void Main()
    {
#if DEBUG
        RunBenchmark();
#else
        RunNormal();
#endif
    }

    private static void RunBenchmark()
    {
        try
        {
            Console.WriteLine("Welcome! (Benchmark Mode)");
            Console.WriteLine("Verifying needed files exist...");
            if (!VerifyFiles())
            {
                Console.WriteLine("Exiting in 5 seconds...");
                Thread.Sleep(5000);
                return;
            }

            Console.WriteLine("Press enter to start benchmarking...");
            Console.ReadLine();

            const int runs = 10;
            var times = new long[runs];

            for (var i = 0; i < runs; i++)
            {
                var sw = StartNew();

                var entries = Parser.ParseFile(InputFilePath);
                Converter.Convert(entries);

                sw.Stop();
                times[i] = sw.ElapsedMilliseconds;
                Console.WriteLine($"Run {i + 1}: {times[i]} ms");
            }

            var sortedTimes = times.OrderBy(t => t).ToArray();
            var median = (runs % 2 == 1)
                ? sortedTimes[runs / 2]
                : (sortedTimes[runs / 2 - 1] + sortedTimes[runs / 2]) / 2.0;

            Console.WriteLine($"Median time: {median} ms");

            var logLines = times
                .Select((time, idx) => $"Run {idx + 1}: {time} ms")
                .ToList();

            logLines.Add($"Median time: {median} ms");

            File.WriteAllLines(LogFilePath, logLines);

            Console.WriteLine($"Benchmark log written to {LogFilePath}");
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Exiting in 5 seconds...");
            Thread.Sleep(5000);
        }
    }

    private static void RunNormal()
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

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();

            var stopWatch = Stopwatch.StartNew();
            Converter.Convert(Parser.ParseFile(InputFilePath));
            stopWatch.Stop();

            Console.WriteLine("Converted!");
            Console.WriteLine($"Elapsed time: {stopWatch.Elapsed.TotalSeconds} seconds - {stopWatch.ElapsedMilliseconds} ms");

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.WriteLine("Exiting in 5 seconds...");
            Thread.Sleep(5000);
        }
    }

    private static bool VerifyFiles()
    {
        var mainDir = Path.GetDirectoryName(MainFilePath);
        if (!string.IsNullOrEmpty(mainDir) && !Directory.Exists(mainDir))
        {
            Directory.CreateDirectory(mainDir);
        }

        if (!File.Exists(MainFilePath))
        {
            using var fs = File.Create(MainFilePath);
        }

        if (File.Exists(InputFilePath)) return true;

        Console.WriteLine($"ERROR, {InputFilePath} file NOT found!");
        return false;
    }
}