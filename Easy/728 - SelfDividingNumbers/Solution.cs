/// Question 728. Self Dividing Numbers
/// Difficulty: Easy
/// 执行用时: 268 ms, 在所有 C# 提交中击败了 24.00% 的用户
/// 内存消耗: 27.5 MB, 在所有 C# 提交中击败了 25.00% 的用户

public class Solution
{
    public IList<int> SelfDividingNumbers(int left, int right)
    {
        IList<int> possibleSDNumbers = new List<int>();

        for (int i = left; i <= right; i++)
        {
            string iStr = i.ToString();
            if (iStr.Contains('0')) { continue; }

            bool fullyDivisible = true;

            foreach (char iChar in iStr)
            {
                int digitComponent = int.Parse(iChar.ToString());

                if (i % digitComponent != 0)
                {
                    fullyDivisible = false;
                    break;
                }
            }

            if (fullyDivisible)
            {
                possibleSDNumbers.Add(i);
            }
        }

        return possibleSDNumbers;
    }
}