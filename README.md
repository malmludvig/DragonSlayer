# Dragon Slayer

Ett litet konsolspel i C# från lektionen [Dragon Slayer](https://malmludvig.github.io/BED26-lektioner/vecka9.html) (vecka 9).

## Kom igång

1. Klona repot.
2. Öppna `DragonSlayer.slnx` i Visual Studio.
3. Kör programmet (F5).

Eller i terminalen:

```
dotnet run --project DragonSlayer
```

## Vad finns i koden?

| Fil | Begrepp |
|-----|---------|
| `Difficulty.cs` | Enum – fiendens svårighetsgrad |
| `Enemy.cs` | Abstrakt klass – det alla fiender har gemensamt |
| `Goblin.cs`, `Dragon.cs` | Arv – en Goblin *är en* Enemy |
| `IWeapon.cs` | Interface – kontraktet för ett vapen |
| `Sword.cs`, `Bow.cs`, `MagicWand.cs` | Implementationer av `IWeapon` |
| `Player.cs` | Composition – en Player *har ett* IWeapon som kan bytas |
| `Program.cs` | Klass och objekt, polymorfism, byte av vapen och en vapenmeny |
