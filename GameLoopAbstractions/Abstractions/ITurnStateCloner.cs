using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ITurnStateCloner
  {
    TurnState CloneTurnState(TurnState turnState);
  }
}
