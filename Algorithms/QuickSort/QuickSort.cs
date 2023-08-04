using System;

// Single Responsibility Principle (SRP) - Her sınıfın ve metodun tek bir sorumluluğu olmalıdır.
// Open/Closed Principle (OCP) - Sınıflar, genişletmeye açık ancak değişime kapalı olmalıdır.
public class QuickSorter : ISorter
{
    public void Sort(int[] arr)
    {
        QuickSort(arr, 0, arr.Length - 1);
    }

    private void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(ref arr[i], ref arr[j]);
            }
        }

        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }

    private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

// Interface Segregation Principle (ISP) - İstemci, kendi için kullanmadığı metotlara bağımlı olmamalıdır.
public interface ISorter
{
    void Sort(int[] arr);
}

// Dependency Inversion Principle (DIP) - Yüksek seviyeli sınıflar, düşük seviyeli sınıflara bağlı olmamalıdır. Her ikisi de soyuta bağlı olmalıdır.
public class Client
{
    private readonly ISorter sorter;

    public Client(ISorter sorter)
    {
        this.sorter = sorter;
    }

    public void PerformSort(int[] data)
    {
        sorter.Sort(data);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int[] data = { 64, 34, 25, 12, 22, 11, 80 };

        ISorter sorter = new QuickSorter();
        Client client = new Client(sorter);

        client.PerformSort(data);

        Console.WriteLine("Sıralanmış Dizi:");
        PrintArray(data);
    }

    private static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
