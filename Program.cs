using System;

class Program
{
    // Перевірка, чи слово є паліндромом
    static bool IsPalindrome(string word)
    {
        word = word.ToLower();
        int i = 0, j = word.Length - 1;
        while (i < j)
        {
            if (word[i] != word[j]) return false;
            i++; j--;
        }
        return true;
    }

    // Підрахунок приголосних у слові
    static int CountConsonants(string word)
    {
        string vowels = "аеєиiїоуюяaeiouy"; // українські + англійські голосні
        int count = 0;
        foreach (char c in word.ToLower())
        {
            if (Char.IsLetter(c) && !vowels.Contains(c)) count++;
        }
        return count;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // щоб коректно виводились укр. букви

        try
        {
            Console.WriteLine("Введiть текстовий рядок:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Рядок порожній! Введіть текст.");

            // ✅ Розбиваємо на слова по пробілах і розділових знаках
            string[] words = input.Split(
                new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '—' },
                StringSplitOptions.RemoveEmptyEntries
            );

            Console.WriteLine("\nРезультат:");

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;

                int consonants = CountConsonants(word);

                // умова: видалити слово, якщо непарна кількість приголосних або якщо воно паліндром
                if (consonants % 2 != 0 || IsPalindrome(word))
                    continue;

                Console.Write(word + " ");
            }

            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Помилка: " + e.Message);
        }
    }
}
