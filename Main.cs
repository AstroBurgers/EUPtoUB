using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using Rage.Attributes;
using Rage.ConsoleCommands;
using Rage.Native;

[assembly: Rage.Attributes.Plugin("EUP to UB", Description = "Does this even get read?", Author = "Astro")]

namespace EUPtoUB
{
    public class EntryPoint
    {
        internal enum PED_COMPONENT
        {
            PED_COMP_HEAD = 0,
            PED_COMP_BERD = 1,
            PED_COMP_HAIR = 2,
            PED_COMP_TORSO = 3,
            PED_COMP_LEG = 4,
            PED_COMP_HAND = 5,
            PED_COMP_FEET = 6,
            PED_COMP_TEETH = 7,
            PED_COMP_SPECIAL = 8, //PV_COMP_ACCS
            PED_COMP_SPECIAL2 = 9, //PV_COMP_TASK 
            PED_COMP_DECL = 10,      //DECAL
            PED_COMP_JBIB = 11 // JBIB
        }
        internal static Ped MainPlayer => Game.LocalPlayer.Character;
        internal static void Main()
        {

        }

        internal static bool IsComponentValid(PED_COMPONENT component, int Drawable, int Texture)
        {
            if (NativeFunction.Natives.IS_PED_COMPONENT_VARIATION_VALID<bool>(MainPlayer, component, Drawable, Texture))
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
