namespace Abstractions.Models
{
  public sealed class Team
  {
    public Team(int uniqueIdentifier)
    {
      UniqueIdentifier = uniqueIdentifier;
    }

    public Team()
    {

    }

    public int UniqueIdentifier { get; set; }

    public Dictionary<int, Champion> Champions { get; set; }

    public bool isAlive { get; set; }
  }
}
