
using System.Text.RegularExpressions;

internal partial class Program
{

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        int gameSum = 0;

        foreach (var line in input)
        {
            // gameSum += CheckGame(line);
            gameSum += FewestCubes(line);

        }

        Console.WriteLine(gameSum);
    }

    private static int FewestCubes(string line)
    {
        int maxBlue = 0;
        int maxGreen = 0;
        int maxRed = 0;

        line = line.Replace(" ", "");
        int gameNumPos = line.IndexOf(":") - line.IndexOf("e");
        var gameNum = int.Parse(line.Substring(line.IndexOf("e") + 1, gameNumPos - 1));

        var sets = line.Substring(line.IndexOf(":") + 1).Split(";");

        foreach (var set in sets)
        {
            var cubes = set.Split(",");
            foreach (var cube in cubes)
            {
                int result = int.Parse(MyRegex().Replace(cube, ""));
                var color = cube.Substring(cube.IndexOf(result.ToString()) + result.ToString().Length);

                if (color.Equals("blue"))
                {
                    if (result <= maxBlue)
                        continue;
                    else
                        maxBlue = result;
                }
                else if (color.Equals("red"))
                {
                    if (result <= maxRed)
                        continue;
                    else maxRed = result;
                }
                else if (color.Equals("green"))
                {
                    if (result <= maxGreen)
                        continue;
                    else maxGreen = result;
                }
            }
        }

        return maxBlue * maxGreen * maxRed;
    }

    private static int CheckGame(string line)
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        line = line.Replace(" ", "");
        int gameNumPos = line.IndexOf(":") - line.IndexOf("e");
        var gameNum = int.Parse(line.Substring(line.IndexOf("e") + 1, gameNumPos - 1));

        var sets = line.Substring(line.IndexOf(":") + 1).Split(";");

        foreach (var set in sets)
        {
            var cubes = set.Split(",");
            foreach (var cube in cubes)
            {
                int result = int.Parse(MyRegex().Replace(cube, ""));
                var color = cube.Substring(cube.IndexOf(result.ToString()) + result.ToString().Length);

                if (color.Equals("blue"))
                {
                    if (result <= maxBlue)
                        continue;
                    else return 0;
                }
                else if (color.Equals("red"))
                {
                    if (result <= maxRed)
                        continue;
                    else return 0;
                }
                else if (color.Equals("green"))
                {
                    if (result <= maxGreen)
                        continue;
                    else return 0;
                }
            }
        }

        return gameNum;
    }

    [GeneratedRegex("[^\\d]")]
    private static partial Regex MyRegex();
}