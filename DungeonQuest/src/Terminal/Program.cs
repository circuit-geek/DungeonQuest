using System;
using DungeonQuest.Core.Enums;
using DungeonQuest.Core.Systems;

Console.WriteLine("=== Welcome to DungeonQuest ===");
Console.Write("Enter your character's name: ");
string name = Console.ReadLine() ?? "Hero";

GameManager game = new GameManager(name);

// THE GAME LOOP: Keeps running until the player wins or dies
while (game.CurrentState != GameState.Victory && game.CurrentState != GameState.GameOver)
{
    Console.Clear(); // Keeps our terminal clean and retro
    Console.WriteLine($"--- {game.Player.Name} | HP: {game.Player.CurrentHp} ---");
    Console.WriteLine("=====================================");

    // Render the story depending on the current active state
    switch (game.CurrentState)
    {
        case GameState.WakingUp:
            Console.WriteLine("You wake up on a cold stone floor. Darkness surrounds you.");
            Console.WriteLine("1. Look around the room.");
            break;

        case GameState.SwordFound:
            Console.WriteLine("Your hand brushes against a cold metallic object. It's a Rusty Sword!");
            Console.WriteLine("1. Pick up the sword.");
            Console.WriteLine("2. Ignore it and walk forward.");
            break;

        case GameState.WolfAmbush:
            Console.WriteLine($"A snarling {game.ActiveEnemy.Name} (HP: {game.ActiveEnemy.Hp}) leaps from the shadows!");
            Console.WriteLine("1. Attack the wolf!");
            break;
    }

    Console.Write("\nWhat do you do? > ");
    string choice = Console.ReadLine();
    
    // Pass the input to our core manager to process state transitions
    game.HandleChoice(choice);
}

// END GAME SCREENS
Console.Clear();
if (game.CurrentState == GameState.Victory)
{
    Console.WriteLine("🎉 VICTORY! You defeated the wolf and escaped the dungeon entrance!");
}
else
{
    Console.WriteLine("💀 GAME OVER. You perished in the darkness.");
}