// Question 290. Word Pattern (https://leetcode-cn.com/problems/word-pattern/)

/// <summary>
/// 执行用时：100 ms, 在所有 C# 提交中击败了 26.76% 的用户
/// 内存消耗：22.2 MB, 在所有 C# 提交中击败了 37.14% 的用户
/// </summary>
public class Solution 
{
    public bool WordPattern(string pattern, string s) 
    {
        Queue<char> patternQueue = new Queue<char>(pattern.ToCharArray());
        Queue<string> stringQueue = new Queue<string>(s.Split(" "));

        Dictionary<char, string> patternWordMapping = new Dictionary<char, string>();
        Dictionary<string, char> wordPatternMapping = new Dictionary<string, char>();

        while (patternQueue.Count != 0 && stringQueue.Count != 0)
        {
            char currentPattern = patternQueue.Dequeue();
            string currentString = stringQueue.Dequeue();

            // System.Console.WriteLine($"currentPattern = {currentPattern}, currentString = {currentString}");

            if ((patternWordMapping.ContainsKey(currentPattern) && !patternWordMapping[currentPattern].Equals(currentString)) ||
                (wordPatternMapping.ContainsKey(currentString) && !wordPatternMapping[currentString].Equals(currentPattern)))
            {
                return false;
            }
            else
            {
                patternWordMapping[currentPattern] = currentString;
                wordPatternMapping[currentString] = currentPattern;
            }
        }

        return patternQueue.Count == 0 && stringQueue.Count == 0;
    }
}