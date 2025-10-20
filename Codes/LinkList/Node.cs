public sealed class Node<T>
{
    //Holds the data while create Node
    public T Data { get; set; }

    //Pointer to next node.
    //Initially it will be null, this means consider as a single node 
    // having no reference to other node
    public Node<T>? Next { get; set; } = null;

    public Node(T data)
    {
        Data = data;
        Next = null;
    }

}