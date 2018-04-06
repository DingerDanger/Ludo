using System;
namespace Ludo
{
    public class Player
    {

        private int[] path = new int[62];
        private Piece[] pieces = new Piece[4];
        private bool moved = false;
        private int playerID;

        public Player(int playerid)
        {
            playerID = playerid;

            path[0] = 0;
            int a = 1;

            #region player specific path (switch and for loops)
            switch (playerID)
            {
                case 1:

                    for (int i = 1; i <= 51; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 53; i <= 58; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 77; i <= 80; i++)
                    {
                        path[a] = i;
                        a++;
                    }


                    break;

                case 2:

                    for (int i = 14; i <= 52; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 1; i <= 12; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 59; i <= 64; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 81; i <= 84; i++)
                    {
                        path[a] = i;
                        a++;
                    }


                    break;

                case 3:

                    for (int i = 27; i <= 52; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 1; i <= 25; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 65; i <= 70; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 85; i <= 88; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    break;

                case 4:

                    for (int i = 40; i <= 52; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 1; i <= 38; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 71; i <= 76; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    for (int i = 89; i <= 92; i++)
                    {
                        path[a] = i;
                        a++;
                    }

                    break;

            }
            #endregion

        }

        public Array GetPath() => path;

        public int Place(int piecePosition)
        {
            if (piecePosition == 0)
            {
                throw new System.ArgumentException("Piece id must be specified for home position");
            }

            else
            {
                return path[piecePosition];
            }
        }

        public int Place(int piecePosition, int piece)
        {
            piece += 1;
            if (piecePosition == 0)
            {
                switch (piece)
                {
                    case 1:
                        return path[58];

                    case 2:
                        return path[59];

                    case 3:
                        return path[60];

                    case 4:
                        return path[61];

                    default:
                        throw new System.ArgumentException("Piece id must be 1-4");
                }
            }

            else
            {
                return path[piecePosition];
            }
        }
        public int PlayerID => playerID;

        public bool Moved 
        {
            get { return moved; }
            set { moved = value; }
        }
    }
}