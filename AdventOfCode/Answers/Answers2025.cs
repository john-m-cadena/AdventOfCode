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

    public static async Task<long> DayTwo(string fileName)
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        long sum = 0;

        var ranges = input[0].Split(",");
        foreach (var range in ranges) {
            var bounds = range.Split("-");
            var (low, high) = (long.Parse(bounds[0]), long.Parse(bounds[1]));
            for (long i = low; i <= high; i++) 
            {
                var str = i.ToString();
                for (int j = 1; j < str.Length; j++) 
                {
                    var part = str[..j];
                    if (str.Length % part.Length != 0) { continue; }
                    var split = str.Chunk(part.Length).Select(e => string.Join("", e));
                    if (split.All(e => e.Equals(part))) 
                    {
                        sum += i;
                        break;
                    }
                }
            }
        }
        return sum;
    }
}
