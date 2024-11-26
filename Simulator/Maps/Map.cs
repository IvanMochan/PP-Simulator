using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract void Add(Creature creature, Point position);
    public abstract void Remove(Creature creature);
    public abstract void Move(Creature creature, Point from, Point to1);
    public abstract List<Creature> At(int x, int y);
    public abstract List<Creature> At(Point point);

    private readonly Rectangle _mapRect;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        //_mapRect = new(new Point(0, 0), new Point(SizeX - 1, SizeY - 1));
        _mapRect = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _mapRect.Contains(p) ;

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
