using System;
namespace Ludo
{
    public class Piece
    {
        private int id;
        private int position = 0;
        private bool done = false;

        public Piece(int tempId)
        {
            id = tempId;
        }

        public void Move(int spaces)
        { 
            position += spaces;

            if (position > 57)
            {
                int positionTemp = position - 57;
                position = 57 - positionTemp;
            }

            else if (position == 57)
            {
                done = true;
            }
        }

        public int GetId() => id;

        public bool IsDone => done;

        public int Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
    }
}
