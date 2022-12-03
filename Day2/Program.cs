public class Program
{
    private static void Main(string[] args)
    {
        Puzzle.Solve1();
        Puzzle.Solve2();
    }
}

public static class Puzzle
{
    public static void Solve1()
    {
        var dictionary = new Dictionary<string, uint>();

        dictionary["A"] = 1;
        dictionary["B"] = 2;
        dictionary["C"] = 3;
        dictionary["X"] = 1;
        dictionary["Y"] = 2;
        dictionary["Z"] = 3;

        uint score = 0;

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {
            var inputs = line.Split(' ');
            var opponent = inputs[0];
            var user = inputs[1];

            score += dictionary[user];

            if (opponent == "A")
            {
                switch (user)
                {
                    case "X":
                        score += 3;
                        break;
                    case "Y":
                        score += 6;
                        break;
                }
            }
            else if (opponent == "B")
            {
                switch (user)
                {
                    case "Y":
                        score += 3;
                        break;
                    case "Z":
                        score += 6;
                        break;
                }
            }
            else if (opponent == "C")
            {
                switch (user)
                {
                    case "Z":
                        score += 3;
                        break;
                    case "X":
                        score += 6;
                        break;
                }
            }
        }

        Console.WriteLine(score);
    }

    public static void Solve2()
    {
        var dictionary = new Dictionary<string, uint>();

        dictionary["A"] = 1;
        dictionary["B"] = 2;
        dictionary["C"] = 3;

        uint score = 0;

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {
            var inputs = line.Split(' ');
            var opponent = inputs[0];
            var user = inputs[1];

            if (user == "X")
            {
                switch (opponent)
                {
                    case "A":
                        score += dictionary["C"];
                        break;
                    case "B":
                        score += dictionary["A"];
                        break;

                    case "C":
                        score += dictionary["B"];
                        break;
                }
            }
            else if (user == "Y")
            {
                //tie
                score += dictionary[opponent] + 3;
            }
            else if (user == "Z")
            {
                score += 6;

                //win
                switch (opponent)
                {
                    case "A":
                        score += dictionary["B"];
                        break;
                    case "B":
                        score += dictionary["C"];
                        break;

                    case "C":
                        score += dictionary["A"];
                        break;
                }
            }
        }

        Console.WriteLine(score);
    }
}