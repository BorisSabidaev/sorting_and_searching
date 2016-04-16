using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class MergeSort
    {
        static public void Do(int[] A, int p, int r)
        {
            if(p < r)
            {
                int q = (p + r) / 2;
                MergeSort.Do(A, p, q);
                MergeSort.Do(A, q + 1, r);
                Merge(A, p, q, r);
            }
        }
        static private void Merge(int[] A, int p, int q, int r)
        {
            int i, j;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1 + 1];
            int[] R = new int[n2 + 1];
            for (i = 0; i < n1; i++)
                L[i] = A[p + i];
            L[n1] = Int32.MaxValue;
            for (j = 0; j < n2; j++)
                R[j] = A[(q + 1) + j];
            R[n2] = Int32.MaxValue;
            i = j = 0;
            for (int k = p; k <= r; k++)
                if (L[i] <= R[j])
                {
                    A[k] = L[i];
                    i++;
                }        
                else
                {
                    A[k] = R[j];
                    j++;
                }
        }
    }
}
