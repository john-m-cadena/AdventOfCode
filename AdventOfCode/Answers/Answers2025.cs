using Xunit.Sdk;

namespace AdventOfCode.Answers;

public class Answers2025
{
    public static async Task<int> DayOne(string fileName)
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        var position = 50;
        int sum = 0;

        foreach (var line in input)
        {
            var turns = int.Parse(line[1..]);

            for (int i = turns; i > 0; i--)
            {
                if (line.StartsWith('R'))
                {
                    position++;
                    if (position > 99) { position = 0; }
                }
                else
                {
                    position--;
                    if (position < 0) { position = 99; }
                }
                if (position == 0) { sum++; }
            } 
        }
        return sum;
    }
}
