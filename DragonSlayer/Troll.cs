public class Troll : Enemy
{
    public Troll() : base("Troll", 60, Difficulty.Medium)
    {
    }

    public override int Damage => 9;

    public override void Attack()
    {
        Console.WriteLine("Trollet slår med en trädstam!");
    }
}
