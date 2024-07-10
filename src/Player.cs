namespace Snake {
    public class Player : Entity
    {
        public required int X { get; set; }
        public required int Y { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }
        public int[,] Tail { get; set; }
        public string Sprite { get; private set; } = ">";

        public Player()
        {
            this.Tail = new int[0,0];
        }

        /// <summary>
        /// Update the coordinates based on the direction moved.
        /// </summary>
        /// <param name="direction"></param>
        public void Move(ConsoleKey direction)
        {
            this.UpdatePrevious();
            switch(direction)
            {
                case ConsoleKey.UpArrow:
                    this.Y--;
                    this.Sprite = "^";
                    break;
                case ConsoleKey.RightArrow:
                    this.X++;
                    this.Sprite = ">";
                    break;
                case ConsoleKey.DownArrow:
                    this.Y++;
                    this.Sprite = "v";
                    break;
                case ConsoleKey.LeftArrow:
                    this.X--;
                    this.Sprite = "<";
                    break;
            }
        }

        /// <summary>
        /// Update the previous X and Y.
        /// </summary>
        public void UpdatePrevious()
        {
            if (Tail.Length == 0)
            {
                this.PreviousX = this.X;
                this.PreviousY = this.Y;
            }
            else 
            {
                // Set the previou X and Y as the last coordinates in the tail.
                this.PreviousX = this.Tail[this.Tail.GetLength(0) - 1, 0];
                this.PreviousY = this.Tail[this.Tail.GetLength(0) - 1, 1];
                for (int i = this.Tail.GetLength(0) - 1; i > 0; i--)
                {
                    this.Tail[i, 0] = this.Tail[i - 1, 0];
                    this.Tail[i, 1] = this.Tail[i - 1, 1];
                }
                this.Tail[0, 0] = this.X;
                this.Tail[0, 1] = this.Y;
            }
        }

        /// <summary>
        /// Extend the length of the tail by 1.
        /// </summary>
        public void AddToTail()
        {
            int[,] newTail = new int[this.Tail.GetLength(0) + 1, 2];
            for (int i = 0; i < this.Tail.GetLength(0); i++)
            {
                newTail[i, 0] = this.Tail[i, 0];
                newTail[i, 1] = this.Tail[i, 1];
            }
            newTail[newTail.GetLength(0) - 1, 0] = this.PreviousX;
            newTail[newTail.GetLength(0) - 1, 1] = this.PreviousY;
            
            this.Tail = newTail;
        }

        public bool LoseTailCheck()
        {
            for (int i = 0; i < this.Tail.GetLength(0); i++)
            {
                if ((this.Tail[i, 0] ==  this.X) && this.Tail[i, 1] == this.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}