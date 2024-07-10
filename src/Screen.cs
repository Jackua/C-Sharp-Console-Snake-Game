namespace Snake {
    public class Screen
    {
        private const int Seconds = 100;

        public Player Player { get; set; }
        public HUD HUD { get; set; }
        private ConsoleKey ConsoleKey { get; set; } = ConsoleKey.RightArrow;
        private Food Food = new();

        public Screen(Player Player, HUD HUD)
        {
            this.Player = Player;
            this.HUD = HUD;
        }

        public void Run() {

            this.Initialize();
            this.HUD.StartStopWatch();
            while (!this.Player.LoseTailCheck())
            {   
                Console.SetCursorPosition(0, 0);
                Console.Write(this.HUD.GetHUD());
                if (Console.KeyAvailable)
                {
                    ConsoleKey = Console.ReadKey(true).Key;
                }
                this.PlayerMove();
                Thread.Sleep(Seconds);
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(this.HUD.Lose());

        }

        private void Initialize()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Draw(this.Player);
            Draw(this.Food);
        }

        private void PlayerMove() {
            this.Player.Move(ConsoleKey);
            this.OffScreen();

            if (this.OverLap())
            {
                this.ReplaceFood();
                this.Player.AddToTail();
                this.HUD.IncrementPoints();
            }

            Draw(this.Player.PreviousX, this.Player.PreviousY, " ");
            Draw(this.Player);
            Draw(this.Player.Tail);
        }

        private static void Draw(int x, int y, string sprite)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sprite);
        }

        private static void Draw(Entity entity)
        {
            Draw(entity.X, entity.Y, entity.Sprite);
        }

        private static void Draw(int[,] tail, string sprite = "O")
        {
            for (int i = 0; i < tail.GetLength(0); i++)
            {
                Draw(tail[i,0], tail[i,1], sprite);
            }
        }

        private void ReplaceFood()
        {
            this.Food = new();
            Draw(this.Food);
        }

        private bool OverLap()
        {
            return this.Player.X == this.Food.X && this.Player.Y == this.Food.Y;
        }

        private void OffScreen()
        {
            if (Player.X >= Console.WindowWidth)
            {
                Player.X = 1;
            } 
            else if (Player.X < 1)
            {
                Player.X = Console.WindowWidth - 1;
            }
            if (Player.Y >= Console.WindowHeight)
            {
                Player.Y = 1;
            }
            else if (Player.Y < 1)
            {
                Player.Y = Console.WindowHeight - 1;
            }
        }
    }
}