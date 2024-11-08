using Rage;

[assembly: Rage.Attributes.Plugin("EUP to UB", Description = "Does this even get read?", Author = "Astro")]

namespace EUPtoUB
{
    internal enum PedComponent
    {
        PedCompHead = 0,
        PedCompBerd = 1,
        PedCompHair = 2,
        PedCompTorso = 3, // UPPERSKIN?
        PedCompLeg = 4, // PANTS
        PedCompHand = 5, //PARACHUTE
        PedCompFeet = 6, // SHOES
        PedCompTeeth = 7, // ACCS?
        PedCompSpecial = 8, // UNDERCOAT?
        PedCompSpecial2 = 9, //PV_COMP_TASK 
        PedCompDecl = 10,      //DECAL
        PedCompJbib = 11 // JBIB/SHIRT
    }

    internal enum PropType
    {
        AnchorHead = 0,
        AnchorEyes,
        AnchorEars,
        AnchorMouth,
        AnchorLeftHand,
        AnchorRightHand,
        AnchorLeftWrist,
        AnchorRightWrist,
        AnchorHip
    }

    public class EntryPoint
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static void Main()
        {
            FileHandler.ValidateFile();
            Game.AddConsoleCommands();

            GameFiber.Hibernate();
        }
    }
}
