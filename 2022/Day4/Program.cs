internal class Program
{
    private static void Main(string[] args)
    {
        PuzzleOne();
        PuzzleTwo();
    }

    static void PuzzleOne()
    {
        int fullCoverage = 0;

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {
            var groupOne = line.Split(',')[0];
            var groupTwo = line.Split(',')[1];

            var groupOneStart = int.Parse(groupOne.Split('-')[0]);
            var groupOneEnd = int.Parse(groupOne.Split('-')[1]);

            var groupTwoStart = int.Parse(groupTwo.Split('-')[0]);
            var groupTwoEnd = int.Parse(groupTwo.Split('-')[1]);

            var groupOneRange = Enumerable.Range(groupOneStart, groupOneEnd - groupOneStart + 1);
            var groupTwoRange = Enumerable.Range(groupTwoStart, groupTwoEnd - groupTwoStart + 1);            

            if(groupOneRange.Contains(groupTwoStart) && groupOneRange.Contains(groupTwoEnd))
                fullCoverage++;
            else if(groupTwoRange.Contains(groupOneStart) && groupTwoRange.Contains(groupOneEnd))
                fullCoverage++;
        }

        Console.WriteLine(fullCoverage);
    }

    static void PuzzleTwo()
    {
        int overlap = 0;

        foreach (var line in System.IO.File.ReadLines("input.txt"))
        {
            var groupOne = line.Split(',')[0];
            var groupTwo = line.Split(',')[1];

            var groupOneStart = int.Parse(groupOne.Split('-')[0]);
            var groupOneEnd = int.Parse(groupOne.Split('-')[1]);

            var groupTwoStart = int.Parse(groupTwo.Split('-')[0]);
            var groupTwoEnd = int.Parse(groupTwo.Split('-')[1]);

            var groupOneRange = Enumerable.Range(groupOneStart, groupOneEnd - groupOneStart + 1);
            var groupTwoRange = Enumerable.Range(groupTwoStart, groupTwoEnd - groupTwoStart + 1);

            if(groupOneRange.Contains(groupTwoStart))
                overlap++;
            else if(groupTwoRange.Contains(groupOneStart))
                overlap++;
        }

        Console.WriteLine(overlap);

    }
}