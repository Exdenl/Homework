using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("请输入矩阵的行数和列数 (M x N):");
        string input = Console.ReadLine();
        string[] inputs = input.Split();

        if (inputs.Length != 2 || !int.TryParse(inputs[0], out int m) || !int.TryParse(inputs[1], out int n))
        {
            Console.WriteLine("输入无效");
            return;
        }

        int[,] matrix = new int[m, n];
        Console.WriteLine("请输入矩阵（按行输入，每行数字用空格分隔）:");
        for (int i = 0; i < m; i++)
        {
            string[] rowInput = Console.ReadLine().Split();
            for (int j = 0; j < n; j++)
            {
                if (int.TryParse(rowInput[j], out int value))
                {
                    matrix[i, j] = value;
                }
                else
                {
                    Console.WriteLine("输入无效，请输入整数");
                    return;
                }
            }
        }

        bool result = getRes(matrix, m, n);
        Console.WriteLine(result ? "True" : "False");
    }

    static bool getRes(int[,] matrix, int m, int n)
    {
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                if (matrix[i, j] != matrix[i + 1, j + 1])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
