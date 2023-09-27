using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Attributes;
using Rage.ConsoleCommands;
using Rage.Native;
using System.Windows.Forms;

[assembly: Rage.Attributes.Plugin("EUP to UB", Description = "Does this even get read?", Author = "Astro")]

namespace EUPtoUB
{
    internal enum PED_COMPONENT
    {
        PED_COMP_HEAD = 0,
        PED_COMP_BERD = 1,
        PED_COMP_HAIR = 2,
        PED_COMP_TORSO = 3, // UPPERSKIN?
        PED_COMP_LEG = 4, // PANTS
        PED_COMP_HAND = 5, //PARACHUTE
        PED_COMP_FEET = 6, // SHOES
        PED_COMP_TEETH = 7, // ACCS?
        PED_COMP_SPECIAL = 8, // UNDERCOAT?
        PED_COMP_SPECIAL2 = 9, //PV_COMP_TASK 
        PED_COMP_DECL = 10,      //DECAL
        PED_COMP_JBIB = 11 // JBIB/SHIRT
    }

    internal enum PROP_TYPE
    {
        ANCHOR_HEAD = 0,
        ANCHOR_EYES,
        ANCHOR_EARS,
        ANCHOR_MOUTH,
        ANCHOR_LEFT_HAND,
        ANCHOR_RIGHT_HAND,
        ANCHOR_LEFT_WRIST,
        ANCHOR_RIGHT_WRIST,
        ANCHOR_HIP
    }

    public class EntryPoint
    {
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static void Main()
        {
            FileHandler.ValidateFile();
            while (true)
            {
                GameFiber.Yield();

                if (Game.IsKeyDown(Keys.G))
                {
                    FileHandler.AppendFile();
                }
            }
        }

        internal static bool IsComponentValid(PED_COMPONENT component, int Drawable, int Texture)
        {
            // xE825F6B6CEA7671D = IS_PED_COMPONENT_VARIATION_VALID
            if (NativeFunction.Natives.xE825F6B6CEA7671D<bool>(MainPlayer, component, Drawable, Texture))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
