using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ITurnMeterQueue
  {
    void Add(TurnMeterChampion champion);

    TurnMeterChampion GetNextChampion();

    void ProcessTurnMeter();

    void ResetTurnMeter(TurnMeterChampion champion);

    void Remove(TurnMeterChampion champion);
  }
}
