/// Question 116. Populating Next Right Pointers in Each Node (https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/)

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
    // 执行用时: 136 ms, 在所有 C# 提交中击败了 19.64% 的用户
    // 内存消耗: 30.3 MB, 在所有 C# 提交中击败了 25.00% 的用户
    public Node Connect(Node root)
    {
        if (root == null) { return root; }

        // A queue of node, together with its level/depth.
        Queue<(Node, int)> queue = new Queue<(Node, int)>();
        queue.Enqueue((root.left, 1));
        queue.Enqueue((root.right, 1));

        while (queue.Any())
        {
            (Node currentNode, int currentDepth) = queue.Dequeue();

            if (currentNode != null)
            {
                if (queue.Any())
                {
                    while (queue.Peek().Item2 == currentDepth)
                    {
                        (Node nextNode, int nextNodeDepth) = queue.Dequeue();
                        currentNode.next = nextNode;

                        queue.Enqueue((currentNode.left, currentDepth + 1));
                        queue.Enqueue((currentNode.right, currentDepth + 1));
                        currentNode = nextNode;
                    }

                    queue.Enqueue((currentNode.left, currentDepth + 1));
                    queue.Enqueue((currentNode.right, currentDepth + 1));
                }
                else
                {
                    currentNode.next = null;
                }
            }
        }

        return root;
    }
}

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
    // 执行用时: 120 ms, 在所有 C# 提交中击败了 89.29% 的用户
    // 内存消耗: 30.3 MB, 在所有 C# 提交中击败了 25.00% 的用户
    public Node Connect(Node root)
    {
        if (root == null) { return root; }

        // A queue of node, together with its level/depth.
        Queue<(Node, int)> queue = new Queue<(Node, int)>();
        queue.Enqueue((root.left, 1));
        queue.Enqueue((root.right, 1));

        while (queue.Any())
        {
            (Node currentNode, int currentDepth) = queue.Dequeue();

            if (currentNode != null)
            {
                if (queue.Any())
                {
                    while (queue.Peek().Item2 == currentDepth)
                    {
                        (Node nextNode, int nextNodeDepth) = queue.Dequeue();
                        currentNode.next = nextNode;

                        queue.Enqueue((currentNode.left, currentDepth + 1));
                        queue.Enqueue((currentNode.right, currentDepth + 1));
                        currentNode = nextNode;
                    }

                    queue.Enqueue((currentNode.left, currentDepth + 1));
                    queue.Enqueue((currentNode.right, currentDepth + 1));
                }
            }
        }

        return root;
    }
}