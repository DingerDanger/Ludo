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
        private int result = 0;
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
                int hitCount = 0;
                int hitPiece = 0;

                if (currentPlayer != player)
                {
                    foreach (int space in playerSet)
                    {
                        if (players[player].Place(pieces[player][piece].Position) == space)
                        {
                            if (pieces[currentPlayer][currentPiece].Position == 1)
                            {
                                pieces[player][piece].Position = 0;
                                break;
                            }
                            hitCount++;

                            hitPiece = currentPiece;
                        }
                        currentPiece++;
                    }

                    if (hitCount == 1)
                    {
                        pieces[currentPlayer][hitPiece].Position = 0;
					    
					}

                    else if (hitCount >1)
                    {
                        pieces[player][piece].Position = 0;
                    }
                }
                currentPlayer++;
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

        public void PlayCheck(int player)
        {
            players[player].InPlay = false;

            foreach (var piece in pieces[player])
            {
                players[player].InPlay |= (piece.Position != 0 && !piece.IsDone);
            }
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
                    PlayCheck(player.PlayerID);


                    if (!player.InPlay)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine("throws left: {0}", 3 - i);
                            if (die.Throw() >= 0)
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
                            Console.WriteLine(" not 6");
                            Console.ResetColor();
                            Thread.Sleep(1000);
                            Update();
                        }
                    }

                    if (player.InPlay)
                    {
						for (int turns = 1; turns >= 1; turns--)
						{
                            Console.WriteLine("throw dice, player {0}", player.PlayerID);
                            Console.WriteLine("selected: {0}", board.SelectedPiece);
                            //result = die.Throw();
                            while (!int.TryParse((keyInfo = Console.ReadKey(true)).KeyChar.ToString(), out result)) ;

                            int cnt = 0;
                            foreach (var piece in pieces[player.PlayerID])
                            {
                                if (piece.Position > 0)
                                {
                                    cnt++;
                                }
                            }

                            if (result == 6)
                            {
                                turns++;
								
                                if (cnt < 4)
								{
									cnt++;
								}
                            }

                            if (cnt == 1)
                            {
                                board.SelectedPiece = 1;
                                Move(player.PlayerID, 0, result);
                            }
                            else
                            {
                                board.SelectedPlayer = player.PlayerID;

                                while (true)
                                {
                                    Update();
                                    Console.WriteLine("You rolled a {0}", result);
                                    Console.WriteLine("Press 'T' to toggle Piece or Press Enter to select Piece , player {0}", player.PlayerID);
                                    Console.WriteLine("selected: {0}", board.SelectedPiece);
                                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                                    if (keyPressed.Key == ConsoleKey.T)
                                    {
                                        
										if (board.SelectedPiece >= cnt)
										{
											board.SelectedPiece = 1;
										}
										else
										{
											board.SelectedPiece++;
											
										}
                                        
                                            if (pieces[player.PlayerID][board.SelectedPiece-1].IsDone)
                                            {
                                                board.SelectedPiece++;
                                            }
                                        

                                    }
                                    if (keyPressed.Key == ConsoleKey.Enter)
                                    {
                                        if (board.SelectedPiece > 0) break;
                                    }


                                }

                                if (pieces[board.SelectedPlayer][board.SelectedPiece-1].Position == 0)
                                {
                                    Move(player.PlayerID, board.SelectedPiece-1, 1);
                                }

                                else
                                {
                                    Move(player.PlayerID, board.SelectedPiece-1, result);
                                }

                                board.SelectedPiece = 0;
                                board.SelectedPlayer = 9;
                                Update();
                            }
                        }
                    }
                }
            }
        }
        private void LuckySix(int player)
        {

            int tempPlayer = player;
            foreach (var piece in pieces[tempPlayer])
            {
                if (piece.Position == 0)
                {
                    Move(player, piece.GetId(), 1);


                    break;
                }


            }



        }

        //board.PiecePlacement(PositionList());


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
