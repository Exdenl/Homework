using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("2 到 100 以内的素数是：");
        getRes(100);
    }

    static void getRes(int max)
    {
        bool[] isPrime = new bool[max + 1];
        for (int i = 2; i <= max; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= max; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= max; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        
        for (int i = 2; i <= max; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}
