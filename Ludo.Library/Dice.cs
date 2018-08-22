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
			result = this.rnd.Next(1,this.sides + 1);

            return result;
        }

        public int LastThrow()
        {
            return this.result;
        }
    }
}
