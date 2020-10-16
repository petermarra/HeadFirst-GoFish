using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Player
    {
        private string name;
        public int CardCount { get { return cards.Count; }}

        public string Name { get { return name; } }
        private Random random;
        private Deck cards;
        private TextBox textBoxOnForm;

        public Player(String name,Random random, TextBox textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            cards = new Deck(new Card[] { });
            textBoxOnForm.Text += $"{name} has jist joined the game.{Environment.NewLine}";
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 0; i < 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                    if (cards.Peek(card).Value == value)
                        howMany++;
                if (howMany == 4)
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            //TODO: add code
            return cards.Peek(random.Next(CardCount)).Value;
        }

        //public Deck DoYouHaveAny (Values value)
        //{
        //    //TODO: add code
            

        //}

        public void AskForACard(List<Player> players,int MyIndex, Deck Stock)
        {
            //TODO: add code
        }
        public void TakeCard(Card card)
        {
            cards.Add(card);
        }

        public IEnumerable<string> GetCardNames()
        {
            return cards.GetCardNames();
        }

        public Card Peek(int cardNumber)
        {
            return cards.Peek(cardNumber);
        }

        public void SortHand()
        {
            cards.SortByValue();
        }
    }
}
