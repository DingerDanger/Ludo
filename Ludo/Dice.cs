using System;

namespace Ludo
{
    public class Dice
    {
        private int sides;
        private int result;
        private Random rnd;

        public Dice(int sides)
        {
            this.sides = sides;
            this.rnd = new Random();
        }

        public int Throw()
        {
            this.result = this.rnd.Next(1,this.sides + 1);

            return this.result;
        }

        public int LastThrow()
        {
            return this.result;
        }
    }
}
