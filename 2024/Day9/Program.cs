using System.Text;

internal class Program
{
    private static List<Tuple<int, string>> BuildProcess(string input)
    {
        List<Tuple<int, string>> process = new();
        int counter = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var times = int.Parse(input[i].ToString());
            for (int j = 0; j != times; j++)
            {
                if (i % 2 == 0)
                {
                    process.Add( new Tuple<int, string>(i, counter.ToString()));
                }
                else
                {
                    process.Add( new Tuple<int, string>(i, "."));
                }
            }

            if (i % 2 == 0)
            {
                counter++;
            }
        }

        return process;
    }

    private static void PartOne(string input)
    {
        var startingStage = BuildProcess(input);
        double checksum = 0;

        for (int i = startingStage.Count - 1; i > 0; i--)
        {
            if(!startingStage[i].Equals("."))
            {
                var period = startingStage.Where( x => x.Item2.Equals(".")).FirstOrDefault();
                if (period != default(Tuple<int, string>))
                {
                    int idx = startingStage.IndexOf(period);
                    Tuple<int, string> swap = startingStage[idx];
                    startingStage[idx] = startingStage[i];
                    startingStage[i] = swap;
                }
                else
                    break;

            }
        }

        startingStage.Remove(startingStage[1]);

        int endIndex = startingStage.IndexOf(startingStage.Where( x => x.Item2.Equals(".") ).First());

        for (int i = 0; i < endIndex; i++)
        {
            checksum += int.Parse(startingStage[i].Item2) * i;
        }

        Console.WriteLine(checksum);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllText("/home/zzz711/Documents/AdventOfCode/Day9/input.txt");
        PartOne(input);
    }
}