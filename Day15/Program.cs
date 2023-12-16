using System.Text;

internal class Program
{

    private static void CalculatedHashSum(string[] sequences)
    {
        int sum = 0;

        foreach (var sequence in sequences)
        {
            int currentValue = 0;
            byte[] asciiValues = Encoding.ASCII.GetBytes(sequence);
            foreach (var value in asciiValues)
            {
                currentValue += value;
                currentValue *= 17;
                currentValue %= 256;
            }
            sum += currentValue;
        }

        Console.WriteLine(sum);
    }

    private static int CalculateHash(string label)
    {
        int currentValue = 0;
        byte[] asciiValues = Encoding.ASCII.GetBytes(label);
        foreach (var value in asciiValues)
        {
            currentValue += value;
            currentValue *= 17;
            currentValue %= 256;
        }

        return currentValue;
    }

    private static void FindFocusPower(string[] sequence)
    {
        List<List<string>> boxes = new List<List<string>>(new List<string>[256]);

        foreach (var lens in sequence)
        {
            

            if (lens.Contains('='))
            {
                var box = CalculateHash(lens[..lens.IndexOf('=')]);

                if(boxes[box] == null)
                {
                    boxes[box] = [lens.Replace(lens[lens.IndexOf('=')], ' ')];
                    continue;
                }
                
                int index = boxes[box].FindIndex(l => l.StartsWith(lens[..lens.IndexOf('=')]));

                if (index != -1)
                {
                    boxes[box][index] = lens.Replace(lens[lens.IndexOf('=')], ' ');
                }
                else
                {
                    boxes[box].Add(lens.Replace(lens[lens.IndexOf('=')], ' '));
                }
            }
            else if (lens.Contains('-'))
            {
                var box = CalculateHash(lens[..lens.IndexOf('-')]);

                if(boxes[box] == null)
                    continue;

                int index = boxes[box].FindIndex(l => l.StartsWith(lens[..lens.IndexOf('-')]));

                if (index != -1)
                {
                    boxes[box].RemoveAt(index);
                }
            }
        }

        int power = 0;

        for(int i = 0; i < boxes.Count; i++)
        {
            if(boxes[i] == null)
                continue;
            
            for(int j = 0; j < boxes[i].Count; j++)
            {
                power += (i + 1) * (j + 1) * int.Parse(boxes[i][j][^1..]);
            }
        }

        Console.WriteLine(power);
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllText("input.txt");

        //CalculatedHashSum(input.Split(','));
        FindFocusPower(input.Split(','));
    }
}