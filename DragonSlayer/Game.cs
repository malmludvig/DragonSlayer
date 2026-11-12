public class Game
{
    private Player player = new Player(new Sword());
    private string weaponName = "Svärd";
    private bool bossDefeated = false;

    // Fienderna som kan dyka upp läses in från enemies.json
    private List<string> enemyNames = EnemyLoader.LoadNames(Path.Combine(AppContext.BaseDirectory, "enemies.json"));

    public void Run()
    {
        Console.WriteLine("=== DRAGON SLAYER ===");
        Console.WriteLine("Drakkungen härjar i landet. Bli stark nog att besegra honom!");

        while (player.IsAlive && !bossDefeated)
        {
            Console.WriteLine();
            ShowStatus();
            Console.WriteLine("1. Gå på äventyr (slåss mot en fiende)");
            Console.WriteLine("2. Vila vid lägerelden");
            Console.WriteLine("3. Besök handlaren");
            Console.WriteLine("4. Utmana Drakkungen");
            Console.WriteLine("0. Avsluta");
            Console.Write("Välj: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Fight(RandomEnemy());
            }
            else if (choice == "2")
            {
                Rest();
            }
            else if (choice == "3")
            {
                Shop();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Du klättrar upp till Drakkungens grotta...");
                Fight(new DragonKing());
            }
            else if (choice == "0" || choice == null)
            {
                Console.WriteLine("Hej då!");
                return;
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }

        Console.WriteLine();
        if (bossDefeated)
        {
            Console.WriteLine("Drakkungen är besegrad! Du är en sann Dragon Slayer!");
        }
        else
        {
            Console.WriteLine("Du har stupat. GAME OVER.");
        }
    }

    private void ShowStatus()
    {
        Console.WriteLine($"Hälsa: {player.Health}/{player.MaxHealth} | Guld: {player.Gold} | Läkedrycker: {player.Potions} | Vapen: {weaponName}");
    }

    private Enemy RandomEnemy()
    {
        // Ett namn som står flera gånger i filen dyker upp oftare
        string name = enemyNames[Random.Shared.Next(enemyNames.Count)];
        return EnemyLoader.Create(name);
    }

    private void Fight(Enemy enemy)
    {
        Console.WriteLine($"En {enemy.Name} ({enemy.Difficulty}) dyker upp!");

        while (enemy.Health > 0 && player.IsAlive)
        {
            Console.WriteLine();
            Console.WriteLine($"{enemy.Name}: {enemy.Health} hälsa | Du: {player.Health}/{player.MaxHealth} hälsa");
            Console.WriteLine("1. Attackera");
            Console.WriteLine($"2. Drick läkedryck ({player.Potions} kvar)");
            Console.WriteLine("3. Fly");
            Console.Write("Välj: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                player.Attack(enemy);
            }
            else if (choice == "2")
            {
                if (player.Potions == 0)
                {
                    Console.WriteLine("Du har inga läkedrycker!");
                    continue;
                }
                player.Potions--;
                player.Heal(40);
                Console.WriteLine("Du dricker en läkedryck och får 40 hälsa.");
            }
            else if (choice == "3" || choice == null)
            {
                if (Random.Shared.Next(2) == 0)
                {
                    Console.WriteLine("Du lyckas fly!");
                    return;
                }
                Console.WriteLine("Du försöker fly men snubblar!");
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
                continue;
            }

            // Fienden slår tillbaka om den fortfarande lever
            if (enemy.Health > 0)
            {
                enemy.Attack();
                player.TakeDamage(enemy.Damage);
                Console.WriteLine($"Du tar {enemy.Damage} i skada.");
            }
        }

        if (enemy.Health == 0)
        {
            int gold = enemy.GoldReward();
            player.Gold += gold;
            player.LevelUp();
            Console.WriteLine($"Du besegrade {enemy.Name} och hittar {gold} guld! Din maxhälsa ökar med 10.");

            if (enemy is DragonKing)
            {
                bossDefeated = true;
            }
        }
    }

    private void Rest()
    {
        Console.WriteLine("Du slår läger och vilar vid elden...");

        // Ibland blir man överfallen när man vilar
        if (Random.Shared.Next(100) < 25)
        {
            Console.WriteLine("En goblin smyger fram ur mörkret!");
            Fight(new Goblin());
            return;
        }

        player.Heal(player.MaxHealth);
        Console.WriteLine("Du vaknar utvilad. Full hälsa!");
    }

    private void Shop()
    {
        Console.WriteLine();
        Console.WriteLine("Handlaren: \"Vad får det lov att vara?\"");
        Console.WriteLine("1. Läkedryck – 15 guld");
        Console.WriteLine("2. Trollstav (15 skada) – 40 guld");
        Console.WriteLine("3. Stridsyxa (25 skada) – 100 guld");
        Console.WriteLine("0. Gå därifrån");
        Console.Write("Välj: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            if (Pay(15))
            {
                player.Potions++;
                Console.WriteLine("Du köper en läkedryck.");
            }
        }
        else if (choice == "2")
        {
            if (Pay(40))
            {
                player.Weapon = new MagicWand();
                weaponName = "Trollstav";
                Console.WriteLine("Du byter till trollstaven.");
            }
        }
        else if (choice == "3")
        {
            if (Pay(100))
            {
                player.Weapon = new Axe();
                weaponName = "Stridsyxa";
                Console.WriteLine("Du byter till stridsyxan.");
            }
        }
    }

    private bool Pay(int price)
    {
        if (player.Gold < price)
        {
            Console.WriteLine("Du har inte råd.");
            return false;
        }
        player.Gold -= price;
        return true;
    }
}
