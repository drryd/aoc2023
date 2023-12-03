using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

var sum_of_gear_ratios = 0;

for (var line_i = 0; line_i < lines.Length; line_i++ )
{
    var line = lines[line_i];
    string? prev_line = null;
    string? next_line = null;
    
    if ( line_i > 0 )
    {
        prev_line = lines[line_i - 1];
    }
    
    if ( line_i + 1 < lines.Length )
    {
        next_line = lines[line_i + 1];
    }

    var char_index = 0;
    while ( TryExtractNextGearIndex( line, char_index, out var gear_index ) )
    {
        var numbersAdjacentToGear = FindAdjacentNumbers( line, gear_index, prev_line, next_line );

        if ( numbersAdjacentToGear.Count == 2 )
        {
            sum_of_gear_ratios += numbersAdjacentToGear[0] * numbersAdjacentToGear[1];
        }

        char_index = gear_index + 1;
    }
}

Console.WriteLine(sum_of_gear_ratios);

// Starting at line[index], finds the index of the next gear.
bool TryExtractNextGearIndex(string line, int index, out int gear_index)
{
    gear_index = -1;

    while ( index < line.Length && line[index] != '*' )
    {
        index++;
    }

    if ( index < line.Length )
    {
        gear_index = index;
        return true;
    }
    
    return false;
}

// Finds all numbers adjacent to line[index] and returns them as a list.
List<int> FindAdjacentNumbers(string line, int gear_index, string? prev_line, string? next_line)
{
    var adjacentNumbers = new List<int>();

    // Check previous line
    var index = 0;
    if ( prev_line != null )
    {
        while ( TryExtractRangeOfNextNumber(prev_line, index, out var start_index, out var end_index) )
        {
            if ( gear_index >= start_index - 1 && gear_index <= end_index + 1 )
            {
                adjacentNumbers.Add(ParseNumAtRange(prev_line, start_index, end_index));
            }

            index = end_index + 1;
        }
    }

    // Check current line
    index = 0;
    while ( TryExtractRangeOfNextNumber(line, index, out var start_index, out var end_index) )
    {
        // When checking the same line as the number, we need to find any number that is directly to the left of the gear, or directly to the right of the gear
        if ( end_index == gear_index - 1 || start_index == gear_index + 1 )
        {
            adjacentNumbers.Add(ParseNumAtRange(line, start_index, end_index));
        }

        index = end_index + 1;
    }

    // Check next line.
    index = 0;
    if ( next_line != null )
    {
        while ( TryExtractRangeOfNextNumber(next_line, index, out var start_index, out var end_index) )
        {
            if ( gear_index >= start_index - 1 && gear_index <= end_index + 1 )
            {
                adjacentNumbers.Add(ParseNumAtRange(next_line, start_index, end_index));
            }

            index = end_index + 1;
        }
    }
    
    return adjacentNumbers;
}

// Given a string and an index, find the next number in the string from index,
// and return the start index and end index
// (note that if there is just one digit, start_index and end_index will be the same)
bool TryExtractRangeOfNextNumber(string s, int index, out int start_index, out int end_index)
{
    start_index = -1;
    end_index = -1;

    if ( index < 0 || index >= s.Length )
    {
        return false;
    }

    // Move index to the next digit we can find.
    while ( index < s.Length && !Char.IsDigit(s[index]) )
    {
        index++;
    }

    // If we found one, this is our starting digit.
    if ( index < s.Length )
    {
        start_index = index;
        end_index = start_index;

        // We know our current position is a digit, so let's move forward to find the end.
        index++;
        
        // Move index to the next non-digit we can find.
        while ( index < s.Length && Char.IsDigit(s[index]) )
        {
            index++;
            end_index += 1;
        }

        return true;
    }
    
    return false;
}

// Given a string and an index range, extract the number as an int.
// Assumes there is a number at that range.
int ParseNumAtRange(string s, int start_index, int end_index)
{
    return Int32.Parse(s.Substring(start_index, end_index - start_index + 1));
}