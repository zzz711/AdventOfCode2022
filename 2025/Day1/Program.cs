var lines = File.ReadAllLines("/home/zzz711/Documents/AdventOfCode/2025/Day1/input.txt");

List<Tuple<string, int>> data = new();

foreach (var line in lines)
{
    //Console.WriteLine(line);
    data.Add(new Tuple<string, int>(line[0].ToString(), int.Parse(line[1..])));
}

#region part 1

int currNum = 50;
List<int> points = [];

foreach (Tuple<string, int> rotation in data)
{
    int nextNum = rotation.Item2;

    if (Math.Abs(nextNum) > 100)
    {
        double currAbs = Math.Abs(nextNum);
        nextNum = (int)(currAbs - (Math.Round(currAbs / 100, 0, MidpointRounding.ToZero) * 100));
    }

    if (rotation.Item1.Equals("L"))
    {
        currNum -= nextNum;

        if (currNum < 0)
            currNum += 100;
    }
    else
    {
        currNum += nextNum;
        if (currNum > 100)
            currNum -= 100;
    }

    //Console.WriteLine(currNum);
    points.Add(currNum);
}

//Console.WriteLine(points.Count( c => c == 100 || c == 0));

#endregion

#region part 2

currNum = 50;
int counter = 0;

foreach (Tuple<string, int> rotation in data)
{
    int nextNum = rotation.Item2;

    if (Math.Abs(nextNum) > 100)
    {
        double currAbs = Math.Abs(nextNum);
        int rotations = (int)Math.Round(currAbs / 100, 0, MidpointRounding.ToZero);
        counter += rotations;
        nextNum = (int)(currAbs -  rotations * 100);        
    }

    if (rotation.Item1.Equals("L"))
    {
        if (currNum == 0)
        {
            currNum -= nextNum;
            continue;    
        }

        currNum -= nextNum;
    

        if (currNum < 0)
        {
            currNum += 100;
            counter++;
        }
        else if (currNum == 0)
            counter++;

    }
    else
    {
        if (currNum == 100)
        {
            currNum += nextNum;
            continue;
        }

        currNum += nextNum;
        if (currNum > 100)
        {
            counter++;
            currNum -= 100;
        }
        else if (currNum == 100)
            counter++;
    }
}

//current answer too low. works for sample set
Console.WriteLine(counter);

#endregion