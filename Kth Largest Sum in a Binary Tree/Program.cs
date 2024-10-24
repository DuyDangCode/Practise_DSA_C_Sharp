namespace Kth_Largest_Sum_in_a_Binary_Tree
{
    internal class Program
    {
        public static long KthLargestLevelSum(TreeNode root, int k)
        {
            var priorityQueue = new PriorityQueue<long, long>(k, new CompareByValue());
            var queueNode = new Queue<TreeNode>();
            queueNode.Enqueue(root);

            while (queueNode.Count > 0)
            {
                long sum = 0;
                int size = queueNode.Count;
                for (var i = 0; i < size; i++)
                {
                    TreeNode treeNode = queueNode.Dequeue();
                    sum += treeNode.val;
                    if (treeNode.left != null) queueNode.Enqueue(treeNode.left);
                    if (treeNode.right != null) queueNode.Enqueue(treeNode.right);
                }
                priorityQueue.Enqueue(sum, sum);
            }
            //Console.WriteLine(levelSums.Aggregate("", (acc, item) => acc + " " + item));
            if (priorityQueue.Count < k) return -1;
            for (var i = 0; i < k - 1; i++)
            {
                priorityQueue.Dequeue();
            }
            return priorityQueue.Dequeue();
        }

        class CompareByValue : IComparer<long>
        {
            public int Compare(long x, long y)
            {
                return y.CompareTo(x);
            }
        }

        static void Main(string[] args)
        {
            var ll = new TreeNode(3);
            var left = new TreeNode(2, ll);
            var root = new TreeNode(1, left);
            Console.WriteLine(KthLargestLevelSum(root, 1));
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode? left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
