using Abstractions.Interfaces;
using Abstractions.Models;
using FastDeepCloner;

namespace DataGeneration.Implementations
{
  internal sealed class TurnStateCloner : ITurnStateCloner
  {
    public TurnState CloneTurnState(TurnState turnState)
    {
      var newState = DeepCloner.Clone(turnState);
      newState.TurnMeterQueue = turnState.TurnMeterQueue;

      foreach (var teamkey in newState.Teams.teams.Keys)
      {
        foreach (var championKey in turnState.Teams.teams[teamkey].Champions.Keys)
        {
          newState.Teams.teams[teamkey].Champions[championKey].Skills = turnState.Teams.teams[teamkey].Champions[championKey].Skills;
        }

        //newState.Teams.teams[key].Champions = turnState.Teams.teams[key].Champions;     
      }

      return newState;
    }
  }
}
