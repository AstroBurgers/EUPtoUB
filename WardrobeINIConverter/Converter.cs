using System.Text;

namespace WardrobeINIConverter;

internal static class Converter
{
    internal static void Convert(Entry[] entries)
    {
        Console.WriteLine("Converting outfits...");

        var outfitChance = entries.Length == 0 ? 1 : Math.Max(1, 100 / entries.Length);

        using var writer = new StreamWriter(@"WardrobeINIConverter\ConvertedLines.txt", false, Encoding.UTF8, 65536);

        foreach (var entry in entries)
        {
            var combos = entry.Combos;

            var glassesSet = new CompCombo();
            var hatSet = new CompCombo();
            var earSet = new CompCombo();
            var beardSet = new CompCombo();
            var shirtSet = new CompCombo();
            var undercoatSet = new CompCombo();
            var decalSet = new CompCombo();
            var accessorySet = new CompCombo();
            var pantsSet = new CompCombo();
            var shoesSet = new CompCombo();
            var vestSet = new CompCombo();
            var upperSkinSet = new CompCombo();
            var parachuteSet = new CompCombo();

            foreach (var combo in combos)
            {
                switch (combo.CompName)
                {
                    case "Glasses": glassesSet = combo; break;
                    case "Hat": hatSet = combo; break;
                    case "Ear": earSet = combo; break;
                    case "Mask": beardSet = combo; break;
                    case "Top": shirtSet = combo; break;
                    case "UnderCoat": undercoatSet = combo; break;
                    case "Decal": decalSet = combo; break;
                    case "Accessories": accessorySet = combo; break;
                    case "Pants": pantsSet = combo; break;
                    case "Shoes": shoesSet = combo; break;
                    case "Armor": vestSet = combo; break;
                    case "UpperSkin": upperSkinSet = combo; break;
                    case "Parachute": parachuteSet = combo; break;
                }
            }

            var outfitComment = entry.EntryName;
            var gender = entry.Gender == "Male" ? "MP_M_FREEMODE_01" : "MP_F_FREEMODE_01";
            
            writer.Write("<!-- ");
            writer.Write(outfitComment); // e.g., M Grapeseed Class A
            writer.Write(" --> <Ped chance=\"");
            writer.Write(outfitChance);
            writer.Write("\" ");

            WriteCompPair("prop_glasses", glassesSet);
            WriteCompPair("prop_hats", hatSet);
            WriteCompPair("prop_ears", earSet);
            WriteCompPair("comp_beard", beardSet);
            WriteCompPair("comp_shirtoverlay", shirtSet);
            WriteCompPair("comp_shirt", upperSkinSet);
            WriteCompPair("comp_decals", decalSet);
            WriteCompPair("comp_accessories", undercoatSet);
            WriteCompPair("comp_pants", pantsSet);
            WriteCompPair("comp_shoes", shoesSet);
            WriteCompPair("comp_eyes", accessorySet);
            WriteCompPair("comp_tasks", vestSet);
            WriteCompPair("comp_hands", parachuteSet);

            writer.Write('>');
            writer.Write(gender);
            writer.WriteLine("</Ped>");
            continue;

            void WriteCompPair(string prefix, CompCombo set)
            {
                writer.Write(prefix);
                writer.Write("=\"");
                writer.Write(set.CompId);
                writer.Write("\" tex_");
                writer.Write(prefix.Substring(5)); // e.g. "glasses" from "prop_glasses"
                writer.Write("=\"");
                writer.Write(set.TexId);
                writer.Write("\" ");
            }
        }

        Console.WriteLine("Finished converting and writing to file.");
    }
}
