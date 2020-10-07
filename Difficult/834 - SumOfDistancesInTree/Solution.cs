/// Question 834. Sum of Distances in Tree (https://leetcode-cn.com/problems/sum-of-distances-in-tree/)

using System.Collections.Generic;

public class Solution
{
    private Dictionary<int, List<int>> graph;
    private int[] sonCount;
    private int[] dynamicProgramming;
    private int[] answer;

    private const int PARENT_INDEX = 0;
    private const int CHILD_INDEX = 1;

    /// <summary>
    /// 执行用时：400 ms, 在所有 C# 提交中击败了 100.00% 的用户
    /// 内存消耗：47.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    /// 
    /// Acknowledgement: This solution is a C# duplication of the [official solution](https://leetcode-cn.com/problems/sum-of-distances-in-tree/solution/shu-zhong-ju-chi-zhi-he-by-leetcode-solution/)
    /// 
    /// </summary>
    /// <param name="N"></param>
    /// <param name="edges"></param>
    /// <returns></returns>
    public int[] SumOfDistancesInTree(int N, int[][] edges)
    {
        this.graph = new Dictionary<int, List<int>>();

        this.answer = new int[N];
        this.sonCount = new int[N];
        this.dynamicProgramming = new int[N];

        for (int i = 0; i < N; i++)
        {
            this.graph[i] = new List<int>();
        }

        foreach (int[] edge in edges)
        {
            int parent = edge[PARENT_INDEX];
            int child = edge[CHILD_INDEX];

            this.graph[parent].Add(child);
            this.graph[child].Add(parent);
        }

        this.DFS(0, -1);
        this.DFS2(0, -1);

        return this.answer;
    }

    private void DFS(int root, int endIndex)
    {
        // Include themselves in the son count.
        this.sonCount[root] = 1;
        this.dynamicProgramming[root] = 0;

        foreach (int node in this.graph[root])
        {
            if (node == endIndex) { continue; }

            this.DFS(node, root);

            this.dynamicProgramming[root] += this.dynamicProgramming[node] + this.sonCount[node];
            this.sonCount[root] += this.sonCount[node];
        }
    }

    private void DFS2(int root, int endIndex)
    {
        this.answer[root] = this.dynamicProgramming[root];

        // Console.WriteLine($"root = {root}, endIndex = {endIndex}, this.graph[{root}] = {string.Join(", ", this.graph[root])}");

        foreach (int node in this.graph[root])
        {
            // Console.WriteLine($"node = {node}, endIndex = {endIndex}, root = {root}");

            if (node == endIndex) { continue; }

            // Console.WriteLine($"After continue, node = {node}, root = {root}, endIndex = {endIndex}, this.graph[{root}] = {string.Join(", ", this.graph[root])}");

            int dpRoot = this.dynamicProgramming[root];
            int dpNode = this.dynamicProgramming[node];
            int sonCountRoot = this.sonCount[root];
            int sonCountNode = this.sonCount[node];

            #region Adjust the dynamic programming records as we now swap the root and one of its child.
            this.dynamicProgramming[root] -= this.dynamicProgramming[node] + this.sonCount[node];
            this.sonCount[root] -= this.sonCount[node];

            this.dynamicProgramming[node] += this.dynamicProgramming[root] + this.sonCount[root];
            this.sonCount[node] += this.sonCount[root];
            #endregion Adjust the dynamic programming records as we now swap the root and one of its child.

            this.DFS2(node, root);

            #region Reset the dynamic programming and son count.
            this.dynamicProgramming[root] = dpRoot;
            this.dynamicProgramming[node] = dpNode;

            this.sonCount[root] = sonCountRoot;
            this.sonCount[node] = sonCountNode;
            #endregion Reset the dynamic programming and son count.
        }

        // Console.WriteLine();
    }
}