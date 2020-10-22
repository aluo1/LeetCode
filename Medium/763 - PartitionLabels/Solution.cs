using System;
public class Solution
{
    /// <summary>
    /// 执行用时：276 ms, 在所有 C# 提交中击败了 40.00% 的用户
    /// 内存消耗：31.4 MB, 在所有 C# 提交中击败了 12.50% 的用户
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    public IList<int> PartitionLabels(string S)
    {
        Dictionary<char, (int, int)> charactersIndex = new Dictionary<char, (int, int)>();
        int sLength = S.Count();

        for (int i = 0; i < sLength; i++)
        {
            char character = S[i];
            if (charactersIndex.ContainsKey(character))
            {
                var (startIndex, endIndex) = charactersIndex[character];
                startIndex = Math.Min(startIndex, i);
                endIndex = Math.Max(endIndex, i);

                charactersIndex[character] = (startIndex, endIndex);
            }
            else
            {
                charactersIndex[character] = (i, int.MinValue);
            }
        }

        // Console.WriteLine(string.Join(", ", charactersIndex));
        IList<int> partitionsLength = new List<int>();

        int currentPartitionStart = 0;
        int currentPartitionEnd = 0;

        for (int i = 0; i < sLength; i++)
        {
            char character = S[i];
            var (startIndex, endIndex) = charactersIndex[character];

            endIndex = Math.Max(startIndex, endIndex);
            currentPartitionEnd = Math.Max(currentPartitionEnd, endIndex);

            if (i == currentPartitionEnd)
            {
                partitionsLength.Add(currentPartitionEnd - currentPartitionStart + 1);
                currentPartitionStart = currentPartitionEnd + 1;
            }
        }

        return partitionsLength;
    }
}