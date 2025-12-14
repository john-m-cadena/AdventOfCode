namespace AdventOfCode.Utilities;

public static class MatrixUtilities
{
    public static char[,] MapInput(string[] input)
    {
        char[,] map = new char[input.Length, input[0].Length];
        for (int i = 0; i < input.Length; i++) 
        {
            var chars = input[i].ToCharArray();
            for (int j = 0; j < input[0].Length; j++)
            {
                map[i,j] = chars[j];
            }
        }
        return map;
    }

    public static bool IsInBounds(int xBound, int x, int yBound, int y)
    {
        return x >= 0 
            && x < xBound
            && y >= 0
            && y < yBound;
    }
}