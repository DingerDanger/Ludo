using System;
namespace Ludo
{
    public class Dice
    {
        private int sides;
        private Random rnd;

        public Dice(int sides)
        {
            this.sides = sides;
            this.rnd = new Random();
        }

        public int Throw(int sides)
        {
            return this.rnd.Next(sides+1);
        }
    }
}
