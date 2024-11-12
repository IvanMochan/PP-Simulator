namespace Simulator;

internal class Program
{
    static void Lab5a()
    {
        try 
        { 
            var rec1 = new Rectangle(4, 2, 2, 7); // Wynik: (2,2):(4,7)
            Console.WriteLine($"Prostokont 1 : {rec1}");

            var point1 = new Point(9, 5);
            var point2 = new Point(4, 6);
            var rec2 = new Rectangle(point1, point2); // Wynik: (5,4):(9,6)
            Console.WriteLine($"Prostokont 2 : {rec2}");

            var point3 = new Point(5, 5);
            var rec3 = new Rectangle(point1, point3);
            Console.WriteLine($"Prostokont 3 : {rec3}"); // Błędne dane
        }

        catch (ArgumentException ex)
        {
            Console.WriteLine($"Błędne dane: {ex.Message} ");
        }

        var rec4 = new Rectangle(1, 1, 6, 7);
        Point insidep = new Point(4, 4);
        Point outsidep = new Point(10, 10);

        Console.WriteLine($"Czy prostokąt zawiera punkt (3, 4): {rec4.Contains(insidep)}"); // True
        Console.WriteLine($"Czy prostokąt zawiera punkt (9, 9): {rec4.Contains(outsidep)}"); // False



        Point start = new Point(5, 5);
        Console.WriteLine($"Punkt startowy: {start}");

        Console.WriteLine($"Next (Left): {start.Next(Direction.Left)}");      // Wynik: (4,5)
        Console.WriteLine($"Next (Right): {start.Next(Direction.Right)}");    // Wynik: (6,5)
        Console.WriteLine($"Next (Up): {start.Next(Direction.Up)}");          // Wynik: (5,6)
        Console.WriteLine($"Next (Down): {start.Next(Direction.Down)}");      // Wynik: (5,4)

        Console.WriteLine($"NextDiagonal (Left): {start.NextDiagonal(Direction.Left)}");     // Wynik: (4,6)
        Console.WriteLine($"NextDiagonal (Right): {start.NextDiagonal(Direction.Right)}");   // Wynik: (6,4)
        Console.WriteLine($"NextDiagonal (Up): {start.NextDiagonal(Direction.Up)}");         // Wynik: (6,6)
        Console.WriteLine($"NextDiagonal (Down): {start.NextDiagonal(Direction.Down)}");     // Wynik: (4,4)
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
}
