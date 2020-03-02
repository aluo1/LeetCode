/// Question 824. Goat Latin
/// Difficulty: Easy
/// 执行用时: 96 ms, 在所有 C# 提交中击败了 100% 的用户
/// 内存消耗: 23.2 MB, 在所有 C# 提交中击败了 9.09% 的用户

public class Solution {
    public string ToGoatLatin(string S) {
        // Get words.
        string[] words = S.Split(" ");
        char[] vowels = {'a', 'e', 'i', 'o', 'u'};

        // Transform words.
        for (int i = 0; i < words.Length; i++) {
            string word = words[i];

            char firstChar = word[0];
            if (vowels.Contains(Char.ToLower(firstChar))) {
                word = $"{word}ma";
            } else {
                string subString = word.Substring(1);
                word = $"{subString}{firstChar}ma";
            }

            word = $"{word}{new String('a', i+1)}";
            words[i] = word;
        }

        return String.Join(" ", words);
    }
}