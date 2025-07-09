using GameLoopLib.Enums;
using GameLoopLib.Models;

namespace Abstractions.Interfaces
{
  public interface ITargetSelector
  {
    Champion PickTarget(int activeTeamId, Teams teams, TargetType targetType);
  }
}
