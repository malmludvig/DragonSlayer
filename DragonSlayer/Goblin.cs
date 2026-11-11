public class Goblin : Enemy
{
    public Goblin() : base("Goblin", 30, Difficulty.Easy)
    {
    }

    public override int Damage => 5;

    public override void Attack()
    {
        Console.WriteLine("Goblinen attackerar med sin klubba!");
    }
}
