using Abstractions.Models;

namespace Abstractions.Interfaces
{
  public interface ISkillSelector
  {
    ISkill GetSkill(Champion activeChampion);
  }
}
