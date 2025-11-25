using System.Text.RegularExpressions;

internal class Program
{
    private static void PartOne(string text)
    {
        var pattern = @"mul\(\d+,\d+\)";
        MatchCollection matches = Regex.Matches(text, pattern);
        int score = 0;

        foreach (Match match in matches)
        {
            score += GetValue(match.Value);
        }

        Console.WriteLine(score);

    }

    private static void PartTwo(string text)
    {
        bool isDo = true;
        var pattern = @"mul\(\d+,\d+\)";
        MatchCollection matches = Regex.Matches(text, pattern);
        int score = 0;

        score += GetValue(matches[0].Value);

        for (int i = 1; i < matches.Count; i++)
        {
            int matchIndex = text.IndexOf(matches[i].Value);
            var strBtw = text.Substring(text.IndexOf(matches[i-1].Value), matchIndex - text.IndexOf(matches[i-1].Value));

            if(strBtw.Contains("don't"))
                isDo = false;
            else if (!strBtw.Contains("don't") && strBtw.Contains("do"))
                isDo = true;

            if (isDo)
            {
                score += GetValue(matches[i].Value);
            }
        }

        Console.WriteLine(score);
    }

    private static int GetValue(string text)
    {
        var commaPos = text.IndexOf(',');
        var endParen = text.IndexOf(')');
        var startParen = text.IndexOf('(');

        int firstNum = int.Parse(text.Substring(startParen + 1, commaPos - startParen - 1));
        int secondNum = int.Parse(text.Substring(commaPos + 1, endParen - commaPos - 1));

        return firstNum * secondNum;
    }

    private static void Main(string[] args)
    {
        var data = File.ReadAllText("input.txt");
        //PartOne(data);
        PartTwo(data);
    }
}