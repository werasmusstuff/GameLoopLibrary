using GameLoopLib.Models;

namespace Abstractions.Interfaces
{
  public interface ITurnStateCloner
  {
    TurnState CloneTurnState(TurnState turnState);
  }
}
