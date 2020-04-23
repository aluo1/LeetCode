/// Question 106. Construct Binary Tree from Inorder and Postorder Traversal (https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/)

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
    // 执行用时: 112 ms, 在所有 C# 提交中击败了 98.21% 的用户
    // 内存消耗: 26.9 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This code got the idea from [this solution](https://leetcode-cn.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/solution/tu-jie-gou-zao-er-cha-shu-wei-wan-dai-xu-by-user72/)

    private Dictionary<int, int> inorderNodeIndex = new Dictionary<int, int>();
    private int[] postorderList;

    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if ((inorder == null || inorder.Count() == 0) && (postorder == null || postorder.Count() == 0))
        {
            return null;
        }

        int inorderSize = inorder.Count();
        for (int i = 0; i < inorderSize; i++)
        {
            this.inorderNodeIndex[inorder[i]] = i;
        }

        this.postorderList = postorder;
        return this.BuildTree(0, inorderSize - 1, 0, postorder.Count() - 1);
    }

    public TreeNode BuildTree(int inorderStart, int inorderEnd, int postorderStart, int postorderEnd)
    {
        if (inorderStart > inorderEnd || postorderStart > postorderEnd)
        {
            return null;
        }

        TreeNode root = new TreeNode(this.postorderList[postorderEnd]);
        int rootIndexInInorder = this.inorderNodeIndex[root.val];

        root.left = BuildTree(inorderStart, rootIndexInInorder - 1, postorderStart, postorderStart + rootIndexInInorder - inorderStart - 1);
        root.right = BuildTree(rootIndexInInorder + 1, inorderEnd, postorderStart + rootIndexInInorder - inorderStart, postorderEnd - 1);

        return root;
    }
}