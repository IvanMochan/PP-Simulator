using Simulator;
using Simulator.Maps;
using System.Text;
namespace SimConsole;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        BigBounceMap map = new BigBounceMap(8, 6);

        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki"}, new Birds() { Description = "Strusie", CanFly = false } , new Birds() { Description = "Orły", CanFly = true }];
        List<Point> points = [new(0,0), new(7,5), new(2,2), new(5,5), new(4,1)];

        string moves = "lrduuulrdduullrdrrud";
        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        Console.WriteLine("SIMULATION!");
        Console.WriteLine("\nStarting positions:");
        while (!simulation.Finished)
        {
            Console.Write(mapVisualizer.Draw());
            Console.WriteLine("Press any key to continue...");
            simulation.Turn();
        }
        Console.Write(mapVisualizer.Draw());
        Console.WriteLine("End of simulation!");
    }
}