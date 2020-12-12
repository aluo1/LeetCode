// Question 649. Dota2 Senate (https://leetcode-cn.com/problems/dota2-senate/)

/// <summary>
/// 执行用时：108 ms, 在所有 C# 提交中击败了 87.50% 的用户
/// 内存消耗：25.3 MB, 在所有 C# 提交中击败了 62.50% 的用户
/// 
/// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/dota2-senate/solution/dota2-can-yi-yuan-by-leetcode-solution-jb7l/)
/// </summary>
public class Solution 
{
    public string PredictPartyVictory(string senate) 
    {
        int N = senate.Count();
        Queue<int> radiants = new Queue<int>();
        Queue<int> dires = new Queue<int>();

        for (int i = 0; i < N; i++)
        {
            char currentParty = senate[i];
            if (currentParty.Equals('R'))
            {
                radiants.Enqueue(i);
            }
            else 
            {
                dires.Enqueue(i);
            }
        }

        while (radiants.Count() != 0 && dires.Count() != 0)
        {
            int radiantIndex = radiants.Dequeue();
            int direIndex = dires.Dequeue();

            if (radiantIndex < direIndex)
            {
                radiants.Enqueue(radiantIndex + N);
            }
            else
            {
                dires.Enqueue(direIndex + N);
            }
        }

        return radiants.Count() == 0 ? "Dire" : "Radiant";
    }
}