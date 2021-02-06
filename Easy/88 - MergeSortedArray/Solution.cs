// Question 88. Merge Sorted Array (https://leetcode-cn.com/problems/merge-sorted-array/)

/// <summary>
/// 执行用时：272 ms, 在所有 C# 提交中击败了 88.40% 的用户
/// 内存消耗：30.3 MB, 在所有 C# 提交中击败了 65.93% 的用户
/// </summary>
public class Solution 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        if (n == 0) { return; }

        Queue<int> nums1Queue = new Queue<int>();
        int nums2Index = 0;

        for (int i = 0; i < m + n; i++)
        {
            if(i < m) { nums1Queue.Enqueue(nums1[i]); }
            
            // No more nums2 elements.
            if (nums2Index >= n)
            {
                nums1[i] = nums1Queue.Dequeue();
            }
            else
            {
                int num1 = nums1Queue.Any() ? nums1Queue.Peek() : int.MaxValue;
                int num2 = nums2[nums2Index];
                
                // System.Console.WriteLine($"i = {i}, num1 = {num1}, nums1Queue.Count = {nums1Queue.Count}, nums2[{nums2Index}] = {nums2[nums2Index]}");
             
                if (num1 <= num2)
                {
                    nums1[i] = num1;
                    nums1Queue.Dequeue();
                }
                else
                {
                    nums1[i] = num2;
                    nums2Index++;
                }
            }
        }                
    }
}