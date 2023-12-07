

using System.Text.RegularExpressions;

internal partial class Program
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();

    private static void Race(string[] input)
    {
        List<int> results = new();

        var times = MyRegex().Matches(input[0]).ToList();
        var distances = MyRegex().Matches(input[1]).ToList();

        for(int i = 0; i < times.Count; i++)
        {
            int ways = 0;
            var time = int.Parse(times[i].Value);
            var distance = int.Parse(distances[i].Value);
            for(int j = 0; j <= time; j++)
            {
                int timeHeld = time - j;
                int distanceGone = timeHeld * j;

                if(distanceGone > distance)
                    ways++;

            }

            results.Add(ways);
        }
        var result = 1;

        foreach(var entry in results)
        {
            result *= entry;
        }

        Console.WriteLine(result);
    }
 
         private static void RacePartTwo(string[] input)
    {
        List<int> results = new();

        var times = MyRegex().Matches(input[0]).ToList();
        var distances = MyRegex().Matches(input[1]).ToList();
         int ways = 0;



            
            
            var timeStr = string.Empty;
            times.ForEach(t => timeStr += t);
            var time = long.Parse(timeStr);

            var distanceStr = string.Empty;
            distances.ForEach(d => distanceStr += d);
            var distance = long.Parse(distanceStr);

            for(long j = 0; j <= time; j++)
            {
                long timeHeld = time - j;
                long distanceGone = timeHeld * j;

                if(distanceGone > distance)
                    ways++;

            }

            results.Add(ways);
        


        Console.WriteLine(ways);
    }   
    

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
//        Race(input);
        RacePartTwo(input);
    }
}