/// Question 105. Construct Binary Tree from Preorder and Inorder Traversal (https://leetcode-cn.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/)

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
    private Dictionary<int, int> inorderIndex = new Dictionary<int, int>();
    private int[] preorderList;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if ((preorder == null || preorder.Count() == 0) && (inorder == null || inorder.Count() == 0))
        {
            return null;
        }

        for (int i = 0; i < inorder.Count(); i++)
        {
            this.inorderIndex[inorder[i]] = i;
        }

        this.preorderList = preorder;

        return BuildTree(0, preorder.Count() - 1, 0, inorder.Count() - 1, "root");
    }

    public TreeNode BuildTree(int preorderStart, int preorderEnd, int inorderStart, int inorderEnd, string tree)
    {
        Console.WriteLine($"\ntree = {tree}");
        Console.WriteLine($"preorderStart = {preorderStart}");
        Console.WriteLine($"preorderEnd = {preorderEnd}");
        Console.WriteLine($"inorderStart = {inorderStart}");
        Console.WriteLine($"inorderEnd = {inorderEnd}");

        if (preorderStart > preorderEnd || inorderStart > inorderEnd) { return null; }

        int rootValue = this.preorderList[preorderStart];
        TreeNode root = new TreeNode(rootValue);
        int rootValueIndexInInorder = this.inorderIndex[rootValue];


        Console.WriteLine($"rootValue = {rootValue}");
        Console.WriteLine($"rootValueIndexInInorder = {rootValueIndexInInorder}\n");

        root.left = this.BuildTree(preorderStart + 1, preorderStart + rootValueIndexInInorder - inorderStart, inorderStart, rootValueIndexInInorder - 1, "left");
        root.right = this.BuildTree(preorderEnd - (inorderEnd - rootValueIndexInInorder) + 1, preorderEnd, rootValueIndexInInorder + 1, inorderEnd, "right");

        return root;
    }
}