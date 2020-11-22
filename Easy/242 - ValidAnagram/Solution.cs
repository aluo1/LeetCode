// Question 242. Valid Anagram (https://leetcode-cn.com/problems/valid-anagram/)

/// <summary>
/// 执行用时：108 ms, 在所有 C# 提交中击败了 44.84% 的用户
/// 内存消耗：23.7 MB, 在所有 C# 提交中击败了 49.59% 的用户
/// </summary>
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) { return false; }

        Dictionary<char, int> sCharactersFrequency = this.BuildCharacterFrequencyDictionary(s);
        Dictionary<char, int> tCharactersFrequency = this.BuildCharacterFrequencyDictionary(t);

        if (sCharactersFrequency.Keys.Count() != tCharactersFrequency.Keys.Count())
        {
            return false;
        }

        foreach (char characterKey in sCharactersFrequency.Keys)
        {
            if (!tCharactersFrequency.ContainsKey(characterKey)
            || sCharactersFrequency[characterKey] != tCharactersFrequency[characterKey])
            {
                return false;
            }
        }

        return true;
    }

    private Dictionary<char, int> BuildCharacterFrequencyDictionary(string s)
    {
        Dictionary<char, int> charactersFrequency = new Dictionary<char, int>();
        foreach (char sCharacter in s)
        {
            if (charactersFrequency.ContainsKey(sCharacter))
            {
                charactersFrequency[sCharacter]++;
            }
            else
            {
                charactersFrequency[sCharacter] = 1;
            }
        }

        return charactersFrequency;
    }
}