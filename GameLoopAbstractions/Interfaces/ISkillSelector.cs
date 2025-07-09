using GameLoopLib.Models;

namespace Abstractions.Interfaces
{
  public interface ISkillSelector
  {
    ISkill GetSkill(Champion activeChampion);
  }
}
