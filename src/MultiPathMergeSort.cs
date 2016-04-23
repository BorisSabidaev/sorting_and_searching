using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class MultiPathMergeSort
    {
        static public void Do(int[] A, int p, int r, int pathesCount)
        {
            if (p < r)
            {
                int length = (r - p + pathesCount) / pathesCount;
                int realPartsCount = (r - p + 1) / length + 1;
                for (int i = 0; i < realPartsCount - 1; i++)
                    MultiPathMergeSort.Do(A, p + length * i, p + length * (i+1) - 1 , pathesCount);
                MultiPathMergeSort.Do(A, p + length * (pathesCount - 1), r, pathesCount);
                Merge(A, p, length, r, realPartsCount);
            }
        }
        static private void Merge(int[] A, int p, int length, int r, int realPartsCount)
        {
            int i, j;
            
            realPartsCount = (r - p + 1) / length + 1;
            int lengthLast = r - (p + length * (realPartsCount - 1)) + 1;

            int[][] array = new int[realPartsCount][];

            for (i = 0; i < realPartsCount - 1; i++)
                array[i] = new int[length + 1];
            array[realPartsCount - 1] = new int[lengthLast + 1];

            for (i = 0; i < realPartsCount - 1; i++)
            {
                for (j = 0; j < length; j++)
                    array[i][j] = A[p + length * i + j];
                array[i][length] = int.MaxValue;
            }
            for (j = 0; j < lengthLast; j++)
                array[realPartsCount - 1][j] = A[p + length * (realPartsCount - 1) + j];
            array[realPartsCount - 1][lengthLast] = int.MaxValue;


            int[] arraysOfIndexes = new int[realPartsCount];
            int min = 0;

            for (i = p; i <= r; i++)
            {
                for (j = 0; j < realPartsCount; j++)
                    if (array[j][arraysOfIndexes[j]] < array[min][arraysOfIndexes[min]])
                        min = j;
                A[i] = array[min][arraysOfIndexes[min]];
                arraysOfIndexes[min]++;
            }
                    
        }
    }
}
