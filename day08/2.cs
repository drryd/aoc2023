using System;
using System.Collections;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

var direction_str = lines[0];

Dictionary<string, (string, string)> path = new();
var curr_nodes = new List<string>();

for ( var line_i = 2; line_i < lines.Length; line_i++ )
{
    ParseLine(lines[line_i], out var key, out var L, out var R);
    path[key] = (L, R);
    if ( key.EndsWith("A") )
    {
        curr_nodes.Add(key);;
    }
}

var directions = new Directions(direction_str);
List<int> num_steps_to_reach_z_per_node = new();
List<int> distances_between_zs_per_node = new();

for ( var node_i = 0; node_i < curr_nodes.Count; node_i++ )
{
    var curr_node = curr_nodes[node_i];
    var num_steps_to_reach_z = 0;
    directions.Reset();

    while ( !curr_node.EndsWith('Z') )
    {
        num_steps_to_reach_z++;
        var next_direction = directions.GetNextDirection();

        if (next_direction == 'L')
        {
            curr_node = path[curr_node].Item1;
        }
        else if (next_direction == 'R')
        {
            curr_node = path[curr_node].Item2;
        }
    }

    num_steps_to_reach_z_per_node.Add(num_steps_to_reach_z);
    var num_steps_to_reach_next_z = FindNumberOfStepsToNextZ(path, directions, curr_node);
    distances_between_zs_per_node.Add(num_steps_to_reach_next_z);

    Console.WriteLine($"Steps to reach z: {num_steps_to_reach_z}");
    Console.WriteLine($"Steps to reach NEXT z: {num_steps_to_reach_next_z}");
    // Surprisingly, the distance to reach z = the distance to reach next z
    // Since this is true, we just need to find when all of these numbers hit the same number,
    // which is the definition of the least common multiple.
    // If this wasn't true, the cycles wouldn't start in sync and we couldn't apply LCM directly.
    // Actually, there is another assumption that might've caused a bug here -- 
    // we didn't check that each of these cycles was hitting the SAME z -- we just checked endswith z.
    // We would have also needed to check that, but apparently it worked without that validation.
}

int FindNumberOfStepsToNextZ(Dictionary<string, (string, string)> path, Directions directions, string curr_node)
{
    // Start at a Z, so move one.
    var next_direction = directions.GetNextDirection();
    if (next_direction == 'L')
    {
        curr_node = path[curr_node].Item1;
    }
    else if (next_direction == 'R')
    {
        curr_node = path[curr_node].Item2;
    }
    
    var num_steps_to_reach_z = 1;

    while ( !curr_node.EndsWith('Z') )
    {
        num_steps_to_reach_z++;

        next_direction = directions.GetNextDirection();

        if (next_direction == 'L')
        {
            curr_node = path[curr_node].Item1;
        }
        else if (next_direction == 'R')
        {
            curr_node = path[curr_node].Item2;
        }
    }

    return num_steps_to_reach_z;
}

void ParseLine(string line, out string key, out string L, out string R)
{
    var split_str = line.Split('=');
    key = split_str[0].Trim();
    var val_half_split = split_str[1].Trim().Split(',');
    L = val_half_split[0].Trim().TrimStart('(');
    R = val_half_split[1].Trim().TrimEnd(')');
}

public class Directions
{
    public int _direction_i;
    public string _directions;

    public Directions(string directions)
    {
        _direction_i = 0;
        _directions = directions;
    }

    public char GetNextDirection()
    {
        var ret_val = _directions[_direction_i];

        _direction_i += 1;

        if ( _direction_i >= _directions.Length ) _direction_i = 0;

        return ret_val;
    }

    public void Reset()
    {
        _direction_i = 0;
    }
}

// Brute force didn't work:

// using System;
// using System.Collections;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var num_steps_to_reach_zzz = 0;
// var direction_str = lines[0];

// Dictionary<string, (string, string)> Path = new();
// var curr_nodes = new List<string>();

// for ( var line_i = 2; line_i < lines.Length; line_i++ )
// {
//     ParseLine(lines[line_i], out var key, out var L, out var R);
//     Path[key] = (L, R);
//     if ( key.EndsWith("A") )
//     {
//         curr_nodes.Add(key);
//     }
// }

// while ( !AllNodesEndInZ(curr_nodes) )
// {
//     for ( var direction_i = 0; direction_i < direction_str.Length; direction_i++ )
//     {
//         for ( var curr_node_i = 0; curr_node_i < curr_nodes.Count; curr_node_i++ )
//         {
//             if (direction_str[direction_i] == 'L')
//             {
//                 curr_nodes[curr_node_i] = Path[curr_nodes[curr_node_i]].Item1;
//             }
//             else if (direction_str[direction_i] == 'R')
//             {
//                 curr_nodes[curr_node_i] = Path[curr_nodes[curr_node_i]].Item2;
//             }
//         }

//         num_steps_to_reach_zzz++;

//         if (AllNodesEndInZ(curr_nodes))
//         {
//             break;
//         }
//     }
// }

// bool AllNodesEndInZ(List<string> nodes)
// {
//     foreach ( var node in nodes )
//     {
//         if ( !node.EndsWith('Z') )
//         {
//             return false;
//         }
//     }

//     return true;
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