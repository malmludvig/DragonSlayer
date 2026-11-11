public class Dragon : Enemy
{
    public Dragon() : base("Drake", 100, Difficulty.Hard)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("Draken sprutar eld!");
    }
}
