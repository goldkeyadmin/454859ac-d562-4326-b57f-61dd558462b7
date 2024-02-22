namespace SequenceFinder.Services
{
    public class Finder
    {
        public int[] FindSequenceInArray(int[] numbers)
        {
            int length = 0;
            int[] sequence = [];

            if (numbers.Length == 0) return [];

            int index = numbers.Length - 1;

            do
            {
                int[] tempSequence = this.SubSequence(numbers, index);
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

        public string FindSequenceInString(string numberString)
        {
            if (String.IsNullOrEmpty(numberString))
            {
                return string.Empty;
            }

            int[] numbers = numberString.Split(" ").Select(int.Parse).ToArray();
            int[] sequence = this.FindSequenceInArray(numbers);

            return string.Join(" ", sequence);
        }

        private int[] SubSequence(int[] numbers, int i)
        {
            if (i == 0)
            {
                return [numbers[i]];
            }

            if (numbers[i - 1] < numbers[i])
            {
                return [.. SubSequence(numbers, i - 1), numbers[i]];
            }
            else
            {
                return [numbers[i]];
            }
        }
    }
}