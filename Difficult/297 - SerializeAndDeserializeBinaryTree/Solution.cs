/// Question 297. Serialize and Deserialize Binary Tree (https://leetcode-cn.com/problems/serialize-and-deserialize-binary-tree/)

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{
    /// 执行用时 : 152 ms, 在所有 C# 提交中击败了 87.23% 的用户
    /// 内存消耗 : 34.7 MB, 在所有 C# 提交中击败了 100.00% 的用户
    private string NULL_REPRESENTATION = "null";

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        List<string> valuesString = new List<string>();

        if (root == null) { return ""; }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            TreeNode encodedValue = queue.Dequeue();
            if (encodedValue == null)
            {
                valuesString.Add(NULL_REPRESENTATION);
            }
            else
            {
                valuesString.Add(encodedValue.val.ToString());
                queue.Enqueue(encodedValue.left);
                queue.Enqueue(encodedValue.right);
            }
        }

        return $"{string.Join(",", valuesString)}";

    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (string.IsNullOrEmpty(data)) { return null; }
        string[] nodeValues = data.Split(',').ToArray();
        int dataCount = nodeValues.Count();

        if (dataCount == 0) { return null; }

        TreeNode root = new TreeNode(int.Parse(nodeValues[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int nodeIndex = 1;

        while (queue.Any() && nodeIndex < dataCount)
        {
            TreeNode currentNode = queue.Dequeue();
            string currentValue = nodeValues[nodeIndex++];

            if (this.IsNumber(currentValue))
            {
                TreeNode leftNode = new TreeNode(int.Parse(currentValue));
                currentNode.left = leftNode;
                queue.Enqueue(leftNode);
            }

            if (nodeIndex < dataCount)
            {
                currentValue = nodeValues[nodeIndex++];

                if (this.IsNumber(currentValue))
                {
                    TreeNode rightNode = new TreeNode(int.Parse(currentValue));
                    currentNode.right = rightNode;
                    queue.Enqueue(rightNode);
                }
            }
        }

        return root;
    }

    private bool IsNumber(string numberString)
    {
        foreach (char numChar in numberString)
        {
            if (!(char.IsNumber(numChar) || numChar == '-'))
            {
                return false;
            }
        }

        return true;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));