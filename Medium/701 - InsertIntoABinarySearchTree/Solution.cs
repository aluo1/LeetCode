/// Question 701. Insert into a Binary Search Tree (https://leetcode-cn.com/problems/insert-into-a-binary-search-tree/)

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
    // 执行用时: 160 ms, 在所有 C# 提交中击败了 77.78% 的用户
    // 内存消耗: 37.1 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root == null) { return new TreeNode(val); }

        this.InsertIntoBinarySearchTree(root, val);
        return root;
    }

    public void InsertIntoBinarySearchTree(TreeNode root, int val)
    {
        if (root.val > val)
        {
            if (root.left == null)
            {
                root.left = new TreeNode(val);
                return;
            }
            else
            {
                InsertIntoBST(root.left, val);
            }
        }
        else
        {
            if (root.right == null)
            {
                root.right = new TreeNode(val);
                return;
            }
            else
            {
                InsertIntoBST(root.right, val);
            }
        }
    }
}


public class SolutionWithIteration
{
    // 执行用时: 164 ms, 在所有 C# 提交中击败了 61.11% 的用户
    // 内存消耗: 37 MB, 在所有 C# 提交中击败了 100.00% 的用户
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        TreeNode newNode = new TreeNode(val);
        if (root == null) { return newNode; }

        TreeNode currentNode = root;
        while (true)
        {
            if (currentNode.val > val)
            {
                if (currentNode.left != null)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode.left = newNode;
                    return root;
                }
            }
            else
            {
                if (currentNode.right != null)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    currentNode.right = newNode;
                    return root;
                }
            }
        }
    }
}