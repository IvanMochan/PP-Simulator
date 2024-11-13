using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int _count = 0;
    private int _agility = 1;

    public int Agility
    {
        get => _agility;
        init => _agility = Validator.Limiter(value, 0, 10);
    }

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public override int Power
    {
        get => 8 * Level + 2 * Agility;
    }

    public Elf () {}

    public Elf (string name = "Unknown", int level = 1, int agility = 1) : base (name, level)
    {
        Agility = agility; 
    }

    public void Sing()
    {
        _count++;
        if ( _count%3 == 0 && _agility < 10)
        {
            _agility++;
        }

    }
    public override string Greeting()
    {
        string greeting = $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
        return greeting;
    }

}