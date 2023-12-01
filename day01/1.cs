// using System;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// uint sumCalibrationValues = 0;

// foreach ( var line in lines )
// {
//     string? firstDigit = null;
//     string? latestDigit = null;
//     foreach ( var c in line )
//     {
//         if ( Char.IsDigit(c) )
//         {
//             if ( firstDigit == null )
//             {
//                 firstDigit = c.ToString();
//             }

//             latestDigit = c.ToString();
//         }
//     }

//     var calibrationValue = UInt32.Parse(firstDigit + latestDigit);
//     sumCalibrationValues += calibrationValue;
// }

// Console.WriteLine(sumCalibrationValues);