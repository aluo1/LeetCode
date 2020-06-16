/// Question 9. Palindrome Number (https://leetcode-cn.com/problems/palindrome-number/)

public class Solution
{
    // 执行用时 : 76 ms , 在所有 C# 提交中击败了 85.07% 的用户
    // 内存消耗 : 16.5 MB, 在所有 C# 提交中击败了 40.00% 的用户

    public bool IsPalindrome(int x)
    {
        string xInString = x.ToString();

        int leftPointer = 0;
        int rightPointer = xInString.Length - 1;

        while (leftPointer < rightPointer)
        {
            if (xInString[leftPointer++] != xInString[rightPointer--])
            {
                return false;
            }
        }

        return true;
    }
}