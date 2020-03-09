///  Question 1331. Rank Transform of an Array (https://leetcode-cn.com/problems/rank-transform-of-an-array/)
///  Difficulty: Easy
/// 
///  执行用时: 576 ms, 在所有 JavaScript 提交中击败了 10.00% 的用户
///  内存消耗: 51.6 MB , 在所有 JavaScript 提交中击败了 100.00% 的用户
///  
///  The normal approach: get distinct elements, sort, reverse does not work here, as it will timeout. So I have
///  to use sorted set and dictionary to minimize the time used during the execution.
public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        if (arr.Length == 0) { return arr; }

        Dictionary<string, int> sortedDistinctArr = new SortedSet<int>(arr).Select((input, index) => new { index, input }).ToDictionary(v => v.input.ToString(), v => v.index);

        return arr.Select(arrElem => sortedDistinctArr[arrElem.ToString()] + 1).ToArray();
    }
}