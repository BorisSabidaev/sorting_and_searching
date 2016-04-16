using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class QuickSort
    {
        static public void Do(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(A, p, r);
                QuickSort.Do(A, p, q - 1);
                QuickSort.Do(A, q + 1, r);
            }
        }
        static private int Partition(int[] A, int p, int r)
        {
            int x = A[r];
            int i = p - 1;
            for(int j = p; j <= r - 1; j++)
            {
                if (A[j] < x)
                {
                    i++;
                    Swap(ref A[i], ref A[j]);
                }
            }
            Swap(ref A[i + 1], ref A[r]);
            return i + 1;
        }
        static private void Swap(ref int a, ref int b)
        {
            int buf = a;
            a = b;
            b = buf;
        }
    }
}
