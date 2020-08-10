using System;
using System.IO;
using System.Linq; 

// Form node modal 
public class Node
{
    public int data;
    public Node left, right;
    public int position;
    public Node(int item)
    {
        this.data = item;
    }
    public Node(int? first)
    {
        this.data = first ?? default(int);
    }
}

public class Maximum
{
    public int max_no = int.MinValue;
}

public class BinaryTree
{
    public Node _root;
    public Maximum max = new Maximum();
    public Node target_leaf = null;
    public Node parent;
    static string[] lines;
    BinaryTree()
    {
        _root = null;
    }
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        int leftPosition = 0;
        string rightPosition = string.Empty;
        // Read the data from the file
        // Create a binary tree which followed by the rule.

        lines = File.ReadAllLines("textFile.txt");
        for (int parent = 0; parent < lines.Length-1; parent++)
        {
            // Insert the first Node
            tree.Insert(int.Parse(lines[parent].Split(' ')[0]), null);
            leftPosition = lines[parent].Split(' ').Length;
            for (int position = 0; position < leftPosition; position++)
            {
                if (parent != 0)
                {
                    // -- Need to refactory
                    // Find the parent node for each left and right node for 
                    // not considering  if  it not follosed the rule

                    var data = int.Parse(lines[parent].Split(' ')[position]);
                    dynamic left = lines[parent - 1].Split(' ');                   
                    dynamic right = lines[parent - 1].Split(' ');                   
                    right =(lines[parent - 1].Split(' ').Length<=position)?0:                        
                        (lines[parent - 1].Split(' ').Length > 1)  ?
                       int.Parse(lines[parent - 1].Split(' ')[position]) : 0;

                    if (position != 0)
                    {
                      
                        left = (lines[parent - 1].Split(' ').Length > 1) ?
                        int.Parse(lines[parent - 1].Split(' ')[position-1]) : 0;
                        if ((data % 2 == left % 2) || (data % 2 == right))
                        {
                            left = int.Parse(lines[parent + 1].Split(' ')[position]);
                            right = int.Parse(lines[parent + 1].Split(' ')[position + 1]);
                            tree.Insert(data, left, right);
                        }
                    }
                    else if((data % 2 == right))
                    {
                        left = int.Parse(lines[parent + 1].Split(' ')[position]);
                        right = int.Parse(lines[parent + 1].Split(' ')[position + 1]);
                        tree.Insert(data, left, right);
                    }
                }
               
            }
        }
        Console.WriteLine("Max sum path");
        int sum = tree.maxSumPath();
        Console.WriteLine("");
        Console.WriteLine("Sum of nodes is : " + sum);
    }
    static int GetNextValue(int parent, int CurrentLine, int currentPosition, out int? first, out int? second)
    {
        int[] nextArray = lines[CurrentLine + 1].Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
        var h = lines[CurrentLine + 1].Split(' ')[currentPosition];
        first = 1; second = 1;
        first = ((parent % 2).Equals(nextArray[currentPosition] % 2)) ? (int?)null : nextArray[currentPosition];
        second = ((parent % 2).Equals(nextArray[currentPosition + 1] % 2)) ? (int?)null : nextArray[currentPosition + 1];

        return currentPosition;
    }

    //private void BuildBinaryTree(BinaryTree tree)
    //{
    //    int i = 0, j = 0;
    //    Array.ForEach(lines, element => {
    //        Array.ForEach(element.Split(' '), number => {
    //            if (!string.IsNullOrEmpty(number))
    //               tree.Insert(int.Parse(number),i,j);
    //            j += 1;
    //        });i += 1;
    //    });
    //}
    

    public void Insert(int data,int i,int j)
    {
        if(_root==null)
        {
            _root = new Node(data);
            _root.left = new Node(i);
            _root.right = new Node(j);
            return;
        }
        InsertRecoursly(_root,new Node(data),  i, j);
           
    }
    public void InsertRecoursly(Node root, Node newNode,int i,int j, bool leftRecursivev=true, bool rightRecursivev = true)
    {
        if ((newNode.data % 2) != (i % 2))
        {
            if (root.left == null)
            {
                if (rightRecursivev) root.left = new Node(i);
            }
            else InsertRecoursly(root.left, newNode, i, j, false, true);
        }
        else if(!leftRecursivev)
            root.left = null;
        if ((newNode.data % 2) != (j % 2))
        {
            if (root.right == null)
            {
                if (leftRecursivev) root.right = new Node(j);
            }
            else
                InsertRecoursly(root.right, newNode, i, j, true, false);
        }
        else if(!rightRecursivev)
            root.right = null;

        //if ((newNode.data % 2) != (root.data % 2))
        //{
        //    if (root.left == null)
        //        root.left = newNode;
        //    else
        //        InsertRecoursly(root.left, newNode,i,j);
        //}
        //else
        //{
        //    if (root.right == null)
        //        root.right = newNode;
        //    else
        //        InsertRecoursly(root.right, newNode,i,j);
        //}



        //int parent =int.Parse(lines[i-1].Split(' ')[j - 1]);

        //if((newNode.data%2)!=(parent%2))
        //{
        //    if (root.left == null)
        //        root.left = newNode;
        //    else
        //        root.right = newNode;
        //}
        //else

        //if (newNode.data < root.data)
        //{
        //    if (root.left == null)
        //        root.left = newNode;
        //    else
        //        InsertRecoursly(root.left, newNode);
        //}
        //else
        //{
        //    if (root.right == null)
        //        root.right = newNode;
        //    else
        //        InsertRecoursly(root.right, newNode);
        //}
    }
   
    // Print the routs which forms the  node to get the max
    public virtual bool printPath(Node node, Node target_leaf)
    {   if (node == null)
        {
            return false;
        }
        if (node == target_leaf || printPath(node.left, target_leaf)
            || printPath(node.right, target_leaf))
        {
            Console.Write(node.data + " ");
            return true;
        }

        return false;
    }

    public virtual void getTargetLeaf(Node node, Maximum max_sum_ref,
                                    int curr_sum)
    {
        if (node == null)
        {
            return;
        } curr_sum = curr_sum + node.data;

        if (node.left == null && node.right == null)
        {
            if (curr_sum > max_sum_ref.max_no)
            {
                max_sum_ref.max_no = curr_sum;
                target_leaf = node;
            }
        }
        getTargetLeaf(node.left, max_sum_ref, curr_sum);
        getTargetLeaf(node.right, max_sum_ref, curr_sum);
    }
    public int maxSumPath()
    {
        // base case 
        if (_root == null)
        {
            return 0;
        } getTargetLeaf(_root, max, 0);

        printPath(_root, target_leaf);
        return max.max_no; // return maximum sum 
    }
    
}
