internal class Program
{
    private static Dictionary<string, (string, string)> ParseInput(string[] nodes)
    {
        string key = string.Empty;
        Dictionary<string, (string, string)> nodeDictionary = [];

        foreach(var node in nodes)
        {
            var split = node.Split("=");
            key = split[0].ToString().Trim();
            var element = split[1].Split(",");
            var instruction = (element[0].Replace("(", "").ToString().Trim(), 
            element[1].Replace(")", "").ToString().Trim());
            nodeDictionary.Add(key, instruction);
        }

        return nodeDictionary;
    }

    private static int StepCounter(string steps, Dictionary<string, (string, string)> nodes)
    {
        int count = 0;

        var keyList = nodes.Keys.ToList();
        var valueList = nodes.Values.ToList();
        int index = keyList.IndexOf("AAA");        
        var stepArr = steps.ToList();
        string key = keyList[index];
        
        while(!keyList[index].Equals("ZZZ"))
        {
            if(stepArr[0] == 'R')
                key = valueList[index].Item2;
            else if(stepArr[0] == 'L')
                key = valueList[index].Item1;

            index = keyList.IndexOf(key);
            char step = stepArr[0];
            stepArr = stepArr[1..];
            stepArr.Add(step);
            count++;
        }

        return count;
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        var steps = input[0];
        Dictionary<string, (string, string)> nodes = ParseInput(input[2..]);
        int stepCount = StepCounter(steps, nodes);
        Console.WriteLine(stepCount);
    }


}