internal class Program
{
    private static void PartOne(List<double> stones, int runCounter)
    {
        
        for (int i = 0; i < runCounter; i++)
        {
            List<Tuple<int,double>> updates = [];

            for (int j = 0; j < stones.Count; j++)
            {
                if(stones[j] == 0)
                {
                    stones[j] = 1;
                }
                else if(stones[j].ToString().Length % 2 == 0)
                {
                    var half = stones[j].ToString().Length / 2;
                    var tmp = stones[j];
                    stones[j] = double.Parse(tmp.ToString()[..half]);
                    Tuple<int,double> tuple = new(j+1, double.Parse(tmp.ToString()[half..]));
                    updates.Add(tuple);
                }
                else
                {
                    stones[j] *= 2024;
                }
            }

            foreach(Tuple<int,double> tuple in updates)
            {
                stones.Insert(tuple.Item1, tuple.Item2);
            }
        }

        Console.WriteLine(stones.Count);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllText("/home/zzz711/Documents/AdventOfCode/Day11/input.txt").Split(' ');
        List<double> rocks = [];
        foreach (var stone in input)
        {
            rocks.Add(double.Parse(stone.Trim()));
        }
       // PartOne(rocks, 25);
        PartOne(rocks, 75);
    }
}