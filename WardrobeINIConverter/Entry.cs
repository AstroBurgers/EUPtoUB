namespace WardrobeINIConverter;

internal struct Entry(string entryName, List<CompCombo> combos, string gender)
{
    internal readonly string EntryName = entryName;
    internal List<CompCombo> Combos = combos;
    internal string Gender = gender;
}

internal struct CompCombo(string Name, int compId, int texId)
{
    internal string CompName = Name;
    internal int CompId = compId;
    internal int TexId = texId;
}