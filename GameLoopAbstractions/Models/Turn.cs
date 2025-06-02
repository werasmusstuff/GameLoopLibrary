using Abstractions.Interfaces;
using Abstractions.Models;

namespace Models.Models
{
  public sealed class Turn
  {
    public Champion ActiveChampion { get; set; }

    public string SkillId { get; set; }

    public List<Team> Teams { get; set; }

    public ITurnMeterQueue turnMeterQueue { get; set; }
  }
}
