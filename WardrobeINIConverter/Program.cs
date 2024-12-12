namespace WardrobeINIConverter;

internal static class WardrobeIniConverter
{
    internal static void Main()
    {
        Console.WriteLine("Welcome!");
        Console.WriteLine("Press any button to continue...");
        Console.ReadLine();
        var parsedData = Parser.ParseFile(@"plugins\EUP\Wardrobe.ini");
        Converter.Convert(parsedData);
        Console.ReadLine();
    }
}