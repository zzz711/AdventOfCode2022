internal class Program
{
    List<string> data = [];

    private int UpDownCount(string nextLine, int startY)
    {
        int count = 0;

        if (nextLine[startY].Equals('@'))
            count++;

        if (startY != 0)
        {
            if (nextLine[startY - 1].Equals('@'))
                count++;
        }

        if (startY != nextLine.Length - 1)
        {
            if (nextLine[startY + 1].Equals('@'))
                count++;
        }

        return count;
    }

    private int LeftRightCount(string currentLine, int y)
    {
        int count = 0;

        if (y != 0 && y < currentLine.Length - 1)
        {
            if (currentLine[y - 1].Equals('@'))
                count++;
            if (currentLine[y + 1].Equals('@'))
                count++;
        }
        else if (y == 0)
        {
            if (currentLine[y + 1].Equals('@'))
                count++;
        }
        else if (y == currentLine.Length - 1)
        {
            if (currentLine[y - 1].Equals('@'))
                count++;
        }

        return count;
    }

    private void PartOne()
    {
        int rollCount = 0;
        int currCount = 0;

        for (int c = 0; c < data[0].Length; c++)
        {

            if (data[0][c].Equals('.'))
                continue;

            currCount = UpDownCount(data[1], c);
            currCount += LeftRightCount(data[0], c);

            if (currCount < 4)
                rollCount++;
        }

        for (int i = 1; i < data.Count - 1; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                if (data[i][j].Equals('.'))
                    continue;

                currCount = UpDownCount(data[i-1], j);
                currCount += UpDownCount(data[i+1], j);
                currCount += LeftRightCount(data[i], j);

                if (currCount < 4)
                    rollCount++;
            }
        }

        for (int c = 0; c < data[^1].Length; c++)
        {

            if (data[^1][c].Equals('.'))
                continue;

            currCount = UpDownCount(data[^2], c);
            currCount += LeftRightCount(data[^1], c);

            if (currCount < 4)
                rollCount++;
        }

        Console.WriteLine(rollCount);
    }

    private static void Main(string[] args)
    {
        Program program = new();
        program.data = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/2025/Day4/input.txt").ToList();
        program.PartOne();
    }
}