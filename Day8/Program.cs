internal class Program
{
    private static void Main(string[] args)
    {
        PuzzleOne();
        PuzzleTwo();
    }

    private static void PuzzleTwo()
    {
        var data = System.IO.File.ReadAllLines("input.txt");

        var bestTree = 0;

        for (int i = 1; i < data.Count() - 1; i++)
        {
            for (int j = 1; j < data[i].Length - 1; j++)
            {
                var up = new List<int>();
                var down = new List<int>();
                var left = new List<int>();
                var right = new List<int>();

                data[0..i].ToList().ForEach(c => up.Add(int.Parse(c[j].ToString())));
                data[(i + 1)..].ToList().ForEach(c => down.Add(int.Parse(c[j].ToString())));

                data[i][new Range(0,j)].ToList().ForEach(c => left.Add(int.Parse(c.ToString())));
                data[i][new Range(j+ 1, data[i].Length)].ToList().ForEach(c => right.Add(int.Parse(c.ToString())));

                var currentTree = int.Parse(data[i][j].ToString());

                left.Reverse();
                var leftIndex = left.FindIndex(x => (int)x >= currentTree);                
                leftIndex = leftIndex > -1 ? leftIndex + 1 : left.Count;

                up.Reverse();
                var upIndex = up.FindIndex(x => x >= currentTree);
                upIndex = upIndex > -1 ? upIndex + 1 : up.Count;
                
                var rightIndex = right.FindIndex(x => (int)x >= currentTree);
                rightIndex = rightIndex > -1 ? rightIndex + 1 : right.Count;

                var downIndex = down.FindIndex(x => x >= currentTree);
                downIndex = downIndex > -1 ? downIndex + 1 : down.Count;

                var score = leftIndex * upIndex * rightIndex * downIndex;                    

                if(score > bestTree)
                    bestTree = score;
                
            }
        }

        Console.WriteLine(bestTree);
    }

    private static void PuzzleOne()
    {
        var data = System.IO.File.ReadAllLines("input.txt");

        var totalTrees = (data.Count() * 2) + (data[0].Length * 2) - 4;

        for (int i = 1; i < data.Count() - 1; i++)
        {
            for (int j = 1; j < data[i].Length - 1; j++)
            {
                var up = new List<int>();
                var down = new List<int>();
                var left = new List<int>();
                var right = new List<int>();

                data[0..i].ToList().ForEach(c => up.Add(int.Parse(c[j].ToString())));
                data[(i + 1)..].ToList().ForEach(c => down.Add(int.Parse(c[j].ToString())));

                data[i][..j].ToList().ForEach(c => left.Add(int.Parse(c.ToString())));
                data[i][(j + 1)..].ToList().ForEach(c => right.Add(int.Parse(c.ToString())));

                var currentTree = int.Parse(data[i][j].ToString());

                //needs to be visiable from the outside
                if (!left.Any(i => (int)i >= currentTree) || !(up.Any(i => i >= currentTree))
                 || !(right.Any(i => (int)i >= currentTree)) || !(down.Any(i => i >= currentTree)))
                {
                    totalTrees++;
                }
            }
        }

        Console.WriteLine(totalTrees);
    }
}