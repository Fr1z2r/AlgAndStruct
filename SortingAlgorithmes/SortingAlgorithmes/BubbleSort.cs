using System;
using System.Collections.Generic;

namespace SortingAlgorithmes
{
    public class BubbleSort<T>:ISorter<T> where T :  IComparable<T>
    {
        public void Sort(T[] array)
        {
            var swaps = true;
            while (swaps)
            {
                swaps = false;
                for (var i = 0; i < array.Length-1; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) <= 0) continue;
                    Swap(array,i,i+1);
                    swaps = true;
                }
            }
        }

        private static void Swap(IList<T> array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}