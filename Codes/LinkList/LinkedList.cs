using System.Collections;

public sealed class LinkedList<T>() : IEnumerable<T>
{
    public Node<T>? Head { get; set; } = null;
    public int Count { get; set; } = 0;

    public void AddFirst(T data)
    {
        //1.Create a node.
        //2. Check if head  is null or not.
        //3. if null then assign head with new created node and return.
        //4.Assign existing node's head to new node

        Node<T> newNode = new Node<T>(data);

        if (Head == null)
        {
            SetHeadToEmptyNode(newNode);
            return;
        }
        SetHeadToNewNode(newNode);

        Count++;

    }

    public void AddLast(T data)
    {
        //1. Create a new node.
        //2. Check if head is null, means it is empty list.
        //2. a. Assign new node to head and return back
        //3. Traverse head where next is null

        Node<T> newNode = new Node<T>(data);

        if (Head == null)
        {
            SetHeadToEmptyNode(newNode);
        }

        Node<T> currentNode = Head;
        while (currentNode?.Next != null)
        {
            currentNode = currentNode.Next;
        }

        currentNode.Next = newNode;
        Count++;
    }

    public void RemoveFirst()
    {
        //1. if Head is null, means list is empty and could not be delete. Display message "Invalid operation" and return it.
        //2. if it is a single node(get count), assign head as null
        //3. if more than one node, get currenthead's next node as Head. 

    }
    
    private void SetHeadToEmptyNode(Node<T> newNode)
    {
        Head = newNode;
        Count++;
    }

    private void SetHeadToNewNode(Node<T> newNode)
    {
        newNode.Next = Head;
        Head = newNode;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}