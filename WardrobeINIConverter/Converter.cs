using System.Text;

namespace WardrobeINIConverter;

internal static class Converter
{
    internal static void Convert(List<Entry> entries)
    {
        Console.WriteLine("Converting outfits...");
         var sb = new StringBuilder();

        foreach (var data in entries)
        {
            // Avoid repeated lookups
            var combos = data.Combos.ToDictionary(c => c.Key, c => c.Value);

            var glassesSet = combos.TryGetValue("Glasses", out var glasses) ? glasses : new CompCombo();
            var hatSet = combos.TryGetValue("Hat", out var hat) ? hat : new CompCombo();
            var earSet = combos.TryGetValue("Ear", out var ear) ? ear : new CompCombo();
            var beardSet = combos.TryGetValue("Mask", out var beard) ? beard : new CompCombo();
            var shirtSet = combos.TryGetValue("Top", out var shirt) ? shirt : new CompCombo();
            var undercoatSet = combos.TryGetValue("UnderCoat", out var undercoat) ? undercoat : new CompCombo();
            var decalSet = combos.TryGetValue("Decal", out var decal) ? decal : new CompCombo();
            var accessorySet = combos.TryGetValue("Accessories", out var accessory) ? accessory : new CompCombo();
            var pantsSet = combos.TryGetValue("Pants", out var pants) ? pants : new CompCombo();
            var shoesSet = combos.TryGetValue("Shoes", out var shoes) ? shoes : new CompCombo();
            var vestSet = combos.TryGetValue("Armor", out var vest) ? vest : new CompCombo();
            var upperSkinSet = combos.TryGetValue("UpperSkin", out var upperSkin) ? upperSkin : new CompCombo();
            var parachuteSet = combos.TryGetValue("Parachute", out var parachute) ? parachute : new CompCombo();

            var outfitComment = data.EntryName;
            var gender = data.Gender["Gender"] == "Male" ? "MP_M_FREEMODE_01" : "MP_F_FREEMODE_01";

            sb.AppendLine($"<!-- {outfitComment} --> <Ped chance=\"UPTOPLAYER\" " +
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