using System.Text.RegularExpressions;

internal partial class Program
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex MyRegex();

    private static IEnumerable<long> CreateRange(long start,long count)
    {
        var limit = start + count;

        while(start < limit)
        {
            yield return start;
            start++;
        }
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

            List<long> keys = CreateRange(startIndex, rangeLength).ToList();
            List<long> vals = CreateRange(rangeStart, rangeLength).ToList();

            var z = keys.Zip( vals, (first, second) => new KeyValuePair<long, long>(first, second)).ToList();
            mapping.AddRange(z);

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

            if(seedSoilMap.Where( s => s.Key == seedValue).FirstOrDefault() is var seedTemp && !seedTemp.Equals(default( KeyValuePair<long, long>))) //soil
                passThrough = seedTemp.Value;
            else
                passThrough = seedValue;

//                Console.WriteLine("Soil " + passThrough);

            if(!(soilFertMap.Where( s => s.Key == passThrough).FirstOrDefault() is var fertTemp && !seedTemp.Equals(default( KeyValuePair<long, long>)))) //fert
                passThrough = fertTemp.Value;

            //    Console.WriteLine("fert " + passThrough);

            if(!(fertWaterMap.Where( s => s.Key == passThrough).FirstOrDefault() is var waterTemp && !seedTemp.Equals(default( KeyValuePair<long, long>)))) //water
                passThrough = waterTemp.Value;

              //  Console.WriteLine("water " + passThrough);

            if(!(waterLightMap.Where( s => s.Key == passThrough).FirstOrDefault() is var lightTemp && !seedTemp.Equals(default( KeyValuePair<long, long>))))
                passThrough = lightTemp.Value;                

            if(!(lightTempMap.Where( s => s.Key == passThrough).FirstOrDefault() is var tempTemp && !seedTemp.Equals(default( KeyValuePair<long, long>)))) //light
                passThrough = tempTemp.Value;

            //Console.WriteLine("light " + passThrough);

            if(!(tempHumidMap.Where( s => s.Key == passThrough).FirstOrDefault() is var humidTemp && !seedTemp.Equals(default( KeyValuePair<long, long>)))) //temp
                passThrough = humidTemp.Value;

            //Console.WriteLine("temp " + passThrough);

            if(!(humidLocMap.Where( s => s.Key == passThrough).FirstOrDefault() is var locTemp && !seedTemp.Equals(default( KeyValuePair<long, long>)))) //humid
                passThrough = locTemp.Value;

            //Console.WriteLine("humid " + passThrough);

            locationList.Add(passThrough);
        }

        locationList.Sort();
        Console.WriteLine(locationList[0]);
    }
}