## How `arr` Is Stored in Memory in C#

```csharp
//Define an array
string[] arr = { "apple", "banana", "cherry" };

//Add an element at the end of the array
arr = [.. arr, "Mango"];
arr =arr.Append("Mango").ToArray();//Same meaning with above;
```



- **Stack:**  
  The variable `arr` (a reference to the array) is stored on the stack inside the `Main` method’s stack frame.

- **Heap:**  
  The actual array object (`string[]`) and its elements (`"apple"`, `"banana"`, `"cherry"`, `"Mango"`) are stored on the heap.

### Visualization

```
Stack                Heap
-----------------    -------------------------
| arr (ref)      |-->| ["apple", "banana", "cherry", "Mango"] |
-----------------    |   |      |      |      |      |
                     | "apple" "banana" "cherry" "Mango" |
                     -------------------------
```

```csharp

//display an item for an specific index
  Console.WriteLine(arr[3]);//Output:Mango
```

### what happen in background when an new element added to an existing array.
```csharp
//In background when added an elment below thing happen.
//1. Array is fixed size. This means once defined size couldn't be change.
//2.When append an element, it create a new array with one more additional space where old array value could copy with additional one
//3.Old array space will remove using .NET garbage collector.


        string[] arr = { "a", "b" };
        var y = arr.Append("c").ToArray;
        
        //When add an element to an array, a new array 
        // is created and the old elements are copied to the new array.
        string[] newArr = new string[arr.Length + 1];
        Array.Copy(arr,newArr,arr.Length+1);
```

## How Deleting an Item from an Array Works Internally in C#

When you run:
```csharp
arr = arr.Where(x => x != "banana").ToArray();
```

### What Happens in the Background

- `Where(x => x != "banana")` creates an enumerable sequence that skips `"banana"`.
- `ToArray()` iterates through this sequence and allocates a new array.
- All elements except `"banana"` are copied into the new array.
- The variable `arr` now points to the new array.
- The old array is no longer referenced and becomes eligible for garbage collection.

### Visual Representation

```
Before:
arr -> ["apple", "banana", "cherry"]

Operation:
arr = arr.Where(x => x != "banana").ToArray();

After:
arr -> ["apple", "cherry"]
(old array ["apple", "banana", "cherry"] is unreferenced)
```

**Summary:**  
Deleting an item from an array in C# creates a new array without the item, and the old array is cleaned up by the garbage collector.


## How to Add an Element to the Start of an Array in C#

Arrays in C# have a fixed size, so you cannot use `Insert` or `unshift` directly.  
To add an element to the start, create a new array and copy the elements:

### Example

```csharp
string[] arr = { "b", "c" };

// Create a new array with one extra slot
string[] newArr = new string[arr.Length + 1];

// Add the new element at the start
newArr[0] = "a";

// Copy the old elements to the new array starting index 1
Array.Copy(arr, 0, newArr, 1, arr.Length);

// newArr is now ["a", "b", "c"]
```

**Summary:**  
You must create a new array and copy elements to add an item at the start in C#.

## How to Mimic JavaScript `splice` with Arrays in C#

Arrays in C# are fixed-size, so you cannot directly remove or insert elements.  
To mimic `splice`, you must create a new array and copy elements as needed.

### Example: Replace element at index 1 with "x"

```csharp
string[] arr = { "a", "b", "c" };

// Create a new array with the same length
string[] newArr = new string[arr.Length];

// Copy elements before index 1
Array.Copy(arr, 0, newArr, 0, 1);

// Insert "x" at index 1
newArr[1] = "x";

// Copy elements after index 1
Array.Copy(arr, 2, newArr, 2, arr.Length - 2);

// newArr is now ["a", "x", "c"]
```

**Summary:**  
To mimic `splice` with arrays, create a new array and manually copy/replace elements as needed.



**Summary:**

- `arr` is a reference on the stack.
- The array and its string elements are objects on the heap.
