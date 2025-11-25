internal class Program
{
    private static void PartOne(List<string> input)
    {
        double result = 0;
        foreach (string line in input)
        {
            double target = double.Parse(line[..line.IndexOf(':')]);
            var nums = line.Substring(line.IndexOf(':')+2).Split(' ');
            for(int i = 0; i < nums.Length -1; i++)
            {
                double num1 = double.Parse(nums[i]);
                double num2 = double.Parse(nums[i+1]);
                double currentNum = 0;

                currentNum = num1 + num2;
                if
            }
        }
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        List<double> results = [];
        List<List<double>> numbers = [];

        foreach (var line in input)
        {
            results.Add(double.Parse(line.Substring(0, line.IndexOf(':'))));
            List<double> numbers2 = [];
            var nums = line.Substring(line.IndexOf(':')+2).Split(' ');
            foreach (var number in nums)
            {
                numbers2.Add(double.Parse(number));
            }
        }
    }
}