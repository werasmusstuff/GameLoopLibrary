using Abstractions.Interfaces;

namespace GameLoop.Services
{
  internal sealed class RandomNumberGenerator : IRandomNumberGenerator
  {
    private readonly Random _random;

    public RandomNumberGenerator()
    {
      _random = new Random();  
    }

    public int GenerateRandomNumber(int minValue, int maxValue)
    {
      return _random.Next(minValue, maxValue);
    }

    public int GenerateRandomNumber()
    { 
      return _random.Next();
    }
  }
}
