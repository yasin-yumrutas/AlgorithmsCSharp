using System;

// Single Responsibility Principle (SRP) - Her sınıfın ve metodun tek bir sorumluluğu olmalıdır.
public class BinarySearch : ISearchAlgorithm
{
    public int Search(int[] arr, int target)
    {
        return BinarySearchRecursive(arr, target, 0, arr.Length - 1);
    }

    private int BinarySearchRecursive(int[] arr, int target, int low, int high)
    {
        if (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] < target)
            {
                return BinarySearchRecursive(arr, target, mid + 1, high);
            }
            else
            {
                return BinarySearchRecursive(arr, target, low, mid - 1);
            }
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
        int[] data = { 11, 12, 22, 25, 34, 64, 90 };
        int target = 22;

        ISearchAlgorithm searchAlgorithm = new BinarySearch();
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
