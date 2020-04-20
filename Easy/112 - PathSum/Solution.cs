/// Question 112. Path Sum (https://leetcode-cn.com/problems/path-sum/)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution
{
    /// 执行用时: 108 ms, 在所有 C# 提交中击败了 94.41% 的用户
    /// 内存消耗: 26.4 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public bool HasPathSum(TreeNode root, int sum)
    {
        if (root == null) { return false; }

        return this.HasPathSum(root, 0, sum);
    }

    private bool HasPathSum(TreeNode root, int sum, int target)
    {
        if (root == null)
        {
            return false;
        }
        else
        {
            sum += root.val;
            if (sum == target && root.left == null && root.right == null)
            {
                return true;
            }

            return this.HasPathSum(root.left, sum, target) || this.HasPathSum(root.right, sum, target);
        }
    }
}

public class SolutionOfficialSolution
{
    /// 执行用时: 112 ms, 在所有 C# 提交中击败了 83.92% 的用户
    /// 内存消耗: 26.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public bool HasPathSum(TreeNode root, int sum)
    {
        if (root == null) { return false; }

        sum -= root.val;

        if (root.left == null && root.right == null) { return sum == 0; }
        return this.HasPathSum(root.left, sum) || this.HasPathSum(root.right, sum);
    }
}