using System.Collections.Generic;
using Microsoft.VisualBasic;
// Question 140. Word Break II (https://leetcode-cn.com/problems/word-break-ii/)

/// <summary>
/// Test cases to be aware of:
///     1. "cbca"
///        ["bc","ca"]
///        This test case has been past now.
/// 
///     2. "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
///        ["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]
///        This test case will cause the program execution time exceed the limitation.
/// </summary>
public class SolutionFailed
{
    private Dictionary<char, List<string>> _charWordMapping;
    private int _stringLength;
    private IList<string> _possibleSentences;


    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        // Create mapping for starting character and the word. 
        this._charWordMapping = new Dictionary<char, List<string>>();
        this._stringLength = s.Count();
        this._possibleSentences = new List<string>();

        foreach (string word in wordDict)
        {
            char startingCharacterForWord = word[0];
            if (this._charWordMapping.ContainsKey(startingCharacterForWord))
            {
                this._charWordMapping[startingCharacterForWord].Add(word);
            }
            else
            {
                this._charWordMapping[startingCharacterForWord] = new List<string>() { word };
            }
        }

        char startingCharacter = s[0];
        if (!this._charWordMapping.ContainsKey(startingCharacter)) { return this._possibleSentences; }

        this.CheckWordCombination(s, 0, new List<string>());

        return this._possibleSentences;
    }

    private void CheckWordCombination(string s, int startingIndex, List<string> currentWords)
    {
        // System.Console.WriteLine($"startingIndex = {startingIndex}, currentWords = [{string.Join(", ", currentWords)}]");

        if (startingIndex == this._stringLength)
        {
            this._possibleSentences.Add(string.Join(" ", currentWords));
            return;
        }

        if (startingIndex > this._stringLength) { return; }

        char currentCharacter = s[startingIndex];
        if (!this._charWordMapping.ContainsKey(currentCharacter)) { return; }

        foreach (var word in this._charWordMapping[currentCharacter])
        {
            var wordIndex = s.IndexOf(word, startingIndex);
            // System.Console.WriteLine($"wordIndex = {wordIndex}, word = {word}, currentWords = [{string.Join(", ", currentWords)}]");

            if (wordIndex == startingIndex)
            {
                var wordsList = currentWords.ToList();
                wordsList.Add(word);
                this.CheckWordCombination(s, startingIndex + word.Count(), wordsList);
            }
        }
    }
}


/// <summary>
/// 执行用时：320 ms, 在所有 C# 提交中击败了 77.78% 的用户
/// 内存消耗：33.2 MB, 在所有 C# 提交中击败了 19.23% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/word-break-ii/solution/dan-ci-chai-fen-ii-by-leetcode-solution/)
/// </summary>
public class Solution
{
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        Dictionary<int, List<List<string>>> map = new Dictionary<int, List<List<string>>>();
        List<List<string>> wordBreaks = this.Backtrack(s, s.Count(), new HashSet<string>(wordDict), 0, map);

        IList<string> breakList = new List<string>();
        foreach (List<string> wordBreak in wordBreaks)
        {
            breakList.Add(string.Join(" ", wordBreak));
        }

        return breakList;
    }

    private List<List<string>> Backtrack(string s, int stringLength, HashSet<string> wordSet, int index, Dictionary<int, List<List<string>>> map)
    {
        if (!map.ContainsKey(index))
        {
            List<List<string>> wordBreaks = new List<List<string>>();
            if (index == stringLength)
            {
                wordBreaks.Add(new List<string>());
            }

            for (int i = index + 1; i <= stringLength; i++)
            {
                string word = s.Substring(index, i - index);
                if (wordSet.Contains(word))
                {
                    List<List<string>> nextWordBreaks = this.Backtrack(s, stringLength, wordSet, i, map);

                    foreach (List<string> nextWordBreak in nextWordBreaks)
                    {
                        List<string> wordBreak = new List<string>(nextWordBreak);

                        wordBreak.Insert(0, word);
                        wordBreaks.Add(wordBreak);
                    }
                }
            }

            map[index] = wordBreaks;
        }

        return map[index];
    }
}