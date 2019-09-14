using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Viev
{
    public class RenderTool
    {
        public void PrintBetMenu(int money)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player Money: ${money}");
            Console.WriteLine($"Type BET ammount: ");
            Console.ResetColor();
        }

        public void ShowWrongSelectionError()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("WRONG SELECTION TRY Again: ");
            Console.ResetColor();
            Console.WriteLine();

        }

        public void ShowPlayerHandCards(Hand hand)
        {
            int _cardNr = 0;
            Console.WriteLine();
            foreach (var card in hand.Cards)
            {
                _cardNr++;
                Console.WriteLine($"PLAYER Card_{_cardNr} : " + card.Face.ToString() + " " + card.Suit.ToString());
            }
        }

        public void ShowDealerHiddenHandCards(Card card)
        {
            Console.WriteLine();
            Console.WriteLine($"DEALER Card_1 : {card.Face.ToString() + " " + card.Suit.ToString()}");
            Console.WriteLine($"DEALER Hidden : XXX");
        }

        public void ShowDealerFirstCardValue(Card card)
        {
            Console.WriteLine();
            Console.WriteLine($"Dealer First Card value: {card.Value}");
        }

        public void ShowPlayerHandValue(Hand hand)
        {
            Console.WriteLine();
            Console.WriteLine($"Player Hand value: {hand.ReturnValueOfMyHand()}");
        }

        public void ShowFullMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Select your choise: 1. STAND   2. HIT  3. SPLIT");
            Console.ResetColor();
        }

        public void ShowTwoOptionsMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Select your choise:  1. STAND  2. HIT ");
            Console.ResetColor();
        }

        public void PrintResults(List<Hand> list, Dealer dealer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RESULTS: ");
            Console.ResetColor();
            Console.WriteLine();

            foreach (var hand in list)
            {
                Console.WriteLine();
                Console.WriteLine("HAND RESULT: ");
                Console.WriteLine();
                int _playerCardnr = 0;
                foreach (var item in hand.Cards)
                {
                    _playerCardnr++;
                    Console.WriteLine($"Player {_playerCardnr} card: " + item.Face.ToString() + " " + item.Suit.ToString());
                }
                
                
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TOTAL PLAYER VALUE: " + hand.ReturnValueOfMyHand());
                Console.ResetColor();
                Console.WriteLine();

                int _dealerCardnr = 0;
                foreach (var item in dealer.MyCards)
                {
                    _dealerCardnr++;
                    Console.WriteLine($"Dealer {_dealerCardnr} card: " + item.Face.ToString() + " " + item.Suit.ToString());
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TOTAL DEALER VALUE: " + dealer.MyHand.ReturnValueOfMyHand());
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(BlackJackCalculator.Winner(hand, dealer));
                Console.ResetColor();
                Console.WriteLine();
            }


        }


    }
}
