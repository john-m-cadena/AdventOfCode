namespace AdventOfCode.Answers;

public class Answers2025
{
    public static async Task<int> DayOne(string fileName)
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        var position = 50;
        int sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var turns = int.Parse(input[i][1..]);
            turns = input[i].StartsWith('R') ? turns : -1 * turns;
            position += turns;
            switch (position)
            {
                case < 0:
                    while (position < 0) { position += 100; }
                    break;
                case > 99:
                    while (position > 99) { position -= 100; }
                    break;
            }
            if (position == 0 || position % 100 == 0) { sum++; }
        }

        return sum;
    }
}