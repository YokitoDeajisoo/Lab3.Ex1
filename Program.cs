using System;
using System.Linq;

class Program
{
    static string text = ""; // збережений текст

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1 - Ввести текст");
            Console.WriteLine("2 - Видалити слова з непарною кiлькiстю приголосних");
            Console.WriteLine("3 - Видалити слова-палiндроми");
            Console.WriteLine("0 - Вихiд");
            Console.Write("Ваш вибiр: ");

            string choice = Console.ReadLine();

            // перевірка правильності вводу
            if (choice != "0" && choice != "1" && choice != "2" && choice != "3")
            {
                Console.WriteLine("❌ Помилка! Виберiть пункт з меню (0-3).");
                Console.WriteLine();
                continue;
            }

            if (choice == "0")
            {
                Console.WriteLine("Програму завершено.");
                break;
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Введiть текст: ");
                    text = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("❌ Ви нiчого не ввели!");
                        text = "";
                    }
                    else
                    {
                        Console.WriteLine("✅ Текст успiшно збережено!");
                    }
                    break;

                case "2":
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("❗ Спочатку введiть текст (пункт 1).");
                    }
                    else
                    {
                        text = RemoveOddConsonantWords(text);
                        Console.WriteLine("Результат: " + text);
                    }
                    break;

                case "3":
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine("❗ Спочатку введiть текст (пункт 1).");
                    }
                    else
                    {
                        text = RemovePalindromes(text);
                        Console.WriteLine("Результат: " + text);
                    }
                    break;
            }

            Console.WriteLine();
        }
    }

    // а) Видаляє слова з непарною кількістю приголосних
    static string RemoveOddConsonantWords(string input)
    {
        string consonants = "бвгґджзйклмнпрстфхцчшщ";
        var words = input.Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        var result = words.Where(w =>
        {
            int count = w.ToLower().Count(c => consonants.Contains(c));
            return count % 2 == 0; // залишаємо тільки слова з парною кількістю приголосних
        });

        return string.Join(" ", result);
    }

    // б) Видаляє слова-паліндроми
    static string RemovePalindromes(string input)
    {
        var words = input.Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        var result = words.Where(w =>
        {
            string lower = w.ToLower();
            string reversed = new string(lower.Reverse().ToArray());
            return lower != reversed; // залишаємо лише не паліндроми
        });

        return string.Join(" ", result);
    }
}
