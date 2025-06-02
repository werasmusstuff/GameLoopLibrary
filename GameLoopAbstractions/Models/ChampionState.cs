namespace Abstractions.Models
{
  public class ChampionState
  {
    public int TurnMeter { get; set; }

    public int TeamId { get; set; }

    public bool isAlive { get; set; }

    public int ActiveHealth { get; set; }
  }
}