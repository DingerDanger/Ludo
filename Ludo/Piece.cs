using System;
namespace Ludo
{
    public enum PieceState { Home, Inplay, Safe, FInished}

    public class Piece
    {

        public Piece(int tempId)
        {
            Id = tempId;
            Position = 0;
        }

        public void Move(int spaces)
        { 
            Position += spaces;

            if (Position > 57)
            {
                int positionTemp = Position - 57;
                Position = 57 - positionTemp;
            }

            else if (Position == 57)
            {
                State = PieceState.FInished;
            }
        }

        public int Id { get; private set; }
        public PieceState State { get; set; }
        public int Position { get; set; }
    }
}
