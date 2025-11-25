internal class Program
{

    private static void PartOne(List<List<int>> data)
    {
        bool isIncreasing = false;
        int safe = 0;

        foreach (var line in data)
        {
            isIncreasing = line[0] < line[1];
            for (int i = 1; i < line.Count; i++)
            {
                if (isIncreasing)
                {
                    var difference = line[i] - line[i - 1];
                    if (difference > 0 && difference < 4 && i == line.Count - 1)
                    {
                        safe++;
                    }
                    else if (difference < 1 || difference > 3)
                    {
                        break;
                    }
                }
                else
                {
                    var difference = line[i - 1] - line[i];
                    if (difference > 0 && difference < 4 && i == line.Count - 1)
                    {
                        safe++;
                    }
                    else if (difference < 1 || difference > 3)
                    {
                        break;
                    }
                }
            }
        }
        Console.WriteLine(safe);
    }

    private static void PartTwo(List<List<int>> data)
    {
        int safe = 0;
        
        foreach (var line in data)
        {
            if(IsSafe(line))
            {
                safe++;
            }
            else
            {
                for (int i = 0; i < line.Count; i++)
                {
                    List<int> newLine = new(line);
                    newLine.RemoveAt(i);
                    if (IsSafe(newLine))
                    {
                        safe++;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(safe);
    }

    private static bool IsSafe(List<int> line)
    {
        bool isSafe = false;
        bool isIncreasing = line[0] < line[1];
        for (int i = 1; i < line.Count; i++)
        {
            if (isIncreasing)
            {
                var difference = line[i] - line[i - 1];
                if (difference > 0 && difference < 4 && i == line.Count - 1)
                {
                    isSafe = true;
                }
                else if (difference < 1 || difference > 3)
                {
                    isSafe = false;
                    break;
                }
            }
            else
            {
                var difference = line[i - 1] - line[i];
                if (difference > 0 && difference < 4 && i == line.Count - 1)
                {
                    isSafe = true;
                }
                else if (difference < 1 || difference > 3)
                {
                    isSafe = false;
                    break;
                }
            }
        }
        return isSafe;
    }

    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/Day2/input.txt");
        var data = new List<List<int>>();
        var parsedLine = new List<int>();

        foreach (var line in lines)
        {
            var splitLine = line.Split(' ');
            foreach (var entry in splitLine)
            {
                parsedLine.Add(int.Parse(entry));
            }
            data.Add(parsedLine);
            parsedLine = new();
        }

        //PartOne(data);
        PartTwo(data);
    }
}