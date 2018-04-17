using System;
using System.Threading;

namespace Ludo
{
    public class Game
    {
		private int nrOfPlayers = 4;
		private int playerMin = 2;
		private int playerMax = 4;
		private int nrOfPieces = 4;
		private int lastPlayer = 0;
		
        private bool won = false;
        private Player[] players;
        private Piece[][] pieces = new Piece[4][];
        private Board board = new Board();
        private Dice die = new Dice(6);
        ConsoleKeyInfo keyInfo;


        public Game()
        {
            Console.CursorVisible = false;
            Menu();
            //InitGame();

        }

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

                            if (keyInfo.Key == ConsoleKey.Escape)
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
                    Console.WriteLine("Choose number of players. (Press {0}-{1})", playerMin, playerMax);
                    Console.WriteLine();
                    Console.WriteLine("Press Escape to exit to main menu");
                    break;

                default:
                    break;
            }
        }

        public void Update()
        {
            board.Draw(PositionList());

            //WritePlayerName(lastPlayer);
        }

        public int[][] PositionList()
        {
            int[][] temp = new int[nrOfPlayers][];

            for (int player = 0; player < nrOfPlayers; player++)
            {
                temp[player] = new int[nrOfPieces]; 
                for (int i = 0; i < nrOfPieces; i++)
                {
                    temp[player][i] = players[player].Place(pieces[player][i].Position, i);
                }
            }

            return temp;
        }

        public void Move(int player, int piece, int spaces)
        {
            int currentPlayer = 0;
            int currentPiece = 0;

            pieces[player][piece].Move(spaces);

            foreach (Array playerSet in PositionList())
            {
                currentPiece = 0;

                if (currentPlayer != player)
                {
                    foreach (int space in playerSet)
                    {
                        if (pieces[player][piece].Position == space)
                        {
                            pieces[currentPlayer][currentPiece].Position = 0;
                        }
                        currentPiece++;
                    }
                    
                }
				currentPlayer ++;
            }
            Update();
        }

        // player done check
        public bool PlayerDone(int player)
        {
            int nr = 0;

            foreach (Piece piece in pieces[players[player].PlayerID])
            {
                if (piece.IsDone)
                {
                    nr++;
                }
            }

            return (nr == nrOfPieces);
        }

        public bool GameWon()
        {
            if (!won)
            {
                // check last player's state
            }

            return won;
        }

        // game done check
        public bool GameDone()
        {
            int nr = 0;

            foreach (Player player in players)
            {
                if (PlayerDone(player.PlayerID))
                {
                    nr++;
                }
            }

            return (nr > 2);
        }

        public void WritePlayerName(int player)
        {
            switch (player)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                default:
                    break;
            }
            int playNr = player + 1;
            Console.WriteLine("player {0}", playNr);
            Console.ResetColor();
        }

        public void InitGame()
        {
            players = new Player[nrOfPlayers];


            for (int i = 0; i < nrOfPlayers; i++)
            {
                players[i] = new Player(i);
            }

            for (int i = 0; i < nrOfPlayers; i++)
            {
                pieces[i] = new Piece[4];

                for (int a = 0; a < nrOfPieces; a++)
                {
                    pieces[i][a] = new Piece(a);
                }
            }


            Update();


            while (!GameDone())
            {
                foreach (Player player in players)
                {
                    lastPlayer = player.PlayerID - 1;

                    if (!player.InPlay)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("throws left: {0}", 3 - i);

                            if (die.Throw() == 6)
                            {
                                int tempPlayer = player.PlayerID;
                                foreach (var piece in pieces[tempPlayer])
                                {
                                    if (piece.Position == 0)
                                    {
                                        Move(player.PlayerID, piece.GetId(), 1);

                                        player.InPlay = true;

                                        break;
                                    }

                                    throw new System.ArgumentException("piece positions doesn't match playerstate");

                                }

                                break;
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("not 6");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Update();
                        }
                    }

                    if (player.InPlay)
                    {
                        Console.WriteLine("throw dice, player {0}", player.PlayerID);
                        die.Throw();

                        //there's supposed to be more stuff in here. like, the rest of a turn,
                        //but I need even more methods, and I'm just at a loss, I guess
                    }
                }
            }
            //board.PiecePlacement(PositionList());


            #region auto (hardcoded garbage)(commented out)
            //      private Dice playerDie = new Dice(4);
            //       while ((!pieces[0][0].IsDone() || !pieces[0][1].IsDone() ||
            //               !pieces[0][2].IsDone() || !pieces[0][3].IsDone()) ||

            //              (!pieces[1][0].IsDone() || !pieces[1][1].IsDone() ||
            //               !pieces[1][2].IsDone() || !pieces[1][3].IsDone()) ||

            //              (!pieces[2][0].IsDone() || !pieces[2][1].IsDone() ||
            //               !pieces[2][2].IsDone() || !pieces[2][3].IsDone()) ||

            //              (!pieces[3][0].IsDone() || !pieces[3][1].IsDone() ||
            //               !pieces[3][2].IsDone() || !pieces[3][3].IsDone()))
            //       {

            //           int i;
            //           int moves;
            //           bool moved;
            //           int sleepTime = 500;

            //           for (int ii = 0; ii < 4; ii++)
            //           {
            //            moves = 0;
            //            moved = false;

            //            if(!players[ii].Moved)
            //            {
            //                for (int a = 0; a < 3; a++)
            //                {
            //                    if (die.Throw() == 6)
            //                    {
            //                        Move(ii,0,1);

            //                        Thread.Sleep(sleepTime);

            //                        Move(ii,0,die.Throw());

            //                        players[ii].Moved = true;

            //                        Thread.Sleep(sleepTime);
            //                    }
            //                }
            //            }

            //            else
            //            {
            //                while (!moved && moves < 10)
            //                {
            //                    i = playerDie.Throw() - 1;

            //                    die.Throw();

            //                    if (pieces[ii][i].Position == 0 && die.LastThrow() == 6)
            //                    {
            //                        Move(ii,i,1);


            //                        Thread.Sleep(sleepTime);

            //                        Move(ii,i,die.Throw());

            //                        players[ii].Moved = true;

            //                        Thread.Sleep(sleepTime);
            //                    }


            //                    else if (!pieces[ii][i].IsDone())
            //                    {
            //                            Move(ii,i,die.LastThrow());

            //if (die.LastThrow() != 6)
            //{
            //                        moved = true;
            //                    }

            //                        Thread.Sleep(sleepTime);
            //                }

            //                else
            //                {
            //                    moves++;
            //                }
            //            }
            //        }
            //    }
            //}
            #endregion

            #region player path print (commented out)
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
            #endregion
        }
    }
}