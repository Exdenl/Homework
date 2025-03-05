using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("请用空格分隔输入的数组");
        string input=Console.ReadLine();
        if(input == null) {
            Console.WriteLine("请正确输入");
        }
        string[] inputs = input.Split();
        if(input.Length == 0 ) {
            Console.WriteLine("请正确输入");
        }
        double[] nums=new double [inputs.Length] ;
        for( int i = 0; i < inputs.Length; i++ )
        {
            double.TryParse(inputs[i], out nums[i]);
        }
        double max = nums[0];
        double min = nums[0];
        double sum = 0;
        for( int i = 0; i < nums.Length; i++ ) {
            max = max > nums[i]? max : nums[i];
            min = min < nums[i] ? min : nums[i];
            sum += nums[i];
        }
        double averange = sum / nums.Length;
        Console.WriteLine("max=" + max + " min=" + min + " sum=" + sum + " averange=" + averange);
    }
}