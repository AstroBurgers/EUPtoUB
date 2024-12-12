namespace WardrobeINIConverter;

internal struct Entry
{
    internal string EntryName;
    internal Dictionary<string, CompCombo> Combos;
    internal Dictionary<string, string> Gender;
    
    public Entry(string entryName, Dictionary<string, CompCombo> combos, Dictionary<string, string> gender)
    {
        EntryName = entryName;
        Combos = combos;
        Gender = gender;
    }
}

internal struct CompCombo
{
    internal int CompId;
    internal int TexId;

    public CompCombo(int compId, int texId)
    {
        CompId = compId;
        TexId = texId;
    }
}