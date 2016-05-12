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
            Node n;
            for (int i = 0; i < A.Length; i++)
            {
                n = new Node(A[i]);
                lHeap = Merge( lHeap, n );
            }

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = lHeap.Key;
                lHeap = Merge(lHeap.left, lHeap.right);
            }

        }

        private static Node lHeap = null;
        private class Node
        {
            public Node right;
            public Node left;
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
                Swap(ref n1, ref n2);
            
            n1.right = Merge(n1.right, n2);
            if (NPL(n1.left) < NPL(n1.right))
                Swap(ref n1.left, ref n1.right);
            if (n1.right != null)
                n1.npl = n1.right.npl + 1;
            
            return n1;
        }

        private static int NPL(Node n)
        {
            if (n == null)
                return -1;
            else
                return n.npl;
        }
        private static void Swap<T>(ref T o1, ref T o2)
        {
            T buf = o1;
            o1 = o2;
            o2 = buf;
        }
    }
}
