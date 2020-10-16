﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add(new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)
            {
                players.Add(new Player(player, random, textBoxOnForm));
            }
            books = new Dictionary<Values, Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();

        }


        private void Deal()
        {
            stock.Shuffle();
            for (int i = 0; i < 5; i++)
            {
                foreach (Player player in players)
                    player.TakeCard(stock.Deal());
            }
          foreach (Player player in players)
            PullOutBooks(player);

        }

        public bool PlayOneRound(int selectedPlayerCard)
        {
            return false;
        }

        public bool PullOutBooks(Player player)
        {

            List<Values> cardBooks = new List<Values>();
            cardBooks  = (List<Values>)player.PullOutBooks();
            foreach (var cardBook in cardBooks)
                books.Add(cardBook, player);
            if (player.CardCount == 0)
                return true;
            else
                return false;
        }

        public string DescribeBooks()
        {
            string playerBooks = "";
            foreach (Player player in players)
            {
                foreach (Values value in books.Keys)
                {
                    playerBooks += $"{ books[value].Name } has a book of {Card.Plural(value)}.\r\n";   
                }

            }
            return playerBooks;
        }

        public string GetWinnerName()
        {
            return "TODO: add code";
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += $"{players[i].Name} has {players[i].CardCount}";
                if (players[i].CardCount == 1)
                    description += " card." + Environment.NewLine;
                else
                    description += " cards." + Environment.NewLine;
            }
            description += $"The stock has {stock.Count} cards left.";
            return description;
        }
    }
}