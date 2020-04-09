/// Question 150. Evaluate Reverse Polish Notation (https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/)
/// 执行用时 : 124 ms, 在所有 C# 提交中击败了 47.85% 的用户
/// 内存消耗 : 25.4 MB, 在所有 C# 提交中击败了 25.00% 的用户

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> operands = new Stack<int>();

        for (int i = 0; i < tokens.Count(); i++)
        {
            string currentToken = tokens[i];
            if (currentToken.Equals("+"))
            {
                int operand1 = operands.Pop();
                int operand2 = operands.Pop();
                operands.Push(operand2 + operand1);
            }
            else if (currentToken.Equals("-"))
            {
                int operand1 = operands.Pop();
                int operand2 = operands.Pop();
                operands.Push(operand2 - operand1);
            }
            else if (currentToken.Equals("*"))
            {
                int operand1 = operands.Pop();
                int operand2 = operands.Pop();
                operands.Push(operand2 * operand1);
            }
            else if (currentToken.Equals("/"))
            {
                int operand1 = operands.Pop();
                int operand2 = operands.Pop();
                operands.Push(operand2 / operand1);
            }
            else
            {
                operands.Push(int.Parse(currentToken));
            }
        }

        return operands.Pop();
    }
}