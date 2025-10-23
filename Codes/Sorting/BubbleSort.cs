namespace LearnDSA.Codes.Sorting
{
    public class BubbleSort : ISortAlgorithm
    {
        public void Display(int[] sortedArray)
        {
            Console.WriteLine("Sorted Array using Bubble Sort:");
            foreach (var item in sortedArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }

        public int[] Sort(int[] nums)
        {
            //1. Get the first element as current element and compare each element with the next element 
            //and find the smallet one and swap it with big number.
            //2.Repeast the same process with all element  and return the sorted array to print.
            //[64, 34, 25, 12, 22, 11, 90]
            //Space complexity: O(1)
            //Bubble Sort sorts the array in place.
            //It does not use any extra data structures or allocate additional memory proportional to the input size.
            //Only a few variables (like loop counters and possibly a temporary variable for swapping) are used, which do not depend on the size of the input array.
            //Time complexity: O(n^2)

            for (int i = 0; i < nums.Length - 1; i++) //O(n)
            {
                for (int j = 0; j < nums.Length - 1; j++) //O(n)
                {
                    if (nums[j] > nums[j + 1]) //O(1)
                    {
                        //using tuple. no temp variable needed here
                        (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);//O(1)
                    }
                }
            }
            return nums;

        }
    }
}
