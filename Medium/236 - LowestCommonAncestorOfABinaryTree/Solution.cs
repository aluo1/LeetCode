/// Question 236. Lowest Common Ancestor of a Binary Tree (https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/)

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
    // 执行用时: 124 ms, 在所有 C# 提交中击败了 66.36% 的用户
    // 内存消耗: 30.8 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/lowest-common-ancestor-of-a-binary-tree/solution/er-cha-shu-de-zui-jin-gong-gong-zu-xian-by-leetcod/).
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        Dictionary<TreeNode, TreeNode> directParents = new Dictionary<TreeNode, TreeNode>();
        directParents[root] = null;

        while (!directParents.ContainsKey(p) || !directParents.ContainsKey(q))
        {
            TreeNode currentNode = stack.Pop();

            if (currentNode.left != null)
            {
                stack.Push(currentNode.left);
                directParents[currentNode.left] = currentNode;
            }

            if (currentNode.right != null)
            {
                stack.Push(currentNode.right);
                directParents[currentNode.right] = currentNode;
            }
        }

        HashSet<TreeNode> ancestors = new HashSet<TreeNode>();
        while (p != null)
        {
            ancestors.Add(p);
            p = directParents[p];
        }

        while (!ancestors.Contains(q))
        {
            q = directParents[q];
        }

        return q;
    }
}