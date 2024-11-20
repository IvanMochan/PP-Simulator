using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        
        var result = new List<Direction>();
        // List<Direction> directions = new();
        foreach (char ch in input.ToUpper())
        {
            switch (ch)
            {
                case 'U':
                    result.Add(Direction.Up);
                    break;
                case 'R':
                    result.Add(Direction.Right);
                    break;
                case 'D':
                    result.Add(Direction.Down);
                    break;
                case 'L':
                    result.Add(Direction.Left);
                    break;
            }
        }
        return result;
    }
}
