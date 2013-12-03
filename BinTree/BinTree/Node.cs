namespace BinTree
{
    public class Node<T>
    {
        public T Value { get; private set ; }
        public Node<T> LeftNode { get; set; }  
        public Node<T> RightNode { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}