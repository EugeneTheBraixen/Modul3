using System;
using System.Collections.Generic;

// Определение делегата для метода сортировки
delegate void SortDelegate(List<int> numbers);

class SortingApp
{
    public static void BubbleSort(List<int> numbers)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

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
        List<int> numbers = new List<int> { 5, 2, 9, 1, 5, 6, 3 };

        Console.WriteLine("Выберите метод сортировки:");
        Console.WriteLine("1. Сортировка пузырьком");
        Console.WriteLine("2. Быстрая сортировка");

        int choice = int.Parse(Console.ReadLine());
        SortDelegate sortDelegate = null;

        switch (choice)
        {
            case 1:
                sortDelegate = SortingApp.BubbleSort;
                break;

            case 2:
                sortDelegate = (list) => SortingApp.QuickSort(list, 0, list.Count - 1);
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        if (sortDelegate != null)
        {
            sortDelegate(numbers);
            Console.WriteLine("Отсортированные числа:");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
