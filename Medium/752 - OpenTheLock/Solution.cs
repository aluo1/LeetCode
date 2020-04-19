/// Question 752. Open the Lock (https://leetcode-cn.com/problems/open-the-lock/)

public class Solution
{
    /// 执行用时 : 968 ms, 在所有 C# 提交中击败了 36.00% 的用户
    /// 内存消耗 : 41.3 MB, 在所有 C# 提交中击败了 100.00% 的用户

    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> dead = new HashSet<string>(deadends);

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");
        queue.Enqueue("");

        HashSet<string> visited = new HashSet<string>() { "0000" };

        int depth = 0;

        while (queue.Any())
        {
            string currentLock = queue.Dequeue();

            if (string.IsNullOrEmpty(currentLock))
            {
                depth++;
                if (queue.Any() && !string.IsNullOrEmpty(queue.Peek()))
                {
                    queue.Enqueue("");
                }
            }
            else if (currentLock.Equals(target))
            {
                return depth;
            }
            else if (!dead.Contains(currentLock))
            {
                for (int i = 0; i < currentLock.Length; i++)
                {
                    string prevString = currentLock.Substring(0, i);
                    int currentInt = int.Parse(currentLock[i].ToString());
                    string postString = currentLock.Substring(i + 1);

                    for (int change = -1; change <= 1; change += 2)
                    {
                        string newLock = $"{prevString}{(currentInt + change + 10) % 10}{postString}";

                        if (!visited.Contains(newLock))
                        {
                            queue.Enqueue(newLock);
                            visited.Add(newLock);
                        }
                    }
                }
            }
        }

        return -1;
    }
}