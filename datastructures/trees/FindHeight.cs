using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_height
{
    public class BinaryTree
    {
        public BinaryTree(int d)
        {
            data = d;
        }
        
        public int data;
        public BinaryTree right;
        public BinaryTree left;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree(1);
            tree.left = new BinaryTree(2);
            tree.right = new BinaryTree(3);
            tree.left.left = new BinaryTree(4);
            tree.left.right = new BinaryTree(5);
            tree.right.left = new BinaryTree(6);
            tree.right.right = new BinaryTree(7);
            tree.right.right.right = new BinaryTree(77);
            tree.right.right.right.right = new BinaryTree(777);
            tree.right.right.right.right.right = new BinaryTree(7777);
            tree.right.right.right.right.right.right = new BinaryTree(77777);
            //tree.Left.Left.Left.Left = new Node<int>(6);

            var ih = new Program();
            Console.WriteLine("Iterative Height => {0}", ih.maxDepthIterative(tree));
        }


        int maxDepthIterative(BinaryTree root)
        {
            if (root == null) return 0;
            Stack<BinaryTree> s = new Stack<BinaryTree>();
            s.Push(root);
            int maxDepth = 0;
            BinaryTree prevTop = null;
            List<int> postOrder = new List<int>();
            while (s.Count != 0)
            {
                BinaryTree top = s.Peek();
                Console.WriteLine("top = {0}, prevTop = {1}", top.data, prevTop == null ? -1 : prevTop.data);
                bool isChildNode = (prevTop == null || prevTop.left == top || prevTop.right == top);
                bool isLeftParent = (top.left == prevTop);
                if (isChildNode)
                {
                    // visit the child node of Top
                    Console.WriteLine("visit the child node of {0}", top.data);
                    if (top.left != null)
                        s.Push(top.left);
                    else if (top.right != null)
                        s.Push(top.right);
                }
                else if (isLeftParent)
                {
                    Console.WriteLine("visit the right child node of {0}", top.data);
                    if (top.right != null)
                        s.Push(top.right);
                }
                else
                {
                    Console.WriteLine("All the left and right subtree of {0} are visited", top.data);
                    s.Pop();
                    postOrder.Add(top.data);
                }
                prevTop = top;
                if (s.Count > maxDepth)
                    maxDepth = s.Count;
            }

            Console.WriteLine("Post order result...");
            foreach (var n in postOrder) {
                Console.Write(" {0}", n);
            }
            return maxDepth;
        }
    }
}
