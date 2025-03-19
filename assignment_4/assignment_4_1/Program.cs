using System;

public class GenericArray<T>
{
    private T[] array;
    public GenericArray(int size)
    {
        array = new T[size];
    }

    public T getItem(int index)
    {
        return array[index];
    }

    public void setItem(int index, T value)
    {
        array[index] = value;
    }
    public void ForEach(Action<T> action)
    {
        foreach (var item in array)
        {
            action(item);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("请输入数组的大小：");
        int size = int.Parse(Console.ReadLine());

        GenericArray<int> array = new GenericArray<int>(size);

        Console.WriteLine($"请输入 {size} 个整数：");
        for (int i = 0; i < size; i++)
        {
            Console.Write($"请输入第 {i + 1} 个元素: ");
            int value = int.Parse(Console.ReadLine());
            array.setItem(i, value);
        }

        Console.WriteLine("\n数组元素:");
        array.ForEach(value => Console.WriteLine(value));

        int max = int.MinValue;
        array.ForEach(value => {
            if (value > max)
            {
                max = value;
            }
        });
        Console.WriteLine($"\n数组中的最大值: {max}");

        int min = int.MaxValue;
        array.ForEach(value => {
            if (value < min)
            {
                min = value;
            }
        });
        Console.WriteLine($"\n数组中的最小值: {min}");

        int sum = 0;
        array.ForEach(value => sum += value);
        Console.WriteLine($"\n数组元素的和: {sum}");
    }
}