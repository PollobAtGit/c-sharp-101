using System;

class Node
{
    public Node left, right;
    public int data;
    public Node(int data)
    {
        this.data = data;
        left = right = null;
    }

    public override string ToString() => "Data: " + data;
}

class Solution
{
    static int getHeight(Node root)
    {
        if(root == null) return -1;
        var leftHeight = getHeight(root.left) + 1;
        var rightHeight = getHeight(root.right) + 1;

        //Debug(root);

        return leftHeight < rightHeight ? rightHeight : leftHeight;
    }

    internal static void Debug(object msg)
    {
        Console.WriteLine(msg);
    }

    static Node insert(Node root, int data)
    {
        if(root == null)
        {
            return new Node(data);
        }
        else
        {
            Node cur;
            if(data <= root.data)
            {
                cur = insert(root.left, data);
                root.left = cur;
            }
            else
            {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }

    static void Main(String[] args)
    {
        Node root = null;
        int T = Int32.Parse(Console.ReadLine());
        while(T-- > 0)
        {
            int data = Int32.Parse(Console.ReadLine());
            root = insert(root, data);
        }
        int height = getHeight(root);
        Console.WriteLine(height);

    }
}
