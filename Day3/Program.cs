internal class Program
{
    private static void Main(string[] args)
    {
        ProblemOne();
    }

    static void ProblemOne()
    {
        int score = 0;

        var matches = new List<char>();

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {



            var partOne = line.Substring(0, line.Length / 2);
            var partTwo = line.Substring(line.Length / 2);

            Console.WriteLine(partOne);
            Console.WriteLine(partTwo);

            var all = partTwo.Where(c => partOne.Any(a => a == c));

            foreach (var match in all)
            {
                /*
                if (!matches.Contains(match))
                {
                    matches.Add(match);
                }
                else
                    continue;*/

                char convertedMatch;

                Console.Write(match + " ");

                if (char.IsUpper(match))
                {
                    convertedMatch = char.ToLower(match);
                    score += (convertedMatch - 96);

                    Console.WriteLine(((int)convertedMatch) - 96);
                }
                else
                {
                    convertedMatch = char.ToUpper(match);
                    score += (convertedMatch - 64);

                    Console.WriteLine(((int)convertedMatch) - 64);
                }
            }

            matches.Clear();
        }

        Console.WriteLine(score);
    }
}