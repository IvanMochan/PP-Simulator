using Simulator;
namespace TestSimulator;
public class ValidatorTests
{

    [Theory]

    [InlineData(10, 5, 15, 10)] 

    [InlineData(20, 5, 15, 15)] 

    [InlineData(0, 5, 15, 5)]  
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }


    [Theory]

    [InlineData("d    h", 3, 5, '#', "D##")] 

    [InlineData("This is a long string that will be shortened", 5, 25, '#', "This is a long string tha")]

    [InlineData("Short", 8, 15, '*', "Short***")]

    [InlineData("hello", 3, 10, '#', "Hello")]

    [InlineData("Valid", 3, 10, '-', "Valid")]

    [InlineData("Fine", 5, 10, '@', "Fine@")]

    [InlineData("Hi", 5, 10, '.', "Hi...")]

    [InlineData("Okay", 3, 10, '*', "Okay")]

    [InlineData("Fine", 4, 10, '@', "Fine")]
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);
        // Assert
        Assert.Equal(expected, result);
    }
}