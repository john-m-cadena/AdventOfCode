using AdventOfCode.Answers;
using Xunit;

namespace AdventOfCode.Tests;

public class Tests2025
{
    [Fact]
    public static async Task Test_DayOne()
    {
        // Arrange
        var expected = 3;

        // Act
        var actual = await Answers2025.DayOne("DayOneTest.txt");

        // Asert
        Assert.Equal(expected, actual);
    }
}