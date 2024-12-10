using System.Text;

internal class Program
{
    private static string BuildProcess(string input)
    {
        string process = string.Empty;
        int counter = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var times = int.Parse(input[i].ToString());            
            for (int j = 0; j != times; j++)
            {
                if(i % 2 == 0)
                {
                    process += counter.ToString();
                }
                else
                {
                    process += ".";
                }
            }

            if( i % 2 == 0)
            {
                counter++;
            }
        }

        return process;
    }

    private static void PartOne(string input)
    {
        var startingStage = new StringBuilder(BuildProcess(input));
        double checksum = 0;

        for(int i = startingStage.Length - 1; i > 0; i--)
        {
            string currentStage = startingStage.ToString();
            int empty = currentStage.IndexOf('.');
            startingStage[empty] = startingStage[i];
            startingStage[i] = '.';
        } 

        startingStage = startingStage.Remove(startingStage.ToString().IndexOf('.'), 1);
        string finalString = startingStage.ToString()[..startingStage.ToString().IndexOf('.')];
        for(int i = 0; i < finalString.Length; i++)
        {
            checksum += int.Parse(finalString[i].ToString()) * i;
        }

        Console.WriteLine(checksum);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllText("/home/zzz711/Documents/AdventOfCode/Day9/input.txt");
        PartOne(input);
    }
}