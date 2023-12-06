using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

var seeds_strs = lines[0].Split(' ');

var seeds_min = long.MaxValue;

// Not enough RAM to process all seeds at once, so let's search each partition
for (var seed_str_i = 1; seed_str_i < seeds_strs.Length; seed_str_i+=2)
{
    var seeds = new List<long>();
    var start_num = Int64.Parse(seeds_strs[seed_str_i]);
    var range = Int64.Parse(seeds_strs[seed_str_i+1]);
    for ( var seed_num = start_num; seed_num < start_num + range; seed_num++ )
    {
        seeds.Add(seed_num);
    }

    var seed_transforms = new List<long>();
    foreach (var _ in seeds)
    {
        seed_transforms.Add(0);
    }

    var line_i = 3;
    while (line_i < lines.Length)
    {
        ExtractMapFromLine(lines[line_i], out var source_range_start, out var destination_range_start, out var range_length);

        for (var seed_i = 0; seed_i < seeds.Count; seed_i++)
        {
            if (seeds[seed_i] >= source_range_start && seeds[seed_i] < source_range_start + range_length)
            {
                // Can't directly set the seeds here, need to use a seed_transforms accumulator so that we don't apply the same map multiple times.
                seed_transforms[seed_i] += (destination_range_start - source_range_start);
            }
        }

        line_i++;

        if (line_i == lines.Length)
        {
            break;
        }

        if (lines[line_i] == string.Empty)
        {
            for (var seed_transform_i = 0; seed_transform_i < seeds.Count; seed_transform_i++)
            {
                seeds[seed_transform_i] += seed_transforms[seed_transform_i];
                seed_transforms[seed_transform_i] = 0;
            }

            line_i += 2;
        }
        //Console.WriteLine($"Processing line {line_i + 1} of {lines.Length}");
    }

    // Since the input doesn't end on an empty line, we need to ensure we apply any last transforms.
    for (var seed_transform_i = 0; seed_transform_i < seeds.Count; seed_transform_i++)
    {
        seeds[seed_transform_i] += seed_transforms[seed_transform_i];
        seed_transforms[seed_transform_i] = 0;
    }

    seeds_min = Math.Min(seeds_min, seeds.Min());
    //Console.WriteLine($"Finished one pair, new min is {seeds_min}");
}

Console.WriteLine(seeds_min);

void ExtractMapFromLine(string line, out long source_range_start, out long destination_range_start, out long range_length)
{
    var chars = line.Split(' ');
    destination_range_start = Int64.Parse(chars[0]);
    source_range_start = Int64.Parse(chars[1]);
    range_length = Int64.Parse(chars[2]);
}