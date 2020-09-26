/**
 * Question 113. Path Sum II (https://leetcode-cn.com/problems/path-sum-ii/)
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

/// <summary>
/// 执行用时：316 ms, 在所有 C# 提交中击败了 15.87% 的用户
/// 内存消耗：36.2 MB, 在所有 C# 提交中击败了 7.14% 的用户
/// 
/// This solution is similar to the DFS approach in the [sample solution](https://leetcode-cn.com/problems/path-sum-ii/solution/lu-jing-zong-he-ii-by-leetcode-solution/).
/// </summary>
public class Solution
{
    private List<IList<int>> paths = new List<IList<int>>();

    public IList<IList<int>> PathSum(TreeNode root, int sum)
    {
        this.FindPath(root, sum, new List<int>(), 0);
        return this.paths;
    }

    private void FindPath(TreeNode root, int targetSum, List<int> currentPath, int currentSum)
    {
        if (root == null) { return; }

        int newSum = currentSum + root.val;
        currentPath.Add(root.val);
        // Console.WriteLine($"newSum = {newSum}, targetSum = {targetSum}, this.paths.Count = {this.paths.Count}, root.val = {root.val}");

        if (newSum == targetSum && root.left == null && root.right == null)
        {
            this.paths.Add(currentPath);
            // Console.WriteLine($"newSum = {newSum}, targetSum = {targetSum}, this.paths.Count = {this.paths.Count}, root.val = {root.val}");
            return;
        }

        this.FindPath(root.left, targetSum, currentPath.Select(node => node).ToList(), newSum);
        this.FindPath(root.right, targetSum, currentPath.Select(node => node).ToList(), newSum)
    }
}