using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Rage;

namespace EUPtoUB
{
    internal class FileHandler
    {
        internal static string CSharpFilePath = @"Plugins\EUPToUB\ConvertedLines.txt";
        internal static string CSharpFileDirectory = @"Plugins\EUPToUB";

        internal static void ValidateFile()
        {
            if (!Directory.Exists(CSharpFileDirectory))
            {
                Directory.CreateDirectory(CSharpFileDirectory);
            }

            if (!File.Exists(CSharpFilePath))
            {
                File.Create(CSharpFilePath);
            }
        }

        internal static void AppendFile()
        {
            string str = $"<Ped chance=\"UPTOPLAYER\" prop_glasses=\"{Conversion_Handlers.GetPropID(PROP_TYPE.ANCHOR_EYES)}\" text_glasses=\"{Conversion_Handlers.GetPropTextureID(PROP_TYPE.ANCHOR_EYES)}\" prop_hats=\"{Conversion_Handlers.GetPropID(PROP_TYPE.ANCHOR_HEAD)}\" tex_hats=\"{Conversion_Handlers.GetPropTextureID(PROP_TYPE.ANCHOR_HEAD)}\" prop_ears=\"{Conversion_Handlers.GetPropID(PROP_TYPE.ANCHOR_EARS)}\" tex_ears=\"{Conversion_Handlers.GetPropTextureID(PROP_TYPE.ANCHOR_EARS)}\" comp_beard=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_BERD)}\" comp_shirtoverlay=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_JBIB)}\" tex_shirtoverlay=\"{Conversion_Handlers.GetTextureID(PED_COMPONENT.PED_COMP_JBIB)}\" comp_shirt=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_TORSO)}\"  comp_decals=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_DECL)}\"  tex_decals=\"{Conversion_Handlers.GetTextureID(PED_COMPONENT.PED_COMP_DECL)}\" comp_accessories=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_SPECIAL)}\" comp_pants=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_LEG)}\" tex_pants\"{Conversion_Handlers.GetTextureID(PED_COMPONENT.PED_COMP_LEG)}\" comp_shoes=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_FEET)}\" comp_eyes=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_TEETH)}\" comp_tasks=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_SPECIAL2)}\"  tex_tasks=\"{Conversion_Handlers.GetTextureID(PED_COMPONENT.PED_COMP_SPECIAL2)}\" comp_hands=\"{Conversion_Handlers.GetDrawableID(PED_COMPONENT.PED_COMP_HAND)}\" tex_hands=\"{Conversion_Handlers.GetTextureID(PED_COMPONENT.PED_COMP_HAND)}\">{EntryPoint.MainPlayer.Model.Name}</Ped>";

            using (FileStream fs2 = new FileStream(CSharpFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs2))
            {
                sw.WriteLine(str);
            }
        }
    }
}
