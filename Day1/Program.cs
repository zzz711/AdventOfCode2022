using System.Linq;

var inputData = new List<uint>();
var elfDictionary = new Dictionary<int, uint>();

int elfNumber = 1;
uint sum = 0;

foreach(var line in System.IO.File.ReadLines("input.txt"))
{
    if(line == string.Empty || line == null)
    {
        elfDictionary[elfNumber] = sum;
        ++elfNumber;
        sum = 0;
    }
    else
    {
        sum += uint.Parse(line);
    }
}

var entry = elfDictionary.OrderBy(key => key.Value);

sum = 0;

Console.WriteLine("Elf {0} Cal {1}", entry.Last().Key, entry.Last().Value);

for(int i = entry.Count() - 1; i > entry.Count() - 4; --i)
{
    sum += entry.ElementAt(i).Value;
}

Console.WriteLine(sum);