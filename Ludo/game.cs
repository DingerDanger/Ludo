using System;
namespace Ludo
{
    public class Game
    {
        private Player[] players = new Player[4];
        private Piece[][] pieces = new Piece[4][];
        private Board board = new Board();
        private Dice die = new Dice(6);
        ConsoleKeyInfo keyInfo;

        private int nrOfPlayers = 4;
        private int playerMin = 2;
        private int playerMax = 4;
        private int nrOfPieces = 4;

        public Game()
        {
            Menu();

        }

        // todo: finish menu
        public void Menu()
        {
            int page = 1;
            bool start = false;
            while (!start)
            {
                switch (page)
                {
                    case 1:

                        DrawMenu(1);

                        while (page == 1)
                        {
                            keyInfo = Console.ReadKey(true);

                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.D1:
                                    page = 2;

                                    break;

                                case ConsoleKey.Escape:
                                    Environment.Exit(0);

                                    break;

                                default:
                                    break;
                            }
                        }
                        break;

                    case 2:
                        DrawMenu(2);

                        while (page == 2 && !start)
                        {
                            start |= ((int.TryParse((keyInfo = Console.ReadKey(true)).KeyChar.ToString(), out nrOfPlayers)) && !(nrOfPlayers < playerMin) && !(nrOfPlayers > playerMax));

                            if(keyInfo.Key == ConsoleKey.Escape)
                            {
                                page = 1;
                            }
                        }

                        break;

                    default:
                        break;
                }
            }
            InitGame();
        }

        public void DrawMenu(int page)
        {
            Console.Clear();
            switch (page)
            {
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Press 1 to start");
                    Console.WriteLine("Press Escape to exit like a wimp");
                    break;

                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Choose number of players. (Press {0}-{1})",playerMin,playerMax);
                    Console.WriteLine();
                    Console.WriteLine("Press Escape to exit to main menu");
                    break;

                default:
                    break;
            }
        }

        public void InitGame()
        {
            for (int i = 0; i < nrOfPlayers; i++)
            {
                players[i] = new Player(i + 1);
            }

            for (int i = 0; i < nrOfPlayers; i++)
            {
                pieces[i] = new Piece[4];

                for (int a = 0; a < nrOfPieces; a++)
                {
                    pieces[i][a] = new Piece(a + 1);
                }
            }

            board.Draw();



            //Console.WriteLine("player paths:");
            //int pathy = 0;
            //Console.WriteLine();
            //Console.WriteLine("player1");
            //foreach (int field in players[0].GetPath())
            //{
            //    Console.Write(pathy + ": ");
            //    Console.WriteLine(field);
            //    pathy++;
            //}
            //pathy = 0;
            //Console.WriteLine();
            //Console.WriteLine("player2");
            //foreach (int field in players[1].GetPath())
            //{
            //    Console.Write(pathy + ": ");
            //    Console.WriteLine(field);
            //    pathy++;
            //}
            //pathy = 0;
            //Console.WriteLine();
            //Console.WriteLine("player3");
            //foreach (int field in players[2].GetPath())
            //{
            //    Console.Write(pathy + ": ");
            //    Console.WriteLine(field);
            //    pathy++;
            //}
            //pathy = 0;
            //Console.WriteLine();
            //Console.WriteLine("player4");
            //foreach (int field in players[3].GetPath())
            //{
            //    Console.Write(pathy + ": ");
            //    Console.WriteLine(field);
            //    pathy++;
            //}
        }
    }
}