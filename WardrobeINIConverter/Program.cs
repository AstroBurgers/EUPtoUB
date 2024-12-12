namespace WardrobeINIConverter;

internal static class WardrobeIniConverter
{
    internal static void Main()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("Press any button to continue...");
        Console.ReadLine();
        var parsedData = Parser.ParseFile(@"plugins\EUP\Wardrobe.ini");
        foreach (var data in parsedData)
        {
            Console.WriteLine(data.EntryName);
            foreach (var combo in data.Combos)
            {
                Console.WriteLine($"{combo.Key}={combo.Value.CompId}:{combo.Value.TexId}");
            }
        }
        Console.ReadLine();
    }
}