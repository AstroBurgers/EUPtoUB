using System;
using System.IO;

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

        internal static void PrintOutfit(string outfitName)
        {
            string outfitComment = outfitName == String.Empty ? String.Empty : $"<!-- {outfitName} --> ";
            string str = $"{outfitComment}<Ped chance=\"UPTOPLAYER\" " +
                $"prop_glasses=\"{ConversionHandlers.GetPropId(PropType.AnchorEyes)}\" " +
                $"tex_glasses=\"{ConversionHandlers.GetPropTextureId(PropType.AnchorEyes)}\" " +
                $"prop_hats=\"{ConversionHandlers.GetPropId(PropType.AnchorHead)}\" " +
                $"tex_hats=\"{ConversionHandlers.GetPropTextureId(PropType.AnchorHead)}\" " +
                $"prop_ears=\"{ConversionHandlers.GetPropId(PropType.AnchorEars)}\" " +
                $"tex_ears=\"{ConversionHandlers.GetPropTextureId(PropType.AnchorEars)}\" " +
                $"comp_beard=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompBerd)}\" " +
                $"tex_beard=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompBerd)}\" " +
                $"comp_shirtoverlay=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompJbib)}\" " +
                $"tex_shirtoverlay=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompJbib)}\" " +
                $"comp_shirt=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompTorso)}\" " +
                $"tex_shirt=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompTorso)}\" " +
                $"comp_decals=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompDecl)}\"  " +
                $"tex_decals=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompDecl)}\" " +
                $"comp_accessories=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompSpecial)}\" " +
                $"tex_accessories=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompSpecial)}\" " +
                $"comp_pants=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompLeg)}\" " +
                $"tex_pants=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompLeg)}\" " +
                $"comp_shoes=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompFeet)}\" " +
                $"tex_shoes=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompFeet)}\" " +
                $"comp_eyes=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompTeeth)}\" " +
                $"tex_eyes=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompTeeth)}\" " +
                $"comp_tasks=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompSpecial2)}\"  " +
                $"tex_tasks=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompSpecial2)}\" " +
                $"comp_hands=\"{ConversionHandlers.GetDrawableId(PedComponent.PedCompHand)}\" " +
                $"tex_hands=\"{ConversionHandlers.GetTextureId(PedComponent.PedCompHand)}\">{EntryPoint.MainPlayer.Model.Name}</Ped>";

            using (FileStream fs2 = new FileStream(CSharpFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (StreamWriter sw = new StreamWriter(fs2))
            {
                sw.WriteLine(str);
            }
        }
    }
}
