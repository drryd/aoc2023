using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

var sum_of_powers = 0;

foreach ( var line in lines )
{
    var game_num = Int32.Parse(line.Split(':')[0].Split(' ')[1]);
    var rounds = line.Split(':')[1].Split(';');
    var min_reds_needed = 0;
    var min_greens_needed = 0;
    var min_blues_needed = 0;
    foreach ( var round in rounds )
    {
        var colors_selected = round.Split(", ");

        foreach ( var color_info in colors_selected )
        {
            var color_info_trimmed = color_info.Trim();
            var color_num = Int32.Parse(color_info_trimmed.Split(" ")[0]);
            var color_name = color_info_trimmed.Split(" ")[1];
            if ( color_name == "red" )
            {
                min_reds_needed = Math.Max(min_reds_needed, color_num);
            }
            else if ( color_name == "green" )
            {
                min_greens_needed = Math.Max(min_greens_needed, color_num);
            }
            else if ( color_name == "blue" )
            {
                min_blues_needed = Math.Max(min_blues_needed, color_num);
            }
        }
    }

    sum_of_powers += min_reds_needed * min_greens_needed * min_blues_needed;
}

Console.WriteLine( sum_of_powers );