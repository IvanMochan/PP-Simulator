﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    public string Name
    {
        get { return _name; }
        init
        {
            _name = value.Trim();
            if (_name.Length > 25)
                _name = _name.Remove(25).Trim();
            if (_name.Length < 3)
                _name = _name.PadRight(3, '#');
            if (char.IsLower(_name[0]))
                _name = char.ToUpper(_name[0]) + _name.Substring(1);
        }
    }
    public int Level
    {
        get { return _level; }
        init
        {
            _level = Math.Clamp(value, 1, 10);
        }
    }
    public string Info => $"{Name} [{Level}]";
    public Creature()
    {

    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");

    public void Upgrade() => _level = _level < 10 ? _level + 1 : _level;
    public void Go(Direction direction) => Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
            Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}");
    }
    public void Go(string input)
    {
        Go(DirectionParser.Parse(input));
    }

}
