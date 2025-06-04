using System;

class StudentNode
{
    public int Id;
    public string Name;
    public StudentNode Left;
    public StudentNode Right;

    public StudentNode(int id, string name)
    {
        Id = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

class StudentBinaryTree
{
    public StudentNode Head;

    public void Insert(int id, string name)
    {
        Head = InsertRec(Head, id, name);
    }

    private StudentNode InsertRec(StudentNode node, int id, string name)
    {
        if (node == null)
            return new StudentNode(id, name);

        if (id < node.Id)
            node.Left = InsertRec(node.Left, id, name);
        else
            node.Right = InsertRec(node.Right, id, name);

        return node;
    }

    public void PrintInOrder(StudentNode node)
    {
        if (node != null)
        {
            PrintInOrder(node.Left);
            Console.WriteLine($"ID: {node.Id}, Name: {node.Name}");
            PrintInOrder(node.Right);
        }
    }
}

class Program
{
    static void Main()
    {
        StudentBinaryTree tree = new StudentBinaryTree();

        tree.Insert(7, "Авдеев В.В.");
        tree.Insert(12, "Морозова А.С.");
        tree.Insert(10, "Васильев Д.Е.");
        tree.Insert(5, "Михеев Л.П.");

        tree.PrintInOrder(tree.Head);
    }
}
