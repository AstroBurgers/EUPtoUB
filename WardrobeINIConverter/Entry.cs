namespace WardrobeINIConverter;

internal struct Entry(string entryName, Dictionary<string, CompCombo> combos, Dictionary<string, string> gender)
{
    internal readonly string EntryName = entryName;
    internal Dictionary<string, CompCombo> Combos = combos;
    internal Dictionary<string, string> Gender = gender;
}

internal struct CompCombo(int compId, int texId)
{
    internal int CompId = compId;
    internal int TexId = texId;
}