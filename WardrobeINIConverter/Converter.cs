using System.Text;

namespace WardrobeINIConverter;

internal static class Converter
{
    internal static void Convert(List<Entry> entries)
    {
        Console.WriteLine("Converting outfits...");
         var sb = new StringBuilder();

         // ReSharper disable once ForCanBeConvertedToForeach
         for (var index = 0; index < entries.Count; index++)
         {
             var data = entries[index];
             // Avoid repeated lookups
             var combos = data.Combos;

             var glassesSet = combos.FirstOrDefault(i => i.CompName == "Glasses");
             var hatSet = combos.FirstOrDefault(i => i.CompName == "Hat");
             var earSet = combos.FirstOrDefault(i => i.CompName == "Ear");
             var beardSet = combos.FirstOrDefault(i => i.CompName == "Mask");
             var shirtSet = combos.FirstOrDefault(i => i.CompName == "Top");
             var undercoatSet = combos.FirstOrDefault(i => i.CompName == "UnderCoat");
             var decalSet = combos.FirstOrDefault(i => i.CompName == "Decal");
             var accessorySet = combos.FirstOrDefault(i => i.CompName == "Accessories");
             var pantsSet = combos.FirstOrDefault(i => i.CompName == "Pants");
             var shoesSet = combos.FirstOrDefault(i => i.CompName == "Shoes");
             var vestSet = combos.FirstOrDefault(i => i.CompName == "Armor");
             var upperSkinSet = combos.FirstOrDefault(i => i.CompName == "UpperSkin");
             var parachuteSet = combos.FirstOrDefault(i => i.CompName == "Parachute");

             var outfitComment = data.EntryName;
             var gender = data.Gender == "Male" ? "MP_M_FREEMODE_01" : "MP_F_FREEMODE_01";
             var outfitChance = (100 / entries.Count) <= 0 ? 1 : 100 / entries.Count;

             sb.AppendLine($"<!-- {outfitComment} --> <Ped chance=\"{outfitChance}\" " +
                           $"prop_glasses=\"{glassesSet.CompId}\" tex_glasses=\"{glassesSet.TexId}\" " +
                           $"prop_hats=\"{hatSet.CompId}\" tex_hats=\"{hatSet.TexId}\" " +
                           $"prop_ears=\"{earSet.CompId}\" tex_ears=\"{earSet.TexId}\" " +
                           $"comp_beard=\"{beardSet.CompId}\" tex_beard=\"{beardSet.TexId}\" " +
                           $"comp_shirtoverlay=\"{shirtSet.CompId}\" tex_shirtoverlay=\"{shirtSet.TexId}\" " +
                           $"comp_shirt=\"{upperSkinSet.CompId}\" tex_shirt=\"{upperSkinSet.TexId}\" " +
                           $"comp_decals=\"{decalSet.CompId}\" tex_decals=\"{decalSet.TexId}\" " +
                           $"comp_accessories=\"{undercoatSet.CompId}\" tex_accessories=\"{undercoatSet.TexId}\" " +
                           $"comp_pants=\"{pantsSet.CompId}\" tex_pants=\"{pantsSet.TexId}\" " +
                           $"comp_shoes=\"{shoesSet.CompId}\" tex_shoes=\"{shoesSet.TexId}\" " +
                           $"comp_eyes=\"{accessorySet.CompId}\" tex_eyes=\"{accessorySet.TexId}\" " +
                           $"comp_tasks=\"{vestSet.CompId}\" tex_tasks=\"{vestSet.TexId}\" " +
                           $"comp_hands=\"{parachuteSet.CompId}\" tex_hands=\"{parachuteSet.TexId}\">" +
                           $"{gender}</Ped>");
         }

         Console.WriteLine("Finished converting...");
        Console.WriteLine("Printing!");
        // Write the entire batch to the file at once
        File.WriteAllText(@"WardrobeINIConverter\ConvertedLines.txt", sb.ToString());
    }
}