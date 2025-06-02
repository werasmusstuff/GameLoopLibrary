using Abstractions.Interfaces;
using Abstractions.Models;

namespace GameLoop.Services
{
  internal sealed class SkillSelector : ISkillSelector
  {
    public ISkill GetSkill(Champion activeChampion)
    {
      return activeChampion.Skills[0];
    }
  }
}
