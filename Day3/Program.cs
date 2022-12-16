internal class Program
{
    private static void Main(string[] args)
    {
        //ProblemOne();
        ProblemTwo();
    }

    static void ProblemOne()
    {
        int score = 0;

        var matches = new List<char>();

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {
            score += line
            .Take(line.Length / 2)
            .Intersect(line.TakeLast(line.Length / 2))
            .Sum(c => c <= 'Z' ? (c -'A' + 27) : (c - 'a' + 1) );
        }

        Console.WriteLine(score);
    }

    static void ProblemTwo()
    {
        var data = System.IO.File.ReadAllLines("input.txt");
        int score = 0;

        for(int i = 0; i < data.Count(); i += 3)
        {
            var group = data[i .. (i + 3)];

            var common = group[0].ToList().FindAll(x => group[1].Contains(x) && group[2].Contains(x)).Distinct();

            score += common.Sum(c => c <= 'Z' ? (c -'A' + 27) : (c - 'a' + 1) );
        }

        Console.WriteLine(score);
    }
}