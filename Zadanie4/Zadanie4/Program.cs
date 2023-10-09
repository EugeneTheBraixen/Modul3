using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество событий: ");
        int eventCount = int.Parse(Console.ReadLine());

        List<string> events = new List<string>();

        for (int i = 0; i < eventCount; i++)
        {
            Console.Write($"Введите дату для события {i + 1} (например, 01.01.2023): ");
            string date = Console.ReadLine();

            Console.Write($"Введите событие для даты {date}: ");
            string eventDescription = Console.ReadLine();

            events.Add($"{date} - {eventDescription}");
        }

        // Сортировка событий по дате по возрастанию
        events.Sort();

        Console.WriteLine("Результаты фильтрации по дате (по возрастанию):");
        foreach (var item in events)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
