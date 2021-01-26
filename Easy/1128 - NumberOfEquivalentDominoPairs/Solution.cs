// Question 1128. Number of Equivalent Domino Pairs (https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/)

/// <summary>
/// 执行用时：164 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：31.5 MB, 在所有 C# 提交中击败了 85.71% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/number-of-equivalent-domino-pairs/solution/deng-jie-duo-mi-nuo-gu-pai-dui-de-shu-li-08z8/)
/// </summary>
public class Solution 
{
    public int NumEquivDominoPairs(int[][] dominoes) 
    {
        int dominoesCount = dominoes.Count();
        if (dominoesCount <= 1) { return 0; }

        int[] num = new int[100];
        int pairsCount = 0;

        for (int i = 0; i < dominoesCount; i++)
        {
            var domino = dominoes[i];
            int valueIndex = domino[0] > domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];
            
            pairsCount += num[valueIndex];
            num[valueIndex] = num[valueIndex] + 1;   
        }

        return pairsCount;
    }

    public bool AreEquivalentDominoPairs(int[] dominoA, int[] dominoB)
    {
        return (dominoA[0] == dominoB[0] && dominoA[1] == dominoB[1]) 
            || (dominoA[0] == dominoB[1] && dominoA[1] == dominoB[0]);
    }
}