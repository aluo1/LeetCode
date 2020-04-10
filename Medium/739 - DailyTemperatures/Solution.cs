/// Question 739. Daily Temperatures (https://leetcode-cn.com/problems/daily-temperatures/)
/// 执行用时: 416 ms, 在所有 C# 提交中击败了 73.68% 的用户
/// 内存消耗: 41.6 MB, 在所有 C# 提交中击败了 100.00% 的用户

public class Solution
{
    public int[] DailyTemperatures(int[] T)
    {
        int[] answer = new int[T.Count()];
        Stack<int> higherTempIndexStack = new Stack<int>();

        for (int i = T.Count() - 1; i >= 0; i--)
        {
            while (higherTempIndexStack.Count > 0 && T[i] >= T[higherTempIndexStack.Peek()])
            {
                higherTempIndexStack.Pop();
            }

            answer[i] = higherTempIndexStack.Count > 0 ? higherTempIndexStack.Peek() - i : 0;
            higherTempIndexStack.Push(i);
        }

        return answer;
    }
}