using System;

// S - Single Responsibility Principle (Tek Sorumluluk Prensibi)
// Fibonacci dizisi hesaplama işlevselliği bu sınıfta uygulanır.
public class FibonacciCalculator
{
    public int CalculateFibonacci(int n)
    {
        if (n <= 0)
            throw new ArgumentException("n must be a positive integer.");

        if (n == 1 || n == 2)
            return 1;

        int prev1 = 1;
        int prev2 = 1;
        int result = 0;

        for (int i = 3; i <= n; i++)
        {
            result = prev1 + prev2;
            prev1 = prev2;
            prev2 = result;
        }

        return result;
    }
}

// O - Open/Closed Principle (Açık/Kapalı Prensip)
// Farklı Fibonacci hesaplama yöntemleri eklenirse mevcut kod değiştirilmeden genişletilebilir.
public interface IFibonacciCalculator
{
    int Calculate(int n);
}

public class IterativeFibonacciCalculator : IFibonacciCalculator
{
    public int Calculate(int n)
    {
        FibonacciCalculator calculator = new FibonacciCalculator();
        return calculator.CalculateFibonacci(n);
    }
}

public class Program
{
    static void Main(string[] args)
    {
        int n = 10; // Hesaplanacak Fibonacci dizisi elemanının indeksi

        IFibonacciCalculator fibonacciCalculator = new IterativeFibonacciCalculator();
        int result = fibonacciCalculator.Calculate(n);

        Console.WriteLine($"Fibonacci({n}) = {result}");
    }
}
