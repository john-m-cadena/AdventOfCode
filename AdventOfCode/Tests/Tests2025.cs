using AdventOfCode.Answers;
using Xunit;

namespace AdventOfCode.Tests;

public class Tests2025
{
    [Fact]
    public static async Task Test_DayOne()
    {
        // Arrange
        var expected = 24;

        // Act
        var actual = await Answers2025.DayOne("DayOneTest.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static async Task Test_DayTwo()
    {
        // Arrange
        var expected = 4174379265;

        // Act
        var actual = await Answers2025.DayTwo("DayTwoTest.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static async Task Test_DayThree()
    {
     // Arrange
        var expected = 357;

        // Act
        var actual = await Answers2025.DayThree("DayThreeTest.txt");

        // Assert
        Assert.Equal(expected, actual);   
    }
}
