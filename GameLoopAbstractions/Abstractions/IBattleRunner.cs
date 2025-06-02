using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface IBattleRunner
  {
    Battle RunBattle(Teams teams, int turns);
  }
}
