/// Question 117. Populating Next Right Pointers in Each Node II (https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/)

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    // 执行用时: 116 ms, 在所有 C# 提交中击败了 77.14% 的用户
    // 内存消耗: 27.8 MB, 在所有 C# 提交中击败了 100.00% 的用户
    // Note: this solution can also be used in Question 116.
    public Node Connect(Node root)
    {
        if (root == null) { return root; }

        // A queue of node, together with its level/depth.
        Queue<(Node, int)> queue = new Queue<(Node, int)>();
        this.EnqueueIfNotNull(queue, root.left, 1);
        this.EnqueueIfNotNull(queue, root.right, 1);

        while (queue.Any())
        {
            (Node currentNode, int currentDepth) = queue.Dequeue();

            while (queue.Any() && queue.Peek().Item2 == currentDepth)
            {
                (Node nextNode, int nextNodeDepth) = queue.Dequeue();

                currentNode.next = nextNode;
                this.EnqueueIfNotNull(queue, currentNode.left, currentDepth + 1);
                this.EnqueueIfNotNull(queue, currentNode.right, currentDepth + 1);

                currentNode = nextNode;
            }

            this.EnqueueIfNotNull(queue, currentNode.left, currentDepth + 1);
            this.EnqueueIfNotNull(queue, currentNode.right, currentDepth + 1);
        }

        return root;
    }

    private void EnqueueIfNotNull(Queue<(Node, int)> queue, Node nextNode, int depth)
    {
        if (nextNode != null)
        {
            queue.Enqueue((nextNode, depth));
        }
    }
}