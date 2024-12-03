using Simulator;
using Simulator.Maps;
using System.Net.WebSockets;
namespace TestSimulator;
public class SmallSquareMapTest
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        // Arrange
        int size = 10;
        // Act
        var map = new SmallSquareMap(size);
        // Assert
        Assert.Equal((size, size), (map.SizeX, map.SizeY));
    }
    [Theory]
    [InlineData(3)]
    [InlineData(30)]
    public void Constructor_InvalidSize_ShouldThrowException(int size)
    {
        // Act
        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() =>
             new SmallSquareMap(size));
    }
    [Theory]
    [InlineData(5, 7, 10, true)]
    [InlineData(13, 7, 14, true)]
    [InlineData(9, 7, 6, false)]
    [InlineData(20, 7, 20, false)]
    public void Exist_CheckIf_PointIsOnTheMap(int x, int y, int size, bool expectec)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(size);
        //act
        var result = squaremap.Exist(testpoint);
        //assert
        Assert.Equal(expectec, result);
    }
    [Theory]
    [InlineData(5, 7, Direction.Right, 6, 7)]
    [InlineData(0, 7, Direction.Left, 0, 7)]
    [InlineData(8, 12, Direction.Up, 8, 13)]
    [InlineData(5, 7, Direction.Down, 5, 6)]
    [InlineData(13, 0, Direction.Down, 13, 0)]
    public void Next_CheckIf_ReturnsProperPoint(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(20);
        //act
        var result = squaremap.Next(testpoint, dir);
        //assert
        var expected = new Point(res_x, res_y);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(5, 7, Direction.Right, 6, 6)]
    [InlineData(3, 7, Direction.Left, 2, 8)]
    [InlineData(8, 12, Direction.Up, 9, 13)]
    [InlineData(5, 7, Direction.Down, 4, 6)]
    [InlineData(13, 0, Direction.Down, 13, 0)]
    public void NextDiagonal_CheckIf_ReturnsProperPoint(int x, int y, Direction dir, int res_x, int res_y)
    {
        //arrange
        Point testpoint = new Point(x, y);
        var squaremap = new SmallSquareMap(20);
        //act
        var result = squaremap.NextDiagonal(testpoint, dir);
        //assert
        var expected = new Point(res_x, res_y);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 9)]
    [InlineData(0, 0)]
    [InlineData(9, 9)]
    public void AddCreature_ShouldAddToCorrectPosition(int x, int y)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var creature = new Orc("TestCreature", 1);
        var position = new Point(x, y);
        // Act
        map.Add(position, creature);
        creature.InitMapAndPosition(map, position);
        // Assert
        Assert.Contains(creature, map.At(position));
        Assert.Equal(position, creature.Position);
    }
    [Theory]
    [InlineData(19, 10)]
    [InlineData(0, -1)]
    [InlineData(10, 5)]
    public void AddCreature_ShouldThrowArgumentExceptionIfInvalidPosition(int x, int y)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var creature = new Orc("TestCreature", 1);
        var position = new Point(x, y);
        // Act and Assert
        Assert.Throws<ArgumentException>(() => map.Add(position, creature));
    }
    // Testy dla usuwania stworzeń z mapy
    [Theory]
    [InlineData(5, 9)]
    [InlineData(0, 0)]
    [InlineData(9, 9)]
    public void RemoveCreature_ShouldRemoveFromMap(int x, int y)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var creature = new Orc("TestCreature", 1);
        var position = new Point(x, y);
        map.Add(position, creature);
        // Act
        map.Remove(position, creature);
        // Assert
        Assert.DoesNotContain(creature, map.At(position));
    }
   
    // Testy dla ruchu stworzenia za pomocą metody Go 
    [Theory]
    [InlineData(5, 8)]
    [InlineData(1, 0)]
    [InlineData(9, 8)]
    public void CreatureGo_ShouldUpdatePositionCorrectly(int x, int y)
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var creature = new Orc("TestCreature", 1);
        var position = new Point(x, y);
        creature.InitMapAndPostion(map, position);
        map.Add(position, creature);
        // Act
        creature.Go(Direction.Up);
        creature.Go(Direction.Left);
        // Assert - oczekiwany ruch do góry i potem w lewo
        Assert.Equal(new Point(x - 1, y + 1), creature.Position);
        Assert.Contains(creature, map.At(new Point(x - 1, y + 1)));
        Assert.DoesNotContain(creature, map.At(position));
    }
}