namespace tests;

using SequenceFinder.Services;

[TestClass]
public class SequenceFinderTests
{
    [TestClass]
    public class WithAnEmptyArrayOfNumbers
    {
        int[] numbers = [];
        [TestMethod]
        public void ItShouldReturnAnEmptyArray()
        {
            int[] expected = [];
            int[] actual = new Finder().findSequenceInArray(numbers);
            CollectionAssert.AreEqual(actual, expected);
        }
    }

    [TestClass]
    public class WithASingleValueInNumbers
    {
        int[] numbers = [6];

        [TestMethod]
        public void ItShouldReturnTheExpectedResult()
        {
            int[] expected = [6];
            int[] actual = new Finder().findSequenceInArray(numbers);
            CollectionAssert.AreEqual(actual, expected);
        }
    }

    [TestClass]
    public class WithASingleSequenceWithinTheArray
    {
        int[] numbers = [6, 1, 5, 9, 2];

        [TestMethod]
        public void ItShouldReturnTheExpectedSequence()
        {
            int[] expected = [1, 5, 9];
            int[] actual = new Finder().findSequenceInArray(numbers);
            CollectionAssert.AreEqual(actual, expected);
        }
    }

    [TestClass]
    public class WithASingleSequenceAtStartOfTheArray
    {
        int[] numbers = [1, 5, 9, 2, 6];

        [TestMethod]
        public void ItShouldReturnTheExpectedSequence()
        {
            int[] expected = [1, 5, 9];
            int[] actual = new Finder().findSequenceInArray(numbers);
            CollectionAssert.AreEqual(actual, expected);
        }
    }

    [TestClass]
    public class WithNoSequenceInArray
    {
        int[] numbers = [5, 4, 3, 2, 1];

        [TestMethod]
        public void ItShouldReturnTheFirstArrayElement()
        {
            int[] expected = [5];
            int[] actual = new Finder().findSequenceInArray(numbers);
            CollectionAssert.AreEqual(actual, expected);
        }
    }
}