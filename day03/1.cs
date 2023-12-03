// using System;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var sum_of_nums_adjacent_to_symbols = 0;

// for (var line_i = 0; line_i < lines.Length; line_i++ )
// {
//     var line = lines[line_i];
//     string? prev_line = null;
//     string? next_line = null;
    
//     if ( line_i > 0 )
//     {
//         prev_line = lines[line_i - 1];
//     }
    
//     if ( line_i + 1 < lines.Length )
//     {
//         next_line = lines[line_i + 1];
//     }

//     var char_index = 0;
//     while ( TryExtractRangeOfNextNumber(line, char_index, out var num_start_index, out var num_end_index) )
//     {
//         if ( IsRangeAdjacentToASymbol( prev_line, line, next_line, num_start_index, num_end_index ) )
//         {
//             sum_of_nums_adjacent_to_symbols += ParseNumAtRange(line, num_start_index, num_end_index);
//         }

//         char_index = num_end_index + 1;
//     }
// }

// Console.WriteLine(sum_of_nums_adjacent_to_symbols);

// // Given a string and an index, find the next number in the string from index,
// // and return the start index and end index
// // (note that if there is just one digit, start_index and end_index will be the same)
// bool TryExtractRangeOfNextNumber(string s, int index, out int start_index, out int end_index)
// {
//     start_index = -1;
//     end_index = -1;

//     if ( index < 0 || index >= s.Length )
//     {
//         return false;
//     }

//     // Move index to the next digit we can find.
//     while ( index < s.Length && !Char.IsDigit(s[index]) )
//     {
//         index++;
//     }

//     // If we found one, this is our starting digit.
//     if ( index < s.Length )
//     {
//         start_index = index;
//         end_index = start_index;

//         // We know our current position is a digit, so let's move forward to find the end.
//         index++;
        
//         // Move index to the next non-digit we can find.
//         while ( index < s.Length && Char.IsDigit(s[index]) )
//         {
//             index++;
//             end_index += 1;
//         }

//         return true;
//     }
    
//     return false;
// }

// // Given three lines and a start/end index of the current line, see if anything in the range is adjacent to a symbol.
// bool IsRangeAdjacentToASymbol(string? prev_line, string line, string? next_line, int start_index, int end_index)
// {
//     for ( var i = start_index - 1; i <= end_index + 1; i++ )
//     {
//         if (i < 0 || i >= line.Length)
//         {
//             continue;
//         }

//         if (prev_line != null && IsSymbol(prev_line[i]))
//         {
//             return true;
//         }

//         if (next_line != null && IsSymbol(next_line[i]))
//         {
//             return true;
//         }

//         // This re-checks each digit we already know is the number, but IsSymbol is fast anyway.
//         if ( IsSymbol(line[i]) )
//         {
//             return true;
//         }
//     }
    
//     return false;
// }

// // Given a string and an index range, extract the number as an int.
// // Assumes there is a number at that range.
// int ParseNumAtRange(string s, int start_index, int end_index)
// {
//     return Int32.Parse(s.Substring(start_index, end_index - start_index + 1));
// }

// // Returns true if c represents a symbol.
// bool IsSymbol(char c)
// {
//     const char EMPTY = '.';

//     return c != EMPTY && !Char.IsDigit(c);
// }