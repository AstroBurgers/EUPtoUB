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
            var entry = entries[index];
            // Avoid repeated lookups
            var combos = entry.Combos;

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

            var outfitComment = entry.EntryName;
            var gender = entry.Gender == "Male" ? "MP_M_FREEMODE_01" : "MP_F_FREEMODE_01";
            var outfitChance = 100 / entries.Count <= 0 ? 1 : 100 / entries.Count;

            sb.AppendLine($"<!-- {outfitComment} --> <Ped chance=\"{outfitChance.ToString()}\" " +
                          $"prop_glasses=\"{glassesSet.CompId.ToString()}\" tex_glasses=\"{glassesSet.TexId.ToString()}\" " +
                          $"prop_hats=\"{hatSet.CompId.ToString()}\" tex_hats=\"{hatSet.TexId.ToString()}\" " +
                          $"prop_ears=\"{earSet.CompId.ToString()}\" tex_ears=\"{earSet.TexId.ToString()}\" " +
                          $"comp_beard=\"{beardSet.CompId.ToString()}\" tex_beard=\"{beardSet.TexId.ToString()}\" " +
                          $"comp_shirtoverlay=\"{shirtSet.CompId.ToString()}\" tex_shirtoverlay=\"{shirtSet.TexId.ToString()}\" " +
                          $"comp_shirt=\"{upperSkinSet.CompId.ToString()}\" tex_shirt=\"{upperSkinSet.TexId.ToString()}\" " +
                          $"comp_decals=\"{decalSet.CompId.ToString()}\" tex_decals=\"{decalSet.TexId.ToString()}\" " +
                          $"comp_accessories=\"{undercoatSet.CompId.ToString()}\" tex_accessories=\"{undercoatSet.TexId.ToString()}\" " +
                          $"comp_pants=\"{pantsSet.CompId.ToString()}\" tex_pants=\"{pantsSet.TexId.ToString()}\" " +
                          $"comp_shoes=\"{shoesSet.CompId.ToString()}\" tex_shoes=\"{shoesSet.TexId.ToString()}\" " +
                          $"comp_eyes=\"{accessorySet.CompId.ToString()}\" tex_eyes=\"{accessorySet.TexId.ToString()}\" " +
                          $"comp_tasks=\"{vestSet.CompId.ToString()}\" tex_tasks=\"{vestSet.TexId.ToString()}\" " +
                          $"comp_hands=\"{parachuteSet.CompId.ToString()}\" tex_hands=\"{parachuteSet.TexId.ToString()}\">" +
                          $"{gender}</Ped>");
        }

        Console.WriteLine("Finished converting...");
        Console.WriteLine("Printing!");
        // Write the entire batch to the file at once
        File.WriteAllText(@"WardrobeINIConverter\ConvertedLines.txt", sb.ToString());
    }
}