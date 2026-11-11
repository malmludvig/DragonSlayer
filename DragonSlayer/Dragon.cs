public class Dragon : Enemy
{
    public Dragon() : base("Drake", 100, Difficulty.Hard)
    {
    }

    public override int Damage => 10;

    public override void Attack()
    {
        Console.WriteLine("Draken sprutar eld!");
    }
}
