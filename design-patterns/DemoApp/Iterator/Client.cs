namespace DemoApp.Iterator
{
    public class Client
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);
            root.Left.Left = new TreeNode(4);
            root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            root.Right.Right = new TreeNode(7);

            Iterator iterator = root.CreateIterator();
            Console.WriteLine("Preorder Traversal:");
            while (iterator.HasMore())
            {
                Console.Write(iterator.GetNext() + " ");
            }
        }
    }
}
