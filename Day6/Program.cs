internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");//

        PuzzleOne();
        PuzzleTwo();
    }

    
    private static void PuzzleTwo()
    {
        var data = System.IO.File.ReadAllText("input.txt");
        
        int marker = 14;

        //TODO: figure out how to use linq to create substring
        for(int i = 0; i < data.Length; i++)
        {
            if(data.Substring(i, 14).Distinct().Count() == 14)
            {
                marker += i;
                break;
            }
        }

        Console.WriteLine(marker);
    }

    static void PuzzleOne()
    {
        var data = System.IO.File.ReadAllText("input.txt");

        Console.WriteLine(data.Substring(0, 4).Distinct().Count());

        int marker = 4;

        for(int i = 0; i < data.Length; i++)
        {
            if(data.Substring(i, 4).Distinct().Count() == 4)
            {
                marker += i;
                break;
            }
        }

        Console.WriteLine(marker);
    }
}