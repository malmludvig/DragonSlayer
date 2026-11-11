// Koden från lektionen, steg för steg
public static class Examples
{
    public static void Run()
    {
        // 1. Klass och objekt – två gobliner har var sin hälsa
        Goblin first = new Goblin();
        Goblin second = new Goblin();

        first.TakeDamage(10);

        Console.WriteLine(first.Health);    // 20
        Console.WriteLine(second.Health);   // 30
        Console.WriteLine();

        // 2. Polymorfism – samma anrop, olika beteende
        List<Enemy> enemies = new List<Enemy>
        {
            new Goblin(),
            new Dragon()
        };

        foreach (Enemy e in enemies)
        {
            e.Attack();
        }
        Console.WriteLine();

        // 3. Composition – spelaren har ett vapen som kan bytas
        Player player = new Player(new Sword());
        Enemy goblin = new Goblin();

        player.Attack(goblin);

        player.Weapon = new Bow();

        player.Attack(goblin);

        Console.WriteLine($"Fiendens hälsa: {goblin.Health}");   // 12
    }
}
