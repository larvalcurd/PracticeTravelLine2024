using Fighters.Models.Fighters;

namespace Fighters.Services;

public interface IFighterService
{
    IFighter CreateFighter();
    List<IFighter> GetFighters();
}