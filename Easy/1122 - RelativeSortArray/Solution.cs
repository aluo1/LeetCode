// Question 1122. Relative Sort Array (https://leetcode-cn.com/problems/relative-sort-array/)

public class Solution 
{
    /// <summary>
    /// 执行用时：280 ms, 在所有 C# 提交中击败了 72.34% 的用户
    /// 内存消耗：30.2 MB, 在所有 C# 提交中击败了 25.53% 的用户
    /// </summary>
    /// <param name="arr1"></param>
    /// <param name="arr2"></param>
    /// <returns></returns>
    public int[] RelativeSortArray(int[] arr1, int[] arr2) 
    {
        int[] arrayForSorting = new int[1001];
        Array.Fill(arrayForSorting, 0);


        int ARRAY_1_LENGTH = arr1.Count();
        int ARRAY_2_LENGTH = arr2.Count();

        for (int i = 0; i < ARRAY_1_LENGTH; i++) 
        {
            int currentValue = arr1[i];
            arrayForSorting[currentValue]++;
        }

        int[] sortedArray = new int[ARRAY_1_LENGTH];
        int arrayPointer = 0;

        for(int i = 0; i < ARRAY_2_LENGTH; i++)
        {  
            int currentValue = arr2[i];
            int valueCount = arrayForSorting[currentValue];
            // System.Console.WriteLine($"arrayForSorting[{currentValue}] = {valueCount}");

            for(int j = 0; j < valueCount; j++)
            {
                sortedArray[arrayPointer] = currentValue;
                arrayPointer++;
            }
            arrayForSorting[currentValue] = 0;
        }

        for (int i = 0; i < arrayForSorting.Count(); i++)
        {
            int currentValue = arrayForSorting[i];
            for(int j = 0; j < currentValue; j++)
            {
                sortedArray[arrayPointer++] = i;
            }
            arrayForSorting[i] = 0; 
        }

        return sortedArray;
    }
}