using System;
using System.Collections.Generic;

namespace Unit3
{
    public class Card 
    {
        public int Rank {get; private set;}
        public char Suit {get; private set;}

        public Card(int rank, char suit) {
            Rank = rank;
            Suit = suit;
            // Can do some validation here...

        }
    }
}
