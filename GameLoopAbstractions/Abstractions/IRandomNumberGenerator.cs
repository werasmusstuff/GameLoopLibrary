namespace Abstractions.Interfaces
{
  public interface IRandomNumberGenerator
  {
    int GenerateRandomNumber(int minValue, int maxValue);

    int GenerateRandomNumber();
  }
}
