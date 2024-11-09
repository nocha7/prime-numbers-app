using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeNumbersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите список чисел, разделенных пробелом, для определения простых чисел:");

            // Считывание и разбор введенного списка чисел
            string input = Console.ReadLine();
            List<int> numbers = input.Split(' ')
                                     .Select(num => int.TryParse(num, out int n) ? n : -1)
                                     .Where(n => n >= 0)
                                     .ToList();

            if (numbers.Count == 0)
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительные целые числа.");
                return;
            }

            // Определение и вывод простых чисел
            List<int> primeNumbers = GetPrimeNumbers(numbers);
            Console.WriteLine("Простые числа в вашем списке: " + string.Join(", ", primeNumbers));
        }

        // Метод для определения простых чисел в списке
        static List<int> GetPrimeNumbers(List<int> numbers)
        {
            return numbers.Where(IsPrime).ToList();
        }

        // Метод проверки, является ли число простым
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
