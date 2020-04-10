/// 133. Clone Graph (https://leetcode-cn.com/problems/clone-graph/)

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class SolutionDFS
{
    // 执行用时 : 296 ms, 在所有 C# 提交中击败了 57.14% 的用户
    // 内存消耗 : 31 MB, 在所有 C# 提交中击败了 100.00% 的用户
    Dictionary<int, Node> nodeCopies = new Dictionary<int, Node>();

    public Node CloneGraph(Node node)
    {
        if (node == null) { return node; }

        if (nodeCopies.ContainsKey(node.val))
        {
            return nodeCopies[node.val];
        }

        Node nodeCopy = new Node(node.val, new List<Node>());
        nodeCopies[node.val] = nodeCopy;

        for (int i = 0; i < node.neighbors.Count(); i++)
        {
            nodeCopy.neighbors.Add(CloneGraph(node.neighbors.ElementAt(i)));
        }

        return nodeCopy;
    }
}

public class SolutionBFS
{
    /// 执行用时 : 300 ms, 在所有 C# 提交中击败了 47.62% 的用户
    /// 内存消耗 : 31.1 MB, 在所有 C# 提交中击败了 100.00% 的用户

    public Node CloneGraph(Node node)
    {
        if (node == null) { return node; }

        Dictionary<int, Node> nodeCopies = new Dictionary<int, Node>();
        nodeCopies[node.val] = new Node(node.val);

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();

            foreach (Node neighbor in currentNode.neighbors)
            {
                int neighborVal = neighbor.val;

                if (!nodeCopies.ContainsKey(neighborVal))
                {
                    Node neighborCopy = new Node(neighborVal);
                    nodeCopies[neighborVal] = neighborCopy;
                    queue.Enqueue(neighbor);
                }

                nodeCopies[currentNode.val].neighbors.Add(nodeCopies[neighborVal]);
            }
        }

        return nodeCopies[node.val];
    }
}