using DungeonQuest.Core.Enums;
using DungeonQuest.Core.Models;

namespace DungeonQuest.Core.Systems;

public class GameManager
{
    public Player Player { get; private set; }
    public Enemy ActiveEnemy { get; private set; }
    public GameState CurrentState { get; private set; }

    public GameManager(string playerName)
    {
        Player = new Player(playerName, 30);
        CurrentState = GameState.WakingUp;
        ActiveEnemy = new Enemy("Dire Wolf", 15, 6);
    }

    // This void method takes the user's terminal input and shifts the game state
    public void HandleChoice(string input)
    {
        // 1. First, branch based on which CHAPTER the player is currently in
        switch (CurrentState)
        {
            case GameState.WakingUp:
                if (input == "1")
                {
                    CurrentState = GameState.SwordFound;
                }
                break;

            case GameState.SwordFound:
                if (input == "1")
                {
                    Player.Inventory.Add("Rusty Sword");
                    CurrentState = GameState.WolfAmbush;
                }
                else if (input == "2")
                {
                    // Chose to leave it behind! Bold strategy.
                    CurrentState = GameState.WolfAmbush;
                }
                break;

            case GameState.WolfAmbush:
                if (input == "1") // Attack!
                {
                    // If they have the sword, deal more damage
                    int damageDealt = Player.Inventory.Contains("Rusty Sword") ? 8 : 3;
                    ActiveEnemy.Hp -= damageDealt;

                    // Wolf counter-attacks if it survives
                    if (ActiveEnemy.Hp > 0)
                    {
                        Player.TakeDamage(ActiveEnemy.AttackPower);
                    }
                    
                    CheckCombatOutcomes();
                }
                break;
        }
    }

    private void CheckCombatOutcomes()
    {
        if (!Player.IsAlive)
        {
            CurrentState = GameState.GameOver;
        }
        else if (ActiveEnemy.Hp <= 0)
        {
            CurrentState = GameState.Victory;
        }
    }
}