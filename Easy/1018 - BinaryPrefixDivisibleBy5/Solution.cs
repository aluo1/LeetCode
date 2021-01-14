// Question 1018. Binary Prefix Divisible By 5 (https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/)

/// <summary>
/// 执行用时：316 ms, 在所有 C# 提交中击败了 31.58% 的用户
/// 内存消耗：34.1 MB, 在所有 C# 提交中击败了 68.42% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/binary-prefix-divisible-by-5/solution/ke-bei-5-zheng-chu-de-er-jin-zhi-qian-zh-asih/)
/// </summary>
public class Solution 
{
    public IList<bool> PrefixesDivBy5(int[] A) 
    {
        int N = A.Count();
        IList<bool> divisibleArray = new List<bool>();
        
        List<int> subArray = new List<int>();
        int value = 0;
        for (var i = 0; i < N; i++)
        {
            value = ((value << 1) + A[i]) % 5;
            divisibleArray.Add(value == 0);
        }

        return divisibleArray;
    }
}