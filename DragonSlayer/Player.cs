public class Player
{
    public IWeapon Weapon { get; set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Gold { get; set; }
    public int Potions { get; set; }

    public Player(IWeapon weapon)
    {
        Weapon = weapon;
        MaxHealth = 100;
        Health = MaxHealth;
    }

    public bool IsAlive => Health > 0;

    public void Attack(Enemy enemy)
    {
        int damage = Weapon.Use();
        enemy.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health = Math.Max(0, Health - damage);
        }
    }

    public void Heal(int amount)
    {
        if (amount > 0)
        {
            Health = Math.Min(MaxHealth, Health + amount);
        }
    }

    // Varje vunnen strid gör spelaren lite starkare
    public void LevelUp()
    {
        MaxHealth += 10;
        Health += 10;
    }
}
