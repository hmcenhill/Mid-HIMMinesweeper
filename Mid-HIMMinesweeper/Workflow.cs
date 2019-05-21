using System;
using System.Collections.Generic;
using System.Text;

namespace Mid_HIMMinesweeper
{
    public static class Workflow
    {
        public static int GetInt(string question, int min, int max)
        {
            Console.Write($"{question} ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.Write($"Input error. Please enter an integer between {min} and {max}: ");
            }
        }
    }
}
