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
                try
                {
                    if (i + 3 >= data.Length || j - 3 < -1)
                    {
                        break;
                    }
                    else if (data[i][j] == pattern[0] && data[i + 1][j - 1] == pattern[1]
                    && data[i + 2][j - 2] == pattern[2] && data[i + 3][j - 3] == pattern[3])
                    {
                        matches++;
                    }
                }
                catch (IndexOutOfRangeException) { break; }
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

    private static void PartTwo(string[] data)
    {
        int occurrences = 0;
        //var patterns = new List<string> { "M.S", "S.M", "M.(?=M)", "S.(?=S)" };
        
        //works with sample set. too low with actual set

        for (int i = 1; i < data.Length - 1; i++)
        {            
            for(int j = 1; j < data[i].Length -1; j++)
            {
                if(data[i][j] == 'A')
                {
                    if(data[i-1][j-1] == 'M' &&data[i-1][j+1] == 'S' && data[i+1][j-1] == 'M' &&data[i+1][j+1] == 'S')
                    {
                        occurrences++;
                    }
                    else if (data[i-1][j-1] == 'S' &&data[i-1][j+1] == 'M' && data[i+1][j-1] == 'S' &&data[i+1][j+1] == 'M') 
                    { 
                        occurrences++; 
                    }
                    else if (data[i-1][j-1] == 'M' &&data[i-1][j+1] == 'M' && data[i+1][j-1] == 'S' &&data[i+1][j+1] == 'S') 
                    {
                        occurrences++;
                    }
                    else if (data[i-1][j-1] == 'S' &&data[i-1][j+1] == 'S' && data[i+1][j-1] == 'M' &&data[i+1][j+1] == 'M')
                    {
                        occurrences++;
                    }
                }
            }
        }

        Console.WriteLine("" + occurrences);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/Day4/input.txt");
        //PartOne(input);
        PartTwo(input);
    }
}