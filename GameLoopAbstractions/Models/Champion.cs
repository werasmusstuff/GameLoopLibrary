using Abstractions.Interfaces;
using GameLoopLib.Enums;

namespace GameLoopLib.Models
{
  public sealed class Champion : ChampionState
  {
    public Champion(int championId)
    {
      ChampionId = championId;
    }

    public ChampionType championType { get; set; }

    public int ChampionId { get; set; }

    public string Name { get; set; }

    public int DamagePower { get; set; }

    public int Stamina { get; set; }

    public int Defense { get; set; }

    public int MaxHealth { get; set; }

    public int Speed { get; set; }

    public List<ISkill> Skills { get; set; }
  }
}
