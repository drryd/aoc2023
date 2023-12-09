// using System;
// using System.Collections;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var num_steps_to_reach_zzz = 0;
// var direction_str = lines[0];

// Dictionary<string, (string, string)> Path = new();

// for ( var line_i = 2; line_i < lines.Length; line_i++ )
// {
//     ParseLine(lines[line_i], out var key, out var L, out var R);
//     Path[key] = (L, R);
// }

// var curr_pos = "AAA";

// while ( curr_pos != "ZZZ" )
// {
//     for ( var direction_i = 0; direction_i < direction_str.Length; direction_i++ )
//     {
//         if (direction_str[direction_i] == 'L')
//         {
//             curr_pos = Path[curr_pos].Item1;
//         }
//         else if (direction_str[direction_i] == 'R')
//         {
//             curr_pos = Path[curr_pos].Item2;
//         }

//         num_steps_to_reach_zzz++;

//         if (curr_pos == "ZZZ")
//         {
//             break;
//         }
//     }
// }

// Console.WriteLine(num_steps_to_reach_zzz);

// void ParseLine(string line, out string key, out string L, out string R)
// {
//     var split_str = line.Split('=');
//     key = split_str[0].Trim();
//     var val_half_split = split_str[1].Trim().Split(',');
//     L = val_half_split[0].Trim().TrimStart('(');
//     R = val_half_split[1].Trim().TrimEnd(')');
// }