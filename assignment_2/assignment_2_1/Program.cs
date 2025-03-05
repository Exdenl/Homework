using System;

class Program { 
    static void Main()
    {
        Console.WriteLine("请输入要检测的数据:");
        string input = Console.ReadLine();
        
        if (!int.TryParse(input,out int result))
        {
            Console.WriteLine("请输入整数");
        }
        else
        {
            getRes(result);
        }
    }
    static void getRes(int num)
    {
        if (num <= 1)
        {
            Console.WriteLine("请输入大于1的正整数");
        }
        for (int i = 2; i*i <= num; i++) {
            if (num % i == 0)
            {
                Console.WriteLine(i+" ");
            }
            while(num%i == 0)
            {
                num = num / i;
            }
        }
        if (num != 1)
        {
            Console.WriteLine(num);
        }
    }
}

