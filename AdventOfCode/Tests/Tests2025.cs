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
        var expected = 3121910778619;

        // Act
        var actual = await Answers2025.DayThree("DayThreeTest.txt");

        // Assert
        Assert.Equal(expected, actual);   
    }

    [Fact]
    public static async Task Test_DayFour()
    {
        // Arrange
        var expected = 43;

        // Act
        var actual = await Answers2025.DayFour("DayFourTest.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static async Task Test_DayFive()
    {
        // Arrange
        var expected = 3;

        // Act
        var actual = await Answers2025.DayFive("DayFiveTest.txt");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public static async Task Test_DaySix()
    {
        // Arrange
        var expected = 4277556;

        // Act
        var actual = await Answers2025.DaySix("DaySixTest.txt");

        // Assert
        Assert.Equal(expected, actual);
    }
}
