using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_ka
{
    class BinaryInsertionSort
    {
        static public int[] Do(int[] a)
        {
            int i, j, k, key;

            for (i = 1; i < a.Length; i++)
            {
                key = a[i];
                k = BinSearch(a, a[i], 0, i - 1);
                for (j = i - 1; j >= k; j--)
                    a[j + 1] = a[j];
                a[j + 1] = key;
            }
            return a;
        }
        static private int BinSearch(int[] a, int key, int l, int r)
        {
            int m;
            r++;

            while (l < r - 1)
            {
                m = (l + r) / 2;
                if (key < a[m])
                    r = m;
                else
                    l = m;
            }
            return r;
        }
    }
}
