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
        bool isIncreasing = false;
        bool removed = false;
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
                        if (!removed)
                        {
                            if (i != line.Count - 1)
                            {
                                difference = line[i + 1] - line[i - 1];
                                if (difference > 0 && difference < 4)
                                {
                                    line.RemoveAt(i);
                                    removed = true;
                                }
                            }
                        }
                        else
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
                        if (!removed)
                        {
                            if (i != line.Count - 1)
                            {
                                difference = line[i - 1] - line[i + 1];
                                if (difference > 0 && difference < 4)
                                {
                                    line.RemoveAt(i);
                                    removed = true;
                                }
                            }
                        }
                        else
                            break;
                    }
                }
            }
            removed = false;
        }
        Console.WriteLine(safe);
    }

    private static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
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