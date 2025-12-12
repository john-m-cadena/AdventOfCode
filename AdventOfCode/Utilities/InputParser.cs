namespace AdventOfCode.Utilities;

public static class InputParser
{
    public static async Task<string[]> ParseInput(string fileName)
    {
        var lines = new List<string>();
        var path = string.Concat("../../../Input/Input2025/", fileName);
        using StreamReader reader = new(path);
        string? line;
        while ((line = await reader.ReadLineAsync()) != null) { lines.Add(line); }
        return [.. lines];
    }
}