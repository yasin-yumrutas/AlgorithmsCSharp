using System;

// Single Responsibility Principle (SRP) - Her sınıfın ve metodun tek bir sorumluluğu olmalıdır.
// Open/Closed Principle (OCP) - Sınıflar, genişletmeye açık ancak değişime kapalı olmalıdır.
public class SelectionSorter : ISorter
{
    public void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }
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
        int[] data = { 64, 34, 25, 12, 22, 11, 90 };

        ISorter sorter = new SelectionSorter();
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
