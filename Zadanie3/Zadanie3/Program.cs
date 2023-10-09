using System;
using System.Collections.Generic;

delegate void TaskDelegate(string task);

class TaskManager
{
    private List<string> tasks = new List<string>();
    private List<TaskDelegate> delegates = new List<TaskDelegate>();

    //добавление задачи
    public void AddTask(string task)
    {
        tasks.Add(task);
    }

    //добавление делегата для выполнения задачи
    public void AddTaskDelegate(TaskDelegate taskDelegate)
    {
        delegates.Add(taskDelegate);
    }

    //выполнение задачи с выбранным делегатом
    public void ExecuteTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (i < delegates.Count)
            {
                delegates[i](tasks[i]);
            }
            else
            {
                Console.WriteLine($"Задача \"{tasks[i]}\" не имеет делегата для выполнения.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        //добавление задач
        Console.Write("Введите задачу 1: ");
        string task1 = Console.ReadLine();
        taskManager.AddTask(task1);

        Console.Write("Введите задачу 2: ");
        string task2 = Console.ReadLine();
        taskManager.AddTask(task2);

        Console.Write("Введите задачу 3: ");
        string task3 = Console.ReadLine();
        taskManager.AddTask(task3);

        //добавление делегатов для выполнения задач
        taskManager.AddTaskDelegate((task) => Console.WriteLine($"Выполнена задача: {task} (Отправка уведомления..)"));
        taskManager.AddTaskDelegate((task) => Console.WriteLine($"Выполнена задача: {task} (Запись в журнал..)"));

        //выполнение задач
        taskManager.ExecuteTasks();

        Console.ReadLine();
    }
}
