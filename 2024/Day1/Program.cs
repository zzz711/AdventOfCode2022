using System.Runtime.ExceptionServices;

internal class Program
{
    private static void PartOne(List<int> first, List<int> second)
    {
        first.Sort();
        second.Sort();
        double totalDistance = 0;

        for (int i = 0; i < second.Count; i++)
        {
            /*
            Console.Write(first[i]);
            Console.Write("   ");
            Console.WriteLine(second[i]);
            Console.WriteLine(second[i] - first[i]);*/

            if(second[i] > first[i])
                totalDistance += second[i] - first[i];
            else
                totalDistance += first[i] - second[i];
        }

        Console.WriteLine(totalDistance);
    }

    private static void PartTwo(List<int> first, List<int> second)
    {
        double similarityScore = 0;

        foreach (var leftNum in first)
        {
           var count = second.Where(s => s== leftNum).ToList().Count;
           count *= leftNum;
           similarityScore += count;
        }

        Console.WriteLine(similarityScore);
    }

    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var left = new List<int>();
        var right = new List<int>();

        foreach (var line in lines)
        {
            var subLine = line.Split("   ");
            //Console.WriteLine(subLine[0]);
            left.Add(int.Parse(subLine[0]));
            right.Add(int.Parse(subLine[1]));
        }

        PartOne(left, right);
        PartTwo(left, right);

    }
}