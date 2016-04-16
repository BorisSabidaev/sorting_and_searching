using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class HeapSort
    {
        static public void Do(int[] A)
        {
            BuildMaxHeap(A);
            int heapSize = A.Count() - 1;
            for (int i = A.Count() - 1; i >= 1; i--)
            {
                Swap(ref A[0], ref A[i]);
                heapSize--;
                MaxHeapify(A, 0, heapSize);
            }

        }

        static void MaxHeapify(int[] A, int i, int heapSize)
        {
            int largest = i;
            int l = Left(i);
            int r = Right(i);
            if (l <= heapSize && A[l] > A[i])
                largest = l;
            if (r <= heapSize && A[r] > A[largest])
                largest = r;
            if (largest != i)
            {
                Swap(ref A[i], ref A[largest]);
                MaxHeapify(A, largest, heapSize);
            }
        }
        static private int Left(int i)
        {
            return 2 * i;
        }
        static private int Right(int i)
        {
            return 2 * i + 1;
        }

        static private void BuildMaxHeap(int[] A)
        {
            for (int i = (A.Count() - 1) / 2; i >= 0; i--)
                MaxHeapify(A, i, A.Count() - 1);
        }
        static private void Swap(ref int a, ref int b)
        {
            int buf = a;
            a = b;
            b = buf;
        }
    }
}
