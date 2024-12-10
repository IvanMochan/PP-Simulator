using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override bool Exist(Point p)
    {
        return _mapRect.Contains(p);
    }
    public static Direction BouncedDirection(Direction d) => d switch
    {
        Direction.Up => Direction.Down,
        Direction.Down => Direction.Up,
        Direction.Left => Direction.Right,
        Direction.Right => Direction.Left,
        _ => d,
    };
    public override Point Next(Point p, Direction d)
    {
        Point next = p.Next(d);
        return Exist(next) ? next : p.Next(BouncedDirection(d));
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiag = p.NextDiagonal(d);
        if (Exist(nextDiag))
        {
            return nextDiag;
        }
        Point bouncedDiag = p.NextDiagonal(BouncedDirection(d));
        return Exist(bouncedDiag) ? bouncedDiag : p;
    }
}