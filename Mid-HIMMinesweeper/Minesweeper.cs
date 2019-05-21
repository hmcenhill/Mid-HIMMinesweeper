using System;
using System.Collections.Generic;
using System.Text;

namespace Mid_HIMMinesweeper
{
    public class Minesweeper
    {
        public void Run()
        {
            var field = new Minefield(Difficulty.Custom);

            field.DisplayField();
        }
    }
}
