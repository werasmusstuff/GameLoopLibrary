using Microsoft.Extensions.DependencyInjection;
using GameLoop.Services;
using Abstractions.Interfaces;

namespace GameLoop.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddGameLoopLibrary(this IServiceCollection services)
    {
      services.AddSingleton<IBattleRunner, BattleRunner>();
      services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>();
      services.AddSingleton<ISkillSelector, SkillSelector>();
      services.AddSingleton<ITargetSelector, RandomTargetSelector>();
      services.AddSingleton<ITurnMeterQueue, TurnMeterQueue>();
      services.AddSingleton<ITurnRunner, TurnRunner>();
      services.AddSingleton<ITurnStateCloner, TurnStateCloner>();

      return services;
    }
  }
}
