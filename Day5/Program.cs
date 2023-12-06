using System.Text.RegularExpressions;

internal partial class Program
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();

    private static Dictionary<long, long> CreateMap(List<string> lines)
    {
        var mapping = new Dictionary<long, long>();

        foreach(var line in lines)
        {
            var matches = MyRegex().Matches(line).ToList();
            var startIndex = long.Parse(matches[1].Value);
            var rangeStart = long.Parse(matches[0].Value);
            var rangeLength = long.Parse(matches[2].Value);

            for(long i = 0; i < rangeLength; i++)
            {
                if(!mapping.ContainsKey(startIndex + i))
                    mapping.Add(startIndex + i, rangeStart + i);
                else
                    mapping[startIndex + 1] = rangeStart + 1;

            }
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

        Dictionary<long,long> seedSoilMap = CreateMap(input.GetRange(seedSoilIndex + 1, soilFertIndex - 2 - seedSoilIndex));
        Dictionary<long,long> soilFertMap = CreateMap(input.GetRange(soilFertIndex + 1, fertWaterIndex - 2 - soilFertIndex ));
        Dictionary<long,long> fertWaterMap = CreateMap(input.GetRange(fertWaterIndex + 1, waterLightIndex - 2 - fertWaterIndex ));
        Dictionary<long,long> waterLightMap = CreateMap(input.GetRange(waterLightIndex + 1, lightTempIndex - 2 - waterLightIndex ));
        Dictionary<long,long> lightTempMap = CreateMap(input.GetRange(lightTempIndex + 1, tempHumidIndex - 2 - lightTempIndex ));
        Dictionary<long,long> tempHumidMap = CreateMap(input.GetRange(tempHumidIndex + 1, humidLocIndex - 2 - tempHumidIndex ));
        Dictionary<long,long> humidLocMap = CreateMap(input.GetRange(humidLocIndex + 1, input.Count - humidLocIndex - 1));

        var seedMatches = MyRegex().Matches(seedList).ToList();
        var locationList = new List<long>();

        foreach(var seed in seedMatches)
        {
            long seedValue = long.Parse(seed.Value);
            long passThrough = 0;

            if(seedSoilMap.ContainsKey(seedValue)) //soil
                passThrough = seedSoilMap[seedValue];
            else
                passThrough = seedValue;

                Console.WriteLine("Soil " + passThrough);

            if(soilFertMap.ContainsKey(passThrough)) //fert
                passThrough = soilFertMap[passThrough];

            //    Console.WriteLine("fert " + passThrough);

            if(fertWaterMap.ContainsKey(passThrough)) //water
                passThrough = fertWaterMap[passThrough];

              //  Console.WriteLine("water " + passThrough);

            if(lightTempMap.ContainsKey(passThrough)) //light
                passThrough = lightTempMap[passThrough];

            //Console.WriteLine("light " + passThrough);

            if(tempHumidMap.ContainsKey(passThrough)) //temp
                passThrough = tempHumidMap[passThrough];

            //Console.WriteLine("temp " + passThrough);

            if(humidLocMap.ContainsKey(passThrough)) //humid
                passThrough = humidLocMap[passThrough];

            //Console.WriteLine("humid " + passThrough);

            locationList.Add(passThrough);
        }

        locationList.Sort();
        Console.WriteLine(locationList[0]);
    }
}