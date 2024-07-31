namespace Fighters.Models.Races;

public class Human : IRace
{
    public string Name => "Human";
    public int Health => 30;
    public int Damage => 4;
    public int Armor => 1;
}
