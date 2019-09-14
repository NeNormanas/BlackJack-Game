using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlackJack.Data
{
   public class Hand 
    {
        public List<Card> Cards { get; set; }

        public int CurrentCardNr { get; set; } = 0;

        public Hand() 
        {
            Cards = new List<Card>();
        }

        public void InitHand(List<Card> cards)
        {
            Cards = cards;
        }
        public int ReturnHowManyCardsIHave()
        {
            return this.Cards.Count;
        }
        public int ReturnValueOfMyHand()
        {
            return Cards.Sum(s => s.Value);
        }
        public Card ReturnACard(int index)
        {
            return Cards[index];
        }
        public int ReturnValueOfOneCardCard(int index)
        {
            return Cards[index].Value;
        }
        public void AddACard(Card card)
        {
            Cards.Add(card);
        }
        public void AceInit()
        {
            foreach (var item in Cards)
            {
                if (item.IsItAce())
                {
                    item.Value = 1;

                    if (this.ReturnValueOfMyHand() <= 11)
                    {
                        item.Value = item.SetAceValuetoEleven();
                    }

                }

            }
        }

    }
}
