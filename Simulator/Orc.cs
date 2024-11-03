using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int _count = 0;
    private int _rage = 1;

    public int Rage
    {
        get => _rage;
        init => _rage = Math.Clamp(value, 0, 10);
    }

    public override int Power
    {
        get => 7 * Level + 3 * Rage;
    }

    public Orc() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = _rage;
    }

    public void Hunt()
    {
        Console.WriteLine($"{Name} is huntung.");
        _count++;
        if (_count % 2 == 0 && _rage < 10)
        {
            _rage++;
        }
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
    }
}
