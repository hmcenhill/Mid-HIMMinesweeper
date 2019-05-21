using System;

namespace Mid_HIMMinesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var minesweeper = new Minesweeper();
            minesweeper.Run();

            Console.WriteLine("\n\n-----------------------------------");
            Console.WriteLine("End of demo. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
