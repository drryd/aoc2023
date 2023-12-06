using System;
using System.IO;

string[] lines = File.ReadAllLines("input.txt");

// Why bother parsing this small of input?
var time = 55826490;
var distance = 246144110121111;

var num_ways_to_win = 0;
for ( var charge_time = 1; charge_time < time; charge_time++ )
{
    if ( WillChargeTimeBeatRecord( charge_time, time, distance ) )
    {
        num_ways_to_win++;
    }
}

Console.WriteLine(num_ways_to_win);

bool WillChargeTimeBeatRecord( long charge_time, long race_time, long distance_record )
{
    var time_remaining_after_charge = race_time - charge_time;
    var distance_travelled_after_release = charge_time * time_remaining_after_charge;
    
    return distance_travelled_after_release > distance_record;
}