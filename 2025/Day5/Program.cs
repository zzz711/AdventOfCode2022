List<string> data = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/2025/Day5/input.txt").ToList();

var spiltLine = data.FindIndex(x => x.Equals(""));

var ranges = data[..spiltLine];
var ingredients = data[++spiltLine..];


List<Tuple<long, long>> rangeSpilt = [];

foreach (var range in ranges)
{
    var split = range.Split('-');
    rangeSpilt.Add(new Tuple<long, long>(long.Parse(split[0]), long.Parse(split[1])));
}

#region part1

long freshCount = 0;

foreach (var ingredient in ingredients)
{
    foreach (var range in rangeSpilt)
    {
        long intIngredient = long.Parse(ingredient);

        if (range.Item1 <= intIngredient  && intIngredient <= range.Item2 )
        {
            freshCount++;
            break;
        }
    }
}

Console.WriteLine(freshCount);

#endregion

#region partTwo


rangeSpilt.Sort();
freshCount = 0;
long currMax = 0;

foreach (var entry in rangeSpilt)
{
    if (entry.Item2 >= currMax)
    {
        freshCount += entry.Item2 - Math.Max(entry.Item1, currMax) + 1;
        currMax = entry.Item2 + 1;
    }
}

Console.WriteLine(freshCount);

#endregion