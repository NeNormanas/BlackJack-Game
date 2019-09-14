using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Data
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public Face Face { get; private set; }
        public int Value { get;  set; }

        public Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
            SetValue();
        }

        private void SetValue()
        {
            switch (Face)
            {
                case Face.Ace:
                    Value = this.SetAceValue();
                    break;
                case Face.Two:
                    Value = 2;
                    break;
                case Face.Three:
                    Value = 3;
                    break;
                case Face.Four:
                    Value = 4;
                    break;
                case Face.Five:
                    Value = 5;
                    break;
                case Face.Six:
                    Value = 6;
                    break;
                case Face.Seven:
                    Value = 7;
                    break;
                case Face.Eight:
                    Value = 8;
                    break;
                case Face.Nine:
                    Value = 9;
                    break;
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    Value = 10;
                    break;
                default:
                    break;
            }


        }

        public int SetAceValue()
        {
                return 1; // default value.
        }

        public int SetAceValuetoEleven()
        {
            return 11;
        }

        public bool IsItAce()
        {
            if (this.Face == Face.Ace)
            {
                return true;

            }
            return false;
        }



    }
}
