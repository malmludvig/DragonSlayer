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

// 4. Extra utmaning – välj vapen tills draken är besegrad
Enemy enemy = new Dragon();

while (enemy.Health > 0)
{
    Console.WriteLine();
    Console.WriteLine($"{enemy.Name} har {enemy.Health} i hälsa.");
    Console.WriteLine("1. Svärd");
    Console.WriteLine("2. Pilbåge");
    Console.WriteLine("3. Trollstav");
    Console.Write("Välj vapen: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        player.Weapon = new Sword();
    }
    else if (choice == "2")
    {
        player.Weapon = new Bow();
    }
    else if (choice == "3")
    {
        player.Weapon = new MagicWand();
    }
    else
    {
        Console.WriteLine("Ogiltigt val.");
        continue;
    }

    player.Attack(enemy);

    if (enemy.Health > 0)
    {
        enemy.Attack();
    }
}

Console.WriteLine($"{enemy.Name} är besegrad!");
