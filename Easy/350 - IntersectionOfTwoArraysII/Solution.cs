/// Question 350. Intersection of Two Arrays II (https://leetcode-cn.com/problems/intersection-of-two-arrays-ii/)

public class Solution
{
    /// 执行用时: 300 ms, 在所有 C# 提交中击败了 35.67% 的用户
    /// 内存消耗: 31.2 MB, 在所有 C# 提交中击败了 100.00% 的用户

    public int[] Intersect(int[] nums1, int[] nums2)
    {
        Dictionary<int, int> nums2Dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Count(); i++)
        {
            int num2 = nums2[i];
            if (nums2Dictionary.ContainsKey(num2))
            {
                nums2Dictionary[num2]++;
            }
            else
            {
                nums2Dictionary[num2] = 1;
            }
        }

        List<int> intersected = new List<int>();

        for (int i = 0; i < nums1.Count(); i++)
        {
            int currentNum1 = nums1[i];
            if (nums2Dictionary.ContainsKey(currentNum1) && nums2Dictionary[currentNum1] > 0)
            {
                intersected.Add(currentNum1);
                nums2Dictionary[currentNum1]--;
            }
        }

        return intersected.ToArray();
    }
}

public class SolutionUsingSorting
{
    /// 执行用时: 280 ms, 在所有 C# 提交中击败了 89.81% 的用户
    /// 内存消耗: 30.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> intersected = new List<int>();

        Array.Sort(nums1);
        Array.Sort(nums2);

        if (nums1.Count().Equals(0) || nums2.Count().Equals(0))
        {
            return intersected.ToArray();
        }

        int i = 0;
        int j = 0;

        while (true)
        {
            if (nums1[i] < nums2[j])
            {
                i++;
            }
            else if (nums1[i] > nums2[j])
            {
                j++;
            }
            else if (nums1[i].Equals(nums2[j]))
            {
                intersected.Add(nums1[i]);
                i++;
                j++;
            }

            if (i.Equals(nums1.Count()) || j.Equals(nums2.Count()))
            {
                return intersected.ToArray();
            }
        }
    }
}