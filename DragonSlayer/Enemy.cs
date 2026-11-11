public abstract class Enemy
{
    public string Name { get; }
    public int Health { get; private set; }
    public Difficulty Difficulty { get; }

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

    public abstract void Attack();
}
