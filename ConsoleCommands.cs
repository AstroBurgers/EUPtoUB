using Rage.Attributes;

namespace EUPtoUB
{
    internal static class ConsoleCommands
    {
        [ConsoleCommand("Prints the current outfit to a text file in the UB XML Format")]
        public static void PrintCurrentOutfit()
        {
            FileHandler.AppendFile();
        }
    }
}
