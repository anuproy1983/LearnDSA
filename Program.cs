using System;
using CustomLinkedList = LearnDSA.Codes.LinkList.LinkedList<int>;
using CustomStringLinkedList = LearnDSA.Codes.LinkList.LinkedList<string>;
using CustomPersonLinkedList = LearnDSA.Codes.LinkList.LinkedList<Person>;
using LearnDSA.Codes.LinkList;

// Comprehensive LinkedList Examples with Step-by-Step Explanations
Console.WriteLine("=== LINKED LIST IMPLEMENTATION AND EXAMPLES ===");
Console.WriteLine();

// Step 1: Understanding the Node Structure
Console.WriteLine("STEP 1: Understanding Node Structure");
Console.WriteLine("====================================");
Console.WriteLine("A Node contains:");
Console.WriteLine("- Data: The actual value stored");
Console.WriteLine("- Next: Reference to the next node (null if last node)");
Console.WriteLine();

// Create individual nodes to demonstrate the concept
var node1 = new Node<int>(10);
var node2 = new Node<int>(20);
var node3 = new Node<int>(30);

Console.WriteLine($"Node1: Data = {node1.Data}, Next = {(node1.Next == null ? "null" : "not null")}");
Console.WriteLine($"Node2: Data = {node2.Data}, Next = {(node2.Next == null ? "null" : "not null")}");
Console.WriteLine($"Node3: Data = {node3.Data}, Next = {(node3.Next == null ? "null" : "not null")}");
Console.WriteLine();

// Manually linking nodes to show the concept
Console.WriteLine("Linking nodes manually:");
node1.Next = node2;  // node1 -> node2
node2.Next = node3;  // node2 -> node3
Console.WriteLine($"After linking: node1 -> {node1.Next?.Data} -> {node1.Next?.Next?.Data} -> null");
Console.WriteLine();

// Step 2: Creating and Using LinkedList
Console.WriteLine("STEP 2: Creating and Using LinkedList Class");
Console.WriteLine("==========================================");

var linkedList = new LearnDSA.Codes.LinkList.LinkedList<int>();
Console.WriteLine($"Created empty linked list. Count: {linkedList.Count}, IsEmpty: {linkedList.IsEmpty}");
Console.WriteLine($"Current state: {linkedList}");
Console.WriteLine();

// Step 3: Adding Elements
Console.WriteLine("STEP 3: Adding Elements");
Console.WriteLine("=======================");

Console.WriteLine("Adding elements to the front (AddFirst):");
linkedList.AddFirst(100);
Console.WriteLine($"After AddFirst(100): {linkedList} | Count: {linkedList.Count}");

linkedList.AddFirst(200);
Console.WriteLine($"After AddFirst(200): {linkedList} | Count: {linkedList.Count}");

linkedList.AddFirst(300);
Console.WriteLine($"After AddFirst(300): {linkedList} | Count: {linkedList.Count}");
Console.WriteLine("Note: AddFirst adds to the beginning, so newest elements appear first");
Console.WriteLine();

Console.WriteLine("Adding elements to the end (AddLast):");
linkedList.AddLast(50);
Console.WriteLine($"After AddLast(50): {linkedList} | Count: {linkedList.Count}");

linkedList.AddLast(25);
Console.WriteLine($"After AddLast(25): {linkedList} | Count: {linkedList.Count}");
Console.WriteLine("Note: AddLast adds to the end, maintaining the order");
Console.WriteLine();

// Step 4: Inserting at Specific Positions
Console.WriteLine("STEP 4: Inserting at Specific Positions");
Console.WriteLine("=======================================");

Console.WriteLine($"Current list: {linkedList}");
Console.WriteLine("Inserting 150 at index 2:");
linkedList.InsertAt(2, 150);
Console.WriteLine($"After InsertAt(2, 150): {linkedList} | Count: {linkedList.Count}");

Console.WriteLine("Inserting 400 at index 0 (beginning):");
linkedList.InsertAt(0, 400);
Console.WriteLine($"After InsertAt(0, 400): {linkedList} | Count: {linkedList.Count}");

Console.WriteLine($"Inserting 10 at index {linkedList.Count} (end):");
linkedList.InsertAt(linkedList.Count, 10);
Console.WriteLine($"After InsertAt({linkedList.Count - 1}, 10): {linkedList} | Count: {linkedList.Count}");
Console.WriteLine();

// Step 5: Searching and Accessing Elements
Console.WriteLine("STEP 5: Searching and Accessing Elements");
Console.WriteLine("========================================");

Console.WriteLine($"Current list: {linkedList}");
Console.WriteLine();

Console.WriteLine("Searching for elements:");
Console.WriteLine($"Contains(150): {linkedList.Contains(150)}");
Console.WriteLine($"Contains(999): {linkedList.Contains(999)}");
Console.WriteLine($"IndexOf(150): {linkedList.IndexOf(150)}");
Console.WriteLine($"IndexOf(999): {linkedList.IndexOf(999)}");
Console.WriteLine();

Console.WriteLine("Accessing elements by index:");
Console.WriteLine($"ElementAt(0): {linkedList.ElementAt(0)} (first element)");
Console.WriteLine($"ElementAt(3): {linkedList.ElementAt(3)} (fourth element)");
Console.WriteLine($"ElementAt({linkedList.Count - 1}): {linkedList.ElementAt(linkedList.Count - 1)} (last element)");
Console.WriteLine();

Console.WriteLine("Quick access methods:");
Console.WriteLine($"First(): {linkedList.First()}");
Console.WriteLine($"Last(): {linkedList.Last()}");
Console.WriteLine();

// Step 6: Removing Elements
Console.WriteLine("STEP 6: Removing Elements");
Console.WriteLine("=========================");

Console.WriteLine($"Current list: {linkedList}");
Console.WriteLine();

Console.WriteLine("Removing by value:");
bool removed = linkedList.Remove(150);
Console.WriteLine($"Remove(150): {removed} | Result: {linkedList} | Count: {linkedList.Count}");

removed = linkedList.Remove(999);
Console.WriteLine($"Remove(999): {removed} | Result: {linkedList} | Count: {linkedList.Count}");
Console.WriteLine();

Console.WriteLine("Removing by index:");
Console.WriteLine($"Before RemoveAt(1): {linkedList}");
linkedList.RemoveAt(1);
Console.WriteLine($"After RemoveAt(1): {linkedList} | Count: {linkedList.Count}");
Console.WriteLine();

Console.WriteLine("Removing first and last elements:");
Console.WriteLine($"Before RemoveFirst(): {linkedList}");
int removedFirst = linkedList.RemoveFirst();
Console.WriteLine($"RemoveFirst() returned: {removedFirst} | Result: {linkedList} | Count: {linkedList.Count}");

Console.WriteLine($"Before RemoveLast(): {linkedList}");
int removedLast = linkedList.RemoveLast();
Console.WriteLine($"RemoveLast() returned: {removedLast} | Result: {linkedList} | Count: {linkedList.Count}");
Console.WriteLine();

// Step 7: Advanced Operations
Console.WriteLine("STEP 7: Advanced Operations");
Console.WriteLine("===========================");

// Add some elements for demonstration
linkedList.Clear();
for (int i = 1; i <= 5; i++)
{
    linkedList.AddLast(i * 10);
}
Console.WriteLine($"Fresh list for advanced operations: {linkedList}");
Console.WriteLine();

Console.WriteLine("Converting to array:");
int[] array = linkedList.ToArray();
Console.WriteLine($"ToArray(): [{string.Join(", ", array)}]");
Console.WriteLine();

Console.WriteLine("Detailed string representation:");
Console.WriteLine(linkedList.ToDetailedString());

Console.WriteLine("Reversing the linked list:");
Console.WriteLine($"Before Reverse(): {linkedList}");
linkedList.Reverse();
Console.WriteLine($"After Reverse(): {linkedList}");
Console.WriteLine();

// Step 8: Iteration Examples
Console.WriteLine("STEP 8: Iteration Examples");
Console.WriteLine("==========================");

Console.WriteLine("Using foreach loop (IEnumerable implementation):");
Console.Write("Elements: ");
foreach (int value in linkedList)
{
    Console.Write($"{value} ");
}
Console.WriteLine();
Console.WriteLine();

// Step 9: Working with Different Data Types
Console.WriteLine("STEP 9: Working with Different Data Types");
Console.WriteLine("=========================================");

// String LinkedList
var stringList = new LearnDSA.Codes.LinkList.LinkedList<string>();
stringList.AddLast("Apple");
stringList.AddLast("Banana");
stringList.AddLast("Cherry");
stringList.AddFirst("Zebra");
Console.WriteLine($"String LinkedList: {stringList}");

// Custom Object LinkedList
var personList = new LearnDSA.Codes.LinkList.LinkedList<Person>();
personList.AddLast(new Person("Alice", 25));
personList.AddLast(new Person("Bob", 30));
personList.AddLast(new Person("Charlie", 35));
Console.WriteLine($"Person LinkedList: {personList}");
Console.WriteLine();

// Step 10: Performance Characteristics
Console.WriteLine("STEP 10: Performance Characteristics");
Console.WriteLine("====================================");
Console.WriteLine("Time Complexities:");
Console.WriteLine("- AddFirst(): O(1) - Always fast");
Console.WriteLine("- AddLast(): O(n) - Must traverse to end");
Console.WriteLine("- InsertAt(index): O(n) - Must traverse to position");
Console.WriteLine("- Remove(value): O(n) - Must search for value");
Console.WriteLine("- RemoveAt(index): O(n) - Must traverse to position");
Console.WriteLine("- RemoveFirst(): O(1) - Always fast");
Console.WriteLine("- RemoveLast(): O(n) - Must traverse to second-to-last");
Console.WriteLine("- Contains(value): O(n) - Must search linearly");
Console.WriteLine("- ElementAt(index): O(n) - Must traverse to position");
Console.WriteLine();

Console.WriteLine("Space Complexity:");
Console.WriteLine("- Each node requires extra memory for the 'Next' pointer");
Console.WriteLine("- No random access like arrays");
Console.WriteLine("- Dynamic size - grows and shrinks as needed");
Console.WriteLine();

// Step 11: Common Use Cases and Best Practices
Console.WriteLine("STEP 11: When to Use Linked Lists");
Console.WriteLine("=================================");
Console.WriteLine("Use Linked Lists when:");
Console.WriteLine("✓ You frequently insert/delete at the beginning");
Console.WriteLine("✓ The size of your data varies significantly");
Console.WriteLine("✓ You don't need random access to elements");
Console.WriteLine("✓ Memory is fragmented and you can't allocate large contiguous blocks");
Console.WriteLine();

Console.WriteLine("Avoid Linked Lists when:");
Console.WriteLine("✗ You need frequent random access to elements");
Console.WriteLine("✗ You're doing lots of searching");
Console.WriteLine("✗ Memory usage is a primary concern");
Console.WriteLine("✗ Cache performance is critical");
Console.WriteLine();

Console.WriteLine("=== END OF LINKED LIST EXAMPLES ===");

// Helper class for demonstration
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"{Name}({Age})";
    }
}