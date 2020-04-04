/// Question 293. Flip Game
/// Difficulty: Easy
/// 执行用时: 288 ms, 在所有 C# 提交中击败了 50.00% 的用户
/// 内存消耗: 32 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public IList<string> GeneratePossibleNextMoves(string s)
    {
        IList<string> flippedStrings = new List<string>();
        int stringLength = s.Length;
        for (int i = 0; i < stringLength - 1; i++)
        {
            if (s[i].Equals(s[i + 1]) && s[i].Equals('+'))
            {

                string flippedString = s.Substring(0, i) + "--";
                if (i + 2 < stringLength)
                {
                    flippedString += s.Substring(i + 2, (stringLength - (i + 2)));
                }

                flippedStrings.Add(flippedString);
            }
        }

        return flippedStrings;
    }
}