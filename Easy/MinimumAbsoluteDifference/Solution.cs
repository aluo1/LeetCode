/// Question 1200. Minimum Absolute Difference
/// Difficulty: Easy
/// 执行用时: 420 ms, 在所有 C# 提交中击败了 50.00% 的用户
/// 内存消耗: 42.6 MB, 在所有 C# 提交中击败了 33.33% 的用户

public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        int minAbsDiff = arr.Max();
        int[] sortedArray = arr;
        Array.Sort(sortedArray);
        
        IList<IList<int>> minCombo = new List<IList<int>>();

        for (int i = 0; i < sortedArray.Length-1; i++) {
            int iVal = sortedArray[i];
            int jVal = sortedArray[i+1];

            int currentDiff = Math.Abs(jVal - iVal);
            
            if (currentDiff == minAbsDiff) {
                minCombo.Add(new List<int>{iVal, jVal});
            } 
            
            if (currentDiff < minAbsDiff) {
                minAbsDiff = currentDiff;
                minCombo = new List<IList<int>>{ new List<int>{iVal, jVal}};
            }    
        }

        return minCombo;
    }
}