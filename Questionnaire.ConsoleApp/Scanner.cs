using System.Diagnostics;
using Questionnaire.Core.Enums;
using Questionnaire.Core.Models;

namespace Questionnaire.ConsoleApp;

public static class Scanner
{
    public static Person GetPerson()
    {
        string name = Scan("Введите имя: ");
        int age = int.Parse(Scan("Введите возраст: ", 
            x => int.TryParse(x, out int result)));
        string sex = Scan("Введите пол [м/ж]: ", 
            x => x.ToLower() == "м" || x.ToLower() == "ж");

        return new Person()
        {
            Name = name,
            Age = age,
            Sex = sex == "м" ? Sex.Male : Sex.Female
        };
    }

    private static string Scan(string title, Predicate<string> isValid = null)
    {
        lableStart:
        Console.Write(title);

        try
        {
            string data = Console.ReadLine();

            if (isValid == null || isValid(data))
            {
                return data;
            }

            Console.WriteLine("Данные введены некоректно, попробуйте снова.");
            goto lableStart;
        }
        catch
        {
            Console.WriteLine("Данные введены некоректно, попробуйте снова.");
            goto lableStart;
        }
    }
} // свичкейс
 // делигаты