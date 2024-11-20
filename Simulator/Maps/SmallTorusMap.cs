using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
    }

    public override Point Next(Point p, Direction d)
    {
        Point next = p.Next(d);

        if (Exist(next))
        {
            return next;
        }
        else
        {
            return new Point((next.X + Size) % Size, (next.Y + Size) % Size);
        }

    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiag = p.NextDiagonal(d);

        if (Exist(nextDiag))
        {
            return nextDiag;
        }
        else
        {
            return new Point((nextDiag.X + SizeX) % SizeY, (nextDiag.Y + SizeY) % SizeX);
        }

    }
}
