using Fighters.Models.Fighters;
using Fighters.Services;

namespace Fighters.GameMaster;

public class GameManager : IGameManager
{
    private readonly IFighterService _fighterService;

    public GameManager( IFighterService fighterService )
    {
        _fighterService = fighterService;
    }

    public void Play()
    {
        Console.WriteLine( "Welcome to the game!" );

        bool isExit = false;
        while ( !isExit )
        {
            ShowMenu();
            string command = Console.ReadLine().ToLower().Trim();
            switch ( command )
            {
                case "add-fighter":
                    CreateFighter();
                    break;
                case "fight":
                    Fight();
                    break;
                case "fighters":
                    ShowFighters();
                    break;
                case "exit":
                    Console.WriteLine( "GG! Bye-bye!" );
                    isExit = true;
                    break;
                default:
                    Console.WriteLine( $"Command '{command}' not recognized." );
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine( "---------------------------------------" );
        Console.WriteLine( "Available commands:" );
        Console.WriteLine( "add-fighter - Add a fighter to the arena" );
        Console.WriteLine( "fight - Start the fight" );
        Console.WriteLine( "fighters - Show list of fighters" );
        Console.WriteLine( "exit - Exit" );
        Console.Write( "Input: " );
    }

    private void CreateFighter()
    {
        IFighter fighter = _fighterService.CreateFighter();
        Console.WriteLine( $"Fighter {fighter.Name} successfully created." );
    }

    private void Fight()
    {
        int round = 0;
        List<IFighter> fighters = _fighterService.GetFighters();
        int fighterCount = fighters.Count;
        if ( fighterCount < 2 )
        {
            ShowFighterCountError( fighterCount );
            return;
        }

        Console.WriteLine( "The fight begins!" );
        while ( fighters.Count( f => f.IsAlive ) > 1 )
        {
            Console.WriteLine( $"Round {++round}" );

            fighters = fighters.OrderBy( f => Random.Shared.Next() ).ToList();

            foreach ( IFighter fighter in fighters )
            {
                if ( !fighter.IsAlive )
                {
                    continue;
                }

                IFighter opponent = fighters.Where( f => f != fighter && f.IsAlive ).OrderBy( f => Random.Shared.Next() ).First();
                Attack( fighter, opponent );
            }

            WaitForKeyPress();

            ShowFighters( "Current status of fighters:" );

            WaitForKeyPress();
        }

        IFighter winner = fighters.FirstOrDefault( f => f.IsAlive );

        Console.WriteLine( $"{winner.Name} won!" );
    }

    private void ShowFighters( string message = "List of fighters:" )
    {
        List<IFighter> fighters = _fighterService.GetFighters();

        if ( fighters.Count == 0 )
        {
            Console.WriteLine( "The list is empty." );
            return;
        }

        Console.WriteLine( message + "\n" );
        foreach ( IFighter fighter in fighters )
        {
            Console.WriteLine( fighter + "\n" );
        }
    }

    private void Attack( IFighter fighter, IFighter opponent )
    {
        int damage = fighter.CalculateDamage();
        int damageTaken = opponent.TakeDamage( damage );
        Console.WriteLine( $"{fighter.Name} attacks {opponent.Name} with damage {damage}." );
        if ( damageTaken < damage )
        {
            Console.WriteLine( $"{opponent.Name} gets {damageTaken} damage and {( opponent.IsAlive ? "survives" : "dies" )}." );
        }
        else
        {
            Console.WriteLine( $"{opponent.Name} gets {damageTaken} damage and {( opponent.IsAlive ? "survives" : "dies" )}." );
        }
    }

    private void WaitForKeyPress()
    {
        Console.WriteLine( "Press any key to continue." );
        Console.ReadKey();
    }

    private void ShowFighterCountError( int fighterCount )
    {
        Console.WriteLine( "Unable to start a battle." );
        Console.WriteLine( $"Minimum number of fighters for battle: 2." );
        Console.WriteLine( $"Current number of fighters: {fighterCount}." );
        Console.WriteLine( $"Add another {2 - fighterCount} fighter/s." );
    }
}