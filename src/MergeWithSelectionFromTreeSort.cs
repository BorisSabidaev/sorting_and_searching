using System;
using System.Collections.Generic;


namespace lab2_ka
{
    class MergeWithSelectionFromTreeSort
    {
        private static int[] originalArray;
        private static int pathes;

        public static void Do(int[] A , int pathesCount)
        {
            originalArray = A;
            pathes = pathesCount;
            Sort(0, A.Length - 1);
            originalArray = null;
        }

        private static void Sort(int start, int end)
        {
            if (start < end)
            {
                int length = (int)Math.Ceiling((double)(end - start + 1) / pathes);

                for (int i = 0; i < pathes - 1; i++)
                {
                    int l, r;
                    l = start + length * i;
                    r = start + length * i + length - 1;
                    Sort(l, r);
                }
                Sort(start + length * (pathes - 1), end);
                Merge(start, end, length);
            }
        }
        private static void Merge(int start, int end, int length)
        {
            int l, r, i, j;
            int[] temp = new int[end - start + 1];
            List<List<int>> merging = new List<List<int>>(pathes);
            
            List<int> tmp;
            for (i = 0; i < pathes - 1 & i < temp.Length; i++)
            {
                l = start + length * i;
                r = start + length * i + length - 1;
                tmp = new List<int>(length);
                for (j = l; j < r + 1; j++)
                    tmp.Add(originalArray[j]);
                merging.Add(tmp);
            }

            if ((r = start + length * (pathes - 1)) <= end)
            {
                tmp = new List<int>(end - r + 1);
                for (j = r; j < end + 1; j++)
                    tmp.Add(originalArray[j]);
                merging.Add(tmp);
            }
            


            int[] treeArray = new int[merging.Count];
            for (i = 0; i < merging.Count; i++)
            {
                treeArray[i] = merging[i][0];
            }

            KeyValuePair<int, int> pair;
            SelectionTree tree = new SelectionTree(pathes);
            tree.BuildTree(treeArray);
            
            j = 0;
            int count = merging.Count;
            while (count != 0)
            {
                pair = tree.Min();
                temp[j] = merging[pair.Key][0];
                merging[pair.Key].RemoveAt(0);

                if (merging[pair.Key].Count == 0)
                {
                    count--;
                    tree.Add(pair.Key, int.MaxValue);
                }
                else
                    tree.Add(pair.Key, merging[pair.Key][0]);
                j++;
            }
            

            for (i = start, j = 0; i < end + 1; i++, j++)
            {
                originalArray[i] = temp[j];
            }
        }

        private class SelectionTree
        {
            public KeyValuePair<int, int>[] treeArray;
            private int elementsCount;
            
            public void Add(int key, int value)
            {
                int index = treeArray.Length - elementsCount + key;
                treeArray[index] = new KeyValuePair<int, int>(key, value);
                if ((index - 1) / 2 >= 0)
                    SiftUp((index - 1) / 2);
            }
            private void SiftUp(int i)
            {
                while (true)
                {
                    int minChild = 2 * i + 1;

                    if (treeArray[minChild + 1].Value < treeArray[minChild].Value)
                        minChild++;
                    treeArray[i] = treeArray[minChild];
                    if (i == 0)
                        break;
                    i = (i - 1) / 2;
                }
            }

            public void BuildTree(int[] originalArray)
            {
                for (int i = 0; i < originalArray.Length; i++)
                {
                    treeArray[elementsCount - 1 + i] = new KeyValuePair<int, int>(i, originalArray[i]);
                }
                for (int i = 0; i < elementsCount - originalArray.Length; i++)
                {
                    treeArray[elementsCount - 1 + originalArray.Length + i] = new KeyValuePair<int, int>(originalArray.Length + i, int.MaxValue);
                }

                FillTree();
            }
            private void FillTree()
            {
                int pair = treeArray.Length - 2;
                int minChild;
                while (pair >= 1)
                {
                    minChild = pair;

                    if (treeArray[minChild + 1].Value < (treeArray[minChild]).Value)
                        minChild++;

                    treeArray[(minChild - 1) / 2] = treeArray[minChild];
                    pair -= 2;
                }
            }
            private int TreeElementsCount(int n)
            {
                int count = 1;
                n--;
                while (n > 0)
                {
                    n = n / 2;
                    count = count * 2;
                }
                return count;
            }

            public KeyValuePair<int, int> Min()
            {
                return treeArray[0];
            }

            public SelectionTree(int pathes)
            {
                elementsCount = TreeElementsCount(pathes);
                treeArray = new KeyValuePair<int, int>[2 * elementsCount - 1];
            }
        }
    }
}
