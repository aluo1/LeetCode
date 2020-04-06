/// 面试题 01.06. 字符串压缩 (https://leetcode-cn.com/problems/compress-string-lcci/)
/// Difficulty: Easy
/// 
/// 执行用时: 384 ms, 在所有 C# 提交中击败了 40.57% 的用户
/// 内存消耗: 45.3 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public string CompressString(string S)
    {
        int sLength = S.Length;
        if (sLength <= 2) { return S; }

        string compressedStr = "";
        int firstPointer = 0;
        int secondPointer = 1;

        char firstChar = S[firstPointer];
        char secondChar;

        while (secondPointer < sLength)
        {
            if (compressedStr.Length >= sLength) { return S; }
            secondChar = S[secondPointer];

            if (secondChar.Equals(firstChar))
            {
                secondPointer++;
            }
            else
            {
                compressedStr += $"{firstChar}{secondPointer - firstPointer}";
                firstPointer = secondPointer;
                firstChar = S[firstPointer];

                secondPointer++;
            }
        }

        compressedStr += $"{S[firstPointer]}{secondPointer - firstPointer}";

        return compressedStr.Length < sLength ? compressedStr : S;
    }
}