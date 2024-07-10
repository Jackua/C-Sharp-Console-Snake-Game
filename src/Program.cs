using System.Diagnostics;

namespace Snake;

class Program
{
    static void Main(string[] args)
    {
        Player player = new() {
            X = 1,
            Y = 1,
        };

        Stopwatch stopwatch = new Stopwatch();
        HUD hud = new HUD(stopwatch);
        Screen screen = new(player, hud);

        screen.Run();
    }
}
