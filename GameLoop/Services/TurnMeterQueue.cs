using Abstractions.Interfaces;
using Abstractions.Models;
namespace DataGeneration.Implementations
{
  internal sealed class TurnMeterQueue : ITurnMeterQueue
  {
    internal List<TurnMeterChampion> heap { get; set; } = new();

    public void Add(TurnMeterChampion champion)
    {
      heap.Add(champion);
      HeapifyUp(heap.Count - 1);
    }

    public TurnMeterChampion GetNextChampion()
    {
      if (heap.Count == 0)
        throw new InvalidOperationException("No champions available.");

      var top = heap[0];
      Swap(0, heap.Count - 1);
      heap.RemoveAt(heap.Count - 1);
      HeapifyDown(0);
      return top;
    }

    public void ProcessTurnMeter()
    {
      foreach (var champion in heap)
      {
        champion.TurnMeter += champion.Speed;
      }

      for (int i = heap.Count / 2 - 1; i >= 0; i--)
      {
        HeapifyDown(i);
      }
    }

    public void ResetTurnMeter(TurnMeterChampion champion)
    {
      champion.TurnMeter = 0;
      Add(champion);
    }

    public void Remove(TurnMeterChampion champion)
    {
      foreach (var item in heap)
      { 
        if (item.ChampionId == champion.ChampionId)
        {
          heap.Remove(item);
          break;
        }
      }
    }

    private void HeapifyUp(int index)
    {
      while (index > 0)
      {
        int parentIndex = (index - 1) / 2;
        if (heap[index].TurnMeter > heap[parentIndex].TurnMeter)
        {
          Swap(index, parentIndex);
          index = parentIndex;
        }
        else break;
      }
    }

    private void HeapifyDown(int index)
    {
      int lastIndex = heap.Count - 1;

      while (index < lastIndex)
      {
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;
        int largest = index;

        if (leftChild <= lastIndex && heap[leftChild].TurnMeter > heap[largest].TurnMeter)
          largest = leftChild;

        if (rightChild <= lastIndex && heap[rightChild].TurnMeter > heap[largest].TurnMeter)
          largest = rightChild;

        if (largest != index)
        {
          Swap(index, largest);
          index = largest;
        }
        else break;
      }
    }

    private void Swap(int i, int j)
    {
      (heap[i], heap[j]) = (heap[j], heap[i]);
    }
  }
}
