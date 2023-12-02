using System.Net.NetworkInformation;

internal class Program
{
    static Dictionary<string, string> map = new Dictionary<string, string>();

    private static string FindDigits(string line)
    {
        var digits = string.Empty;

        foreach (var letter in line)
        {
            if (char.IsDigit(letter))
            {
                digits += letter;
                break;
            }
        }

        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(line[i]))
            {
                digits += line[i];
                break;
            }
        }

        //Console.WriteLine(digits);
        return digits;
    }

    private static string FindDigitsOrWord(string line)
    {
        var digits = string.Empty;
        
        void Work()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    digits += line[i];
                    return;
                }
                var subStr = string.Empty;

                foreach (var item in map)
                {
                    if ((item.Key.Length + i) < line.Length && line.Substring(i, item.Key.Length).Equals(item.Key))
                    {
                        digits += item.Value;
                        i += item.Key.Length;
                        return;
                    }
                }
            }


        }

        Work();


        void WorkBack()
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                int pos = i;

                if (char.IsDigit(line[pos]))
                {
                    digits += line[pos];
                    return;
                }

                foreach (var item in map)
                {
                    var startPos = pos - item.Key.Length;
                    if (startPos < 0)
                        continue;

                    var subStr = line.Substring(startPos + 1, item.Key.Length);
                    if (startPos > 0 && subStr.Equals(item.Key))
                    {
                        digits += item.Value;
                        //pos += item.Key.Length;
                        return;
                    }
                }
            }
        }

        WorkBack();


        Console.WriteLine(digits);
        return digits;
    }

    private static void Main(string[] args)
    {
        map.Add("one", "1");
        map.Add("two", "2");
        map.Add("three", "3");
        map.Add("four", "4");
        map.Add("five", "5");
        map.Add("six", "6");
        map.Add("seven", "7");
        map.Add("eight", "8");
        map.Add("nine", "9");

        var input = File.ReadAllLines("input.txt");
        var sum = 0;
        var wordSum = 0;

        foreach (var line in input)
        {
            //sum += int.Parse(FindDigits(line));
            wordSum += int.Parse(FindDigitsOrWord(line));
        }

        Console.WriteLine(wordSum);
    }
}