﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creaturePositions;


    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }
        _creaturePositions = new Dictionary<Point, List<Creature>>();
    }
    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentException($"Pozycja spoza zakresu mapy {position}");
        if (!_creaturePositions.ContainsKey(position))
            _creaturePositions[position] = [];
        _creaturePositions[position].Add(creature);
        creature.Position = position;
        //Console.WriteLine($"Creature added: {_creaturePositions[position]}");
    }

    public override void Remove(Creature creature)
    {
        if (!_creaturePositions.ContainsKey(creature.Position))
            return;
        _creaturePositions[creature.Position].Remove(creature);
        if (_creaturePositions[creature.Position].Count == 0)
            _creaturePositions.Remove(creature.Position);
    }
    public override void Move(Creature creature, Point from, Point to)
    {
        Console.WriteLine($"{Exist(to)} {to}");
        if (!Exist(to))
            throw new ArgumentException($"Docelowa pozycja spoza zakresu mapy {to}");

        if (!_creaturePositions.ContainsKey(from))
            return;

        if (_creaturePositions[from].Remove(creature))
            Add(creature, to);

    }
    public override List<Creature> At(Point position)
    {
        if (_creaturePositions.TryGetValue(position, out var creatures))
            return creatures;
        return [];
    }
    public override List<Creature> At(int x, int y) => At(new Point(x, y));
}