// using System;
// using System.Collections;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var sum_extrapolated_values = 0;

// foreach ( var line in lines )
// {
//     ParseSequence(line, out var sequence);

//     sum_extrapolated_values += FindNextItemInSequence(sequence);
// }

// Console.WriteLine(sum_extrapolated_values);

// int FindNextItemInSequence( List<int> sequence )
// {
//     var sequences = new List<List<int>>();
//     sequences.Add(sequence);
//     List<int> next_sequence;
//     while ( !GetNextSequence( sequence, out next_sequence ) )
//     {
//         sequences.Add(next_sequence);
//         sequence = next_sequence;
//     }

//     // Add the one from when we broke out
//     sequences.Add(next_sequence);

//     int last_element_in_last_sequence = 0;
//     int running_counter = 0;
//     // At this point, all elements in the last sequence are equal.
//     for ( var i = sequences.Count - 1; i >= 0; i-- )
//     {
//         var last_element_in_this_sequence = sequences[i][sequences[i].Count - 1];
//         running_counter += last_element_in_this_sequence;
//         last_element_in_last_sequence = last_element_in_this_sequence;
//     }

//     return running_counter;
// }

// // Returns true if all elements in the returned sequence are equal.
// bool GetNextSequence(List<int> sequence, out List<int> next_sequence)
// {
//     next_sequence = new List<int>();
//     bool all_equal = true;

//     for ( var i = 1; i < sequence.Count; i++ )
//     {
//         var next_item = sequence[i] - sequence[i-1];
//         if ( next_sequence.Count > 0 && next_item != next_sequence[0] )
//         {
//             all_equal = false;
//         }
//         next_sequence.Add(next_item);
//     }

//     return all_equal;
// }

// void ParseSequence( string line, out List<int> sequence )
// {
//     sequence = new List<int>();
//     var digits = line.Split(' ');
//     foreach ( var digit in digits )
//     {
//         sequence.Add(int.Parse(digit.Trim()));
//     }
// }