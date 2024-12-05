using System.Text.RegularExpressions;

internal class Program
{
    private static int FindHorizontal(string[] data, string pattern)
    {
        int matches = 0;

        foreach (var line in data)
        {
            matches += Regex.Matches(line, pattern).Count;
        }

        return matches;
    }

    private static int FindVertical(string[] data, string pattern)
    {
        int matches = 0;

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (i + 3 >= data[i].Length)
                {
                    break;
                }
                else if (data[i][j] == pattern[0] && data[i + 1][j] == pattern[1]
                && data[i + 2][j] == pattern[2] && data[i + 3][j] == pattern[3])
                {
                    matches++;
                }
            }
        }

        return matches;
    }

    private static int FindDiagonalLR(string[] data, string pattern)
    {
        int matches = 0;

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (i + 3 >= data.Length || j + 3 >= data[i].Length)
                {
                    break;
                }
                else if (data[i][j] == pattern[0] && data[i + 1][j + 1] == pattern[1]
                && data[i + 2][j + 2] == pattern[2] && data[i + 3][j + 3] == pattern[3])
                {
                    matches++;
                }
            }
        }

        return matches;
    }

    private static int FindDiagonalRL(string[] data, string pattern)
    {
        int matches = 0;

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = data[i].Length - 1; j > 0; j--)
            {
                if (i + 3 >= data.Length || j - 3 <= 0)
                {
                    break;
                }
                else if (data[i][j] == pattern[0] && data[i + 1][j - 1] == pattern[1]
                && data[i + 2][j - 2] == pattern[2] && data[i + 3][j - 3] == pattern[3])
                {
                    matches++;
                }
            }
        }

        return matches;
    }

    private static void PartOne(string[] data)
    {
        int occurrences = 0;
        occurrences += FindHorizontal(data, "XMAS");
        occurrences += FindHorizontal(data, "SAMX");
        occurrences += FindVertical(data, "XMAS");
        occurrences += FindVertical(data, "SAMX");
        occurrences += FindDiagonalLR(data, "XMAS");
        occurrences += FindDiagonalLR(data, "SAMX");
        occurrences += FindDiagonalRL(data, "XMAS");
        occurrences += FindDiagonalRL(data, "SAMX");
        Console.WriteLine(occurrences);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        PartOne(input);
    }
}