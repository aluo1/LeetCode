// Question 842. Split Array into Fibonacci Sequence (https://leetcode-cn.com/problems/split-array-into-fibonacci-sequence/)

/// <summary>
/// 执行用时：256 ms, 在所有 C# 提交中击败了 80.00% 的用户
/// 内存消耗：30.2 MB, 在所有 C# 提交中击败了 80.00% 的用户
/// 
/// Acknowledgement: This solution is a C#-version duplicate of the [official solution](https://leetcode-cn.com/problems/split-array-into-fibonacci-sequence/solution/jiang-shu-zu-chai-fen-cheng-fei-bo-na-qi-ts6c/)
/// </summary>
public class Solution 
{
    public IList<int> SplitIntoFibonacci(string S) 
    {
        var answer = new List<int>();
        this.Backtrack(answer, S, S.Count(), 0, 0, 0);
        return answer;
    }

    public bool Backtrack(List<int> list, string S, int length, int index, int sum, int previous) 
    {
        if (index == length) { return list.Count() >= 3; }

        long currentLong = 0;
        for (int i = index; i < length; i++)
        {
            if (i > index && S[index] == '0') { break; }

            currentLong = currentLong * 10 + (S[i] - '0');
            if (currentLong > int.MaxValue) { break; }

            int currentValue = (int) currentLong;
            if (list.Count() >= 2) 
            {
                if (currentValue < sum) { continue; }
                if (currentValue > sum) { break; }
            }

            list.Add(currentValue);
            if (this.Backtrack(list, S, length, i + 1, previous + currentValue, currentValue))
            {
                return true;
            }
            else
            {
                list.RemoveAt(list.Count() - 1);
            }
        }

        return false;
    }
}