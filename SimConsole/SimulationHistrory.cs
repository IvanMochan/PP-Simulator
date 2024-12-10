using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class SimulationHistory
{
    private readonly Simulation _simulation;
    private readonly List<Tuple<Point, string>> _movements;
    private readonly List<IMappable> _mappables;
    private readonly List<string> _frames;
    private readonly MapVisualizer _visualizer;
    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation;
        _movements = [];
        _mappables = [];
        _frames = [];
        _visualizer = new(simulation.Map);

        RunSimulation();
    }
    public void RunSimulation()
    {
        _frames.Add(_visualizer.Draw());
        while (!_simulation.Finished)
        {
            _mappables.Add(_simulation.CurrentMappable);
            _movements.Add(new(_simulation.CurrentMappable.Position, _simulation.CurrentMoveName));
            _simulation.Turn();
            _frames.Add(_visualizer.Draw());
        }
    }

    public void DisplayTurn(int turn)
    {
        if (turn - 1 == -1)
        {
            Console.WriteLine("\nStarting positions:");
            Console.WriteLine($"\nTurn {turn}");
            Console.WriteLine(_frames[turn]);
        }
        else
        {
            Console.WriteLine($"\nTurn {turn}");
            Console.WriteLine($"{_mappables[turn - 1]} {_movements[turn - 1].Item1} goes {_movements[turn - 1].Item2}:");
            Console.WriteLine(_frames[turn]);
        }
    }
    public void DisplayHistory(int turn = 0)
    {
        while (true)
        {
            DisplayTurn(turn);
            Console.WriteLine("\nType the index of the turn you would like to view or nothing to stop:");
            var uInput = Console.ReadLine();
            if (uInput == "")
            {
                Console.WriteLine("End of simulation!");
                break;
            }
            else
            {
                turn = Math.Clamp(Convert.ToInt32(uInput), 0, _mappables.Count);
            }

            Console.Clear();
        }
    }
}