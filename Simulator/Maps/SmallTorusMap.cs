using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }
    private Rectangle _mapRect;

    public SmallTorusMap(int size) 
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException($"Rozmiar musi być w przedziale [5;20]. Podany rozmiar: {size}");
        }
        
        Size = size;
        _mapRect = new(new Point(0, 0), new Point(Size - 1, Size - 1));
    }

    public override bool Exist(Point p)
    {
        return _mapRect.Contains(p);
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
            return new Point((nextDiag.X + Size) % Size, (nextDiag.Y + Size) % Size);
        }

    }
}
