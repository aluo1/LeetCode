/// Question 543. Diameter of Binary Tree (https://leetcode-cn.com/problems/diameter-of-binary-tree/)
/// Difficulty: Easy
/// 执行用时: 112 ms, 在所有 C# 提交中击败了 80.95% 的用户
/// 内存消耗: 25.4 MB, 在所有 C# 提交中击败了 11.11% 的用户
/// 
/// We need to be aware that in some cases, the longest diameter does not pass the root node, this confused me and 
/// failed to first submission. A screenshot of the example is also provided.
/// 
/// Acknowledgement: This solution is borrowed from the official solution (https://leetcode-cn.com/problems/diameter-of-binary-tree/solution/er-cha-shu-de-zhi-jing-by-leetcode-solution/).

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
    int ans;

    public int DiameterOfBinaryTree(TreeNode root)
    {
        ans = 1;
        Depth(root);
        return ans - 1;
    }

    public int Depth(TreeNode node)
    {
        if (node == null) return 0;
        int L = Depth(node.left);
        int R = Depth(node.right);
        ans = Math.Max(ans, L + R + 1);
        return Math.Max(L, R) + 1;
    }

    #region Solution without using object variable (ans).
    public int DiameterOfBinaryTreeWithoutObjectVariable(TreeNode root) {
        /// 执行用时 : 172 ms, 在所有 C# 提交中击败了 7.14% 的用户
        /// 内存消耗 : 27.5 MB, 在所有 C# 提交中击败了 11.11% 的用户
        if (root == null)  return 0;

        Tuple<int, int> finalValue = Depth(root, 1);
        return finalValue.Item2 - 1;
    }

    public Tuple<int, int> Depth(TreeNode node, int depth) {
        if (node == null) return Tuple.Create(0, depth);

        Tuple<int, int> L = Depth(node.left, depth);
        Tuple<int, int> R = Depth(node.right, depth);

        int ans = new List<int>() { L.Item2, R.Item2, L.Item1 + R.Item1 + 1 }.Max();
        return Tuple.Create(Math.Max(L.Item1, R.Item1) + 1, ans);
    }
    #endregion Solution without using object variable (ans).
}