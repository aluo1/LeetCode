/// Question 173. Binary Search Tree Iterator (https://leetcode-cn.com/problems/binary-search-tree-iterator/)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class BSTIteratorOfficialSolution
{
    // 执行用时: 200 ms, 在所有 C# 提交中击败了 40.00% 的用户
    // 内存消耗: 41.3 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Acknowledgement: This solution is borrowed from the [official solution](https://leetcode-cn.com/problems/binary-search-tree-iterator/)
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    private void BSTInorderTraverse(TreeNode root)
    {
        while (root != null)
        {
            stack.Push(root);
            root = root.left;
        }
    }

    public BSTIterator(TreeNode root)
    {
        this.BSTInorderTraverse(root);
    }

    /** @return the next smallest number */
    public int Next()
    {
        TreeNode topMostNode = this.stack.Pop();
        if (topMostNode.right != null)
        {
            this.BSTInorderTraverse(topMostNode.right);
        }

        return topMostNode.val;
    }

    /** @return whether we have a next smallest number */
    public bool HasNext()
    {
        return this.stack.Any();
    }
}

public class BSTIteratorFailedSolution
{
    // The memory usage (O(N)) does not match the requirement (O(h), h stands for the depth of tree).
    private List<int> inorderTree;
    private int currentPointer;

    private List<int> BSTInorderTraverse(TreeNode root)
    {
        List<int> currentList = new List<int>();

        while (root != null)
        {
            currentList = currentList.Concat(this.BSTInorderTraverse(root.left)).ToList();
            currentList.Add(root.val);
            currentList = currentList.Concat(this.BSTInorderTraverse(root.right)).ToList();
        }

        return currentList;
    }

    public BSTIterator(TreeNode root)
    {
        this.currentPointer = 0;
        this.inorderTree = this.BSTInorderTraverse(root);
        Console.WriteLine("line 33");
    }

    /** @return the next smallest number */
    public int Next()
    {
        Console.WriteLine("line 39");
        return this.inorderTree.ElementAt(this.currentPointer++);
    }

    /** @return whether we have a next smallest number */
    public bool HasNext()
    {
        return this.currentPointer < this.inorderTree.Count();
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
