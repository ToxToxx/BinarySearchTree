namespace BinarySearchTree
{
    class BinaryTreeNode
    {
        public int Data { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    class BinaryTree
    {
        public BinaryTreeNode Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }

        public void Insert(int data)
        {
            Root = InsertRec(Root, data);
        }

        private BinaryTreeNode InsertRec(BinaryTreeNode root, int data)
        {
            if (root == null)
            {
                root = new BinaryTreeNode(data);
                return root;
            }

            if (data < root.Data)
            {
                root.Left = InsertRec(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = InsertRec(root.Right, data);
            }

            return root;
        }

        public void Remove(int data)
        {
            Root = RemoveRec(Root, data);
        }

        private BinaryTreeNode RemoveRec(BinaryTreeNode root, int data)
        {
            if (root == null)
            {
                return root;
            }

            if (data < root.Data)
            {
                root.Left = RemoveRec(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = RemoveRec(root.Right, data);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }

                root.Data = MinValue(root.Right);

                root.Right = RemoveRec(root.Right, root.Data);
            }

            return root;
        }

        private static int MinValue(BinaryTreeNode root)
        {
            int minValue = root.Data;
            while (root.Left != null)
            {
                minValue = root.Left.Data;
                root = root.Left;
            }
            return minValue;
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRec(Root);
            Console.WriteLine();
        }

        private void InOrderTraversalRec(BinaryTreeNode root)
        {
            if (root != null)
            {
                InOrderTraversalRec(root.Left);
                Console.Write(root.Data + " ");
                InOrderTraversalRec(root.Right);
            }
        }

        public void BreadthFirstTraversal()
        {
            if (Root == null)
            {
                return;
            }

            Queue<BinaryTreeNode> queue = new();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BinaryTreeNode node = queue.Dequeue();
                Console.Write(node.Data + " ");

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            Console.WriteLine();
        }

        public void DepthFirstTraversal()
        {
            Console.WriteLine("Pre-order traversal:");
            PreOrderTraversal(Root);
            Console.WriteLine();

            Console.WriteLine("Post-order traversal:");
            PostOrderTraversal(Root);
            Console.WriteLine();
        }

        private void PreOrderTraversal(BinaryTreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Data + " ");
                PreOrderTraversal(root.Left);
                PreOrderTraversal(root.Right);
            }
        }

        private void PostOrderTraversal(BinaryTreeNode root)
        {
            if (root != null)
            {
                PostOrderTraversal(root.Left);
                PostOrderTraversal(root.Right);
                Console.Write(root.Data + " ");
            }
        }
        public void DrawTree()
        {
            DrawTreeRec(Root, 0);
        }

        private void DrawTreeRec(BinaryTreeNode root, int level)
        {
            if (root != null)
            {
                DrawTreeRec(root.Right, level + 1);

                for (int i = 0; i < level; i++)
                {
                    Console.Write("    ");
                }

                Console.WriteLine(root.Data);

                DrawTreeRec(root.Left, level + 1);
            }
        }

    }

    class Program
    {
        static void Main()
        {
            BinaryTree tree = new();

            // Вставка элементов в бинарное дерево
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            // Вывод бинарного дерева в виде рисунка
            Console.WriteLine("Бинарное дерево:");
            tree.DrawTree();

            // Обход бинарного дерева в порядке возрастания
            Console.WriteLine("Обход по возрастанию:");
            tree.InOrderTraversal();

            // Обход бинарного дерева в ширину
            Console.WriteLine("Обход в ширину:");
            tree.BreadthFirstTraversal();

            // Обход бинарного дерева в глубину
            Console.WriteLine("Обход в глубину:");
            tree.DepthFirstTraversal();

            // Удаление элемента из бинарного дерева
            tree.Remove(30);
            Console.WriteLine("Обход в ширину после удаления:");
            tree.BreadthFirstTraversal();
        }
    }
}