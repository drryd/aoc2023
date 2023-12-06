// using System;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var time_strings = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
// var distance_strings = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

// var times = time_strings.Select( x => int.Parse(x) ).ToArray();
// var distances = distance_strings.Select( x => int.Parse(x) ).ToArray();

// int? num_ways_to_win_product = null;
// for ( var i = 0; i < times.Length; i++ )
// {
//     var num_ways_to_win = 0;

//     // Searching from the middle would likely reduce the search space.
//     for ( var charge_time = 1; charge_time < times[i]; charge_time++ )
//     {
//         if ( WillChargeTimeBeatRecord( charge_time, times[i], distances[i] ) )
//         {
//             num_ways_to_win++;
//         }
//     }

//     if ( num_ways_to_win_product == null )
//     {
//         num_ways_to_win_product = num_ways_to_win;
//     }
//     else
//     {
//         num_ways_to_win_product *= num_ways_to_win;
//     }
// }

// Console.WriteLine(num_ways_to_win_product);

// bool WillChargeTimeBeatRecord( int charge_time, int race_time, int distance_record )
// {
//     var time_remaining_after_charge = race_time - charge_time;
//     var distance_travelled_after_release = charge_time * time_remaining_after_charge;
    
//     return distance_travelled_after_release > distance_record;
// }