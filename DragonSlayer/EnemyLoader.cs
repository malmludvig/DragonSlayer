using System.Text.Json;

// Läser in vilka fiender som finns från en JSON-fil
public static class EnemyLoader
{
    public static List<string> LoadNames(string path)
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<string>>(json);
    }

    // Gör om ett namn från JSON-filen till ett riktigt fiendeobjekt
    public static Enemy Create(string name)
    {
        switch (name)
        {
            case "Goblin":
                return new Goblin();
            case "Troll":
                return new Troll();
            case "Dragon":
                return new Dragon();
            default:
                throw new ArgumentException($"Okänd fiende: {name}");
        }
    }
}
