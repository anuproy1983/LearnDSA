# Linked List Data Structure

## Table of Contents
1. [Introduction](#introduction)
2. [Structure](#structure)
3. [Node Implementation](#node-implementation)
4. [LinkedList Implementation](#linkedlist-implementation)
5. [Operations](#operations)
6. [Time and Space Complexity](#time-and-space-complexity)
7. [Advantages and Disadvantages](#advantages-and-disadvantages)
8. [Types of Linked Lists](#types-of-linked-lists)
9. [Common Use Cases](#common-use-cases)
10. [Examples](#examples)

## Introduction

A **Linked List** is a linear data structure where elements are stored in nodes, and each node contains data and a reference (or pointer) to the next node in the sequence. Unlike arrays, linked list elements are not stored in contiguous memory locations.

### Key Characteristics:
- **Dynamic Size**: Can grow or shrink during runtime
- **Sequential Access**: Elements must be accessed sequentially from the head
- **Memory Efficient**: Only allocates memory as needed
- **No Random Access**: Cannot directly access elements by index like arrays

## Structure

```
[Data|Next] -> [Data|Next] -> [Data|Next] -> NULL
     Node1          Node2          Node3
```

### Visual Representation:
```
Head -> [10|•] -> [20|•] -> [30|NULL]
        Node1     Node2     Node3
```

## Node Implementation

The `Node<T>` class represents a single element in the linked list:

```csharp
public class Node<T>
{
    public T Data { get; set; }        // The actual data stored
    public Node<T>? Next { get; set; } // Reference to next node
    
    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}
```

### Key Components:
- **Data**: Stores the actual value
- **Next**: Points to the next node (null for the last node)

## LinkedList Implementation

Our `LinkedList<T>` class provides a complete implementation with:

### Properties:
- `Head`: Reference to the first node
- `Count`: Number of elements in the list
- `IsEmpty`: Whether the list is empty

### Core Methods:
- `AddFirst(T data)`: Add element at the beginning
- `AddLast(T data)`: Add element at the end
- `InsertAt(int index, T data)`: Insert at specific position
- `Remove(T data)`: Remove first occurrence of value
- `RemoveAt(int index)`: Remove element at index
- `Contains(T data)`: Check if element exists
- `ElementAt(int index)`: Get element at index

## Operations

### 1. Insertion Operations

#### AddFirst (Insert at Beginning)
```csharp
public void AddFirst(T data)
{
    Node<T> newNode = new Node<T>(data);
    newNode.Next = Head;  // Point to current first node
    Head = newNode;       // Update head to new node
    Count++;
}
```

**Step-by-step process:**
1. Create a new node with the data
2. Point the new node's Next to current Head
3. Update Head to point to the new node
4. Increment count

**Visual Example:**
```
Before: Head -> [20] -> [30] -> NULL
Insert 10 at beginning:
After:  Head -> [10] -> [20] -> [30] -> NULL
```

#### AddLast (Insert at End)
```csharp
public void AddLast(T data)
{
    Node<T> newNode = new Node<T>(data);
    
    if (Head == null)
    {
        Head = newNode;
        return;
    }
    
    Node<T> current = Head;
    while (current.Next != null)
    {
        current = current.Next;
    }
    current.Next = newNode;
    Count++;
}
```

**Step-by-step process:**
1. Create a new node
2. If list is empty, make it the head
3. Otherwise, traverse to the last node
4. Point the last node's Next to the new node

### 2. Deletion Operations

#### RemoveFirst
```csharp
public T RemoveFirst()
{
    if (Head == null)
        throw new InvalidOperationException("List is empty");
    
    T data = Head.Data;
    Head = Head.Next;  // Move head to next node
    Count--;
    return data;
}
```

#### Remove by Value
```csharp
public bool Remove(T data)
{
    if (Head == null) return false;
    
    // If head contains the data
    if (EqualityComparer<T>.Default.Equals(Head.Data, data))
    {
        Head = Head.Next;
        Count--;
        return true;
    }
    
    // Search for the node to remove
    Node<T> current = Head;
    while (current.Next != null)
    {
        if (EqualityComparer<T>.Default.Equals(current.Next.Data, data))
        {
            current.Next = current.Next.Next;  // Skip the node
            Count--;
            return true;
        }
        current = current.Next;
    }
    return false;
}
```

### 3. Search Operations

#### Contains
```csharp
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
```

### 4. Advanced Operations

#### Reverse
```csharp
public void Reverse()
{
    Node<T>? previous = null;
    Node<T>? current = Head;
    Node<T>? next = null;
    
    while (current != null)
    {
        next = current.Next;     // Store next
        current.Next = previous; // Reverse link
        previous = current;      // Move previous
        current = next;          // Move current
    }
    
    Head = previous;  // Update head
}
```

**Visual Example of Reverse:**
```
Before: [1] -> [2] -> [3] -> NULL
After:  [3] -> [2] -> [1] -> NULL
```

## Time and Space Complexity

| Operation | Time Complexity | Space Complexity | Notes |
|-----------|----------------|------------------|-------|
| AddFirst | O(1) | O(1) | Always constant time |
| AddLast | O(n) | O(1) | Must traverse to end |
| InsertAt(index) | O(n) | O(1) | Must traverse to position |
| RemoveFirst | O(1) | O(1) | Always constant time |
| RemoveLast | O(n) | O(1) | Must find second-to-last |
| Remove(value) | O(n) | O(1) | Must search for value |
| RemoveAt(index) | O(n) | O(1) | Must traverse to position |
| Contains | O(n) | O(1) | Linear search required |
| ElementAt(index) | O(n) | O(1) | Must traverse to position |
| Reverse | O(n) | O(1) | Single pass through list |

### Space Complexity Analysis:
- **Per Node**: O(1) extra space for the Next pointer
- **Overall**: O(n) where n is the number of elements
- **Overhead**: Each node requires additional memory for the pointer

## Advantages and Disadvantages

### Advantages ✅
1. **Dynamic Size**: Can grow and shrink during runtime
2. **Memory Efficient**: Only allocates memory as needed
3. **Fast Insertion/Deletion**: O(1) at the beginning
4. **No Memory Waste**: Uses exactly the memory needed
5. **Flexible**: Easy to implement other data structures

### Disadvantages ❌
1. **No Random Access**: Cannot access elements by index directly
2. **Extra Memory**: Each node requires additional pointer storage
3. **Poor Cache Performance**: Nodes may be scattered in memory
4. **Sequential Access Only**: Must traverse from the beginning
5. **Slower Search**: O(n) linear search required

## Types of Linked Lists

### 1. Singly Linked List (Our Implementation)
- Each node points to the next node
- Traversal only in one direction

### 2. Doubly Linked List
- Each node has pointers to both next and previous nodes
- Bidirectional traversal possible

### 3. Circular Linked List
- Last node points back to the first node
- Forms a circle

### 4. Circular Doubly Linked List
- Combines circular and doubly linked features

## Common Use Cases

### When to Use Linked Lists:
1. **Frequent Insertions/Deletions at Beginning**: Ideal for stacks, queues
2. **Unknown or Variable Size**: When you don't know the final size
3. **Memory Constraints**: When you can't allocate large contiguous blocks
4. **Implementation of Other Data Structures**: Stacks, queues, graphs

### Real-world Examples:
- **Music Playlist**: Next/previous song functionality
- **Browser History**: Back and forward navigation
- **Undo/Redo Operations**: In text editors
- **Memory Management**: Free list in allocators

### When NOT to Use:
1. **Frequent Random Access**: Use arrays instead
2. **Binary Search Requirements**: Need sorted arrays
3. **Memory is Limited**: Pointer overhead might be significant
4. **Cache Performance Critical**: Arrays provide better locality

## Examples

### Basic Usage Example:
```csharp
var list = new LinkedList<int>();

// Add elements
list.AddFirst(10);    // [10]
list.AddLast(20);     // [10] -> [20]
list.AddLast(30);     // [10] -> [20] -> [30]

// Insert at position
list.InsertAt(1, 15); // [10] -> [15] -> [20] -> [30]

// Search
bool found = list.Contains(20);  // true
int index = list.IndexOf(15);    // 1

// Remove
list.Remove(15);      // [10] -> [20] -> [30]
list.RemoveFirst();   // [20] -> [30]

// Access
int first = list.First();  // 20
int last = list.Last();    // 30
```

### Iteration Example:
```csharp
var list = new LinkedList<string>();
list.AddLast("Apple");
list.AddLast("Banana");
list.AddLast("Cherry");

// Using foreach (IEnumerable implementation)
foreach (string fruit in list)
{
    Console.WriteLine(fruit);
}

// Manual traversal
Node<string>? current = list.Head;
while (current != null)
{
    Console.WriteLine(current.Data);
    current = current.Next;
}
```

### Performance Comparison with Arrays:

| Scenario | Array | Linked List | Winner |
|----------|-------|-------------|--------|
| Access by index | O(1) | O(n) | Array |
| Insert at beginning | O(n) | O(1) | Linked List |
| Insert at end | O(1)* | O(n) | Array |
| Search for value | O(n) | O(n) | Tie |
| Memory usage | Lower | Higher | Array |
| Cache performance | Better | Worse | Array |

*Assuming dynamic array with available capacity

---

## Conclusion

Linked Lists are fundamental data structures that provide dynamic memory allocation and efficient insertion/deletion at the beginning. While they have limitations like lack of random access and extra memory overhead, they are essential for understanding more complex data structures and are useful in specific scenarios where their advantages outweigh their disadvantages.

The key to mastering linked lists is understanding when to use them versus other data structures like arrays or dynamic arrays, and being comfortable with pointer manipulation and recursive thinking.