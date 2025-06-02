using Abstractions.Interfaces;
using Abstractions.Models;

namespace GameLoop.Services
{
  public sealed class BattleRunner : IBattleRunner
  {
    private readonly ITurnRunner _turnRunner;
    private readonly ITurnMeterQueue _turnMeterQueue;
    private List<TurnState> turnCollection;

    public BattleRunner(ITurnRunner turnRunner, ITurnMeterQueue turnMeterQueue)
    {
      _turnRunner = turnRunner;
      _turnMeterQueue = turnMeterQueue;
    }

    public Battle RunBattle(Teams teams, int turns = 50)
    {
      Battle battleReturn = new();
      int winnerId;
      turnCollection = new List<TurnState>();

      var turnState = BuildInitialTurnState(teams);

      for (int i = 0; i < turns; i++)
      {
        turnState = _turnRunner.Run(turnState);
        turnCollection.Add(turnState);

        winnerId = DetermineWinner(turnState);

        if (winnerId <= 0)
        {
          continue;
        }
        else
        {
          battleReturn.Winner = winnerId;
          break;
        }
      }

      battleReturn.StartingTeams = teams;

      //battleReturn.Result  (turns1[turns.length - 1]).winner;
      battleReturn.Turns = turnCollection;

      return battleReturn;
    }

    private static int DetermineWinner(TurnState turnState)
    {
      bool isAlive;

      foreach (var key in turnState.Teams.teams.Keys)
      {
        isAlive = false;

        if (key == turnState.ActiveChampion.TeamId)
        {
          continue;
        }

        foreach (var champion in turnState.Teams.teams[key].Champions.Values)
        {
          if (champion.isAlive)
          {
            isAlive = true;
            break;
          }
        }

        if (!isAlive)
        {
          return turnState.ActiveChampion.TeamId;
        }
      }

      return -1000;
    }

    private TurnState BuildInitialTurnState(Teams teams)
    {
      TurnState turnState = new TurnState();

      foreach (var team in teams.teams.Values)
      {
        foreach (var champion in team.Champions.Values)
        {
          _turnMeterQueue.Add(new TurnMeterChampion 
          { 
            ChampionId = champion.ChampionId,
            TeamId = champion.TeamId,
            TurnMeter = 0,
            Speed = champion.Speed
          });
        }
      }

      turnState.TurnMeterQueue = _turnMeterQueue;
      turnState.Teams = teams;

      return turnState;
    }
  }
}
