using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Puzzle1();
        Puzzle2();
    }

    private static void Puzzle2()
    {
        throw new NotImplementedException();
    }

    private static void Puzzle1()
    {
        var stacks = new List<Stack<string>>();


        var data = System.IO.File.ReadAllLines("input.txt").ToList();

        var moveStart = data.IndexOf(string.Empty);
        var actions = data.GetRange(moveStart + 1, data.Count - moveStart - 1);

        for(int i = 0; i < moveStart; i++)
        {
            stacks.Add(new Stack<string>());
        }

        for(int i = moveStart - 2; i >= 0 ; i--)
        {
            int index = data[i].IndexOf("[");

            while(index >= 0)
            {   
                index++;
                var stackNum = int.Parse(data[moveStart - 1][index].ToString());
                stacks[stackNum-1].Push(data[i][index].ToString());
                index = data[i].IndexOf("[", index);
            }
            
        }

        foreach(var action in actions)
        {
            int moves = int.Parse(Regex.Match(action, @"\d+").Value);
            
            int to = int.Parse(Regex.Match(action, @"\d+(?!\D*\d)").Value) - 1;
            int from = int.Parse(Regex.Match(action.Substring(7), @"\d+").Value) - 1;

            Console.WriteLine("Move: {0}", moves);
            Console.WriteLine("From: {0}", from);
            Console.WriteLine("To: {0}", to);

            for(int i = 0; i < moves; i++)
            {
                var item = stacks[from].Pop();
                stacks[to].Push(item);
            }
        }

        foreach(var itemStack in stacks)
        {
            Console.Write(itemStack.Peek());
        }
        Console.WriteLine();

    }
}