namespace WardrobeINIConverter;

internal readonly struct CompCombo
{
    internal string CompName { get; }
    internal int CompId { get; }
    internal int TexId { get; }

    public CompCombo(string name, int compId, int texId)
    {
        CompName = name;
        CompId = compId;
        TexId = texId;
    }
}

internal readonly struct Entry
{
    internal string EntryName { get; }
    internal List<CompCombo> Combos { get; }
    internal string Gender { get; }

    public Entry(string entryName, List<CompCombo> combos, string gender)
    {
        EntryName = entryName;
        Combos = combos;
        Gender = gender;
    }
}