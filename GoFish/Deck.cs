using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    class Deck
    {
        private List<Card> cards;
        private Random random  = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    cards.Add(new Card((Suits)suit, (Values)value));
        }
        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        /// <summary>
        /// Deal a card from the in  the deck  
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
           return cardToDeal;
        }

        /// <summary>
        /// Deal from the top of the deck
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        {
            return Deal(0);
        }

        public void Shuffle()
        {
            List<Card> shuffledCards = new List<Card>();
            while (cards.Count> 0)
            {
                int cardToMove = random.Next(cards.Count);
                shuffledCards.Add(cards[cardToMove]);
                cards.RemoveAt(cardToMove);
            }
            cards = shuffledCards;
        }

        public IEnumerable<string> GetCardNames()
        {
            //this method returns a string array contains each cards name
            string[] cardName = new string[cards.Count];
            //my code.. a for loop was better because it used less lines
            //int cardNumber = 0;
            //foreach (var card in cards)
            //{
            //    cardName[cardNumber] = card.Name;
            //    cardNumber++;
            //}

            for (int i = 0; i < cards.Count; i++)
            {
                cardName[i] = cards[i].Name;
            }
            return cardName;
        }
        
        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue()); 
        }

        /// <summary>
        /// Look at a card without dealing it
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        /// <summary>
        /// deck for value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
                if (card.Value == value)
                    return true;
            return false;
        }

        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].Value == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }

        public bool HasBook(Values value)
        {
            int numberOfCards = 0;
            foreach (Card card in cards)
                if (card.Value == value)
                    numberOfCards++;
            if (numberOfCards == 4)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
