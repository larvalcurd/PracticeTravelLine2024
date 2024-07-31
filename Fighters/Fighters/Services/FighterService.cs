using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Services;

public class FighterService : IFighterService
{
    private readonly List<IFighter> _fighters = new List<IFighter>();

    public IFighter CreateFighter()
    {
        string name = GetNonEmptyStringFromConsole( "Enter the fighter's name: " );
        IRace race = ChooseRace();
        IWeapon weapon = ChooseWeapon();
        IArmor armor = ChooseArmor();
        IFighter fighter = new Fighter( name, race, weapon, armor );

        _fighters.Add( fighter );

        return fighter;
    }

    public List<IFighter> GetFighters() => _fighters.ToList();

    private string GetNonEmptyStringFromConsole(string message, string errorMessage = "Invalid input. The entered string cannot be empty. Try again." )
    {
        string input = string.Empty;

        while ( true )
        {
            Console.Write( message );
            input = Console.ReadLine();
            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                break;
            }

            Console.WriteLine( errorMessage );
        }

        return input;
    }

    private IRace ChooseRace()
    {
        bool isValidChoise = false;
        IRace race = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Select your fighter race:\n" +
                "1 - Human\n" +
                "2 - Lizard\n" +
                "Input: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    race = new Human();
                    break;
                case "2":
                    race = new Lizard();
                    break;
                default:
                    Console.WriteLine( "Invalid input. Try again." );
                    isValidChoise = false;
                    break;
            };
        }

        return race;
    }

    private IWeapon ChooseWeapon()
    {
        bool isValidChoise = false;
        IWeapon weapon = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Select a fighter's weapon:\n" +
                "1 - Fists\n" +
                "2 - Sword\n" +
                "3 - Bow\n" +
                "Input: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    weapon = new Fists();
                    break;
                case "2":
                    weapon = new Sword();
                    break;
                case "3":
                    weapon = new Bow();
                    break;
                default:
                    Console.WriteLine( "Invalid input. Try again." );
                    isValidChoise = false;
                    break;
            };
        }

        return weapon;
    }

    private IArmor ChooseArmor()
    {
        bool isValidChoise = false;
        IArmor armor = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Choose a fighter's armor:\n" +
                "1 - Without Armor\n" +
                "2 - Human Armor\n" +
                "3 - Lizard Armor\n" +
                "Input: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    armor = new NoArmor();
                    break;
                case "2":
                    armor = new HumanArmor();
                    break;
                case "3":
                    armor = new LizardArmor();
                    break;
                default:
                    Console.WriteLine( "Invalid input. Try again." );
                    isValidChoise = false;
                    break;
            };
        }

        return armor;
    }
}
