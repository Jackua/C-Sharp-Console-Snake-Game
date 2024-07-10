namespace Snake {
    public class Food : Entity
    {
        public int X { get; }
        public int Y { get; }
        public string Sprite { get; } = "@";

        private readonly Random Random = new();

        /// <summary>
        /// Create a food with random coordinates.
        /// </summary>
        public Food()
        {
            this.X = Random.Next(1, Console.WindowWidth);
            this.Y = Random.Next(1, Console.WindowHeight);
        }
    }
}