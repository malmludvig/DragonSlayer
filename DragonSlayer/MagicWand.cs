public class MagicWand : IWeapon
{
    public int Use()
    {
        Console.WriteLine("Du kastar en eldboll med trollstaven!");
        return 15;
    }
}
