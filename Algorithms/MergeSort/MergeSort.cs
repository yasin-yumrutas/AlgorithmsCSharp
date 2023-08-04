using System;

// Single Responsibility Principle (SRP) - Her sınıfın ve metodun tek bir sorumluluğu olmalıdır.
// Open/Closed Principle (OCP) - Sınıflar, genişletmeye açık ancak değişime kapalı olmalıdır.
public class MergeSorter : ISorter
{
    public void Sort(int[] arr)
    {
        MergeSort(arr, 0, arr.Length - 1);
    }

    private void MergeSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSort(arr, low, mid);
            MergeSort(arr, mid + 1, high);
            Merge(arr, low, mid, high);
        }
    }

    private void Merge(int[] arr, int low, int mid, int high)
    {
        int leftSize = mid - low + 1;
        int rightSize = high - mid;

        int[] leftArr = new int[leftSize];
        int[] rightArr = new int[rightSize];

        Array.Copy(arr, low, leftArr, 0, leftSize);
        Array.Copy(arr, mid + 1, rightArr, 0, rightSize);

        int i = 0, j = 0, k = low;

        while (i < leftSize && j < rightSize)
        {
            if (leftArr[i] <= rightArr[j])
            {
                arr[k] = leftArr[i];
                i++;
            }
            else
            {
                arr[k] = rightArr[j];
                j++;
            }
            k++;
        }

        while (i < leftSize)
        {
            arr[k] = leftArr[i];
            i++;
            k++;
        }

        while (j < rightSize)
        {
            arr[k] = rightArr[j];
            j++;
            k++;
        }
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
        int[] data = { 64, 34, 25, 12, 22, 11, 90 };

        ISorter sorter = new MergeSorter();
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
