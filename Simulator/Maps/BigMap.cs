﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _mappablePositions;


    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 1000)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high");
        }
        _mappablePositions = [];
    }
    public override void Add(Point position, IMappable mappable)
    {
        if (!Exist(position))
            throw new ArgumentException($"Pozycja spoza zakresu mapy {position}");
        if (!_mappablePositions.ContainsKey(position))
            _mappablePositions[position] = [];
        _mappablePositions[position].Add(mappable);
    }

    public override void Remove(Point point, IMappable mappable)
    {
        if (!_mappablePositions.TryGetValue(point, out List<IMappable>? value))
            return;
            value.Remove(mappable);

        if (_mappablePositions[point].Count == 0)
            value.Remove(mappable);
        if (value.Count == 0)
            _mappablePositions.Remove(point);
    }
    public override void Move(IMappable mappable, Point from, Point to, Direction direction)
    {
        if (!Exist(to))
            throw new ArgumentException($"Docelowa pozycja spoza zakresu mapy {to}");

        if (!_mappablePositions.TryGetValue(from, out List<IMappable>? value))
            return;

        if (value.Remove(mappable))
        {
            Add(to, mappable);
        }

    }
    public override List<IMappable> At(Point position)
    {
        return _mappablePositions.TryGetValue(position, out var mappables) ? mappables : ([]);
    }
    public override List<IMappable> At(int x, int y) => At(new Point(x, y));
}