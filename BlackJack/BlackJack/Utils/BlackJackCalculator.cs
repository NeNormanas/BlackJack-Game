using BlackJack.Controllers;
using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    static class BlackJackCalculator
    {
        public static int _moneyWinnedWithBet = 0;
        public static int _moneyLost = 0;
        public static int _moneyWinned = 0;

        public static int TakeChoise()
        {
            try
            {
                return Int32.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Wrong Choise!");
                return 0;
            }
        }
        public static int ReturnMoneyAfterRoundPlayed(List<Hand> hands, Dealer dealer, Player player, int bet)
        {
            int _money = player.Money;

            foreach (var item in hands)
            {
                var temp = Winner(item, dealer);

                if (temp == BlackJack.Winner.DealerWins)
                {
                    _moneyWinnedWithBet = 0;
                    _moneyLost = bet;
                }
                if (temp == BlackJack.Winner.PlayerWins)
                {
                    _moneyWinnedWithBet += bet * 2;
                    _moneyWinned += bet;
                }
                if (temp == BlackJack.Winner.Draw)
                {
                    _moneyWinnedWithBet += bet / 2;
                    _moneyWinned += bet/2;
                }
            }

            return _money + _moneyWinnedWithBet;
        }
        public static Winner Winner(Hand hand, Dealer dealer)
        {
            if (hand.ReturnValueOfMyHand() == dealer.CalculateValueOfMyCards() ||
                (hand.ReturnValueOfMyHand() > 21 && dealer.CalculateValueOfMyCards() > 21))
            {
                if (hand.ReturnValueOfMyHand() > 21 && dealer.CalculateValueOfMyCards() > 21)
                {
                    return BlackJack.Winner.DealerWins;
                }
                return BlackJack.Winner.Draw;
            }
            else if (hand.ReturnValueOfMyHand() > dealer.CalculateValueOfMyCards())
            {
                if (hand.ReturnValueOfMyHand() < 22)
                {

                    return BlackJack.Winner.PlayerWins;
                }
                return BlackJack.Winner.DealerWins;
            }
            else if (dealer.CalculateValueOfMyCards() > hand.ReturnValueOfMyHand())
            {
                if (dealer.CalculateValueOfMyCards() < 22)
                {
                    return BlackJack.Winner.DealerWins;
                }

                return BlackJack.Winner.PlayerWins;
            }

            else
            {
                return BlackJack.Winner.Error;
            }



        }
    }

}
