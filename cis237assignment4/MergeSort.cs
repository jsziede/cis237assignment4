//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class MergeSort
    {
        //sort method with one parameter of a generic that must implement IComparable
        public void Sort<T>(T[] arr)
            where T : IComparable<T>
        {
            //basic counter
            int counter = 0;

            //while loop to count all non-null elements in the array
            while (arr[counter] != null)
            {
                counter++;
            }

            //calls an overloaded sort method
            Sort<T>(arr, 0, counter);
        }

        //overloaded merge sort method
        public void Sort<T>(T[] arr, int low, int high)
            where T : IComparable<T>
        {
            //integer N is initailly set to the amount of non-null elements in the array minus 0
            int N = high - low;

            //base case
            if (N <= 1)
                return;

            //mid is initialized to be the middle index of the array
            int mid = low + N / 2;

            //recursive calls for each half of the arrays
            Sort(arr, low, mid);
            Sort(arr, mid, high);

            //a new generic array is created to use for comparing
            T[] aux = new T[N];

            //the start and middle points of the new array are initialized
            int i = low, j = mid;

            //while there are elements in the left or right sides
            for (int k = 0; k < N; k++)
            {
                //if the left-side head exists and is <= the existing right-side head.
                if (i == mid) aux[k] = arr[j++];
                else if (j == high) aux[k] = arr[i++];
                else if (arr[j].CompareTo(arr[i]) < 0) aux[k] = arr[j++];
                else aux[k] = arr[i++];
            }

            //the original array copies the sorted array
            for (int k = 0; k < N; k++)
            {
                arr[low + k] = aux[k];
            }
        }
    }
}