// Question 547. Number of Provinces (https://leetcode-cn.com/problems/number-of-provinces/)

/// <summary>
/// 执行用时：152 ms, 在所有 C# 提交中击败了 22.81% 的用户
/// 内存消耗：28.6 MB, 在所有 C# 提交中击败了 12.28% 的用户
/// </summary>
public class Solution 
{
    public int FindCircleNum(int[][] isConnected) 
    {
        List<HashSet<int>> provinces = new List<HashSet<int>>();
        int N = isConnected.Count();
        
        bool[][] recorded = new bool[N][];
        for (int i = 0; i < N; i++) { recorded[i] = new bool[N]; }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (isConnected[i][j] == 1 && !recorded[i][j] && !recorded[j][i])
                {
                    List<HashSet<int>> province = provinces.Where(pro => pro.Contains(i) || pro.Contains(j)).ToList();
                    if (province.Count() == 0)
                    {
                        provinces.Add(new HashSet<int>() { i, j });
                    }
                    else
                    {
                        HashSet<int> unionedProvince = province[0];
                        int provinceCount = province.Count();
                        for (int provinceIndex = 1; provinceIndex < provinceCount; provinceIndex++)
                        {
                            unionedProvince.UnionWith(province[provinceIndex]);
                        }

                        provinces = provinces.Where(pro => !(pro.Contains(i) || pro.Contains(j))).ToList();
                        
                        unionedProvince.Add(i);
                        unionedProvince.Add(j);
                        provinces.Add(unionedProvince);
                    }
                    recorded[i][j] = true;
                    recorded[j][i] = true;
                }
            }
        }

        System.Console.WriteLine(string.Join(",\n", provinces.Select(province => $"[{string.Join(", ", province)}]")));
        return provinces.Count();
    }
}