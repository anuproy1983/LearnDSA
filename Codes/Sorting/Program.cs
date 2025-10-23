using LearnDSA.Codes.Sorting;

namespace LearnDSA.Codes.SortingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bubble Sort
            var nums = new int[] { 64, 34, 25, 12, 22, 11, 90 };
            var sortAlgorithm = new BubbleSort();
            var result = sortAlgorithm.Sort(nums);
            sortAlgorithm.Display(result);
            #endregion


            
        }
    }
}
