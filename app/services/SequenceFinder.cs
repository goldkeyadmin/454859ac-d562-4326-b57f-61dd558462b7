

using System.Diagnostics;

namespace SequenceFinder.Services
{
  public class Finder
  {
    public int[] findSequenceInArray(int[] numbers)
    {
      int length = 0;
      int[] sequence = [];

      if (numbers.Length == 0) return [];

      int index = numbers.Length - 1;

      do
      {
        int[] tempSequence = this.subSequence(numbers, index);
        if (tempSequence.Length >= length)
        {
          sequence = tempSequence;
          length = tempSequence.Length;
        }
        index -= Math.Max(1, tempSequence.Length);
      }
      while (index >= 0);

      return sequence;
    }

    private int[] subSequence(int[] numbers, int i)
    {
      if (i == 0)
      {
        return [numbers[i]];
      }

      if (numbers[i - 1] < numbers[i])
      {
        return subSequence(numbers, i - 1).Concat([numbers[i]]).ToArray();
      }
      else
      {
        return [numbers[i]];
      }
    }
  }
}