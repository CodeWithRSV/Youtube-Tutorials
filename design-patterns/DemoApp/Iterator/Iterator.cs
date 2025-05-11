namespace DemoApp
{
    public interface Iterator
    {
        public abstract object GetNext();
        public abstract bool HasMore();
    }
    public class TreePreorderIterator : Iterator
    {
        private Stack<TreeNode> stack;
        public TreePreorderIterator(TreeNode root)
        {
            stack = new Stack<TreeNode>();
            if (root != null)
            {
                stack.Push(root);
            }
        }
        public object GetNext()
        {
            if (!HasMore())
            {
                throw new InvalidOperationException("No more elements in the iterator.");
            }
            TreeNode current = stack.Pop();
            if (current.Right != null)
            {
                stack.Push(current.Right);
            }
            if (current.Left != null)
            {
                stack.Push(current.Left);
            }
            return current.Value;
        }
        public bool HasMore()
        {
            return stack.Count > 0;
        }
    }
}