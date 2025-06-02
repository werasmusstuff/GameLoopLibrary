using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ITurnRunner
  {
    TurnState Run(TurnState turnState);
  }
}
