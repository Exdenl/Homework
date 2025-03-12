using System;

abstract class Shape
{
    public abstract double CalculArea();

    public abstract bool IsValid();
}

class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double CalculArea()
    {
        if (IsValid())
        {
            return Width * Height;
        }
        else
        {
            return 0;
        }
    }

    public override bool IsValid()
    {
        return Width > 0 && Height > 0;
    }
}

class Square : Rectangle
{
    public Square(double side) : base(side, side) { }

    public override bool IsValid()
    {
        return Width > 0;
    }
}

class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double CalculArea()
    {
        if (!IsValid()) return 0;
        double s = (A + B + C) / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }

    public override bool IsValid()
    {
        return A > 0 && B > 0 && C > 0 && (A + B > C) && (A + C > B) && (B + C > A);
    }
}

class ShapeFactory
{
    private static Random random = new Random();

    public static Shape CreateRandomShape()
    {
        int shapeType = random.Next(3); 
        switch (shapeType)
        {
            case 0: 
                return new Rectangle(random.Next(1, 10), random.Next(1, 10));
            case 1: 
                return new Square(random.Next(1, 10));
            case 2: 
                while (true) 
                {
                    double a = random.Next(1, 10);
                    double b = random.Next(1, 10);
                    double c = random.Next(1, 10);
                    Triangle triangle = new Triangle(a, b, c);
                    if (triangle.IsValid()) return triangle;
                }
            default:
                return null;
        }
    }
}

class Program
{
    static void Main()
    {
        Shape[] shapes = new Shape[10];
        double totalArea = 0;

        for (int i = 0; i < 10; i++)
        {
            shapes[i] = ShapeFactory.CreateRandomShape();
            double area = shapes[i].CalculArea();
            Console.WriteLine($"图形 {i + 1}: {shapes[i].GetType().Name}, 面积: {area:F2}");
            totalArea += area;
        }

        Console.WriteLine($"总面积: {totalArea:F2}");
    }
}
