using System;
namespace Ludo
{
    public class Board
    {
        string tileSize = "    ";

        char[][] boLa = new char[17][];

        public Board()
        {
            Draw();
        }

        public void Draw()
        {
            boLa[0] = new char[] { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' };

            boLa[1] = new char[] { 'B', 'r', 'r', 'r', 'r', 'r', 'r', 'G', 'w', 'G', 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            boLa[2] = new char[] { 'B', 'r', 'w', 'r', 'r', 'w', 'r', 'w', 'b', 'b', 'b', 'w', 'b', 'b', 'w', 'b', 'B' };

            boLa[3] = new char[] { 'B', 'r', 'r', 'r', 'r', 'r', 'r', 'G', 'b', 'G', 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            boLa[4] = new char[] { 'B', 'r', 'r', 'r', 'r', 'r', 'r', 'w', 'b', 'w', 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            boLa[5] = new char[] { 'B', 'r', 'w', 'r', 'r', 'w', 'r', 'G', 'b', 'G', 'b', 'w', 'b', 'b', 'w', 'b', 'B' };

            boLa[6] = new char[] { 'B', 'r', 'r', 'r', 'r', 'r', 'r', 'w', 'b', 'w', 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            boLa[7] = new char[] { 'B', 'w', 'r', 'w', 'G', 'w', 'G', 'B', 'b', 'B', 'G', 'w', 'G', 'w', 'G', 'w', 'B' };

            boLa[8] = new char[] { 'B', 'G', 'r', 'r', 'r', 'r', 'r', 'r', 'B', 'y', 'y', 'y', 'y', 'y', 'y', 'G', 'B' };

            boLa[9] = new char[] { 'B', 'w', 'G', 'w', 'G', 'w', 'G', 'B', 'g', 'B', 'G', 'w', 'G', 'w', 'y', 'w', 'B' };

            boLa[10] = new char[]{ 'B', 'g', 'g', 'g', 'g', 'g', 'g', 'w', 'g', 'w', 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            boLa[11] = new char[]{ 'B', 'g', 'w', 'g', 'g', 'w', 'g', 'G', 'g', 'G', 'y', 'w', 'y', 'y', 'w', 'y', 'B' };

            boLa[12] = new char[]{ 'B', 'g', 'g', 'g', 'g', 'g', 'g', 'w', 'g', 'w', 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            boLa[13] = new char[]{ 'B', 'g', 'g', 'g', 'g', 'g', 'g', 'G', 'g', 'G', 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            boLa[14] = new char[]{ 'B', 'g', 'w', 'g', 'g', 'w', 'g', 'g', 'g', 'w', 'y', 'w', 'y', 'y', 'w', 'y', 'B' };

            boLa[15] = new char[]{ 'B', 'g', 'g', 'g', 'g', 'g', 'g', 'G', 'w', 'G', 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            boLa[16] = new char[]{ 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' };

            foreach (var row in this.boLa)
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (var tile in row)
                    {
                        switch (tile)
                        {
                            case 'b':
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'y':
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'r':
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'g':
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'w':
                                Console.BackgroundColor = ConsoleColor.White;
                                //Console.ForegroundColor = ConsoleColor.Red;
                                //if (i == 0)
                                //{
                                //    Console.Write("(TT)");
                                //}
                                //else
                                //{
                                //    Console.Write(" || ");
                                //}
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'B':
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;

                            case 'G':
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.Write(this.tileSize);
                                Console.ResetColor();
                                break;
                        }


                    }
                    Console.WriteLine();
                }

            }

        }
    }
}


