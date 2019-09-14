using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.Data
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }
        private int numOfCards = 0;

        public Deck()
        {
            InitDeck();
        }


        private void InitDeck()
        {
            Cards = new List<Card>();

            for (int i = 0; i < Constants.SuitsCount; i++)
            {
                for (int j = 0; j < Constants.FacesCount; j++)
                {
                    Cards.Add(new Card((Suit)i, (Face)j));
                }
            }
            numOfCards = Cards.Count;
        }
        public void Shuffle()
        {
            int cardsCountNumber = Cards.Count;

            Random rnd = new Random();

            while (cardsCountNumber > 0)
            {
                cardsCountNumber--;
                int k = rnd.Next(cardsCountNumber);
                Card card = Cards[k];
                Cards[k] = Cards[cardsCountNumber];
                Cards[cardsCountNumber] = card;
            }
        }
        public Card DealARandomCard()
        {
            Random rnd = new Random();
            int k = rnd.Next(numOfCards);

            numOfCards--;
            Card card = Cards[k];
            Cards.Remove(Cards[k]);

            return card;
        }
        public Card DealATopCard()
        {
            Stack<Card> myStack = new Stack<Card>(Cards);
            numOfCards--;
            Card card = myStack.Pop();
            Cards = myStack.ToList();
            return card;
        }
        public int ReturnCountOfCards()
        {
            return numOfCards;
        }

    }
}
