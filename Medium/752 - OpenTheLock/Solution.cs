/// Question 752. Open the Lock (https://leetcode-cn.com/problems/open-the-lock/)

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");
        queue.Enqueue("");

        Dictionary<string, bool> seen = new Dictionary<string, bool>();
        seen["0000"] = true;

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
            else if (!deadends.Any(s => s.Equals(currentLock)))
            {
                for (int i = 0; i < currentLock.Length; i++)
                {
                    string prevString = currentLock.Substring(0, i);
                    int currentInt = int.Parse(currentLock[i].ToString());
                    string postString = currentLock.Substring(i + 1);

                    for (int change = -1; change <= 1; change += 2)
                    {
                        string newLock = $"{prevString}{(currentInt + change + 10) % 10}{postString}";

                        if (!seen.ContainsKey(newLock))
                        {
                            queue.Enqueue(newLock);
                            seen[newLock] = true;
                        }
                    }
                }
            }
        }

        return -1;
    }
}