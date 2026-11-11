public abstract class Enemy
{
    public string Name { get; }
    public int Health { get; private set; }
    public Difficulty Difficulty { get; }

    // Hur mycket skada fienden gör när den attackerar spelaren
    public abstract int Damage { get; }

    protected Enemy(string name, int health, Difficulty difficulty)
    {
        Name = name;
        Health = health;
        Difficulty = difficulty;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health = Math.Max(0, Health - damage);
        }
    }

    // Svårare fiender ger mer guld
    public int GoldReward()
    {
        switch (Difficulty)
        {
            case Difficulty.Easy:
                return 10;
            case Difficulty.Medium:
                return 25;
            default:
                return 50;
        }
    }

    public abstract void Attack();
}
