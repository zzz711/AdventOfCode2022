
using System.Text.RegularExpressions;

internal partial class Program
{
    private static int CalculateWinnings(string line)
    {
        int points = 0;

        var splitLine = line.Split(": ");
        splitLine = splitLine[1].Trim().Split(" | ");

        var winningNums = MyRegex().Matches(splitLine[0]).ToList();
        var nums = MyRegex().Matches(splitLine[1]).ToList();

        var matches = nums.Where(n => winningNums.Any(w => w.Value.Equals(n.Value))).ToList();

        if (matches.Count > 0)
        {
            points = 1;
            for (int i = 1; i < matches.Count; i++) //there has to be a better way
            {
                points *= 2;
            }
        }

        return points;
    }

    private static void CountCards(List<string> lines)
    {

        var copiedList = new List<string>();

        for (int i = 0; i < lines.Count; i++)
        {
            var splitLine = lines[i].Split(": ");
            splitLine = splitLine[1].Trim().Split(" | ");

            var winningNums = MyRegex().Matches(splitLine[0]).ToList();
            var nums = MyRegex().Matches(splitLine[1]).ToList();

            var matches = nums.Where(n => winningNums.Any(w => w.Value.Equals(n.Value))).ToList();

            if (matches.Count > 0)
            {
                var range = lines.GetRange(i + 1, matches.Count);
                copiedList.AddRange(range);
                lines.AddRange(range);
            }
        }

        lines.ForEach(l => Console.WriteLine(l));
        Console.WriteLine(lines.Count);
        Console.WriteLine(copiedList.Count);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        int points = 0;

        CountCards(input.ToList());

        foreach (var line in input)
        {
            points += CalculateWinnings(line);
        }

        // Console.WriteLine(points);
    }



    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();
}