using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorithmes;

namespace SortingTests
{
    [TestClass]
    public class SortingTests
    {
        private int[] array;
        private ISorter<int> _sorter;

        private void SetUp(ISorter<int> sorter)
        {
            array = new[] { 3, 4, 1, 5, 2 };
            _sorter = sorter;
        }

        private bool SortAndCompare()
        {
            _sorter.Sort(array);
            var expected = new[] {1, 2, 3, 4, 5};
            var equals = (array.Length == expected.Length);
            if (array.Where((t, i) => t != expected[i]).Any())
            {
                @equals = false;
            }
            return equals;
        }
            
        [TestMethod]
        public void BubbleSortTest()
        {
            SetUp(new BubbleSort<int>());
            Assert.IsTrue(SortAndCompare());
        }
    }
}
