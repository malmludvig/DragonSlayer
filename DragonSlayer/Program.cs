Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("1. Spela Dragon Slayer");
Console.WriteLine("2. Kör exemplen från lektionen");
Console.Write("Välj: ");
string choice = Console.ReadLine();

if (choice == "2")
{
    Examples.Run();
}
else
{
    Game game = new Game();
    game.Run();
}
