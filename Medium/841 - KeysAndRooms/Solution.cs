/// Question 841. Keys and Rooms (https://leetcode-cn.com/problems/keys-and-rooms/)

public class Solution
{
    /// 执行用时: 164 ms, 在所有 C# 提交中击败了 11.11% 的用户
    /// 内存消耗: 28.2 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        // Initialize the keys queue with first room's keys.
        Queue<int> keys = new Queue<int>(rooms.First());
        // Count number of unlocked rooms, set to 1 by default, as room 0 is unlocked.
        List<int> unlockedRooms = new List<int>() { 0 };

        while (keys.Any())
        {
            int keyOfRoom = keys.Dequeue();

            foreach (int key in rooms.ElementAt(keyOfRoom))
            {
                if (!unlockedRooms.Exists(room => room == keyOfRoom))
                {
                    keys.Enqueue(key);
                }
            }

            if (!unlockedRooms.Exists(room => room == keyOfRoom))
            {
                unlockedRooms.Add(keyOfRoom);
            }
        }

        return unlockedRooms.Count() == rooms.Count();
    }
}

/// <summary>
/// 执行用时：136 ms, 在所有 C# 提交中击败了 37.04% 的用户
/// 内存消耗：26.6 MB, 在所有 C# 提交中击败了 14.29% 的用户
/// </summary>
public class SolutionTwo
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        // Initialize the keys queue with first room's keys.
        Queue<int> keys = new Queue<int>(rooms.First());
        // Count number of unlocked rooms, set to 1 by default, as room 0 is unlocked.
        Dictionary<int, bool> unlockedRooms = new Dictionary<int, bool> { { 0, true } };

        while (keys.Any())
        {
            int keyOfRoom = keys.Dequeue();
            if (unlockedRooms.ContainsKey(keyOfRoom)) { continue; }

            foreach (int key in rooms.ElementAt(keyOfRoom))
            {
                if (!unlockedRooms.ContainsKey(key))
                {
                    keys.Enqueue(key);
                }
            }

            unlockedRooms[keyOfRoom] = true;
        }

        return unlockedRooms.Count() == rooms.Count();
    }
}