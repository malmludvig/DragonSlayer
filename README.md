# Dragon Slayer

Ett litet RPG i konsolen, skrivet i C# till lektionen [Dragon Slayer](https://malmludvig.github.io/BED26-lektioner/vecka9.html) (vecka 9).

## Kom igång

1. Klona repot.
2. Öppna `DragonSlayer.slnx` i Visual Studio.
3. Kör programmet (F5) och välj **1. Spela Dragon Slayer** – eller **2** för att köra exemplen från lektionen.

Eller i terminalen:

```
dotnet run --project DragonSlayer
```

## Spelet

Drakkungen härjar i landet. Bli stark nog att besegra honom!

| Val | Vad händer |
|-----|------------|
| Gå på äventyr | Slåss mot en goblin, ett troll eller en drake. Vinn guld och få mer maxhälsa. |
| Vila vid lägerelden | Få full hälsa – men ibland smyger en goblin fram ur mörkret. |
| Besök handlaren | Köp läkedrycker, en trollstav eller en stridsyxa. |
| Utmana Drakkungen | Slutbossen. Besegra honom och vinn spelet. |

I striden kan du **attackera**, **dricka en läkedryck** eller försöka **fly**.

| Fiende | Hälsa | Skada | Svårighet | Guld |
|--------|-------|-------|-----------|------|
| Goblin | 30 | 5 | Easy | 10 |
| Troll | 60 | 9 | Medium | 25 |
| Drake | 100 | 10 | Hard | 50 |
| Drakkungen | 180 | 16 | Hard | 50 |

## Vad finns i koden?

| Fil | Begrepp |
|-----|---------|
| `Difficulty.cs` | Enum – fiendens svårighetsgrad |
| `Enemy.cs` | Abstrakt klass – det alla fiender har gemensamt |
| `Goblin.cs`, `Troll.cs`, `Dragon.cs`, `DragonKing.cs` | Arv – en Goblin *är en* Enemy |
| `IWeapon.cs` | Interface – kontraktet för ett vapen |
| `Sword.cs`, `Bow.cs`, `MagicWand.cs`, `Axe.cs` | Implementationer av `IWeapon` |
| `Player.cs` | Composition – en Player *har ett* IWeapon som kan bytas |
| `Game.cs` | Spelet: menyn, striderna, vilan och handlaren |
| `enemies.json` | Vilka fiender som kan dyka upp på äventyret. Ett namn som står flera gånger dyker upp oftare. |
| `EnemyLoader.cs` | Läser JSON-filen och gör om namnen till fiendeobjekt |
| `Examples.cs` | Exemplen från lektionen, steg för steg |
| `Program.cs` | Startmenyn |

## Bygg vidare

- Ändra i `enemies.json` så att det kommer fler drakar.
- Lägg till en ny fiende, till exempel en `Skeleton`. Vad behöver du ändra i `EnemyLoader.cs` och `enemies.json`?
- Lägg till ett nytt vapen hos handlaren.
- Låt Drakkungen göra dubbel skada var tredje runda.
