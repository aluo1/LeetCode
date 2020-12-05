// Question 621. Task Scheduler (https://leetcode-cn.com/problems/task-scheduler/)

/// <summary>
/// 执行用时：248 ms, 在所有 C# 提交中击败了 16.67% 的用户
/// 内存消耗：34.7 MB, 在所有 C# 提交中击败了 20.83% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the 
/// [official solution](https://leetcode-cn.com/problems/task-scheduler/solution/ren-wu-diao-du-qi-by-leetcode-solution-ur9w/) method I.
/// </summary>
public class Solution 
{
    public int LeastInterval(char[] tasks, int n) 
    {
        if (n == 0) { return tasks.Count(); }

        Dictionary<char, int> taskFrequency = new Dictionary<char, int>();
        foreach (char task in tasks)
        {
            taskFrequency[task] = this.GetOrDefault(taskFrequency, task) + 1;
        }

        int totalTaskNumber = taskFrequency.Count();
        List<int> nextValid = new List<int>();
        List<int> rest = new List<int>();

        foreach (KeyValuePair<char, int> task in taskFrequency)
        {
            // By default all tasks are valid in next round.
            nextValid.Add(1);
            rest.Add(task.Value);
        }

        int time = 0;
        for (int i = 0; i < tasks.Count(); ++i)
        {
            ++time;
            int minNextValid = int.MaxValue;
            for (int j = 0; j < totalTaskNumber; ++j)
            {
                if (rest[j] > 0)
                {
                    minNextValid = Math.Min(minNextValid, nextValid[j]);
                }
            }

            time = Math.Max(time, minNextValid);
            int best = -1;
            for (int j = 0; j < totalTaskNumber; ++j)
            {
                if (rest[j] > 0 && nextValid[j] <= time)
                {
                    if (best == -1 || rest[j] > rest[best])
                    {
                        best = j;
                    }
                }
            }

            nextValid[best] = time + n + 1;
            --rest[best];
        }

        return time;
    }

    private int GetOrDefault<T>(Dictionary<T, int> dictionary, T key, int defaultValue = 0) where T: IComparable
    {
        if (dictionary.ContainsKey(key)) { return dictionary[key]; }

        return defaultValue;
    }
}