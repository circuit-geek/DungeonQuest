namespace DungeonQuest.Core.Models;

public class Player
{
    public string Name { get; set; }
    public int CurrentHp { get; set; } 
    public int MaxHp { get; set; }
    public List<string> Inventory { get; set; } = new();
    
    public bool IsAlive => CurrentHp > 0;
    public Player(string name, int maxHp)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
    }

    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;
        if (CurrentHp < 0)
        {
            CurrentHp = 0;
        }
    }
}