using System;

internal class Program
{
    private static void PartOne(List<string> patterns, List<string> designs)
    {
        int count = 0;

        foreach (string design in designs)
        {
            string alteredDesign = design;

            foreach (string pattern in patterns)
            {
                int patternIndex = alteredDesign.IndexOf(pattern);
                while (patternIndex != -1)
                {
                    alteredDesign = alteredDesign.Remove(patternIndex, pattern.Length);
                    patternIndex = alteredDesign.IndexOf(pattern);
                }
            }

            if (alteredDesign.Length == 0)
                count++;
        }

        Console.WriteLine(count);
    }

    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/Day19/input.txt");
        var patterns = lines[0].Split(',').Select(x=> x.Trim()).ToList();
        patterns.Sort((x,y) => x.Length.CompareTo(y.Length));
        //patterns.Reverse();
        var designs = lines.ToList().GetRange(2, lines.Length - 2);

        PartOne(patterns, designs);
    }
}