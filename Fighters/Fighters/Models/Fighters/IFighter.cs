using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public interface IFighter
{
    IRace Race { get; }
    IWeapon Weapon { get; }
    IArmor Armor { get; }
    string Name { get; }
    int CurrentHealth { get; }
    int ArmorPoints { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    int Damage { get; }
    int TakeDamage( int damage );
    int CalculateDamage();
}
