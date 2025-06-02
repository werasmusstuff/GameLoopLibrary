using Abstractions.Enums;
using Abstractions.Interfaces;
using Abstractions.Models;

namespace GameLoop.Services
{
  internal sealed class RandomTargetSelector : ITargetSelector
  {
    public IRandomNumberGenerator _randomNumberGenerator { get; }

    public RandomTargetSelector(IRandomNumberGenerator randomNumberGenerator)
    {
      _randomNumberGenerator = randomNumberGenerator;
    }

    public Champion PickTarget(int activeTeamId, Teams teams, TargetType targetType)
    {
      Team team = new Team();

      switch (targetType)
      {
        case TargetType.Enemy:
          team = GetEnemyTeam(activeTeamId, teams);
          break;
        case TargetType.Friendly:
          team = GetFriendlyTeam(activeTeamId, teams);
          break;
        default:
          break;
      }

      return team.Champions.Where(entry => entry.Value.isAlive)
            .OrderBy(_ => _randomNumberGenerator.GenerateRandomNumber())
            .FirstOrDefault()
            .Value; 

      //Where (_randomNumberGenerator.GenerateRandomNumber(0,4)).Value;
    }

    private static Team GetFriendlyTeam(int activeTeamId, Teams teams)
    { 
      return teams.teams[activeTeamId]; 
    }

    private static Team GetEnemyTeam(int activeTeamId, Teams teams)
    {
      Team team = new Team(0);

      foreach (var key in teams.teams.Keys)
      {
        if (key != activeTeamId)
        {
          team = teams.teams[key];
          break;
        }
      }

      return team;
    }


  }
}
