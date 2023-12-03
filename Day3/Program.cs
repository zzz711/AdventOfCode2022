using System.Text.RegularExpressions;

internal partial class Program
{

    private static readonly List<string> specialChars = new() { "!", "@", "#", "$", "%", "&", "*", "-", "=", "+", @"/" };

    private static bool CheckAbove(string[] input, int curLine, string match)
    {
        if (curLine == 0)
            return false;

        bool isPart = false;
        string line = input[curLine - 1];
        string curLineStr = input[curLine];
        string subLine = string.Empty;

        if (curLineStr.IndexOf(match) == 0)
            subLine = line.Substring(curLineStr.IndexOf(match), match.Length + 2);
        else if (curLineStr.IndexOf(match) + match.Length == curLineStr.Length)
            subLine = line.Substring(curLineStr.IndexOf(match), match.Length);
        else
            subLine = line.Substring(curLineStr.IndexOf(match) - 1, match.Length + 2);

        if (specialChars.Any(c => subLine.Contains(c)))
            return true;

        return isPart;
    }

    private static bool CheckFront(string[] input, int curLine, string match)
    {
        if (input[curLine].IndexOf(match) == 0)
            return false;



        bool isPart = false;
        string line = input[curLine];
        int endPos = line.IndexOf(line.Substring(line.IndexOf(match), match.Length)) - 1;

        if (specialChars.Any(c => c.Contains(line[endPos])))
            return true;

        return isPart;
    }

    private static bool CheckBack(string[] input, int curLine, string match)
    {
        if (input[curLine].IndexOf(match) + match.Length >= input[curLine].Length)
            return false;

        bool isPart = false;
        string line = input[curLine];
        int endPos = line.IndexOf(line.Substring(line.IndexOf(match), match.Length)) + match.Length;

        if (specialChars.Any(c => c.Contains(line[endPos])))
            return true;

        return isPart;
    }

    private static bool CheckBelow(string[] input, int curLine, string match)
    {
        if (curLine == input.Length - 1)
            return false;

        string line = input[curLine + 1];
        string curLineStr = input[curLine];
        string subLine = string.Empty;

        if (curLineStr.IndexOf(match) == 0 || int.Parse(match) < 10)
            subLine = line.Substring(curLineStr.IndexOf(match), match.Length + 2);
        else if (curLineStr.IndexOf(match) + match.Length == curLineStr.Length)
            subLine = line.Substring(curLineStr.IndexOf(match), match.Length);
        else
            subLine = line.Substring(curLineStr.IndexOf(match) - 1, match.Length + 2);

        if (specialChars.Any(c => subLine.Contains(c)))
            return true;

        return false;
    }

    private static int PartSum(string[] input)
    {
        int sum = 0;

        string line = input[0];
        List<Match> matches = new List<Match>();

        for (int i = 0; i < input.Length; i++)
        {
            line = input[i];
            matches = MyRegex().Matches(line).ToList();
            //Console.WriteLine(i);

            foreach (Match match in matches)
            {
                if (CheckFront(input, i, match.Value))
                {
                    Console.WriteLine(match.Value);
                    sum += int.Parse(match.Value);
                    line = line.Substring(line.IndexOf(match.Value) - 1);

                    continue;
                }
                else if (CheckBack(input, i, match.Value))
                {
                    Console.WriteLine(match.Value);
                    sum += int.Parse(match.Value);

                    if (line.IndexOf(match.Value) > 0)
                        line = line.Substring(line.IndexOf(match.Value) - 1);

                    continue;
                }
                else if (CheckBelow(input, i, match.Value))
                {
                    Console.WriteLine(match.Value);
                    sum += int.Parse(match.Value);

                    if (line.IndexOf(match.Value) > 0)
                        line = line.Substring(line.IndexOf(match.Value) - 1);

                    continue;
                }
                else if (CheckAbove(input, i, match.Value))
                {
                    Console.WriteLine(match.Value);
                    sum += int.Parse(match.Value);

                    if (line.IndexOf(match.Value) > 0)
                        line = line.Substring(line.IndexOf(match.Value) - 1);

                    continue;
                }
                Console.WriteLine();
            }
        }

        return sum;
    }

    private static void Main(string[] args)
    {
        string[] input = File.ReadAllLines("input.txt");
        int sum = PartSum(input);
        Console.WriteLine(sum);
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();
}