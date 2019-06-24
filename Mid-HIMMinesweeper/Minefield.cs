using System;
using System.Collections.Generic;
using System.Text;

namespace Mid_HIMMinesweeper
{
    class Minefield
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int MineCount { get; set; }
        public Char[,] Field { get; set; }
        public Char[,] VisibleField { get; set; }

        public Minefield()
        {
            switch ((Difficulty)(Workflow.GetInt("Choose Difficulty:\n1-Easy   2-Medium   3-Hard   4-Custom:", 1, 4) - 1))
            {
                case Difficulty.Easy:
                    Height = 9; Width = 9; MineCount = 10;
                    break;
                case Difficulty.Medium:
                    Height = 16; Width = 16; MineCount = 40;
                    break;
                case Difficulty.Hard:
                    Height = 16; Width = 32; MineCount = 99;
                    break;
                case Difficulty.Custom:
                    Height = Workflow.GetInt("Height: ", 5, 36);
                    Width = Workflow.GetInt("Width: ", 5, 36);
                    MineCount = Workflow.GetInt("Mines: ", 1, Height * Width - 5);
                    break;
            }
            GenerateField();
        }
        private void GenerateField()
        {
            Field = new char[Height, Width];
            VisibleField = new char[Height, Width];
            var rand = new Random();
            for (var i = 0; i < MineCount; i++)
            {
                while (true)
                {
                    var x = rand.Next(0, Width);
                    var y = rand.Next(0, Height);
                    if (Field[y, x] != '*')
                    {
                        Field[y, x] = '*';
                        break;
                    }
                }
            }
            for(var i=0; i<Field.GetLength(0); i++)
            {
                for(var j=0;j<Field.GetLength(1); j++)
                {
                    if (Field[i,j] == '*') continue;
                    Field[i,j] = CountNeighbors(i,j);
                }
            }
        }
        private Char CountNeighbors(int x, int y)
        {
            var counter = 0;
            for(var i = -1; i <= 1; i++)
            {
                for(var j = -1; j <= 1; j++)
                {
                    if (x + i < 0 || x + i >= Field.GetLength(0) || y + j < 0 || y + j >= Field.GetLength(1) || (i == 0 && j == 0))
                    {
                        continue;
                    }
                    else if (Field[x + i, y + j] == '*')
                    {
                        counter++;
                    }
                }
            }
            if(counter == 0)
            {
                return ' ';
            }
            else
            {
                return counter.ToString().ToCharArray()[0];
            }
        }
        public void DisplayField()
        {
            Console.Write("  ");
            for (var j = 0; j < Field.GetLength(1); j++)
            {
                Console.Write($" {Translator(j)}");
            }
            for (var i = 0; i < Field.GetLength(0); i++)
            {
                Console.Write($"\n {Translator(i)}");
                for (var j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write($" {Field[i, j]}");
                }
            }
        }
        private Char Translator(int input)
        {
            var dict = new Dictionary<int, Char>() { { 0, '0' }, { 1, '1' }, { 2, '2' }, { 3, '3' }, { 4, '4' }, { 5, '5' }, { 6, '6' }, { 7, '7' }, { 8, '8' }, { 9, '9' }, { 10, 'A' }, { 11, 'B' }, { 12, 'C' }, { 13, 'D' }, { 14, 'E' }, { 15, 'F' }, { 16, 'G' }, { 17, 'H' }, { 18, 'I' }, { 19, 'J' }, { 20, 'K' }, { 21, 'L' }, { 22, 'M' }, { 23, 'N' }, { 24, 'O' }, { 25, 'P' }, { 26, 'Q' }, { 27, 'R' }, { 28, 'S' }, { 29, 'T' }, { 30, 'U' }, { 31, 'V' }, { 32, 'W' }, { 33, 'X' }, { 34, 'Y' }, { 35, 'Z' } };

            if (dict.TryGetValue(input, out char result))
            {
                return result;
            }
            Console.WriteLine("Dictionary Lookup Error.");
            return ' ';
        }
    }
}