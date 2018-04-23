using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SampleSorts
    {
        //https://www.codeproject.com/Articles/32382/Radix-Sorting-Implementation-with-C
        /*
         *Sample Radix sort, using just arrays 
         */
        public static int[] Sort(int[] array)
        {
            return RadixSortAux(array, 1);
        }
        static int[] RadixSortAux(int[] array, int digit)
        {
            bool Empty = true;
            KVEntry[] digits = new KVEntry[array.Length];//array that holds the digits;
            int[] SortedArray = new int[array.Length];//Hold the sorted array
            for (int i = 0; i < array.Length; i++)
            {
                digits[i] = new KVEntry();
                digits[i].Key = i;
                digits[i].Value = (array[i] / digit) % 10;
                if (array[i] / digit != 0)
                    Empty = false;
            }

            if (Empty)
                return array;

            KVEntry[] SortedDigits = CountingSort(digits);
            for (int i = 0; i < SortedArray.Length; i++)
                SortedArray[i] = array[SortedDigits[i].Key];
            return RadixSortAux(SortedArray, digit * 10);
        }
        static KVEntry[] CountingSort(KVEntry[] ArrayA)
        {
            int[] ArrayB = new int[MaxValue(ArrayA) + 1];
            KVEntry[] ArrayC = new KVEntry[ArrayA.Length];

            for (int i = 0; i < ArrayB.Length; i++)
                ArrayB[i] = 0;

            for (int i = 0; i < ArrayA.Length; i++)
                ArrayB[ArrayA[i].Value]++;

            for (int i = 1; i < ArrayB.Length; i++)
                ArrayB[i] += ArrayB[i - 1];

            for (int i = ArrayA.Length - 1; i >= 0; i--)
            {
                int value = ArrayA[i].Value;
                int index = ArrayB[value];
                ArrayB[value]--;
                ArrayC[index - 1] = new KVEntry();
                ArrayC[index - 1].Key = i;
                ArrayC[index - 1].Value = value;
            }
            return ArrayC;
        }

        static int MaxValue(KVEntry[] arr)
        {
            int Max = arr[0].Value;
            for (int i = 1; i < arr.Length; i++)
                if (arr[i].Value > Max)
                    Max = arr[i].Value;
            return Max;
        }
        struct KVEntry
        {
            int key;
            int value;

            public int Key
            {
                get
                {
                    return key;
                }
                set
                {
                    if (key >= 0)
                        key = value;
                    else
                        throw new Exception("Invalid key value");
                }
            }

            public int Value
            {
                get
                {
                    return value;
                }
                set
                {
                    this.value = value;
                }
            }
        }
    }
}
