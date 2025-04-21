using System;

class Program
{
    static void Main()
    {
        Console.Write("请输入第一个数字: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("请输入第二个数字: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("请输入运算符 (+, -, *, /): ");
        string operatorSymbol = Console.ReadLine();

        double result = 0;
        bool canCal = true;

        switch (operatorSymbol)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("除数不能为零！");
                    canCal = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            default:
                Console.WriteLine("无效的运算符!");
                canCal = false;
                break;
        }

        if (canCal)
        {
            Console.WriteLine($"结果: {result}");
        }
    }
}
