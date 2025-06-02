using Abstractions.Enums;
using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ITargetSelector
  {
    Champion PickTarget(int activeTeamId, Teams teams, TargetType targetType);
  }
}
