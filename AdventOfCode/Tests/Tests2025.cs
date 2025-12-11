using AdventOfCode.Answers;
using Xunit;

namespace AdventOfCode.Tests;

public class Tests2025
{
    [Fact]
    public static void Test_DayOne()
    {
        // Arrange
        var expected = 4;

        // Act
        var actual = Answers2025.DayOne();

        // Asert
        Assert.Equal(expected, actual);
    }
}