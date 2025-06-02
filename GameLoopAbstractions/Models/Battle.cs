namespace Abstractions.Models
{
  public sealed class Battle
  {
    public Teams StartingTeams { get; set; }

    public int Winner { get; set; }

    public List<TurnState> Turns { get; set; }
  }
}
