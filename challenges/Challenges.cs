using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace challenges
{
    public static partial class Challenges
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-preorder-traversal
        /// </summary>
        /// <param name="root"></param>
        public static void PreOrder(Node root)
        {
            if (root == null) return;

            Console.WriteLine(root.Data + " ");

            PreOrder(root.Left);
            PreOrder(root.Right);
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-postorder-traversal
        /// </summary>
        /// <param name="root"></param>
        public static void PostOrder(Node root)
        {
            if (root == null) return;

            PostOrder(root.Left);
            PostOrder(root.Right);

            Console.WriteLine(root.Data + " ");
        }
        
        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-inorder-traversal
        /// </summary>
        /// <param name="root"></param>
        public static void InOrder(Node root)
        {
            if (root == null) return;

            InOrder(root.Left);

            Console.WriteLine(root.Data + " ");

            InOrder(root.Right);
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-height-of-a-binary-tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int Height(Node root)
        {
            if (root == null) return -1;

            return Math.Max(
                    Height(root.Left) + 1,
                    Height(root.Right) + 1
                );
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-top-view
        /// </summary>
        /// <param name="root"></param>
        public static void TopView(Node root)
        {
            if (root == null) return;
            
            TopView(root.Left, true);

            Console.WriteLine(root.Data + " ");

            TopView(root.Right, false);
        }

        public static void TopView(Node node, bool isLeft)
        {
            if (node == null) return;

            if (isLeft)
            {
                TopView(node.Left, true);
                Console.WriteLine(node.Data + " ");
            }
            else
            {
                Console.WriteLine(node.Data + " ");
                TopView(node.Right, false);
            }
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/tree-level-order-traversal
        /// </summary>
        /// <param name="node"></param>
        public static void LevelOrder(Node root)
        {
            var nodes = new LinkedList<Node>(new [] {root});

            for (var it = nodes.First; it != null; it = it.Next)
            {
                Console.WriteLine(it.Value.Data + " ");
                if (it.Value.Left != null)
                {
                    nodes.AddLast(it.Value.Left);
                }
                if (it.Value.Right != null)
                {
                    nodes.AddLast(it.Value.Right);
                }
            }

        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/binary-search-tree-insertion
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Node Insert(Node root, int value)
        {
            if (root == null)
            {
                root = new Node { Data = value};
                return root;
            }

            if (value < root.Data)
            {
                root.Left = Insert(root.Left, value);
            }
            else // value > root.Data
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/binary-search-tree-lowest-common-ancestor
        /// 
        /// The value of a common ancestor has to always be between the two values in question.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Node LCA(Node root, int v1, int v2)
        {
            //Decide if you have to call recursively
            //Smaller than both
            if (root.Data < v1 && root.Data < v2)
            {
                return LCA(root.Right, v1, v2);
            }
            //Bigger than both
            if (root.Data > v1 && root.Data > v2)
            {
                return LCA(root.Left, v1, v2);
            }

            //Else solution already found
            return root;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/self-balancing-tree
        /// http://www.geeksforgeeks.org/avl-tree-set-1-insertion/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Node BalancedInsert(Node node, int value)
        {
            // Insertion
            if (node == null)
            {
                Node newNode = new Node();
                newNode.Data = value;
                return newNode;
            }
            if (value < node.Data) node.Left = BalancedInsert(node.Left, value);
            else node.Right = BalancedInsert(node.Right, value);

            // Height
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

            // Balanced ?
            int balance = GetHeight(node.Left) - GetHeight(node.Right);

            // If node unbalanced, there are 4 cases
            // Left Left case
            if (balance > 1 && value < node.Left.Data)
                return RightRotate(node);

            // Left Right case
            if (balance > 1 && value > node.Left.Data)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Right case
            if (balance < -1 && value > node.Right.Data)
                return LeftRotate(node);

            // Right Left case
            if (balance < -1 && value < node.Right.Data)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;  
        }

        private static int GetHeight(Node node)
        {
            if (node == null) return -1;
            return node.Height;
        }
        
        // left rotate subtree rooted with x
        private static Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            // perform rotation
            y.Left = x;
            x.Right = T2;

            // update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            // return new root
            return y;
        }

        // right rotate subtree rooted with y
        private static Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            // perform rotation
            x.Right = y;
            y.Left = T2;

            // update heights
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            // return new root
            return x;
        }

    }
}
