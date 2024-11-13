using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    public string Name
    {
        get { return _name; }
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }
    public int Level
    {
        get { return _level; }
        init
        {
            _level = Validator.Limiter(value, 1, 10);
        }
    }

    public abstract int Power { get; }
    public abstract string Info { get; }
    public Creature()
    {

    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public abstract string Greeting();

    public void Upgrade() => _level = _level < 10 ? _level + 1 : _level;
    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public string[] Go(Direction[] directions)
    {
        var result = new string[directions.Length];

        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
            
    }
    public string[] Go(string input) => Go(DirectionParser.Parse(input));

    public override string ToString() => $"{this.GetType().Name.ToUpper()}: {Info}";

}
