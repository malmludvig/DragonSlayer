public class Player
{
    public IWeapon Weapon { get; set; }

    public Player(IWeapon weapon)
    {
        Weapon = weapon;
    }

    public void Attack(Enemy enemy)
    {
        int damage = Weapon.Use();
        enemy.TakeDamage(damage);
    }
}
