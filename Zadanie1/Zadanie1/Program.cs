using System;

// Базовый класс "Фигура"
class Shape
{
    public virtual double CalculateArea()
    {
        return 0.0;
    }
}

// Класс "Круг"
class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус должен быть положительным числом.");
        }
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

// Класс "Прямоугольник"
class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
        {
            throw new ArgumentException("Ширина и высота должны быть положительными числами.");
        }
        this.width = width;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return width * height;
    }
}

// Класс "Треугольник"
class Triangle : Shape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (sideA <= 0 || sideB <= 0 || sideC <= 0)
        {
            throw new ArgumentException("Стороны треугольника должны быть положительными числами.");
        }
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public override double CalculateArea()
    {
        double s = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }
}

class Program
{
    delegate double CalculateAreaDelegate();

    static void Main()
    {
        Console.WriteLine("Выберите фигуру:");
        Console.WriteLine("1. Круг");
        Console.WriteLine("2. Прямоугольник");
        Console.WriteLine("3. Треугольник");

        int choice = int.Parse(Console.ReadLine());
        CalculateAreaDelegate calculateAreaDelegate = null;

        switch (choice)
        {
            case 1:
                Console.Write("Введите радиус круга: ");
                double radius = double.Parse(Console.ReadLine());
                if (radius <= 0)
                {
                    Console.WriteLine("Радиус должен быть положительным числом.");
                    return;
                }
                Circle circle = new Circle(radius);
                calculateAreaDelegate = circle.CalculateArea;
                break;

            case 2:
                Console.Write("Введите ширину прямоугольника: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Введите высоту прямоугольника: ");
                double height = double.Parse(Console.ReadLine());
                if (width <= 0 || height <= 0)
                {
                    Console.WriteLine("Ширина и высота должны быть положительными числами.");
                    return;
                }
                Rectangle rectangle = new Rectangle(width, height);
                calculateAreaDelegate = rectangle.CalculateArea;
                break;

            case 3:
                Console.Write("Введите сторону A треугольника: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону B треугольника: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Введите сторону C треугольника: ");
                double sideC = double.Parse(Console.ReadLine());
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    Console.WriteLine("Стороны треугольника должны быть положительными числами.");
                    return;
                }
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                calculateAreaDelegate = triangle.CalculateArea;
                break;

            default:
                Console.WriteLine("Ошибка! Неверный выбор.");
                return;
        }

        double area = calculateAreaDelegate();
        Console.WriteLine($"Площадь выбранной фигуры: {area}");

        Console.ReadLine();
    }
}