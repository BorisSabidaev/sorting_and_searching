using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_ka
{
    class SelectionSort
    {
        static public int[] Do(int[] a)
        {
            int i, j;

            for (i = 0; i < a.Length - 1; i++)
            {
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                        Swap(ref a[i], ref a[j]);
                }
            }
            return a;
        }
        static void Swap(ref int a, ref int b)
        {
            int buf;

            buf = a;
            a = b;
            b = buf;
        }
    }
}
