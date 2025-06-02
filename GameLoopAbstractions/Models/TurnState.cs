using Abstractions.Interfaces;

namespace Abstractions.Models
{
  public sealed class TurnState
  {
    public int TurnCounter { get; set; } = 0;

    public Champion ActiveChampion { get; set; }

    public string SkillId { get; set; }

    public Teams Teams { get; set; }

    public ITurnMeterQueue TurnMeterQueue { get; set; }
  }
}
