using System.Formats.Asn1;

internal class Program
{
    Dictionary<(ulong number, int numberOfTimes), ulong> cache = new();
    ulong answer = 0;

    private ulong PartOne(ulong stone, int runCounter)
    {
        if (runCounter == 0)
            return 1;
        else
        {

            if (cache.TryGetValue((stone, runCounter), out ulong result)) return result;

            if (stone == 0)
            {
                result = PartOne(1, runCounter - 1);
            }
            else
            {
                var current = stone.ToString();

                if (current.Length % 2 == 0)
                {
                    var half = current.Length / 2;
                    var tmp = current;
                    result += PartOne(ulong.Parse(tmp.ToString()[half..]), runCounter - 1);
                    result += PartOne(ulong.Parse(tmp.ToString()[..half]), runCounter - 1);
                }
                else
                {
                    result = PartOne(stone * 2024, runCounter - 1);
                }
            }
            cache[(stone, runCounter)] = result;
            return result;
        }
    }

    private static void Main(string[] args)
    {
        Program program = new();
        var input = File.ReadAllText("/home/zzz711/Documents/AdventOfCode/Day11/input.txt").Split(' ').Select(a => ulong.Parse(a)).ToList();
        // PartOne(rocks, 25);
        foreach (var number in input)
        {
            program.answer += program.PartOne(number, 75);
        }
        Console.WriteLine(program.answer);
    }
}