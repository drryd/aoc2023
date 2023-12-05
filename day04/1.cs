// using System;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// var sum_game_scores = 0;

// foreach ( var line in lines )
// {
//     ExtractNumsFromLine(line, out var winning_numbers, out var my_numbers);

//     var game_score = 0;

//     foreach ( var num in my_numbers )
//     {
//         if ( winning_numbers.Contains(num) )
//         {
//             if ( game_score == 0 )
//             {
//                 game_score++;
//             }
//             else
//             {
//                 game_score *= 2;
//             }
//         }
//     }

//     sum_game_scores += game_score;
// }

// Console.WriteLine(sum_game_scores);

// void ExtractNumsFromLine(string line, out HashSet<int> winning_numbers, out List<int> my_numbers)
// {
//     winning_numbers = new HashSet<int>();
//     my_numbers = new List<int>();

//     var card = line.Split(':')[1].Trim();
//     var nums = card.Split('|');

//     var winning_numbers_string = nums[0].Trim();
//     foreach ( var num in winning_numbers_string.Split(' ', StringSplitOptions.RemoveEmptyEntries) )
//     {
//         winning_numbers.Add(Int32.Parse(num));
//     }

//     var my_numbers_string = nums[1].Trim();
//     foreach ( var num in my_numbers_string.Split(' ', StringSplitOptions.RemoveEmptyEntries) )
//     {
//         my_numbers.Add(Int32.Parse(num));
//     }
// }