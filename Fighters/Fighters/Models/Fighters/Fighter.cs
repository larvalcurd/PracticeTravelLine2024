using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public class Fighter : IFighter
{
    public IRace Race { get; }

    public IWeapon Weapon { get; }

    public IArmor Armor { get; }

    public string Name { get; }

    public int CurrentHealth { get; private set; }

    public int ArmorPoints { get; private set; }
    public int MaxHealth { get; }

    public int Damage => Race.Damage + Weapon.Damage;

    public bool IsAlive => CurrentHealth > 0;

    public Fighter( string name, IRace race, IWeapon weapon, IArmor armor )
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        MaxHealth = Race.Health;
        CurrentHealth = MaxHealth;
        ArmorPoints = Race.Armor + Armor.Armor;
    }

    public int CalculateDamage()
    {
        const double MinMultiplierDamage = 0.8;
        const double MaxMultiplierDamage = 1.2;
        const double CriticalPercentChance = 20;
        const int CriticalMultiplier = 2;


        double attackMultiplier = ( double )Random.Shared.Next( ( int )( MinMultiplierDamage * 100 ), ( int )( MaxMultiplierDamage * 100 + 1 ) ) / 100;
        int fighterDamage = ( int )( Damage * attackMultiplier );

        bool isCriticalAttack = Random.Shared.Next( 1, 101 ) < CriticalPercentChance;

        if ( isCriticalAttack )
        {
            fighterDamage *= CriticalMultiplier;
        }

        return fighterDamage;

    }

    public int TakeDamage (int opponentDamage)
    {
        int startHealth = CurrentHealth;
        int newHealth = CurrentHealth - opponentDamage;

        if ( newHealth < 0 )
        {
            newHealth = 0;
        }

        CurrentHealth = newHealth;

        int damageDealt = startHealth - CurrentHealth;

        return damageDealt;
    }


    public override string ToString()
    {
        return $"Fighter: {Name}\n" + 
            $"Race: {Race.Name}\n" +
            $"Weapon: {Weapon.Name}\n" +
            $"Armor: {Armor.Name}\n" +
            $"Maximum Health: {MaxHealth}\n" +
            $"Current Health: {CurrentHealth}\n" +
            $"Armor Points: {ArmorPoints}\n" +
            $"Damage: {Damage}\n" +
            $"State: {( IsAlive ? "Alive" : "RIP" )}";
    }
}

