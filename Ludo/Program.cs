using System;
using System.Threading;

namespace Ludo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dice die = new Dice(6);
            die.Throw();
        }
    }
}
