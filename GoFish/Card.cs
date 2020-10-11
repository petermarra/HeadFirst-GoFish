using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Card
    {
        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public string Name
        {
            get
            {
                return $"{Value.ToString()} of {Suit.ToString()}";
            }
        }

        public Suits NumberBetween0And3 { get; }
        public Values NumberBetween1And13 { get; }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value; 
        }

        static string Plural(Values value)
        {
            if (value == Values.Six)
                return "Sixes";
            else
                return $"value.ToString(){"s"}";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
