/// Question 136. Single Number (https://leetcode-cn.com/problems/single-number/)
/// Difficulty: Easy

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        /// 执行用时: 144 ms, 在所有 C# 提交中击败了 30.82% 的用户
        /// 内存消耗: 30.3 MB, 在所有 C# 提交中击败了 5.88% 的用户
        Dictionary<string, int> frequencyDictionary = new Dictionary<string, int>();

        foreach (int num in nums)
        {
            string numString = num.ToString();
            if (frequencyDictionary.ContainsKey(numString))
            {
                frequencyDictionary[numString] += 1;
            }
            else
            {
                frequencyDictionary[numString] = 1;
            }
        }

        foreach (KeyValuePair<string, int> frequency in frequencyDictionary)
        {
            if (frequency.Value == 1)
            {
                return int.Parse(frequency.Key);
            }
        }

        // Should not be reached.
        return -1;
    }

    /*
    Better solution, with the following results:

    执行用时: 120 ms, 在所有 C# 提交中击败了 73.49% 的用户
    内存消耗: 26.3 MB, 在所有 C# 提交中击败了 29.41% 的用户
    */
    public int SingleNumberSecondTry(int[] nums)
    {
        int a = 0;

        foreach (int num in nums)
        {
            a ^= num;
        }

        return a;
    }
}