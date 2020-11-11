// Question 514. Freedom Trail (https://leetcode-cn.com/problems/freedom-trail/)

/// <summary>
/// This solution failed in the following test case:
/// Input:
///     "caotmcaataijjxi"
///     "oatjiioicitatajtijciocjcaaxaaatmctxamacaamjjx"
/// Output: 146
/// Expected output: 137
/// </summary>
public class SolutionFailed
{
    private int DIAL_SIZE;
    private string DIAL_RING;
    private Dictionary<char, List<int>> CHARACTERS_INDEX_DICTIONARY;

    public int FindRotateSteps(string ring, string key) 
    {
        this.DIAL_SIZE = ring.Length;
        this.DIAL_RING = ring;
        this.BuildCharactersIndexDictionary();

        int KEY_LENGTH = key.Length;

        int dialPointer = 0;
        int nextCharacterPointer = 0;
        int steps = 0;

        while (nextCharacterPointer < KEY_LENGTH)
        {
            (int minStep, int nextDialPointer) = this.MinimumStepToGetTheCharacter(key[nextCharacterPointer], dialPointer);
            System.Console.WriteLine($"minStep = {minStep}, nextDialPointer = {nextDialPointer}, key[{nextCharacterPointer}] = {key[nextCharacterPointer]}");

            steps += minStep + 1;
            dialPointer = nextDialPointer;
            nextCharacterPointer++;
        }
        

        return steps;
    }

    private void BuildCharactersIndexDictionary() 
    {
        this.CHARACTERS_INDEX_DICTIONARY = new Dictionary<char, List<int>>();

        for (int i = 0; i < this.DIAL_SIZE; i++)
        {
            char currentCharacter = this.DIAL_RING[i];
            if (this.CHARACTERS_INDEX_DICTIONARY.ContainsKey(currentCharacter))
            {
                this.CHARACTERS_INDEX_DICTIONARY[currentCharacter].Add(i);
            }
            else 
            {
                this.CHARACTERS_INDEX_DICTIONARY[currentCharacter] = new List<int>() { i };
            }
        }
    }

    private (int, int) MinimumStepToGetTheCharacter(char targetCharacter, int currentIndex) 
    {
        List<int> characterIndexList = this.CHARACTERS_INDEX_DICTIONARY[targetCharacter];
        int minStep = int.MaxValue;
        int nextIndex = currentIndex;

        foreach (int characterIndex in characterIndexList)
        {
            int clockwiseDistance = 0;
            int anticlockwiseDistance = 0;
            if (currentIndex > characterIndex)
            {
                anticlockwiseDistance = currentIndex  - characterIndex;
                clockwiseDistance  = (this.DIAL_SIZE - 1 - currentIndex) + (characterIndex + 1);
            }
            else
            {
                clockwiseDistance  = characterIndex - currentIndex;
                anticlockwiseDistance = currentIndex + this.DIAL_SIZE - characterIndex;
                System.Console.WriteLine($"characterIndex = {characterIndex}, targetCharacter = {targetCharacter}, clockwiseDistance = {clockwiseDistance}, anticlockwiseDistance = {anticlockwiseDistance}");
            }

            int distance = Math.Min(clockwiseDistance, anticlockwiseDistance);

            if (distance < minStep)
            {
                minStep = distance;
                nextIndex = characterIndex;
            }            
        }

        return (minStep, nextIndex);
    }
}

/// <summary>
/// 执行用时：108 ms, 在所有 C# 提交中击败了 100.00% 的用户
/// 内存消耗：26.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/freedom-trail/solution/zi-you-zhi-lu-by-leetcode-solution/)
/// </summary>
public class Solution
{
    private int DIAL_SIZE;
    private string DIAL_RING;
    private int KEY_LENGTH;
    private Dictionary<char, List<int>> CHARACTERS_INDEX_DICTIONARY;

    public int FindRotateSteps(string ring, string key) 
    {
        this.DIAL_SIZE = ring.Length;
        this.DIAL_RING = ring;
        this.KEY_LENGTH = key.Length;

        this.BuildCharactersIndexDictionary();
        int[][] dp = new int[this.KEY_LENGTH][];

        for (int i = 0; i < this.KEY_LENGTH; i++)
        {
            dp[i] = new int[this.DIAL_SIZE];
            Array.Fill(dp[i], int.MaxValue);
        }

        foreach (int characterIndex in this.CHARACTERS_INDEX_DICTIONARY[key[0]])
        {
            dp[0][characterIndex] = Math.Min(characterIndex, this.DIAL_SIZE - characterIndex) + 1;
        }

        for (int i = 1; i < this.KEY_LENGTH; i++)
        {
            foreach (int j in this.CHARACTERS_INDEX_DICTIONARY[key[i]])
            {
                foreach (int k in this.CHARACTERS_INDEX_DICTIONARY[key[i-1]])
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i-1][k] + Math.Min(Math.Abs(j - k), this.DIAL_SIZE - Math.Abs(j  - k)) + 1);
                }
            }
        }

        return dp[this.KEY_LENGTH - 1].Min();
    }

    private void BuildCharactersIndexDictionary() 
    {
        this.CHARACTERS_INDEX_DICTIONARY = new Dictionary<char, List<int>>();

        for (int i = 0; i < this.DIAL_SIZE; i++)
        {
            char currentCharacter = this.DIAL_RING[i];
            if (this.CHARACTERS_INDEX_DICTIONARY.ContainsKey(currentCharacter))
            {
                this.CHARACTERS_INDEX_DICTIONARY[currentCharacter].Add(i);
            }
            else 
            {
                this.CHARACTERS_INDEX_DICTIONARY[currentCharacter] = new List<int>() { i };
            }
        }
    }
}