using System;
using System.Collections.Generic;

// Single Responsibility Principle (SRP) - Her sınıfın ve metodun tek bir sorumluluğu olmalıdır.
public class BreadthFirstSearch : ISearchAlgorithm
{
    public int Search(int[] arr, int target)
    {
        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            queue.Enqueue(arr[i]);
        }

        int index = 0;
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            if (current == target)
            {
                return index;
            }
            index++;
        }

        return -1; // Hedef bulunamadığında -1 döndür
    }
}

// Interface Segregation Principle (ISP) - İstemci, kendi için kullanmadığı metotlara bağımlı olmamalıdır.
public interface ISearchAlgorithm
{
    int Search(int[] arr, int target);
}

// Dependency Inversion Principle (DIP) - Yüksek seviyeli sınıflar, düşük seviyeli sınıflara bağlı olmamalıdır. Her ikisi de soyuta bağlı olmalıdır.
public class Client
{
    private readonly ISearchAlgorithm searchAlgorithm;

    public Client(ISearchAlgorithm searchAlgorithm)
    {
        this.searchAlgorithm = searchAlgorithm;
    }

    public int PerformSearch(int[] data, int target)
    {
        return searchAlgorithm.Search(data, target);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] data = { 11, 25, 34, 12, 90, 22, 64 };
        int target = 22;

        ISearchAlgorithm searchAlgorithm = new BreadthFirstSearch();
        Client client = new Client(searchAlgorithm);

        int result = client.PerformSearch(data, target);

        if (result != -1)
        {
            Console.WriteLine($"Hedef {target} dizinin {result}. indeksinde bulundu.");
        }
        else
        {
            Console.WriteLine($"Hedef {target} dizide bulunamadı.");
        }
    }
}
