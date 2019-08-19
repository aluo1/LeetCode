/// Question 136. Single Number
/// Difficulty: Easy
/// 执行用时: 232 ms, 在所有 C# 提交中击败了 26.57% 的用户
/// 内存消耗: 29.5 MB, 在所有 C# 提交中击败了 5.34% 的用户

public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<string, int> frequencyDictionary = new Dictionary<string, int>();
        
        foreach (int num in nums) {
            string numString = num.ToString();
            if (frequencyDictionary.ContainsKey(numString)) {
                frequencyDictionary[numString] += 1;
            } else {
                frequencyDictionary[numString] = 1;
            }
        }
        
        foreach (KeyValuePair<string, int> frequency in frequencyDictionary) {
            if (frequency.Value == 1) {
                return int.Parse(frequency.Key);
            }
        }
        
        // Should not be reached.
        return -1;   
    }
}