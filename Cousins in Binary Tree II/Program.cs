namespace Cousins_in_Binary_Tree_II
{
    public class Program
    {
        public static TreeNode ReplaceValueInTree(TreeNode root)
        {
            var tempRoot = root;

            var nodeQueue = new Queue<TreeNode>();
            var valueOfNodeInSameLevel = new Queue<List<List<int>>>();

            nodeQueue.Enqueue(tempRoot);
            valueOfNodeInSameLevel.Enqueue([[tempRoot.val]]);

            while (nodeQueue.Count > 0)
            {
                int lengthOfNodeQueue = nodeQueue.Count;
                var valueOfAllChildNodesInSameLevel = new List<List<int>>();
                for (var i = 0; i < lengthOfNodeQueue; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    var valueOfChildNode = new List<int>();

                    if (node.left != null)
                    {
                        valueOfChildNode.Add(node.left.val);
                        nodeQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        valueOfChildNode.Add(node.right.val);
                        nodeQueue.Enqueue(node.right);
                    }
                    if (valueOfChildNode.Count > 0)
                        valueOfAllChildNodesInSameLevel.Add(valueOfChildNode);
                }
                if (valueOfAllChildNodesInSameLevel.Count > 0)
                    valueOfNodeInSameLevel.Enqueue(valueOfAllChildNodesInSameLevel);
            }

            valueOfNodeInSameLevel.Print();
            var newValueForTree = new List<int>();
            while (valueOfNodeInSameLevel.Count > 0)
            {
                List<List<int>> valueOfAllNodeInSameLevel = valueOfNodeInSameLevel.Dequeue();
                if (valueOfAllNodeInSameLevel.Count == 1)
                {
                    for (var i = 0; i < valueOfAllNodeInSameLevel[0].Count; i++)
                    {
                        newValueForTree.Add(0);
                    }
                }
                else if (valueOfAllNodeInSameLevel.Count > 1)
                {
                    var sumOfGroup = new List<int>(valueOfAllNodeInSameLevel.Count);
                    for (var i = 0; i < valueOfAllNodeInSameLevel.Count; i++)
                    {
                        sumOfGroup.Add(valueOfAllNodeInSameLevel[i].Aggregate(0, (acc, item) => acc + item));
                    }
                    for (var i = 0; i < valueOfAllNodeInSameLevel.Count; i++)
                    {
                        var sum = 0;
                        for (var j = 0; j < sumOfGroup.Count; j++)
                        {
                            if (i != j) sum += sumOfGroup[j];
                        }
                        for (var j = 0; j < valueOfAllNodeInSameLevel[i].Count; j++)
                        {
                            newValueForTree.Add(sum);
                        }
                    }
                }
            }
            newValueForTree.Print();

            nodeQueue.Enqueue(tempRoot);
            var index = 0;
            while (nodeQueue.Count > 0)
            {
                int lengthOfNodeQueue = nodeQueue.Count;
                for (var i = 0; i < lengthOfNodeQueue; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    node.val = newValueForTree[index];
                    if (node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                    index++;
                }
            }
            nodeQueue.Enqueue(tempRoot);
            while (nodeQueue.Count > 0)
            {
                int lengthOfNodeQueue = nodeQueue.Count;
                for (var i = 0; i < lengthOfNodeQueue; i++)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    Console.WriteLine(node.val);
                    if (node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                }
            }
            return root;
        }
        static void Main(string[] args)
        {
            TreeNode root = new(
    5,
    new TreeNode(
        4,
        new TreeNode(1),
        new TreeNode(10)
    ),
    new TreeNode(
        9,
        null,
        new TreeNode(7)
    )
);
            TreeNode root2 = new TreeNode(
                3,
                new TreeNode(1),
                new TreeNode(2)
                );

            ReplaceValueInTree(root);
            ReplaceValueInTree(root2);

        }

    }
    public static class QueueExtensions
    {
        public static void Print(this Queue<List<List<int>>> queue)
        {
            var i = 1;
            queue.ToList().ForEach(item =>
            {
                Console.WriteLine($"Level {i}: ");
                var j = 1;
                item.ForEach(item2 =>
                {
                    Console.Write($"Group {j}: ");
                    item2.ForEach(item3 =>
                    {
                        Console.Write(item3 + " ");
                    });
                    Console.WriteLine();
                    j++;
                });
                i++;
                Console.WriteLine();
            });
        }
    }
    public static class ListExtensions
    {
        public static void Print(this List<int> list)
        {
            list.ForEach(item =>
                Console.Write(item + " ")
            );
            Console.WriteLine();
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
