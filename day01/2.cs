using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

uint sumCalibrationValues = 0;

foreach ( var line in lines )
{
    string? firstDigit = null;
    string? latestDigit = null;
    for ( var c_i = 0; c_i < line.Length; c_i++ )
    {
        if ( Char.IsDigit(line[c_i]) )
        {
            if ( firstDigit == null )
            {
                firstDigit = line[c_i].ToString();
            }

            latestDigit = line[c_i].ToString();
        }
        else if ( TryParseDigitStringAtIndex(line, c_i, out var digitString) )
        {
            digitString = ConvertSpelledOutDigitToDigit(digitString);

            if ( firstDigit == null )
            {
                firstDigit = digitString;
            }

            latestDigit = digitString;

            // It would be more efficient and technically more correct to move c_i by the size of digit string here, but it's not strictly necessary since no digit string is a subset of another.
        }
    }

    var calibrationValue = UInt32.Parse(firstDigit + latestDigit);
    sumCalibrationValues += calibrationValue;
}

Console.WriteLine(sumCalibrationValues);

// Returns true and populates digitString if there is a digit string within line starting at index.
bool TryParseDigitStringAtIndex(string line, int index, out string? digitString)
{
    digitString = null;
    // Basic idea: Start with a set of all possible digit strings and compare these to line at index
    //             If we get fully through any string we know it's a match, otherwise if we remove every string from the set, we know it's not a match.

    HashSet<string> possibleDigitStrings = new() { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };    // Zero doesn't exist in the input.

    const int maximumOffset = 5;    // We know we don't need to search further than the longset possible string.
    for ( var offset = 0; offset <= maximumOffset && possibleDigitStrings.Count > 0; offset++ )
    {
        foreach ( var possibleDigitString in possibleDigitStrings )
        {
            if ( offset >= possibleDigitString.Length )
            {
                // We've exceeded the length of the string without removing it, so it must have matched.
                digitString = possibleDigitString;
                return true;
            }

            if ( index + offset >= line.Length )
            {
                return false;
            }

            if ( line[index + offset] != possibleDigitString[offset] )
            {
                possibleDigitStrings.Remove(possibleDigitString);
            }
        }
    }

    return false;
}

// Takes arguments like "one" and returns "1".
string ConvertSpelledOutDigitToDigit(string? spelledOutDigitString) => spelledOutDigitString switch
{
    // Zero doesn't exist in the input.
    "one" => "1",
    "two" => "2",
    "three" => "3",
    "four" => "4",
    "five" => "5",
    "six" => "6",
    "seven" => "7",
    "eight" => "8",
    "nine" => "9",
    _ => throw new ArgumentOutOfRangeException(nameof(spelledOutDigitString)),
};