using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorting
{
    class QuickSort
    {
        public static void QSort(int[] arrayToSort, int start, int finish)
        {
            /* By: John O'Brien, James Doggett
             * Date: 4/21/2018
             * Last Updated: 4/23/2018
             * Version: 1.0
             * Based on: Various youtube series, Ben Kohler's threaded QuickSort 
             * 
             * Precondition: Pass in an array, and the first and last index of the array
             *               In the calling program these should be 0 and array.Length
             * Postcondition: Return an array sorted by QuickSort method
             * 
             * This quicksort accepts an array and its first and last indexes as parameters.
             * Once those have been sent in the initial call, it sets new first and last indexes 
             * based on the final pivot position as it sorts the array and places the pivot in the center
             * of the "sorted" portion of the array.  It then calls itself recursively until the 
             * array indexes it passes in are too small to sort.
             * We use a second set of start/finish values so the absolute start and finish position can be
             * maintained for the next for the next iteration of the loop.
             * 
             * There is currently a bug that causes a StackOverflowException, in the cases of: 
             * random numbers with a small range, and pre-sorted arrays in ascending/descending order.
             * Changing the pivot selection method may partially alleviate this, but is unlikely to 
             * completely fix it.
             */
            int pivotStart = start, pivotFinish = finish, wall = start;
            if (start >= finish) //check to see if we have array items left to sort
            {
                //Console.WriteLine("");
                //PrintArray(arrayToSort);                
            }
            else
            {
                //currently using the final item in the array as the pivot
                int pivot = pivotFinish;  //more sophisticated pivot selection?
                
                /*
                 * Loop through the portion of the array that has been sent to the sort
                 * If the item in each loop is smaller than the pivot, we swap it with the item
                 * on the right side of the wall, then increment the wall
                 */
                for (int i = pivotStart; i <= pivotFinish; i++)
                {                    
                    if (arrayToSort[i] <= arrayToSort[pivot])
                    {
                        Swap(arrayToSort, i, wall);
                        wall++;
                        //PrintArray(arrayToSort);
                    }
                }
                pivotFinish = wall - 2;  //create a stopping point for the next bottom sort
                pivotStart = wall;  //create a starting point for the next top sort                
                //QSort(arrayToSort, wall, finish);
            }
            if (pivotFinish > start)    //This recursive call takes the bottom half of the array and sends it to a recursion
                QSort(arrayToSort, start, pivotFinish);
            if (pivotStart < finish)    //This recursive call takes the top half of the array and sends it to a recursion
                QSort(arrayToSort, pivotStart, finish);
        }


        public static void Swap(int[] arrayToSort, int first, int second)   //simple swap method for the array
        {
            int temp = arrayToSort[first];
            arrayToSort[first] = arrayToSort[second];
            arrayToSort[second] = temp;
        }

        public static void PrintArray(int[] arrayToSort)    //method for printing that can be called from the main program
        {
            for (int i = 0; i < arrayToSort.Length; i++)
                Console.Write(arrayToSort[i].ToString() + " ");
            Console.WriteLine();
        }
    }
}
