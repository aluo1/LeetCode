
/// 面试题57 - II. 和为s的连续正数序列
/// Difficulty: Easy

public class Solution
{
    public int[][] FindContinuousSequence(int target)
    {
        return FindContinuousSequenceFirstTry(target);
    }

    public int[][] FindContinuousSequenceFirstTry(int target)
    {
        /// 执行用时: 1876 ms, 在所有 C# 提交中击败了 11.11% 的用户
        /// 内存消耗: 28.4 MB, 在所有 C# 提交中击败了 100.00% 的用户

        List<int[]> consecutiveIntList = new List<int[]>();

        int halfOfTarget = target % 2 == 0 ? target / 2 : (target / 2) + 1;
        for (int i = 1; i <= halfOfTarget; i++)
        {
            List<int> consecutiveInts = new List<int>();
            for (int j = i; true; j++)
            {
                consecutiveInts.Add(j);
                int currentSum = consecutiveInts.Sum();
                if (currentSum == target && consecutiveInts.Count >= 2)
                {
                    consecutiveIntList.Add(consecutiveInts.ToArray());
                    break;
                }
                else if (currentSum > target)
                {
                    break;
                }
            }
        }

        return consecutiveIntList.ToArray();
    }

    public int[][] FindContinuousSequenceSecondTry(int target)
    {
        /// 执行用时: 248 ms, 在所有 C# 提交中击败了 100.00% 的用户
        /// 内存消耗: 26 MB, 在所有 C# 提交中击败了 100.00% 的用户
        /// Acknowledgement: https://leetcode-cn.com/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof/solution/cchun-shu-xue-bu-jie-er-ci-fang-cheng-100nei-cun-s/

        List<int[]> res = new List<int[]>();

        for (int i = 2; i < target; i++)
        {
            if ((i % 2 == 1 && i / 2 >= target / i) || (i % 2 == 0 && i / 2 > target / i)) { break; }

            if (i % 2 == 0 && target % i == i / 2) //i偶数 & target/i=m+0.5
            {
                int[] oneres = new int[i];
                int left = target / i - i / 2 + 1;
                for (int index = 0; index < i; index++)
                    oneres[index] = left + index;
                res.Add(oneres);
            }
            else if (i % 2 == 1 && target % i == 0) //i奇数 & target/i整除
            {
                int[] oneres = new int[i];
                int left = target / i - i / 2;
                for (int index = 0; index < i; index++)
                {

                    oneres[index] = left + index;
                }
                
                res.Add(oneres);
            }
        }
        res.Reverse();
        return res.ToArray();
    }
}