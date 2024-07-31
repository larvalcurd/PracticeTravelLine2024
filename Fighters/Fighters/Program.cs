using Fighters.GameMaster;
using Fighters.Services;

namespace Fighters;

internal class Program
{
    static void Main( string[] args )
    {
        IGameManager gameManager = new GameManager( new FighterService() );
        gameManager.Play();
    }
}