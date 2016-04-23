using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_ka
{
    class LeftistHeapSort
    {
        public static void Do(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                lHeap = Merge(lHeap, new Node(A[i]));
            }

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = lHeap.Key;
                if (lHeap.left != null)
                    lHeap.left.parent = null;
                if (lHeap.right != null)
                    lHeap.right.parent = null;
                lHeap = Merge(lHeap.left, lHeap.right);
            }

        }

        private static Node lHeap = null;
        private class Node
        {
            public Node right;
            public Node left;
            public Node parent;
            public int Key { get; }
            public int npl;

            public Node(int key)
            {
                Key = key;
            }
        }

        private static Node Merge(Node n1, Node n2)
        {
            if (n1 == null)
                return n2;
            if (n2 == null)
                return n1;

            if (n1.Key > n2.Key)
                Swap<Node>(ref n1, ref n2);
            
            n1.right = Merge(n1.right, n2);
            n1.npl = n1.right.npl + 1;

            return n1;
        }
        private static void Swap<T>(ref T o1, ref T o2)
        {
            T buf = o1;
            o1 = o2;
            o2 = buf;
        }
    }
}
