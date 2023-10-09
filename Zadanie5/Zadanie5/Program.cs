using System;
using System.Collections.Generic;

// Определение делегата для метода сортировки
delegate void SortDelegate(List<int> numbers);

class SortingApp
{
    public static void QuickSort(List<int> numbers, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(numbers, left, right);
            QuickSort(numbers, left, pivotIndex - 1);
            QuickSort(numbers, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<int> numbers, int left, int right)
    {
        int pivot = numbers[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (numbers[j] < pivot)
            {
                i++;
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }
        }

        int temp2 = numbers[i + 1];
        numbers[i + 1] = numbers[right];
        numbers[right] = temp2;

        return i + 1;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите числа через пробел: ");
        string input = Console.ReadLine();
        string[] inputValues = input.Split(' ');

        List<int> numbers = new List<int>();

        foreach (var value in inputValues)
        {
            if (int.TryParse(value, out int number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine($"Ошибка при вводе числа: {value}. Пропускаем его.");
            }
        }

        SortingApp.QuickSort(numbers, 0, numbers.Count - 1);

        Console.WriteLine("Отсортированные числа:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        Console.ReadLine();
    }
}
