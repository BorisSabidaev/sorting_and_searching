using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class D_aryHeapSort
    {
        static public void Do(int[] A, int d)
        {
            if (d < 2)
                throw new Exception("Incorrect d");
            BuildMaxHeap(A, d);
            int heapSize = A.Count() - 1;
            for (int i = A.Count() - 1; i >= 1; i--)
            {
                Swap(ref A[0], ref A[i]);
                heapSize--;
                MaxHeapify(A, 0, heapSize, d);
            }

        }

        static void MaxHeapify(int[] A, int i, int heapSize, int d)
        {
            int largest = i;
            int child;
            for(int j = 1; j <= d; j++)
            {
                child = Child(i, j, d);
                if (child <= heapSize && A[child] > A[largest])
                    largest = child;
            }

            if (largest != i)
            {
                Swap(ref A[i], ref A[largest]);
                MaxHeapify(A, largest, heapSize, d);
            }
        }
        static private int Child(int parent, int childNumber, int d)
        {
            return (d * parent) + childNumber;
        }

        static private void BuildMaxHeap(int[] A, int d)
        {
            for (int i = (A.Count() - 1) / d; i >= 0; i--)
                MaxHeapify(A, i, A.Count() - 1, d);
        }
        static private void Swap(ref int a, ref int b)
        {
            int buf = a;
            a = b;
            b = buf;
        }
    }
}
