// Question 1370. Increasing Decreasing String (https://leetcode-cn.com/problems/increasing-decreasing-string/)

/// <summary>
/// 执行用时：132 ms, 在所有 C# 提交中击败了 30.43% 的用户
/// 内存消耗：26.6 MB, 在所有 C# 提交中击败了 8.70% 的用户
/// </summary>
public class Solution 
{
    public string SortString(string s) 
    {
        Dictionary<char, int> charFreqCount = new Dictionary<char, int>();
        HashSet<char> uniqueChar = new HashSet<char>();

        foreach (char character in s)
        {
            if (charFreqCount.ContainsKey(character))
            {
                charFreqCount[character]++;
            }
            else
            {
                charFreqCount[character] = 1;
            }

            uniqueChar.Add(character);
        }

        List<char> sortedCharacters = uniqueChar.ToList();
        int charactersSize = sortedCharacters.Count;
        sortedCharacters.Sort();

        string sortedString = "";
        int characterIndex = 0;
        int indexStep = 1;
        while (true)
        {
            System.Console.WriteLine($"characterIndex = {characterIndex}, indexStep = {indexStep}, sortedString = {sortedString}");
            char currentChar = sortedCharacters[characterIndex];
            if (charFreqCount[currentChar] > 0)
            {
                sortedString += currentChar;
                charFreqCount[currentChar]--;
            }

            if (sortedString.Length == s.Length) { break; }
            
            if (characterIndex == charactersSize - 1)
            {
                indexStep = indexStep == 1 ? 0 : -1;
                characterIndex += indexStep;
                continue;
            }
            else if (characterIndex == 0)
            {
                indexStep = indexStep == -1 ? 0 : 1;
                characterIndex += indexStep;
                continue;
            }
            else
            {
                characterIndex += indexStep;
            }
        }

        return sortedString;
    }
}