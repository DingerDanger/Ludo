﻿using System;
using System.Threading;

namespace Ludo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            while(true)
            {
				Game br = new Game();
                Thread.Sleep(5000);
                Console.Clear();    
            }
        }
    }
}
