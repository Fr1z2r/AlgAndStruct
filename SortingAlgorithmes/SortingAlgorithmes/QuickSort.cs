using System;

namespace SortingAlgorithmes
{
    public class QuickSort<T>:ISorter<T> where T:IComparable<T>
    {
        public void Sort(T[] array)
        {
            SortRecursion(array,0,array.Length-1);
        }

        private void SortRecursion(T[] array, int startIndex, int endIndex)
        {
            if(endIndex-startIndex<1)return;
            int m=Partition(array,startIndex,endIndex);
            if(m==-1)return;
            //int m = startIndex + (endIndex - startIndex)/2;
            SortRecursion(array,startIndex,m-1);
            SortRecursion(array,m+1,endIndex);
        }

        private int Partition(T[] array,int startIndex,int endIndex)
        {
            int diff = endIndex - startIndex;
            if (diff <= 0) return 0;
            if (diff == 1)
            {
                if (array[startIndex].CompareTo(array[endIndex]) > 0)
                {
                    Swap(array, startIndex, endIndex);
                }
                return -1;
            }
            int m = startIndex + (endIndex - startIndex) / 2;
            int l = startIndex;
            int r = endIndex;
            while (l<r)
            {
                while (array[l].CompareTo(array[m])<0) l++;
                while (array[r].CompareTo(array[m])>0) r--;
                Swap(array,l,r);
                if (m == l) m = r;
                else if (m == r) m = l;
                r--;
                l++;
            }
            return m;

        }

        private static void Swap(T[] array, int i, int j)
        {
            var tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}