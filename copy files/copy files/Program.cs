﻿
using System.Diagnostics;

string fail1 = "C:\\Users\\Пользователь\\Desktop\\1.txt"; // путь к исходному файлу
string fail2 = "C:\\Users\\Пользователь\\Desktop\\2.txt"; // путь к файлу назначения

try
{
    // Копирование файла
    File.Copy(fail1, fail2);
    Console.WriteLine("Файл скопирован успешно.");
}
catch (Exception e)
{
    Console.WriteLine("Ошибка при копировании файла: " + e.Message);
}
//последовательное копирование 
string fail3 = "C:\\Users\\Пользователь\\Desktop\\3.txt"; // путь к первому исходному файлу
string fail4 = "C:\\Users\\Пользователь\\Desktop\\4.txt"; // путь ко второму исходному файлу
string fail5 = "C:\\Users\\Пользователь\\Desktop\\5.txt"; // путь к файлу назначения для первого файла
string fail6 = "C:\\Users\\Пользователь\\Desktop\\6.txt"; // путь к файлу назначения для второго файла

try
{
    Stopwatch timer = new Stopwatch();

    // Копирование первого файла
    timer.Start();
    File.Copy(fail3, fail4);
    timer.Stop();
    Console.WriteLine("Первый файл скопирован успешно. Время выполнения: " + timer.Elapsed);

    timer.Reset();

    // Копирование второго файла
    timer.Start();
    File.Copy(fail5, fail6);
    timer.Stop();
    Console.WriteLine("Второй файл скопирован успешно. Время выполнения: " + timer.Elapsed);
}
catch (Exception e)
{
    Console.WriteLine("Ошибка при копировании файла: " + e.Message);
}
//паралллельное копирование 
string fail7 = "C:\\Users\\Пользователь\\Desktop\\7.txt"; // путь к первому исходному файлу
string fail8 = "C:\\Users\\Пользователь\\Desktop\\8.txt"; // путь ко второму исходному файлу
string fail9 = "C:\\Users\\Пользователь\\Desktop\\9.txt"; // путь к файлу назначения для первого файла
string fail10 = "C:\\Users\\Пользователь\\Desktop\\10.txt"; // путь к файлу назначения для второго файла

try
{
    Stopwatch timer = new Stopwatch();

    // Создание задач для копирования каждого файла
    Task task1 = Task.Factory.StartNew(() =>
    {
        timer.Start();
        File.Copy(fail7, fail8);
        timer.Stop();
        Console.WriteLine("Первый файл скопирован успешно. Время выполнения: " + timer.Elapsed);
    });

    Task task2 = Task.Factory.StartNew(() =>
    {
        timer.Start();
        File.Copy(fail9, fail10);
        timer.Stop();
        Console.WriteLine("Второй файл скопирован успешно. Время выполнения: " + timer.Elapsed);
    });

    // Ожидание завершения обеих задач
    Task.WaitAll(task1, task2);
}
catch (Exception e)
{
    Console.WriteLine("Ошибка при копировании файла: " + e.Message);
}
