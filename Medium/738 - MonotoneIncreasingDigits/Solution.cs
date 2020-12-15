// Question 738. Monotone Increasing Digits (https://leetcode-cn.com/problems/monotone-increasing-digits/)

/// <summary>
/// 执行用时：52 ms, 在所有 C# 提交中击败了 21.62% 的用户
/// 内存消耗：15.9 MB, 在所有 C# 提交中击败了 5.41% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution] (https://leetcode-cn.com/problems/monotone-increasing-digits/solution/dan-diao-di-zeng-de-shu-zi-by-leetcode-s-5908/)
/// </summary>
public class Solution 
{
    public int MonotoneIncreasingDigits(int N) 
    {
        char[] stringN = N.ToString().ToCharArray();
        int stringLength = stringN.Count();
        int turningIndex = 1;

        while (turningIndex < stringLength && stringN[turningIndex - 1] <= stringN[turningIndex])
        {
            turningIndex++;
        }

        if (turningIndex < stringLength)
        {
            while (turningIndex > 0 && stringN[turningIndex - 1] > stringN[turningIndex])
            {
                stringN[turningIndex - 1] = (char) (((int)stringN[turningIndex - 1]) - 1);
                turningIndex--;
            }

            for (turningIndex +=1; turningIndex < stringLength; turningIndex++)
            {
                stringN[turningIndex] = '9';
            }
        }

        return int.Parse(string.Join("", stringN));
    }
}