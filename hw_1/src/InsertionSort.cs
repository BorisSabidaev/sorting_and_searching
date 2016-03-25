using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_ka
{
    class InsertionSort
    {
        static public int[] Do(int[] a)
        {
            int i, j, key;

            for (i = 1; i < a.Length; i++)
            {
                key = a[i];
                for (j = i - 1; j >= 0 && a[j] > key; j--)
                    a[j + 1] = a[j];
                a[j + 1] = key;
            }
            return a;
        }
    }
}
