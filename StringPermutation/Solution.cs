/// 面试题 01.02. Check Permutation LCCI
/// Difficulty: Easy

public class Solution {
    public bool CheckPermutation(string s1, string s2) {
        return CheckPermutationFirstTry(s1, s2);
    }

    public bool CheckPermutationFirstTry(string s1, string s2) {
        // 执行用时: 92 ms, 在所有 C# 提交中击败了 35.71% 的用户
        // 内存消耗: 21.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
        
        if (s1.Length != s2.Length) { return false; }

        char[] sortedS1 = s1.OrderBy(c => c).ToArray();
        char[] sortedS2 = s2.OrderBy(c => c).ToArray();

        for (int i = 0; i < sortedS1.Length; i++) {
            if (sortedS1[i] != sortedS2[i]) {
                return false;
            }
        }

        return true;
    }

    public bool CheckPermutationSecondTry(string s1, string s2) {
        // 执行用时: 96 ms, 在所有 C# 提交中击败了 19.05% 的用户
        // 内存消耗: 21.7 MB, 在所有 C# 提交中击败了 100.00% 的用户

        if (s1.Length != s2.Length) { return false; }

        Dictionary<char, int> s1Freq = new Dictionary<char, int>();
        Dictionary<char, int> s2Freq = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; i++) {
            if (s1Freq.ContainsKey(s1[i])) {
                s1Freq[s1[i]] += 1;
            } else {
                s1Freq[s1[i]] = 1;
            }

            if (s2Freq.ContainsKey(s2[i])) {
                s2Freq[s2[i]] += 1;
            } else {
                s2Freq[s2[i]] = 1;
            }
        }

        foreach(KeyValuePair<char, int> s1CharFreq in s1Freq) {
            if (!s2Freq.ContainsKey(s1CharFreq.Key)) {
                return false;
            }
            
            if (s1CharFreq.Value != s2Freq[s1CharFreq.Key]) {
                return false;
            }
        }

        return true;
    }
}