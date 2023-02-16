// SALEM'S SIMPLE SEARCH LIBRARY
namespace SearchLib
{
    public static class SearchMethods
    {
        // Linear Search Algorithm for int -- return index
        public static int LinearSearchInt(int[] anArray, int item)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                if (anArray[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        // Linear Search Algorithm for string -- return index
        public static int LinearSearchStr(string[] anArray, string item)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                if (anArray[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        // Binary Search Algorithm for int -- return index (needs sorted data)
        public static int BinarySearchInt(int[] anArray, int item)
        {
            int lowIndex = 0;
            int midIndex;
            int upIndex = anArray.Length - 1;

            bool isSearching = true;
            while (isSearching)
            {
                midIndex = (lowIndex + upIndex) / 2;

                if (item == anArray[midIndex])
                {
                    return midIndex;
                }
                else if (item < anArray[midIndex])
                {
                    upIndex = midIndex - 1;
                }
                else // item > value at midIndex
                {
                    lowIndex = midIndex + 1;
                }
                // if lower index is above upper index, number is not in array
                if (lowIndex > upIndex)
                {
                    isSearching = false;
                }
            }
            return -1;
        }

        // Binary Search Algorithm for string -- return index (needs alphabetically sorted data)
        public static int BinarySearchStr(string[] anArray, string item)
        {
            int lowIndex = 0;
            int midIndex;
            int upIndex = anArray.Length - 1;

            bool isSearching = true;
            while (isSearching)
            {
                midIndex = (lowIndex + upIndex) / 2;

                if (item == anArray[midIndex])
                {
                    return midIndex;
                }
                // string.Compare s1<s2 returns -1
                else if (string.Compare(item, anArray[midIndex]) == -1)
                {
                    upIndex = midIndex - 1;
                }
                else // item > value at midIndex
                {
                    lowIndex = midIndex + 1;
                }
                // if lower index is above upper index, number is not in array
                if (lowIndex > upIndex)
                {
                    isSearching = false;
                }
            }
            return -1;
        }
    }
}
