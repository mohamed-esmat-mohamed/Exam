using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    static class Input
    {
        public static int ReadInt(string message, int min, int max)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.Write($"Invalid input, enter a number between {min} and {max}: ");
            }
            return value;
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            string text = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(text))
            {
                Console.Write("Can't be empty, try again: ");
                text = Console.ReadLine();
            }
            return text;
        }
    }
}
