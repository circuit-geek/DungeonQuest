namespace DungeonQuest.Core.Models;

public class Enemy
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int AttackPower { get; set; }

    public Enemy(string name, int hp, int attackPower)
    {
        Name = name;
        Hp = hp;
        AttackPower = attackPower;
    }
}