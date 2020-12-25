// Question 455. Assign Cookies (https://leetcode-cn.com/problems/assign-cookies/)

/// <summary>
/// 执行用时：164 ms, 在所有 C# 提交中击败了 44.90% 的用户
/// 内存消耗：29.9 MB, 在所有 C# 提交中击败了 81.63% 的用户
/// </summary>
public class Solution 
{
    public int FindContentChildren(int[] g, int[] s) 
    {
        Array.Sort(g);
        Array.Sort(s);

        int G = g.Count();
        int S = s.Count();

        int count = 0;
        int j = 0;

        for (int i = 0; i < G; i++)
        {
            int currentG = g[i];

            while (j < S)
            {
                int currentS = s[j++];
                if (currentS >= currentG)
                {
                    count++;
                    break;
                }
            }
        }

        return count;
    }
}