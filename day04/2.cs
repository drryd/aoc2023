using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

// It would be better to remove items from the list after we've processed them, but we know this input file is small and single-use, so who cares
int[] num_copies_of_cards = new int[lines.Length];
for ( var i = 0; i < num_copies_of_cards.Length; i++ )
{
    num_copies_of_cards[i] = 1;
}

var num_cards_processed = 0;

for ( var line_i = 0; line_i < lines.Length; line_i++ )
{
    ExtractNumsFromLine(lines[line_i], out var winning_numbers, out var my_numbers);

    // Count number of matching numbers
    var num_matching_nums = 0;
    foreach ( var num in my_numbers )
    {
        if ( winning_numbers.Contains(num) )
        {
            num_matching_nums++;
        }
    }

    // Increment future cards based on how many of the current card I have, for each number we've matched.
    for (var i = 1; i <= num_matching_nums; i++)
    {
        num_copies_of_cards[line_i + i] += num_copies_of_cards[line_i];
    }

    num_cards_processed += num_copies_of_cards[line_i];
}

Console.WriteLine(num_cards_processed);

void ExtractNumsFromLine(string line, out HashSet<int> winning_numbers, out List<int> my_numbers)
{
    winning_numbers = new HashSet<int>();
    my_numbers = new List<int>();

    var card = line.Split(':')[1].Trim();
    var nums = card.Split('|');

    var winning_numbers_string = nums[0].Trim();
    foreach ( var num in winning_numbers_string.Split(' ', StringSplitOptions.RemoveEmptyEntries) )
    {
        winning_numbers.Add(Int32.Parse(num));
    }

    var my_numbers_string = nums[1].Trim();
    foreach ( var num in my_numbers_string.Split(' ', StringSplitOptions.RemoveEmptyEntries) )
    {
        my_numbers.Add(Int32.Parse(num));
    }
}