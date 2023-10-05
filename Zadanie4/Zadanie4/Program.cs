using System;
using System.Collections.Generic;
using System.Linq;

// Определение делегата для функции фильтрации
delegate bool FilterDelegate(string item);

class DataFilter
{
    private List<string> data = new List<string>();

    // Добавление элемента в список данных
    public void AddData(string item)
    {
        data.Add(item);
    }

    // Фильтрация данных с использованием выбранного делегата
    public List<string> FilterData(FilterDelegate filter)
    {
        return data.Where(item => filter(item)).ToList();
    }
}

class Program
{
    static void Main()
    {
        DataFilter dataFilter = new DataFilter();

        // Добавление данных
        dataFilter.AddData("Сегодня важная дата: 01.01.2023");
        dataFilter.AddData("Начните планировать отпуск");
        dataFilter.AddData("Завершите проект к концу недели");
        dataFilter.AddData("Протестируйте приложение");

        Console.WriteLine("Выберите тип фильтрации:");
        Console.WriteLine("1. По дате");
        Console.WriteLine("2. По ключевым словам");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Введите дату для фильтрации (например, 01.01.2023): ");
                string date = Console.ReadLine();
                dataFilter.AddData("Сегодня важная дата: " + date);

                List<string> filteredDataByDate = dataFilter.FilterData(item => item.Contains(date));
                Console.WriteLine("Результаты фильтрации по дате:");
                foreach (var item in filteredDataByDate)
                {
                    Console.WriteLine(item);
                }
                break;

            case 2:
                Console.Write("Введите ключевые слова для фильтрации (через пробел): ");
                string keywordsInput = Console.ReadLine();
                string[] keywords = keywordsInput.Split(' ');

                List<string> filteredDataByKeywords = dataFilter.FilterData(item => keywords.All(keyword => item.Contains(keyword)));
                Console.WriteLine("Результаты фильтрации по ключевым словам:");
                foreach (var item in filteredDataByKeywords)
                {
                    Console.WriteLine(item);
                }
                break;

            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }

        Console.ReadLine();
    }
}
