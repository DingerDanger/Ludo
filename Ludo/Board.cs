using System;
namespace Ludo
{
    public class Board
    {
        private string tileSize = "OwO ";

        private char[][] eBoLa = new char[17][];
        private char[] path = new char[93];
        private int[] placement = new int[16];


        public Board()
        {
            PathReset();

            eBoLa[0] = new char[]  { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' };

            eBoLa[1] = new char[]  { 'B', 'r', 'r', 'r', 'r', 'r', 'r', path[11], path[12], path[13], 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            eBoLa[2] = new char[]  { 'B', 'r', path[78], 'r', 'r', path[79], 'r', path[10], path[59], path[14], 'b', path[81], 'b', 'b', path[82], 'b', 'B' };

            eBoLa[3] = new char[]  { 'B', 'r', 'r', 'r', 'r', 'r', 'r',  path[9], path[60], path[15], 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            eBoLa[4] = new char[]  { 'B', 'r', 'r', 'r', 'r', 'r', 'r',  path[8], path[61], path[16], 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            eBoLa[5] = new char[]  { 'B', 'r', path[77], 'r', 'r', path[80], 'r',  path[7], path[62], path[17], 'b', path[84], 'b', 'b', path[83], 'b', 'B' };

            eBoLa[6] = new char[]  { 'B', 'r', 'r', 'r', 'r', 'r', 'r',  path[6], path[63], path[18], 'b', 'b', 'b', 'b', 'b', 'b', 'B' };

            eBoLa[7] = new char[]  { 'B', path[52],  path[1],  path[2],  path[3],  path[4],  path[5], 'B', path[64], 'B', path[19], path[20], path[21], path[22], path[23], path[24], 'B' };

            eBoLa[8] = new char[]  { 'B', path[51], path[53], path[54], path[55], path[56], path[57], path[58], 'B', path[70], path[69], path[68], path[67], path[66], path[65], path[25], 'B' };

            eBoLa[9] = new char[]  { 'B', path[50], path[49], path[48], path[47], path[46], path[45], 'B', path[76], 'B', path[31], path[30], path[29], path[28], path[27], path[26], 'B' };

            eBoLa[10] = new char[] { 'B', 'g', 'g', 'g', 'g', 'g', 'g', path[44], path[75], path[32], 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            eBoLa[11] = new char[] { 'B', 'g', path[91], 'g', 'g', path[92], 'g', path[43], path[74], path[33], 'y', path[88], 'y', 'y', path[85], 'y', 'B' };

            eBoLa[12] = new char[] { 'B', 'g', 'g', 'g', 'g', 'g', 'g', path[42], path[73], path[34], 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            eBoLa[13] = new char[] { 'B', 'g', 'g', 'g', 'g', 'g', 'g', path[41], path[72], path[35], 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            eBoLa[14] = new char[] { 'B', 'g', path[90], 'g', 'g', path[89], 'g', path[40], path[71], path[36], 'y', path[87], 'y', 'y', path[86], 'y', 'B' };

            eBoLa[15] = new char[] { 'B', 'g', 'g', 'g', 'g', 'g', 'g', path[39], path[38], path[37], 'y', 'y', 'y', 'y', 'y', 'y', 'B' };

            eBoLa[16] = new char[] { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' };
        }

        public void Draw()
        {
            Console.Clear();

            foreach (var row in this.eBoLa)
            {
                for (int i = 0; i < 2; i++)
                {
                    foreach (char tile in row)
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

        public void PiecePlacement()
        {
            
        }

        public void PathReset()
        {
            for (int i = 1; i <= 92; i++)
            {
                switch (i)
                {
                    case 1:
                        path[i] = 'r';
                        break;

                    case 14:
                        path[i] = 'b';
                        break;

                    case 27:
                        path[i] = 'y';
                        break;

                    case 40:
                        path[i] = 'g';
                        break;

                    default:

                        if (i > 76)
                        {
                            path[i] = 'w';
                        }

                        else if (i > 52)
                        {
                            if (i <= 58)
                            {
                                path[i] = 'r';
                            }

                            else if (i <= 64)
                            {
                                path[i] = 'b';
                            }

                            else if (i <= 70)
                            {
                                path[i] = 'y';
                            }

                            else if (i <= 76)
                            {
                                path[i] = 'g';
                            }
                        }

                        else if (i % 2 == 0)
                        {
                            path[i] = 'w';
                        }

                        else
                        {
                            path[i] = 'G';
                        }
                        break;
                }
            }
        }
    }
}