namespace SequenceFinder.Services
{
    /// <summary>
    /// Finder class to find subsequences in strings and arrays
    /// </summary>
    public class Finder
    {
        /// <summary>
        /// Find largest increasing subsequence in the passed array
        /// </summary>
        /// <param name="numbers">The array of numbers to check</param>
        /// <returns>An array containing the largest subsequence found</returns>
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

        /// <summary>
        /// Find the largest increasing subsequence 
        /// </summary>
        /// <param name="numberString">A space delimited string of numbers</param>
        /// <returns>A string containing the sequence found</returns>
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