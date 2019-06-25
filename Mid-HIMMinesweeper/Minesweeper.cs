using System;
using System.Collections.Generic;
using System.Text;

namespace Mid_HIMMinesweeper
{
    public class Minesweeper
    {
        public void Run()
        {
            do
            {
                var playing = true;
                var field = new Minefield();
                while (playing)
                {
                    Console.Clear();
                    field.DisplayField();

                    playing = TakeTurn(field);
                }
                Console.Clear();
                EndGame(field);
                field.DisplayField();
            } while (Workflow.KeepGoing("\n\nWould you like to play again?"));
        }
        private bool TakeTurn(Minefield field)
        {
            var x = Workflow.GetInt("\n\nrow: ", 0, field.Field.GetLength(0)-1);
            var y = Workflow.GetInt("col: ", 0, field.Field.GetLength(1)-1);

            field.Reveal(x, y);

            if(field.Field[x,y] == '*') return false;
            return true;
        }
        private void EndGame(Minefield field)
        {
            var countNotRevealed = 0;
            for (var i = 0; i < field.Field.GetLength(0); i++)
            {
                for (var j = 0; j < field.Field.GetLength(1); j++)
                {
                    if (field.VisibleField[i, j] == '+')
                    {
                        countNotRevealed++;
                    }
                    if(field.Field[i,j] == '*')
                    {
                        field.VisibleField[i, j] = 'X';
                    }
                }
            }
            if(field.MineCount == countNotRevealed)
            {
                Console.WriteLine("You Win!\n");
            }
            else
            {
                Console.WriteLine("You lose :(\n");
            }
        }
    }
}
