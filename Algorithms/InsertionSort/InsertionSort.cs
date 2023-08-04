using System;

// Sınıfımızın sorumluluğu, verilerin Insertion Sort algoritması ile sıralanmasıdır.
public class InsertionSorter
{
    // Sıralama işlemi, bir sınıfın metodu olarak yazılmıştır.
    // Bu metot, Open/Closed prensibine uygun bir şekilde genişletmeye açıktır.
    public void Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int current = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > current)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = current;
        }
    }
}

// İstemci sınıf, InsertionSorter sınıfına bağımlıdır.
// Ancak, Interface Segregation prensibine uygun bir şekilde sadece sıralama metodu kullanılmaktadır.
public class Client
{
    private readonly InsertionSorter sorter;

    public Client(InsertionSorter sorter)
    {
        this.sorter = sorter;
    }

    public void PerformSort(int[] data)
    {
        sorter.Sort(data);
    }
}

// Uygulama başlangıcında, InsertionSorter sınıfı enjekte edilerek istemci oluşturulur.
public class Program
{
    public static void Main(string[] args)
    {
        int[] data = { 64, 34, 25, 12, 22, 11, 90 };

        InsertionSorter sorter = new InsertionSorter();
        Client client = new Client(sorter);

        client.PerformSort(data);

        Console.WriteLine("Sıralanmış Dizi:");
        PrintArray(data);
    }

    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
