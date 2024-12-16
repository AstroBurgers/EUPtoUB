namespace WardrobeINIConverter;

internal struct Entry(string entryName, List<CompCombo> combos, string gender)
{
    internal readonly string EntryName = entryName;
    internal readonly List<CompCombo> Combos = combos;
    internal readonly string Gender = gender;
}

internal struct CompCombo(string name, int compId, int texId)
{
    internal readonly string CompName = name;
    internal int CompId = compId;
    internal int TexId = texId;
}