namespace WardrobeINIConverter;

internal static class Converter
{
    internal static void Convert(List<Entry> entries)
    {
        using StreamWriter streamWriter = new StreamWriter(@"Plugins\EUPToUB\ConvertedLines.txt");
        foreach (var data in entries)
        {
            var outfitComment = data.EntryName;
            var gender = data.Gender["Gender"] == "Male" ? "MP_M_FREEMODE_01" : "MP_F_FREEMODE_01";
            var glassesSet = data.Combos.FirstOrDefault(i => i.Key == "Glasses").Value;
            var hatSet = data.Combos.FirstOrDefault(i => i.Key == "Hat").Value;
            var earSet = data.Combos.FirstOrDefault(i => i.Key == "Ear").Value;
            var beardSet = data.Combos.FirstOrDefault(i => i.Key == "Mask").Value;
            var shirtSet = data.Combos.FirstOrDefault(i => i.Key == "Top").Value;
            var undercoatSet = data.Combos.FirstOrDefault(i => i.Key == "UnderCoat").Value;
            var decalSet = data.Combos.FirstOrDefault(i => i.Key == "Decal").Value;
            var accessorySet = data.Combos.FirstOrDefault(i => i.Key == "Accessories").Value;
            var pantsSet = data.Combos.FirstOrDefault(i => i.Key == "Pants").Value;
            var shoesSet  = data.Combos.FirstOrDefault(i => i.Key == "Shoes").Value;
            var vestSet = data.Combos.FirstOrDefault(i => i.Key == "Armor").Value;
            var upperSkinSet = data.Combos.FirstOrDefault(i => i.Key == "UpperSkin").Value;
            var parachuteSet = data.Combos.FirstOrDefault(i => i.Key == "Parachute").Value;
            string str = $"<!-- {outfitComment} --> <Ped chance=\"UPTOPLAYER\" " +
                    $"prop_glasses=\"{glassesSet.CompId}\" " +
                    $"tex_glasses=\"{glassesSet.TexId}\" " +
                    $"prop_hats=\"{hatSet.CompId}\" " +
                    $"tex_hats=\"{hatSet.TexId}\" " +
                    $"prop_ears=\"{earSet.CompId}\" " +
                    $"tex_ears=\"{earSet.TexId}\" " +
                    $"comp_beard=\"{beardSet.CompId}\" " +
                    $"tex_beard=\"{beardSet.TexId}\" " +
                    $"comp_shirtoverlay=\"{shirtSet.CompId}\" " +
                    $"tex_shirtoverlay=\"{shirtSet.TexId}\" " +
                    $"comp_shirt=\"{upperSkinSet.CompId}\" " +
                    $"tex_shirt=\"{upperSkinSet.TexId}\" " +
                    $"comp_decals=\"{decalSet.CompId}\"  " +
                    $"tex_decals=\"{decalSet.TexId}\" " +
                    $"comp_accessories=\"{undercoatSet.CompId}\" " +
                    $"tex_accessories=\"{undercoatSet.TexId}\" " +
                    $"comp_pants=\"{pantsSet.CompId}\" " +
                    $"tex_pants=\"{pantsSet.TexId}\" " +
                    $"comp_shoes=\"{shoesSet.CompId}\" " +
                    $"tex_shoes=\"{shoesSet.TexId}\" "+
                    $"comp_eyes=\"{accessorySet.CompId}\" " +
                    $"tex_eyes=\"{accessorySet.TexId}\" " +
                    $"comp_tasks=\"{vestSet.CompId}\"  " +
                    $"tex_tasks=\"{vestSet.TexId}\" " +
                    $"comp_hands=\"{parachuteSet.CompId}\" " +
                    $"tex_hands=\"{parachuteSet.TexId}\">{gender}</Ped>";
            Console.WriteLine($"Printing line: {str}");
            streamWriter.WriteLine(str);
        }
    }
}