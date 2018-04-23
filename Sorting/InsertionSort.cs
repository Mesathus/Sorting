using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertionSort
    {
        public InsertionSort() { }

        public void Sort(int[] arrayToSort)
        {
            for(int i = 1; i < arrayToSort.Length; i++)
            {
                int entry = arrayToSort[i];
                int j = i;
                while(j > 1 && arrayToSort[j-1] > entry)
                {
                    arrayToSort[j] = arrayToSort[--j];
                }
                arrayToSort[j] = entry;
            }
        }
    }
}
