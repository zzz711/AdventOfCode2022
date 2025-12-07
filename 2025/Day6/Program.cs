
List<string> data = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/2025/Day6/input.txt").ToList();

List<List<string>> actualData = [];

foreach (var line in data)
{
    line.Trim();
    actualData.Add([.. line.Split(" ")]);
}

#region part1

List<ProblemStruct> problems = [];
List<long> problemTotals = [];

int lineLength = actualData[0].Count;

for (int i = 0; i < lineLength; i++)
{
    ProblemStruct problemStruct = new();
    problemStruct.values = new();

    for (int j = 0; j < actualData[i].Count - 1; j++)
    {
        if (actualData[j][i].Equals(""))
            continue;
        else
            problemStruct.values.Add(long.Parse(actualData[j][i]));

    }

    problems.Add(problemStruct);
}

for (int i = 0; i < lineLength; i++)
{
    var problem = problems[i];
    problem.operation = data[^1][i].ToString(); ;
    problems[i] = problem;
}

foreach (var problem in problems)
{
    string action = problem.operation;

    if (problem.operation.Equals("*"))
        problemTotals.Add(problem.values.Aggregate((x, y) => x * y));
    else
        problemTotals.Add(problem.values.Sum());
}

Console.WriteLine(problemTotals.Sum());

#endregion

struct ProblemStruct
{
    public List<long> values;
    public string operation;
}