
using System.Text.RegularExpressions;
using NCalc;

public class Monkey
{
    public List<int> items = new List<int>();

    public object operationNum = new Object();
    private int inspected;

    public int Inspected { get => inspected; set => inspected = value; }

    public int test = 0;

    public string operation = string.Empty;

    public uint worryLevel = 0;

    public int trueThrow = 0;
    public int falseThrow = 0;
}

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        PuzzleOne();
    }

    private static void PuzzleOne()
    {
        List<Monkey> monkeys = new List<Monkey>();

        var input = System.IO.File.ReadAllLines("input.txt");

        var monkeyLines = input.Where(m => m.Contains("Monkey"));
        var startingItems = input.Where(m => m.Contains("items")).ToList();
        var operation = input.Where(m => m.Contains("Operation")).ToList();
        var test = input.Where(m => m.Contains("Test")).ToList();
        var ifTrue = input.Where(m => m.Contains("If true")).ToList();
        var ifFalse = input.Where(m => m.Contains("If false")).ToList();

        for(int i = 0; i < monkeyLines.Count(); i++)
        {
            monkeys.Add(new Monkey());
            foreach(var item in startingItems[i].Substring(startingItems[i].IndexOf(':')+2).Split(','))
            {
                monkeys[i].items.Add(int.Parse(item));
            }

            monkeys[i].operation = operation[i].Substring(operation[i].IndexOf("d") + 2, 1);
            int opVal = 0;            

            if(int.TryParse(Regex.Match(operation[i], @"\d+").Value, out opVal))
            {
                monkeys[i].operationNum = opVal;
            }
            else
            {
                monkeys[i].operationNum = operation[i].Substring(operation[i].IndexOf("old")+6);
            }

            monkeys[i].test = int.Parse(Regex.Match(test[i], @"\d+").Value);
            monkeys[i].trueThrow = int.Parse(Regex.Match(ifTrue[i], @"\d+").Value);
            monkeys[i].falseThrow = int.Parse(Regex.Match(ifFalse[i], @"\d+").Value);
        }

        for(int x = 0; x < 20; x++)
        {
            foreach(var monkey in monkeys)
            {
                foreach(var item in monkey.items)
                {   
                    int newItem = 0;
                    
                    //item = item monkey.operation monkey.operationNum
                    if(monkey.operationNum.GetType() == typeof(string))
                    {
                        //item = item monkey.operation item;
                        Expression expression = new Expression(item.ToString() + monkey.operation + item.ToString());
                        newItem = (int) expression.Evaluate() / 3;
                    }
                    else
                    {
                        //item = item monkey.operation monkey.operationNum;
                        Expression expression = new Expression(item.ToString() + monkey.operation + monkey.operationNum.ToString());
                        newItem = (int) expression.Evaluate() / 3;
                    }

                    if(newItem % monkey.test == 0)
                    {
                        monkeys[monkey.trueThrow].items.Add(newItem);
                    }
                    else
                    {
                        monkeys[monkey.falseThrow].items.Add(newItem);
                    }

                    monkey.Inspected++;
                }
                monkey.items.Clear();
            }
        }


        monkeys = monkeys.OrderByDescending(m => m.Inspected).ToList();
        Console.WriteLine(monkeys[0].Inspected * monkeys[1].Inspected);
    }

}