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
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";

    public Orc() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public void Hunt()
    {
        _count++;
        if (_count % 2 == 0 && _rage < 10)
        {
            _rage++;
        }
    }

    public override string Greeting()
    {
        string greeting = $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
        return greeting;
    }
}
