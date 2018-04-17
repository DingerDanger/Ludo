using System;
using System.Threading;

namespace Ludo
{
    public class Dice
    {
        private int sides;
        private int result;
        private Random rnd;
        ConsoleKeyInfo keyInfo;

        public Dice(int sides)
        {
            this.sides = sides;
            this.rnd = new Random();
        }

        public int Throw()
        {
            Console.WriteLine("press 'k' to throw dice");

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.K) ;


			result = this.rnd.Next(1,this.sides + 1);

            Console.Write("Throwing dice ");

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(300);
                Console.Write(". ");
            }
            Thread.Sleep(300);
            Console.WriteLine();
            Console.Write("You rolled a {0}", result);

            return result;
        }

        public int LastThrow()
        {
            return this.result;
        }
    }
}
