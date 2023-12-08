// using System;
// using System.Collections;
// using System.IO;

// string[] lines = File.ReadAllLines("input.txt");

// List<Hand> sortedHands = new();

// var total_winnings = 0;

// foreach ( var line in lines )
// {
//     ParseLine(line, out var hand_str, out var bid);

//     var hand = new Hand(hand_str, bid);
    
//     // Iterate over sortedHands and insert newly parsed hand into the list.
//     sortedHands.Add(hand);
//     sortedHands.Sort();
// }

// // Iterate over answers and compute total winnings
// for ( var i = 0; i < sortedHands.Count; i++ )
// {
//     var hand_rank = i + 1;
//     total_winnings += sortedHands[i].Bid * hand_rank;
//     //Console.WriteLine( $"{i} - {sortedHands[i].HandStr} - {sortedHands[i].HandType.ToString()}" );
// }

// Console.WriteLine(total_winnings);

// void ParseLine(string line, out string hand, out int bid)
// {
//     var split_line = line.Split(' ');
//     hand = split_line[0];
//     bid = int.Parse(split_line[1]);
// }

// public enum HandType
// {
//     HighCard = 0,
//     OnePair = 1,
//     TwoPair = 2,
//     ThreeOfAKind = 3,
//     FullHouse = 4,
//     FourOfAKind = 5,
//     FiveOfAKind = 6
// }

// public class Hand : IComparable<Hand>
// {
//     public readonly int Bid;
//     public readonly HandType HandType;
//     public readonly string HandStr;

//     public Hand(string hand, int bid)
//     {
//         this.HandStr = hand;
//         Bid = bid;
//         HandType = ComputeHandType( hand );
//     }

//     private static HandType ComputeHandType(string hand)
//     {
//         Dictionary<char, int> cardCount = new();

//         foreach ( var card in hand )
//         {
//             if ( cardCount.ContainsKey( card ) )
//             {
//                 cardCount[card]++;
//             }
//             else
//             {
//                 cardCount.Add( card, 1 );
//             }
//         }

//         switch ( cardCount.Count )
//         {
//             case 1:
//                 return HandType.FiveOfAKind;
//             case 2:
//                 foreach ( var entry in cardCount )
//                 {
//                     if ( entry.Value == 4 )
//                     {
//                         return HandType.FourOfAKind;
//                     }
//                 }

//                 return HandType.FullHouse;
//             case 3:
//                 foreach ( var entry in cardCount )
//                 {
//                     if ( entry.Value == 3 )
//                     {
//                         return HandType.ThreeOfAKind;
//                     }
//                 }

//                 return HandType.TwoPair;
//             case 4:
//                 return HandType.OnePair;
//             default:
//                 return HandType.HighCard;
//         }
//     }

//     public int CompareTo(Hand? that)
//     {
//         if ( that == null ) throw new ArgumentException();

//         var thisHandType = this.HandType;
//         var thatHandType = that.HandType;

//         if ( thisHandType < thatHandType ) return -1;
//         if ( thisHandType > thatHandType ) return 1;

//         if ( thisHandType == thatHandType )
//         {
//             for ( var i = 0; i < this.HandStr.Length; i++ )
//             {
//                 var compareCard = CardComparer.CompareCard(this.HandStr[i], that.HandStr[i]);
//                 if ( compareCard != 0 )
//                     return compareCard;
//             }
//         }
        
//         return 0;
//     }
// }

// public static class CardComparer
// {
//     private static Dictionary<char, int> strengthRank;

//     static CardComparer()
//     {
//         strengthRank = new();

//         strengthRank.Add('2', 0);
//         strengthRank.Add('3', 1);
//         strengthRank.Add('4', 2);
//         strengthRank.Add('5', 3);
//         strengthRank.Add('6', 4);
//         strengthRank.Add('7', 5);
//         strengthRank.Add('8', 6);
//         strengthRank.Add('9', 7);
//         strengthRank.Add('T', 8);
//         strengthRank.Add('J', 9);
//         strengthRank.Add('Q', 10);
//         strengthRank.Add('K', 11);
//         strengthRank.Add('A', 12);
//     }

//     public static int CompareCard( char card1, char card2 )
//     {
//         if ( strengthRank[card1] < strengthRank[card2] )
//             return -1;

//         if ( strengthRank[card1] > strengthRank[card2] )
//             return 1;

//         return 0;
//     }
// }