using System;
namespace Ludo
{
    public class Game
    {
        private Player[] players = new Player[4];
        private Piece[][] pieces = new Piece[4][];
        private Board board = new Board();
        private Dice die = new Dice(6);

        private int nrOfPlayers = 4;
        private int nrOfPieces = 4;

        public Game()
        {
            
            
            for (int i = 0; i < nrOfPlayers; i++)
            {
                players[i] = new Player(i+1);
            }

            for (int i = 0; i < nrOfPlayers; i++)
            {
                pieces[i] = new Piece[4];

                for (int a = 0; a < nrOfPieces; a++)
                {
                    pieces[i][a] = new Piece(a+1);
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
