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

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        //using tuple. no temp variable needed here
                        (nums[j + 1], nums[j]) = (nums[j], nums[j + 1]);
                    }
                }
            }
            return nums;

        }
    }
}
