//// S - Single Responsibility Principle (Tek Sorumluluk Prensibi)
//// DFS algoritmasının işlevselliği bu sınıfta uygulanır.
//public class DepthFirstSearch
//{
//    public void DFS(Node node)
//    {
//        if (node == null)
//            return;

//        Console.WriteLine(node.Value); // Ziyaret edilen düğümü işle

//        foreach (Node child in node.Children)
//        {
//            DFS(child); // Çocuk düğümleri ziyaret et
//        }
//    }
//}

//// O - Open/Closed Principle (Açık/Kapalı Prensip)
//// Yeni düğüm türleri eklendikçe mevcut kod değişmez, sadece yeni düğüm sınıfları eklenir.
//public abstract class Node
//{
//    public int Value { get; set; }
//    public List<Node> Children { get; set; }

//    protected Node(int value)
//    {
//        Value = value;
//        Children = new List<Node>();
//    }
//}

//public class TreeNode : Node
//{
//    public TreeNode(int value) : base(value)
//    {
//    }
//}

//public class GraphNode : Node
//{
//    public GraphNode(int value) : base(value)
//    {
//    }
//}

//// L - Liskov Substitution Principle (Liskov Yerine Geçme Prensibi)
//// Node sınıfı ve türetilmiş sınıflar birbirinin yerine geçebilir.
//// Düğüm türlerinin kullanımı, temel sınıfın yöntemlerini kullanarak yapılır.
//public class Program
//{
//    static void Main(string[] args)
//    {
//        TreeNode rootNode = new TreeNode(1);
//        TreeNode childNode1 = new TreeNode(2);
//        TreeNode childNode2 = new TreeNode(3);

//        rootNode.Children.Add(childNode1);
//        rootNode.Children.Add(childNode2);

//        DepthFirstSearch dfs = new DepthFirstSearch();
//        dfs.DFS(rootNode);
//    }
//}






using System;
using System.Collections.Generic;
using System.IO;

// S - Single Responsibility Principle (Tek Sorumluluk Prensibi)
// DFS algoritmasının işlevselliği bu sınıfta uygulanır.
public class DepthFirstSearch
{
    public int CountFilesWithExtension(string directoryPath, string extension)
    {
        int count = 0;

        Stack<string> stack = new Stack<string>();
        stack.Push(directoryPath);

        while (stack.Count > 0)
        {
            string currentDir = stack.Pop();
            try
            {
                string[] files = Directory.GetFiles(currentDir);

                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == extension)
                    {
                        count++;
                    }
                }

                string[] subDirectories = Directory.GetDirectories(currentDir);
                foreach (string subDir in subDirectories)
                {
                    stack.Push(subDir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing {currentDir}: {ex.Message}");
            }
        }

        return count;
    }
}

// O - Open/Closed Principle (Açık/Kapalı Prensip)
// Yeni dosya işleme türleri eklendikçe mevcut kod değişmez, sadece yeni işleme sınıfları eklenir.
public interface IFileProcessor
{
    int ProcessFiles(string directoryPath, string extension);
}

public class ExtensionFileProcessor : IFileProcessor
{
    public int ProcessFiles(string directoryPath, string extension)
    {
        DepthFirstSearch dfs = new DepthFirstSearch();
        return dfs.CountFilesWithExtension(directoryPath, extension);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\yasin\OneDrive\Masaüstü\FreeLance"; // İşlem yapılacak dizin yolu
        string extension = ".txt"; // Sayılacak dosya uzantısı

        IFileProcessor fileProcessor = new ExtensionFileProcessor();
        int count = fileProcessor.ProcessFiles(directoryPath, extension);

        Console.WriteLine($"Number of '{extension}' files: {count}");
    }
}
