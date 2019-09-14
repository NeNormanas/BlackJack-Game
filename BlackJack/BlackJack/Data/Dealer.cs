using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class Dealer : Player
    {
        private Deck _deck;

        public Dealer() 
        {
            _deck = new Deck();
        }

        public Card DealCard()
        {
            this.ShuffleDeck();
            return _deck.DealARandomCard();
        }
        public void ShuffleDeck()
        {
            _deck.Shuffle();
        }
        




    }
}
