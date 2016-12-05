using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceTest
{
    public class Sequence
    {
        private List<int> _inputIntegerList;

        public Sequence(string inputString)
        {
            _inputIntegerList = convertStringArrayToInt(inputString);
        }

        public Sequence()
        {

        }

        public List<List<int>> calculateIncreasingSequences(List<int> integerList)
        {
            List<List<int>> increasingSubSequences = new List<List<int>>();
            increasingSubSequences.Add(new List<int>(){integerList[0]});

            for (int i = 1; i < integerList.Count; i++)
            {
                increasingSubSequences.Add(new List<int>());
                List<int> currentLongestSubSequence = new List<int>();
                for (int n = 0; n < i; n++)
                {
                    //Check to see if current number (i) is higher than check number (n)
                    //Also check to see if the potential new subsequence length (+1) is greater than
                    //the current subsequence length i.e. have we found a longer subsequence
                    if (integerList[n] < integerList[i] && increasingSubSequences[n].Count + 1 > currentLongestSubSequence.Count)
                    {
                        //Create new list not just pointer to other list
                        currentLongestSubSequence = new List<int>(increasingSubSequences[n]);
                    }
                }

                currentLongestSubSequence.Add(integerList[i]);
                increasingSubSequences[i] = currentLongestSubSequence;
            }

            return increasingSubSequences;
        }

        public List<int> findLargestIncreasingSequence(List<List<int>> increasingSubSequences)
        {
            List<int> largestSubSequence = increasingSubSequences[0];
            int maxSubSeuquenceLength = 0;

            foreach (List<int> subSequence in increasingSubSequences)
            {
                if (subSequence.Count > maxSubSeuquenceLength)
                {
                    maxSubSeuquenceLength = subSequence.Count;
                    largestSubSequence = subSequence;
                }
            }

            return largestSubSequence;
        }

        public List<int> convertStringArrayToInt(string listToConvert)
        {
            List<int> integerList = new List<int>();
            string[] temp = listToConvert.Split(' ');
            foreach (string element in temp)
            {
                integerList.Add(Convert.ToInt32(element));
            }

            return integerList;
        }

        public static void printCollection(List<int> collection)
        {
            foreach (int item in collection)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }

        private static bool checkIfIncreasing(List<int> inputList)
        {
            int previousInt = 0;
            bool increasing = true;

            foreach (int item in inputList)
            {
                if (previousInt >= item)
                {
                    increasing = false;
                }

                previousInt = item;
            }

            return increasing;
        }
    }
}