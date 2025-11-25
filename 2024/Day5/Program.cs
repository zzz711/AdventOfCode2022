internal class Program
{
    public static void PartOne(List<Tuple<int, int>> rules, List<List<int>> updates)
    {
        int middlePageNum = 0;
        int notValidMPN = 0;

        foreach (var update in updates)
        {
            bool valid = true;
            for (int i = 0; i < update.Count - 1; i++)
            {
                var checkList = new List<int>(update[i..]);
                checkList.RemoveAt(0);
                var ruleMatches = rules.Where(x => x.Item1 == update[i]).Select(x => x.Item2).ToList();
                var intersect = checkList.Intersect(ruleMatches).ToList();

                if (!intersect.SequenceEqual(checkList))
                {
                    valid = false;
                    break;
                }
                //Console.WriteLine(intersect.SequenceEqual(checkList));
            }
            if (valid)
            {
                middlePageNum += update[update.Count / 2];
            }
        }

        Console.WriteLine(middlePageNum);
        Console.WriteLine(notValidMPN);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/Day5/input.txt").ToList();

        int blankLineIndex = input.IndexOf(string.Empty);

        var rules = input.GetRange(0, blankLineIndex);
        var updates = input.GetRange(blankLineIndex + 1, input.Count - blankLineIndex - 1);

        var parsedRules = new List<Tuple<int, int>>();
        foreach (var rule in rules)
        {
            var spiltRule = rule.Split('|');
            parsedRules.Add(new Tuple<int, int>(int.Parse(spiltRule[0]), int.Parse(spiltRule[1])));
        }

        var intUps = new List<List<int>>();

        foreach (var up in updates)
        {
            var update = up.Split(',').ToList();
            List<int> upList = [];
            foreach (var up2 in update)
            {
                upList.Add(int.Parse(up2));
            }
            intUps.Add(upList);
        }

        PartOne(parsedRules, intUps);
    }
}