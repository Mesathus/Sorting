using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        /* By: John O'Brien, James Doggett
         * Date: 4/21/2018
         * Last Updated: 4/23/2018
         * 
         * This project is designed to test several different sort implementations to check for the 
         * highest performing sort under three conditions: Randomly filled array, Ascending order array, 
         * and Descending order array.
         */
        static void Main(string[] args)
        {
            //From Stopwatch to right sw.Reset, except for the PrintRandom, is currently here just to
            //test the RadixSort.  This can be deleted and PrintRandom uncommented to see all three
            //sorts run at once.
            Stopwatch sw = new Stopwatch();
            int[] myArray = RandArray();
            string timer;
            //PrintRandom();    //uncomment this line to run all three sorts
            myArray = RandArray();
            sw.Start();
            RadixSort.RSort(myArray);
            sw.Stop();
            timer = sw.ElapsedMilliseconds.ToString();
            Console.WriteLine("Elapsed time, RadixSort: {0}", timer);
            sw.Reset();
            //RadixSort.PrintArray(myArray);
            //QuickSort.PrintArray(myArray);
            Console.WriteLine("Random array times.");
            Console.ReadKey();
        }

        /*
         * This module was present in the main body of the project, it was moved to this module to 
         * facilitate testing a single sort at a time without having to delete or comment out parts.
         * It creates a new random array before it runs each sort, so they are not run on identical arrays.         * 
         */
        public static void PrintRandom()
        {
            //initialize our array and our common variables
            Stopwatch sw = new Stopwatch();
            int[] myArray = RandArray();
            string timer;
            sw.Start();
            QuickSort.QSort(myArray, 0, myArray.Length - 1);
            sw.Stop();
            timer = sw.ElapsedMilliseconds.ToString();            
            Console.WriteLine("Elapsed time, Quicksort: {0}", timer);
            sw.Reset();
            //Generate a new array for Radix sort
            myArray = RandArray();
            sw.Start();
            RadixSort.RSort(myArray);
            sw.Stop();
            timer = sw.ElapsedMilliseconds.ToString();            
            Console.WriteLine("Elapsed time, RadixSort: {0}", timer);
            sw.Reset();
            //Generate a new array for the sample Radix sort
            myArray = RandArray();
            sw.Start();
            RadixSort.Sort(myArray);
            sw.Stop();
            timer = sw.ElapsedMilliseconds.ToString();            
            Console.WriteLine("Elapsed time, Rosetta Code Radix Sort: {0}", timer);
            sw.Reset();
        }

        /*
         * Below are the three methods for creating arrays, one each for: Random, Ascending order, 
         * and Descending order.
         */
        public static int[] RandArray()
        {
            Random rand = new Random();
            int[] myArray = new int[500000];    //count of items in the array can be adjusted here
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rand.Next();   //random number range can be adjusted here
            }
            return myArray;
        }

        public static int[] AscArray()
        {
            int[] myArray = new int[500000];
            for (int i = 0; i < myArray.Length; i++)
                myArray[i] = i;
            return myArray;
        }

        public static int[] DescArray()
        {
            int[] myArray = new int[500000];
            for (int i = myArray.Length - 1; i > 0; i--)
                myArray[i] = i;
            return myArray;
        }
    }
}
