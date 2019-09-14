using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlackJack.Data
{
    public class Player 
    {
        public int Money { get; set; }
        public List<Card> MyCards { get; set; }
        public Hand MyHand { get; set; }
        public List<Hand> Hands { get; set; }
        public Player() 
        {
            MyCards = new List<Card>();
            MyHand = new Hand();
            Hands = new List<Hand>();


            MyHand.InitHand(MyCards);
        }
        public void RequestACard(Card card)
        {
            MyCards.Add(card);
            //MyHand.AddACard(card);

        }

        public void RemoveOneCard(int index)
        {
            MyCards.RemoveAt(index);
        }

        public int HowManyCardsInMyhands()
        {
          return MyHand.ReturnHowManyCardsIHave();
           
        }

        public int CalculateValueOfMyCards()
        {
            int valueOfMyCards = 0;

            foreach (var card in MyCards)
            {
                valueOfMyCards += card.Value;
            }
            return valueOfMyCards;
        }
    }
}
