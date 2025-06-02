using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ISkill
  {
    public int CurrentCooldown { get; set; }

    public TurnState Execute(TurnState turnState);
  }
}
