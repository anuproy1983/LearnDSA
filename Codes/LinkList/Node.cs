using System;

namespace LearnDSA.Codes.LinkList
{
    /// <summary>
    /// Represents a single node in a linked list
    /// Each node contains data and a reference to the next node
    /// </summary>
    /// <typeparam name="T">The type of data stored in the node</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// The data stored in this node
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Reference to the next node in the linked list
        /// If this is the last node, Next will be null
        /// </summary>
        public Node<T>? Next { get; set; }

        /// <summary>
        /// Constructor to create a new node with the specified data
        /// </summary>
        /// <param name="data">The data to store in this node</param>
        public Node(T data)
        {
            Data = data;
            Next = null; // Initially, no next node
        }

        /// <summary>
        /// Constructor to create a new node with data and next node reference
        /// </summary>
        /// <param name="data">The data to store in this node</param>
        /// <param name="next">Reference to the next node</param>
        public Node(T data, Node<T>? next)
        {
            Data = data;
            Next = next;
        }

        /// <summary>
        /// Returns a string representation of the node
        /// </summary>
        /// <returns>String representation of the node's data</returns>
        public override string ToString()
        {
            return Data?.ToString() ?? "null";
        }
    }
}