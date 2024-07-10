using System.Diagnostics;

namespace Snake
{
    public class HUD(Stopwatch stopwatch)
    {
        public int Points { get; set; } = 0;
        public Stopwatch Stopwatch { get; set; } = stopwatch;

        public string GetScorePoints()
        {
            return $"Score: {Points}";
        }

        public void IncrementPoints()
        {
            this.Points++;
        }

        public void StartStopWatch()
        {
            this.Stopwatch.Start();
        }

        public string GetTime()
        {
            return $"Time: {Stopwatch.Elapsed.Seconds}:{Stopwatch.Elapsed.Milliseconds}";
        }

        public string GetHUD()
        {
            string scorePoints = this.GetScorePoints().PadLeft(6);
            string time = this.GetTime();
            int numOfSpaceBetween = Console.WindowWidth - scorePoints.Length - 12;
            string combined = scorePoints.PadRight(numOfSpaceBetween) + time;
            return combined;
        }

        public string Lose()
        {
            string lose = "You Lose!";
            int numOfSpaceBetween = (Console.WindowWidth - lose.Length) / 2;
            return lose.PadLeft(numOfSpaceBetween).PadRight(numOfSpaceBetween);
        }
    }
}