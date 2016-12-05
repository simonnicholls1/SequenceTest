using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SequenceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence sequenceCalculator = new Sequence();
            Console.WriteLine("Please enter an array of numbers for example 0 8 4 12 2 10 6 14:");
            string input = Console.ReadLine();
            List<int> integerListInput = sequenceCalculator.convertStringArrayToInt(input);
            List<List<int>> increasingSubSequences = sequenceCalculator.calculateIncreasingSequences(integerListInput);
            List<int> largestSubSequence = sequenceCalculator.findLargestIncreasingSequence(increasingSubSequences);
            Console.WriteLine("The longest sub sequence is:");
            Sequence.printCollection(largestSubSequence);
            Console.ReadLine();
        }
    }
}
