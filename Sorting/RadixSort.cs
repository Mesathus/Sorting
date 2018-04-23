using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class RadixSort
    {
        /* By: John O'Brien, James Doggett
         * Date: 4/22/2018
         * Last Updated: 4/23/2018
         * Version: 1.0
         * 
         * Precondition: Unsorted integer array
         * Postcondition: Integer array sorted by Radix sort
         * 
         * This sort aims to create a non-comparative Radix sort.  It recieves an array and creates
         * a second array of queues to hold the numbers as it reorganizes them beginning with least 
         * significant digit.  It first measures the length of the longest number in the array to set
         * a maximum on number of times it must reorganize.  It then loops through the sort a number of
         * times equal to this length.
         * 
         * Currently this sort is less efficient than the Quicksort, most likely due to overcomplexity.
         * Example Radix sorts tend to use two arrays rather than building queues, presumably to 
         * reduce overhead.  This sort does currently have an advantage in that the QuickSort presently
         * throws StackOverflow errors on ascending and descending arrays of 500k items, and on random
         * arrays of 500k items if the range of numbers is too small.
         */
        public static void RSort(int[] arrayToSort)
        {
            Queue[] buckets = new Queue[10];    //create the array for out queues
            for(int i = 0; i < buckets.Length; i++) //loop to instantiate the queues in our list
            {                                       //perhaps this could be changed to a check on insert
                buckets[i] = new Queue();           //if we don't expect to use them all, which is a pipedream
            }
            /*
             * This next loop sequence is to obtain the largest value in our array so we know how many
             * digits are in our largest number.
             */
            int max = arrayToSort[0];
            for (int i = 0; i < arrayToSort.Length; i++)
                if (arrayToSort[i] > max)
                    max = arrayToSort[i];
            int order = max.ToString().Length;
            int place = 1;  //this is used to determine what power we raise our modular division to
            while (place <= order)  //check that we still have digits left to check
            {
                for (int i = 0; i < arrayToSort.Length; i++)  //this fills our queue array with the 
                {                                             //current significant digit sorted value
                    int listSpot = (arrayToSort[i] % Power(10,place)) / Power(10, (place - 1));
                    buckets[listSpot].Enqueue(arrayToSort[i]);
                }
                int sortIndex = 0;  //this index is used to move through the queue array to rebuild the original
                for(int i = 0; i < buckets.Length; i ++)
                {
                    while (buckets[i].head != null) //skips queues that have no numbers in them
                    {
                        //Queue.Node temp = buckets[i].Dequeue();
                        //
                        arrayToSort[sortIndex] = buckets[i].Dequeue().Value; //temp.Value;
                        sortIndex++;    //advances us through our sorted array as we dequeue items
                    }
                    //PrintArray(arrayToSort);
                }
                //PrintArray(arrayToSort);
                place++;    //advances to the next significant digit
            }
        }
        public static void PrintArray(int[] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
                Console.Write(arrayToSort[i].ToString() + " ");
            Console.WriteLine();            
        }

        private static int Power(int baseNum, int exp)  //function to calculate powers of ten for our modulus
        {
            if (exp == 0)
                return 1;
            else
            {
                for (int i = 0; i < (exp - 1); i++)
                {
                    baseNum *= 10;
                }
                return baseNum;
            }
            
        }

        //rosetta code version
        public static void Sort(int[] old)
        {
            int i, j;
            int[] tmp = new int[old.Length];
            for (int shift = 31; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < old.Length; ++i)
                {
                    bool move = (old[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)  // shift the 0's to old's head
                        old[i - j] = old[i];
                    else                            // move the 1's to tmp
                        tmp[j++] = old[i];
                }
                Array.Copy(tmp, 0, old, old.Length - j, j);
            }
        }
    }
}
