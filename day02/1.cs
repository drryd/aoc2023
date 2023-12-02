// using System;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// const int MAX_REDS = 12;
// const int MAX_GREENS = 13;
// const int MAX_BLUES = 14;

// var sum_of_possible_game_ids = 0;

// foreach ( var line in lines )
// {
//     var game_num = Int32.Parse(line.Split(':')[0].Split(' ')[1]);
//     var rounds = line.Split(':')[1].Split(';');
//     var game_would_be_possible = true;
//     foreach ( var round in rounds )
//     {
//         var colors_selected = round.Split(", ");

//         foreach ( var color_info in colors_selected )
//         {
//             var color_info_trimmed = color_info.Trim();
//             var color_num = Int32.Parse(color_info_trimmed.Split(" ")[0]);
//             var color_name = color_info_trimmed.Split(" ")[1];
//             if ( color_name == "red" && color_num > MAX_REDS )
//             {
//                 game_would_be_possible = false;
//             }
//             else if ( color_name == "green" && color_num > MAX_GREENS )
//             {
//                 game_would_be_possible = false;
//             }
//             else if ( color_name == "blue" && color_num > MAX_BLUES )
//             {
//                 game_would_be_possible = false;
//             }
//         }
//     }
    
//     if ( game_would_be_possible )
//     {
//         sum_of_possible_game_ids += game_num;
//     }
// }

// Console.WriteLine( sum_of_possible_game_ids );