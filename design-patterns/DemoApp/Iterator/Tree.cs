namespace DemoApp
{
    public interface IterableCollection
    {
        Iterator CreateIterator();
    }
    public class TreeNode : IterableCollection 
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public Iterator CreateIterator()
        {
            return new TreePreorderIterator(this);
        }
    }

}
