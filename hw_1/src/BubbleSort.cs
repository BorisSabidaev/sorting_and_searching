using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_ka
{
    class BubbleSort
    {
        static public int[] Do(int[] a)
        {
            int i, j;

            for (i = 0; i < a.Length - 1; i++)
            {
                for (j = a.Length - 1; j > i; j--)
                    if (a[j] < a[j - 1])
                        Swap(ref a[j - 1], ref a[j]);
            }
            return a;
        }
        static private void Swap(ref int a, ref int b)
        {
            int buf;

            buf = a;
            a = b;
            b = buf;
        }
    }
}
