List<string> data = [.. File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/2025/Day3/input.txt")];

#region part1

double jolt = 0;
List<double> jolts = [];

foreach (string currentJolt in data)
{    
    for (int i = 0; i < currentJolt.Length -1; i++)
    {
        if (char.GetNumericValue(currentJolt[i]) * 10 < jolt)
            continue;

        jolt = char.GetNumericValue(currentJolt[i]) * 10;
        double joltI = jolt;

        for (int j = i + 1; j < currentJolt.Length; j++)
        {
            double batt2 = char.GetNumericValue(currentJolt[j]);
            double newJolt = joltI + batt2;

            if (newJolt > jolt)
                jolt = newJolt;
            
        }        
    }

    jolts.Add(jolt);
    jolt = 0;
}

Console.WriteLine(jolts.Sum());

#endregion

#region part2

jolts.Clear();

foreach (string currentJolt in data)
{
    //sort to find 
    char[] joltArray = currentJolt.ToCharArray();
    Array.Sort(joltArray);
    joltArray = joltArray.Reverse().ToArray();

    string sortedJolt = new(joltArray);
    sortedJolt = sortedJolt.Substring(0, 12);
    
    
    char[] joltArr = new char[currentJolt.Length];

//reorder
    foreach (char volt in sortedJolt)
    {
        int index = currentJolt.IndexOf(volt);
        joltArr[index] = volt; //right track. need to better handle duplicates
    }

    
    List<char> joltList = joltArr.ToList(); 
    joltList = joltList.Where(x => !string.IsNullOrEmpty(x.ToString())).ToList();
    jolts.Add(double.Parse(string.Concat(joltList)));

    Console.WriteLine(double.Parse(string.Concat(joltList)));
}

Console.WriteLine(jolts.Sum());

#endregion