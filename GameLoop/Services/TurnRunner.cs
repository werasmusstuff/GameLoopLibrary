using Abstractions.Interfaces;
using Abstractions.Models;

namespace GameLoop.Services
{
  internal sealed class TurnRunner : ITurnRunner
  {
    private readonly ISkillSelector _skillSelector;
    private readonly ITurnStateCloner _turnStateCloner;

    public TurnRunner(ISkillSelector skillSelector, ITurnStateCloner turnStateCloner)
    {
      _skillSelector = skillSelector;
      _turnStateCloner = turnStateCloner;
    }

    public TurnState Run(TurnState turnState)
    {
      var newState = _turnStateCloner.CloneTurnState(turnState);

      newState.TurnCounter++;

      newState.TurnMeterQueue.ProcessTurnMeter();

      //Tick cds

      TurnMeterChampion turnMeterChampion = newState.TurnMeterQueue.GetNextChampion();

      Champion activeChampion = turnState.Teams.teams[turnMeterChampion.TeamId].Champions[turnMeterChampion.ChampionId];
      newState.ActiveChampion = activeChampion;
      ISkill skill = _skillSelector.GetSkill(activeChampion);
      newState = skill.Execute(newState);
      newState.TurnMeterQueue.ResetTurnMeter(turnMeterChampion);
      return newState;
    }
  }
}
