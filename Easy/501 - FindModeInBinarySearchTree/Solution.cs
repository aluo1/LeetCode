/// Question 501. Find Mode in Binary Search Tree (https://leetcode-cn.com/problems/find-mode-in-binary-search-tree/)

using System.Collections.Generic;
using System;
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

/// <summary>
/// 执行用时：288 ms, 在所有 C# 提交中击败了 83.67% 的用户
/// 内存消耗：33.7 MB, 在所有 C# 提交中击败了 21.21% 的用户
/// </summary>
public class Solution
{
    private Dictionary<int, int> nodeFrequencies = new Dictionary<int, int>();
    private int highestFrequencies = 0;

    public int[] FindMode(TreeNode root)
    {
        this.TraverseAllNodes(root);
        List<int> modes = new List<int>();

        foreach (KeyValuePair<int, int> keyValuePair in this.nodeFrequencies)
        {
            if (keyValuePair.Value == this.highestFrequencies)
            {
                modes.Add(keyValuePair.Key);
            }
        }

        return modes.ToArray();
    }

    private void TraverseAllNodes(TreeNode root)
    {
        if (root == null)
        {
            return;
        }

        if (nodeFrequencies.ContainsKey(root.val))
        {
            int newFrequency = nodeFrequencies[root.val] + 1;
            nodeFrequencies[root.val] = newFrequency;
            this.highestFrequencies = Math.Max(this.highestFrequencies, newFrequency);
        }
        else
        {
            nodeFrequencies.Add(root.val, 1);
            this.highestFrequencies = Math.Max(this.highestFrequencies, 1);
        }

        TraverseAllNodes(root.left);
        TraverseAllNodes(root.right);
    }
}