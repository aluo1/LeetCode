// Question 127. Word Ladder (https://leetcode-cn.com/problems/word-ladder/)

using System;
using System.IO;


public class Solution
{
    private Dictionary<string, int> wordIdDictionary = new Dictionary<string, int>();
    private List<List<int>> edges = new List<List<int>>();
    private int nodeNum = 0;

    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        // return this.LadderLengthBFS(beginWord, endWord, wordList);
        return this.LadderLengthBFSBidirection(beginWord, endWord, wordList);
    }

    /// <summary>
    /// 执行用时：184 ms, 在所有 C# 提交中击败了 83.46% 的用户
    /// 内存消耗：45.7 MB, 在所有 C# 提交中击败了 5.34% 的用户
    /// 
    /// Acknowledgement: This solution is a C#-version duplication of the [official solution](https://leetcode-cn.com/problems/word-ladder/solution/dan-ci-jie-long-by-leetcode-solution/) method 1.
    /// </summary>
    public int LadderLengthBFS(string beginWord, string endWord, IList<string> wordList)
    {
        // Build hash map.
        foreach (string word in wordList)
        {
            this.AddEdge(word);
        }

        this.AddEdge(beginWord);

        if (!this.wordIdDictionary.ContainsKey(endWord))
        {
            return 0;
        }

        int[] distances = new int[this.nodeNum];
        Array.Fill(distances, int.MaxValue);

        int beginWordId = this.wordIdDictionary[beginWord];
        int endWordId = this.wordIdDictionary[endWord];
        distances[beginWordId] = 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(beginWordId);

        while (queue.Count != 0)
        {
            int currentWordId = queue.Dequeue();
            if (currentWordId == endWordId) { return distances[endWordId] / 2 + 1; }

            List<int> edge = edges[currentWordId];
            foreach (var newWordId in edge)
            {
                if (distances[newWordId] == int.MaxValue)
                {
                    distances[newWordId] = distances[currentWordId] + 1;
                    queue.Enqueue(newWordId);
                }
            }
        }

        return 0;
    }

    /// <summary>
    /// 执行用时：204 ms, 在所有 C# 提交中击败了 72.18% 的用户
    /// 内存消耗：46.6 MB, 在所有 C# 提交中击败了 5.34% 的用户
    /// 
    /// Acknowledgement: This solution is a C#-version duplication of the [official solution](https://leetcode-cn.com/problems/word-ladder/solution/dan-ci-jie-long-by-leetcode-solution/) method 2.
    /// </summary>
    /// <param name="beginWord"></param>
    /// <param name="endWord"></param>
    /// <param name="wordList"></param>
    /// <returns></returns>
    public int LadderLengthBFSBidirection(string beginWord, string endWord, IList<string> wordList)
    {
        // Build hash map.
        foreach (string word in wordList)
        {
            this.AddEdge(word);
        }

        this.AddEdge(beginWord);

        if (!this.wordIdDictionary.ContainsKey(endWord))
        {
            return 0;
        }

        int[] distanceFromBegin = new int[this.nodeNum];
        Array.Fill(distanceFromBegin, int.MaxValue);
        var beginWordId = this.wordIdDictionary[beginWord];
        distanceFromBegin[beginWordId] = 0;
        Queue<int> queueFromBegin = new Queue<int>();
        queueFromBegin.Enqueue(beginWordId);

        int[] distanceFromEnd = new int[this.nodeNum];
        Array.Fill(distanceFromEnd, int.MaxValue);
        var endWordId = this.wordIdDictionary[endWord];
        distanceFromEnd[endWordId] = 0;
        Queue<int> queueFromEnd = new Queue<int>();
        queueFromEnd.Enqueue(endWordId);

        while (queueFromBegin.Count > 0 && queueFromEnd.Count > 0)
        {
            var beginQueueSize = queueFromBegin.Count;
            for (var i = 0; i < beginQueueSize; i++)
            {
                var currentWordId = queueFromBegin.Dequeue();
                if (distanceFromEnd[currentWordId] != int.MaxValue)
                {
                    return (distanceFromBegin[currentWordId] + distanceFromEnd[currentWordId]) / 2 + 1;
                }

                List<int> edge = this.edges[currentWordId];
                foreach (var wordId in edge)
                {
                    if (distanceFromBegin[wordId] == int.MaxValue)
                    {
                        distanceFromBegin[wordId] = distanceFromBegin[currentWordId] + 1;
                        queueFromBegin.Enqueue(wordId);
                    }
                }
            }

            var endQueueSize = queueFromEnd.Count;
            for (var i = 0; i < endQueueSize; i++)
            {
                var currentWordId = queueFromEnd.Dequeue();
                if (distanceFromBegin[currentWordId] != int.MaxValue)
                {
                    return (distanceFromBegin[currentWordId] + distanceFromEnd[currentWordId]) / 2 + 1;
                }

                List<int> edge = this.edges[currentWordId];
                foreach (var wordId in edge)
                {
                    if (distanceFromEnd[wordId] == int.MaxValue)
                    {
                        distanceFromEnd[wordId] = distanceFromEnd[currentWordId] + 1;
                        queueFromEnd.Enqueue(wordId);
                    }
                }
            }
        }

        return 0;
    }

    private void AddEdge(string word)
    {
        this.AddWord(word);

        var currentWordId = this.wordIdDictionary[word];

        char[] characters = word.ToCharArray();
        for (var i = 0; i < characters.Count(); i++)
        {
            var replacedChar = characters[i];

            // Create new intermediate word.
            characters[i] = '*';
            var newWord = new String(characters);
            this.AddWord(newWord);

            // Build edges.
            var newWordId = this.wordIdDictionary[newWord];
            this.edges[currentWordId].Add(newWordId);
            this.edges[newWordId].Add(currentWordId);

            // Swap back to original characters.
            characters[i] = replacedChar;
        }
    }

    private void AddWord(string word)
    {
        if (!this.wordIdDictionary.ContainsKey(word))
        {
            this.wordIdDictionary[word] = nodeNum++;
            this.edges.Add(new List<int>());
        }
    }
}