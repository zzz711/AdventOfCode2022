using System.Text.RegularExpressions;

var data = File.ReadAllText("/home/zzz711/Documents/AdventOfCode/2025/Day2/input.txt");

List<string> idRanges = [.. data.Split(',')];

#region part1

List<long> invalidIds = [];

foreach (string range in idRanges)
{
    long start = long.Parse(range.Split('-')[0]);
    long end = long.Parse(range.Split('-')[1]);

    for (long i = start; i <= end; i++)
    {
        string idStr = i.ToString();

        if (idStr.Length % 2 != 0)
            continue;    

        if(idStr[..(idStr.Length / 2)].Equals(idStr[(idStr.Length/2)..]))
            invalidIds.Add(i);
    }
}

//Console.WriteLine(invalidIds.Sum());

#endregion

#region part2

invalidIds.Clear();

string pattern = @"^(\d+)\1+$";
Regex regex = new(pattern);

foreach (string range in idRanges)
{
    long start = long.Parse(range.Split('-')[0]);
    long end = long.Parse(range.Split('-')[1]);

    for (long i = start; i <= end; i++)
    {
        string idStr = i.ToString();

        if( regex.Match(idStr).Success)
            invalidIds.Add(i);
    }    
}

Console.WriteLine(invalidIds.Sum());

#endregion