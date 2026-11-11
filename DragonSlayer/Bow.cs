public class Bow : IWeapon
{
    public int Use()
    {
        Console.WriteLine("Du skjuter en pil!");
        return 8;
    }
}
