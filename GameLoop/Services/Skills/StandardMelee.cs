using Abstractions.Enums;
using Abstractions.Interfaces;
using Abstractions.Models;

namespace GameLoop.Services.Skills
{
  public sealed class StandardMelee : ISkill
  {
    public ITargetSelector _targetSelector { get; }

    public  TargetType _targetType { get; }

    public readonly int _maxCooldown = 0;

    public int CurrentCooldown { get; set; }

    public StandardMelee(ITargetSelector targetSelector)
    {
      _targetSelector = targetSelector;
      _targetType = TargetType.Enemy;
    }

    public TurnState Execute(TurnState turnState)
    {
      Champion target = _targetSelector.PickTarget(turnState.ActiveChampion.TeamId, turnState.Teams, _targetType);
      target.ActiveHealth -= calculateDamage(turnState.ActiveChampion);

      if (target.ActiveHealth <= 0)
      { 
        Console.WriteLine(turnState.ActiveChampion.ChampionId.ToString() + " killed " + target.ChampionId.ToString());
        turnState.TurnMeterQueue.Remove(new TurnMeterChampion { ChampionId = target.ChampionId, TeamId = target.TeamId, Speed = target.Speed, TurnMeter = target.TurnMeter });
        target.isAlive = false;
      }

      turnState.Teams.teams[target.TeamId].Champions[target.ChampionId] = target;

      CurrentCooldown = _maxCooldown;
      return turnState;
    }

    private int calculateDamage(Champion champion)
    {
      return 100 + champion.DamagePower;
    }
  }
}
