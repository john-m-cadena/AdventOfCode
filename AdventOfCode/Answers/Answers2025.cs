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

    public static async Task<long> DayThree(string fileName) 
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        long sum = 0;

        foreach(var line in input) {
            var batteries = line
                .ToCharArray()
                .Select(jolt => long.Parse(jolt.ToString()))
                .ToArray();
            sum += long.Parse(FindHighestJoltage(batteries, 11, string.Empty));
        }
        return sum;
    }

    private static string FindHighestJoltage(long[] remaining, int bound, string joltage)
    {
        if (bound < 0) { return joltage; }
        var max = remaining[..(remaining.Length-bound)].Max();
        var index = remaining.IndexOf(max);
        return string.Concat(joltage, 
            FindHighestJoltage(remaining[(index+1)..],
                bound - 1,
                max.ToString()
            ));
    }

    public static async Task<int> DayFour(string fileName) 
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        var map = Utilities.MatrixUtilities.MapInput(input);
        var sum = 0;

        for (int row = 0; row < input.Length; row++) 
        {
            for (int col = 0; col < input[0].Length; col++)
            {
                if (map[row, col] != '@') { continue; }
                if (CanBeRemoved(map, row, col)) 
                { 
                    sum++;
                    map[row, col] = '.';
                    row = 0;
                    col = 0;
                }
            }
        }
        return sum;
    }

    private static bool CanBeRemoved(char[,] map, int row, int col) 
    {
        var count = 0;
        var xBound = map.GetLength(0);
        var yBound = map.GetLength(1);

        for (int x = row - 1; x <= row + 1; x++)
        {
            for (int y = col - 1; y <= col + 1; y++)
            {
                if (x == row && y == col) { continue; }
                if (Utilities.MatrixUtilities.IsInBounds(xBound, x, yBound, y)
                    && map[x,y] == '@') { count++; }
                if (count > 3) { return false; }
            }

        }
        return true;
    }

    public static async Task<int> DayFive(string fileName)
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        var sum = 0;
        var blankIndex = 0;

        for (int i = 0; i < input.Length; i++) 
        {
            if (string.IsNullOrEmpty(input[i])) 
            {
                blankIndex = i;
                break;
            }
        }

        var ranges = input[..blankIndex];
        var parsedRanges = ranges.Select(r => r.Split("-").Select(long.Parse).ToList());
        var freshIds = input[(blankIndex + 1)..].Select(long.Parse).ToList();

        foreach (var fresh in freshIds)
        {
            var isValid = false;
            foreach (var range in parsedRanges)
            {
                if (fresh >= range[0] && fresh <= range[1])
                {
                    isValid = true;
                    break;
                }
            }
            if (isValid) { sum++; }
        }

        return sum;
    }

    public static async Task<long> DaySix(string fileName) 
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        long sum = 0;
        var parsed = new List<string[]>();
        foreach (var line in input)
        {
            parsed.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
        for (int i = 0; i < parsed[0].Length; i++)
        {
            long total;
            var op = parsed[^1][i];
            if (op == "+") { total = long.Parse(parsed[0][i]) + long.Parse(parsed[1][i]); }
            else { total = long.Parse(parsed[0][i]) * long.Parse(parsed[1][i]);}
            for (int j = 2; j < parsed.Count - 1; j++) 
            {
                if (op == "+") { total += long.Parse(parsed[j][i]); }
                else { total *= long.Parse(parsed[j][i]); }
            }
            sum += total;
        }
        return sum;
    }

    public static async Task<int> DaySeven(string fileName)
    {
        var input = await Utilities.InputParser.ParseInput(fileName);
        var map = Utilities.MatrixUtilities.MapInput(input);
        var sum = 0;

        var beamIndexes = new List<int> { input[0].IndexOf('S') };
        for (int i = 1; i < input.Length; i++) 
        {
            var temp = new List<int>(beamIndexes);
            foreach (var index in beamIndexes)
            {
                if (map[i,index] != '^') { continue; }
                sum++;
                temp.Remove(index);
                if (index > 0) { temp.Add(index - 1); }
                if (index < input[0].Length) { temp.Add(index + 1); }
            }
            beamIndexes = [.. temp.Distinct()];
        }
        return sum;
    }
}
