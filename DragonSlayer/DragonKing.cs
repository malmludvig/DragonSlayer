// Slutbossen
public class DragonKing : Enemy
{
    public DragonKing() : base("Drakkungen", 180, Difficulty.Hard)
    {
    }

    public override int Damage => 16;

    public override void Attack()
    {
        Console.WriteLine("Drakkungen sveper med svansen och sprutar svart eld!");
    }
}
