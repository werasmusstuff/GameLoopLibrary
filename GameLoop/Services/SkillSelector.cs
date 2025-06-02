using Abstractions.Interfaces;
using Abstractions.Models;

namespace DataGeneration.Implementations
{
  internal sealed class SkillSelector : ISkillSelector
  {
    public ISkill GetSkill(Champion activeChampion)
    {
      return activeChampion.Skills[0];
    }
  }
}
