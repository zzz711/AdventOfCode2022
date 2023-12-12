using System.Text.RegularExpressions;

internal partial class Program
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();

    private static long FindValue(long val, List<KeyValuePair<long, long>> map)
    {

        for(int i = 0; i < map.Count; i += 2)
        {
            if(map[i].Key <= val && val <= map[i + 1].Key)
            {
                long difference = map[i +1].Key - val;
                val = map[i +1].Value - difference;
                break;
            }
        }

        return val;
    }

    private static List<KeyValuePair<long, long>> CreateMap(List<string> lines)
    {
        var mapping = new List<KeyValuePair<long, long>>();

        foreach(var line in lines)
        {
            var matches = MyRegex().Matches(line).ToList();
            var startIndex = long.Parse(matches[1].Value);
            var rangeStart = long.Parse(matches[0].Value);
            var rangeLength = long.Parse(matches[2].Value);

            mapping.Add(new KeyValuePair<long, long>(startIndex, rangeStart));
            mapping.Add(new KeyValuePair<long, long>(startIndex + rangeLength -1, rangeStart + rangeLength -1));

        }

        return mapping;
    }

    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt").ToList();
        var seedList = input[0];

        var seedSoilIndex = input.FindIndex(item => item.Contains("seed-to-soil"));
        var soilFertIndex = input.FindIndex(item => item.Contains("soil-to-fertilizer"));
        var fertWaterIndex = input.FindIndex(item => item.Contains("fertilizer-to-water"));
        var waterLightIndex = input.FindIndex(item => item.Contains("water-to-light"));
        var lightTempIndex = input.FindIndex(item => item.Contains("light-to-temperature"));
        var tempHumidIndex = input.FindIndex(item => item.Contains("temperature-to-humidity"));
        var humidLocIndex = input.FindIndex(item => item.Contains("humidity-to-location"));

        var seedSoilMap = CreateMap(input.GetRange(seedSoilIndex + 1, soilFertIndex - 2 - seedSoilIndex));
        var soilFertMap = CreateMap(input.GetRange(soilFertIndex + 1, fertWaterIndex - 2 - soilFertIndex ));
        var fertWaterMap = CreateMap(input.GetRange(fertWaterIndex + 1, waterLightIndex - 2 - fertWaterIndex ));
        var waterLightMap = CreateMap(input.GetRange(waterLightIndex + 1, lightTempIndex - 2 - waterLightIndex ));
        var lightTempMap = CreateMap(input.GetRange(lightTempIndex + 1, tempHumidIndex - 2 - lightTempIndex ));
        var tempHumidMap = CreateMap(input.GetRange(tempHumidIndex + 1, humidLocIndex - 2 - tempHumidIndex ));
        var humidLocMap = CreateMap(input.GetRange(humidLocIndex + 1, input.Count - humidLocIndex - 1));

        var seedMatches = MyRegex().Matches(seedList).ToList();
        var locationList = new List<long>();

        foreach(var seed in seedMatches)
        {
            long seedValue = long.Parse(seed.Value);
            long passThrough = 0;

            //soil
            passThrough = FindValue(seedValue, seedSoilMap);

            //fert
            passThrough = FindValue(passThrough, soilFertMap);

            //water
            passThrough = FindValue(passThrough, fertWaterMap);
        
            //light
            passThrough = FindValue(passThrough, waterLightMap);

            //temp
            passThrough = FindValue(passThrough, lightTempMap);

            //humid
            passThrough = FindValue(passThrough, tempHumidMap);

            //location
            passThrough = FindValue(passThrough, humidLocMap);

            locationList.Add(passThrough);
        }

        locationList.Sort();
        Console.WriteLine(locationList[0]);
    }
}