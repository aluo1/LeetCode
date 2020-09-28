/// Question 117. Populating Next Right Pointers in Each Node II (https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/)


// Definition for a Node.
public class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next)
    {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class ProvidedSolution
{
    /// <summary>
    /// 执行用时：116 ms, 在所有 C# 提交中击败了 76.92% 的用户
    /// 内存消耗：26.2 MB, 在所有 C# 提交中击败了 66.67% 的用户
    /// 
    /// Acknowledgement: This solution borrows idea from the [official solution](https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/solution/tian-chong-mei-ge-jie-dian-de-xia-yi-ge-you-ce-15/).
    /// </summary>

    private Node last = null;
    private Node nextStart = null;

    public Node Connect(Node root)
    {
        if (root == null) { return root; }

        Node start = root;
        this.nextStart = root.left;

        while (start != null)
        {
            this.last = null;
            this.nextStart = null;

            for (Node p = start; p != null; p = p.next)
            {
                if (p.left != null)
                {
                    this.Handle(p.left);
                }

                if (p.right != null)
                {
                    this.Handle(p.right);
                }
            }

            start = nextStart;
        }

        return root;
    }

    private void Handle(Node node)
    {
        if (last != null)
        {
            last.next = node;
        }

        if (nextStart == null)
        {
            nextStart = node;
        }

        last = node;
    }
}