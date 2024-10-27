namespace Flip_Equivalent_Binary_Trees
{
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
    public static class QueueExtensions
    {
        public static void Print(this Queue<TreeNode?> queue)
        {
            queue.ToList().ForEach(item =>
            {
                if (item != null)
                    Console.Write(item.val + " ");
            });
            Console.WriteLine();
        }
    }
    internal class Program
    {
        public static bool FlipEquiv(TreeNode? root1, TreeNode? root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;
            if (root1.val != root2.val) return false;

            var queueNodeTree1 = new Queue<TreeNode?>();
            var queueNodeTree2 = new Queue<TreeNode?>();

            queueNodeTree1.Enqueue(root1);
            queueNodeTree2.Enqueue(root2);


            while (queueNodeTree1.Count > 0 && queueNodeTree2.Count > 0)
            {
                for (var i = 0; i < Math.Min(queueNodeTree1.Count, queueNodeTree2.Count); i++)
                {
                    TreeNode? nodeTree1 = queueNodeTree1.Dequeue();
                    TreeNode? nodeTree2 = queueNodeTree2.Dequeue();

                    int l1 = nodeTree1?.left == null ? -1 : nodeTree1.left.val;
                    int r1 = nodeTree1?.right == null ? -1 : nodeTree1.right.val;
                    int l2 = nodeTree2?.left == null ? -1 : nodeTree2.left.val;
                    int r2 = nodeTree2?.right == null ? -1 : nodeTree2.right.val;

                    if (l1 != l2 && l1 != r2) return false;
                    if (l2 != l1 && l2 != r1) return false;
                    if (r1 != r2 && r1 != l2) return false;
                    if (r2 != r1 && r2 != l1) return false;

                    if (l1 != l2 && l1 * r1 > 0)
                    {
                        //swap
                        if (l1 != -1) queueNodeTree1.Enqueue(nodeTree1?.right);
                        if (r1 != -1) queueNodeTree1.Enqueue(nodeTree1?.left);
                    }
                    else
                    {
                        if (l1 != -1) queueNodeTree1.Enqueue(nodeTree1?.left);
                        if (r1 != -1) queueNodeTree1.Enqueue(nodeTree1?.right);
                    }
                    if (l2 != -1) queueNodeTree2.Enqueue(nodeTree2?.left);
                    if (r2 != -1) queueNodeTree2.Enqueue(nodeTree2?.right);

                }
            }
            if (queueNodeTree1.Count > 0 || queueNodeTree2.Count > 0) return false;
            return true;
        }

        static void Main(string[] args)
        {

            TreeNode root1 = new TreeNode(
                1,
                new TreeNode(
                    2,
                    new TreeNode(4),
                    new TreeNode(
                        5,
                        new TreeNode(7),
                        new TreeNode(8)
                    )
                ),
                new TreeNode(
                    3,
                    new TreeNode(6),
                    null
                )
            );

            TreeNode root2 = new TreeNode(
                1,
                new TreeNode(
                    3,
                    null,
                    new TreeNode(6)
                ),
                new TreeNode(
                    2,
                    new TreeNode(4),
                    new TreeNode(
                        5,
                        new TreeNode(8),
                        new TreeNode(7)
                    )
                )
            );
            Console.WriteLine(FlipEquiv(root1, root2));
        }
    }
}

