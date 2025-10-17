using System.Collections;
using System.Text;

namespace LearnDSA.Codes.LinkList
{
    /// <summary>
    /// A generic implementation of a singly linked list
    /// This implementation provides all essential operations for managing a linked list
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the linked list</typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Reference to the first node in the linked list
        /// If the list is empty, Head will be null
        /// </summary>
        public Node<T>? Head { get; private set; }

        /// <summary>
        /// The number of elements currently in the linked list
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets whether the linked list is empty
        /// </summary>
        public bool IsEmpty => Head == null;

        /// <summary>
        /// Constructor to create an empty linked list
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Adds a new element to the beginning of the linked list
        /// Time Complexity: O(1)
        /// </summary>
        /// <param name="data">The data to add</param>
        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        /// <summary>
        /// Adds a new element to the end of the linked list
        /// Time Complexity: O(n) - needs to traverse to the end
        /// </summary>
        /// <param name="data">The data to add</param>
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            // If list is empty, make the new node the head
            if (Head == null)
            {
                Head = newNode;
                Count++;
                return;
            }

            // Traverse to the last node
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Link the last node to the new node
            current.Next = newNode;
            Count++;
        }

        /// <summary>
        /// Inserts an element at the specified index
        /// Time Complexity: O(n) - needs to traverse to the position
        /// </summary>
        /// <param name="index">The zero-based index where to insert</param>
        /// <param name="data">The data to insert</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is invalid</exception>
        public void InsertAt(int index, T data)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            // If inserting at the beginning
            if (index == 0)
            {
                AddFirst(data);
                return;
            }

            Node<T> newNode = new Node<T>(data);
            Node<T> current = Head!;

            // Traverse to the node before the insertion point
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }

            // Insert the new node
            newNode.Next = current.Next;
            current.Next = newNode;
            Count++;
        }

        /// <summary>
        /// Removes the first occurrence of the specified element
        /// Time Complexity: O(n) - might need to traverse the entire list
        /// </summary>
        /// <param name="data">The data to remove</param>
        /// <returns>True if the element was found and removed, false otherwise</returns>
        public bool Remove(T data)
        {
            if (Head == null)
                return false;

            // If the head node contains the data to remove
            if (EqualityComparer<T>.Default.Equals(Head.Data, data))
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            Node<T> current = Head;
            while (current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Data, data))
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes the element at the specified index
        /// Time Complexity: O(n) - needs to traverse to the position
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is invalid</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            // If removing the head
            if (index == 0)
            {
                Head = Head!.Next;
                Count--;
                return;
            }

            Node<T> current = Head!;

            // Traverse to the node before the one to remove
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next!;
            }

            // Remove the node
            current.Next = current.Next!.Next;
            Count--;
        }

        /// <summary>
        /// Removes the first element from the linked list
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns>The data of the removed element</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty</exception>
        public T RemoveFirst()
        {
            if (Head == null)
                throw new InvalidOperationException("Cannot remove from an empty list");

            T data = Head.Data;
            Head = Head.Next;
            Count--;
            return data;
        }

        /// <summary>
        /// Removes the last element from the linked list
        /// Time Complexity: O(n) - needs to traverse to find the second-to-last node
        /// </summary>
        /// <returns>The data of the removed element</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty</exception>
        public T RemoveLast()
        {
            if (Head == null)
                throw new InvalidOperationException("Cannot remove from an empty list");

            // If there's only one element
            if (Head.Next == null)
            {
                T data = Head.Data;
                Head = null;
                Count--;
                return data;
            }

            // Find the second-to-last node
            Node<T> current = Head;
            while (current.Next!.Next != null)
            {
                current = current.Next;
            }

            T lastData = current.Next.Data;
            current.Next = null;
            Count--;
            return lastData;
        }

        /// <summary>
        /// Searches for the specified element in the linked list
        /// Time Complexity: O(n) - might need to traverse the entire list
        /// </summary>
        /// <param name="data">The data to search for</param>
        /// <returns>True if the element is found, false otherwise</returns>
        public bool Contains(T data)
        {
            Node<T>? current = Head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Finds the index of the first occurrence of the specified element
        /// Time Complexity: O(n) - might need to traverse the entire list
        /// </summary>
        /// <param name="data">The data to search for</param>
        /// <returns>The zero-based index of the element, or -1 if not found</returns>
        public int IndexOf(T data)
        {
            Node<T>? current = Head;
            int index = 0;

            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                    return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Gets the element at the specified index
        /// Time Complexity: O(n) - needs to traverse to the position
        /// </summary>
        /// <param name="index">The zero-based index</param>
        /// <returns>The element at the specified index</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is invalid</exception>
        public T ElementAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");

            Node<T> current = Head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }

            return current.Data;
        }

        /// <summary>
        /// Gets the first element in the linked list
        /// Time Complexity: O(1)
        /// </summary>
        /// <returns>The first element</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty</exception>
        public T First()
        {
            if (Head == null)
                throw new InvalidOperationException("List is empty");
            return Head.Data;
        }

        /// <summary>
        /// Gets the last element in the linked list
        /// Time Complexity: O(n) - needs to traverse to the end
        /// </summary>
        /// <returns>The last element</returns>
        /// <exception cref="InvalidOperationException">Thrown when the list is empty</exception>
        public T Last()
        {
            if (Head == null)
                throw new InvalidOperationException("List is empty");

            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        /// <summary>
        /// Removes all elements from the linked list
        /// Time Complexity: O(1)
        /// </summary>
        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        /// <summary>
        /// Converts the linked list to an array
        /// Time Complexity: O(n)
        /// </summary>
        /// <returns>An array containing all elements</returns>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            Node<T>? current = Head;
            int index = 0;

            while (current != null)
            {
                array[index++] = current.Data;
                current = current.Next;
            }

            return array;
        }

        /// <summary>
        /// Reverses the linked list in place
        /// Time Complexity: O(n)
        /// Space Complexity: O(1)
        /// </summary>
        public void Reverse()
        {
            Node<T>? previous = null;
            Node<T>? current = Head;
            Node<T>? next = null;

            while (current != null)
            {
                // Store the next node
                next = current.Next;
                
                // Reverse the link
                current.Next = previous;
                
                // Move pointers forward
                previous = current;
                current = next;
            }

            // Update head to point to the new first node
            Head = previous;
        }

        /// <summary>
        /// Creates a string representation of the linked list
        /// </summary>
        /// <returns>A string showing all elements in the list</returns>
        public override string ToString()
        {
            if (Head == null)
                return "[]";

            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            Node<T> current = Head;
            while (current != null)
            {
                sb.Append(current.Data?.ToString() ?? "null");
                if (current.Next != null)
                    sb.Append(" -> ");
                current = current.Next;
            }

            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Creates a detailed string representation showing the structure
        /// </summary>
        /// <returns>A detailed string representation</returns>
        public string ToDetailedString()
        {
            if (Head == null)
                return "Empty List";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"LinkedList with {Count} elements:");

            Node<T> current = Head;
            int index = 0;

            while (current != null)
            {
                sb.AppendLine($"  [{index}] {current.Data?.ToString() ?? "null"}");
                current = current.Next;
                index++;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Implements IEnumerable<T> to allow foreach iteration
        /// </summary>
        /// <returns>An enumerator for the linked list</returns>
        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Implements IEnumerable to allow foreach iteration
        /// </summary>
        /// <returns>An enumerator for the linked list</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}