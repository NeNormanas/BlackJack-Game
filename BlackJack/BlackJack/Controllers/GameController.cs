using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BlackJack.Viev;

namespace BlackJack.Controllers
{
    internal class GameController
    {
        // Variables
        private RenderTool _renderTool;
        private BlackJackGameData _blackJackGame;
        private List<Hand> _playedHandsList;

        //Controller
        public GameController()
        {
            _renderTool = new RenderTool();
        }

        //Methods
        public void StartGameController()
        {
            int _playerMoney = 1000; // galima padaryti ir kad pats zaidejas inesa, su kiek nori zaisti
            int _playerBet = 0;
            bool _playGame = true;
            int _roundsPlayed = 0;

            while (_playGame)
            {
                _blackJackGame = new BlackJackGameData();

                #region TAKING BETS
              
                _blackJackGame.Player.Money = _playerMoney;
                _renderTool.PrintBetMenu(_playerMoney);

                try
                {
                    _playerBet = Int32.Parse(Console.ReadLine());
                    if (_playerBet > _playerMoney) // jei pastatoma daugiau negu turi zaidejas, tai prilyginama all in.
                    {
                        _playerBet = _playerMoney;
                    }
                }
                catch (Exception)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("With This input you can not bet :), Try again!");
                    Console.ResetColor();
                    continue;
                }

                _blackJackGame.MakeBet(_playerBet);
                _playerMoney = _blackJackGame.Player.Money;

                #endregion

                _playedHandsList = new List<Hand>();
                _blackJackGame.Player.Hands.Add(_blackJackGame.Player.MyHand);

                while (_blackJackGame.Player.Hands.Count > _blackJackGame.Player.MyHand.CurrentCardNr)
                {
                    StartGame(_blackJackGame.Player.Hands[_blackJackGame.Player.MyHand.CurrentCardNr]);
                }

                #region STATISTICS AND RESULTS PRINTING

                _roundsPlayed++;
                _renderTool.PrintResults(_playedHandsList, _blackJackGame.Dealer);

                _playerMoney = BlackJackCalculator.ReturnMoneyAfterRoundPlayed(_playedHandsList, _blackJackGame.Dealer, _blackJackGame.Player, _playerBet);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("STATISTICS:");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine($"Rounds Played:{_roundsPlayed}");
                Console.WriteLine($"You have Earned: ${BlackJackCalculator._moneyWinned}");
                Console.WriteLine($"You have Lost: ${BlackJackCalculator._moneyLost}");
                Console.WriteLine($"Your Account Money: ${_playerMoney}");
                #endregion

                Console.WriteLine();
                Console.WriteLine("Want to play again?  Press Y");
                string _choise = Console.ReadLine();

                switch (_choise)
                {
                    case "Y":
                    case "y":
                        _playGame = true;
                        break;
                    default:
                        _playGame = false;
                        break;
                }
                Console.Clear();
            }
        }

        private void StartGame(Hand hand) // pradedams zaidimas paduodant HAND t.y. 2 kortas.
        {
            _renderTool.ShowPlayerHandCards(hand);
            _renderTool.ShowPlayerHandValue(hand);

            _renderTool.ShowDealerHiddenHandCards(_blackJackGame.Dealer.MyHand.Cards[0]);
            _renderTool.ShowDealerFirstCardValue(_blackJackGame.Dealer.MyHand.Cards[0]);

            bool _again = true;
            int _actionChoise;

            if (_blackJackGame.CanPlayerSplit(hand))
            {
                _renderTool.ShowFullMenu();
                _actionChoise = BlackJackCalculator.TakeChoise();
                if (_actionChoise != 1 && _actionChoise != 2 && _actionChoise != 3)
                {
                    Console.WriteLine("CHOISE NOT EXISTS!");
                    _again = false;
                }
            }
            else
            {
                _renderTool.ShowTwoOptionsMenu();
                _actionChoise = BlackJackCalculator.TakeChoise();
                if (_actionChoise != 1 && _actionChoise != 2)
                {
                    Console.WriteLine("CHOISE NOT EXISTS!");
                    _again = false;
                }
            }

            while (_again)
            {
                switch (_actionChoise)
                {
                    case (int)PlayerActions.Stand:

                        _blackJackGame.Stand(hand);

                        Console.WriteLine();

                        _playedHandsList.Add(hand);

                        _blackJackGame.Player.Hands.Remove(hand);

                        _again = false;

                        break;

                    case (int)PlayerActions.Hit:

                        _blackJackGame.Hit(hand);

                        _renderTool.ShowPlayerHandCards(hand);
                        _renderTool.ShowPlayerHandValue(hand);

                        if (hand.ReturnValueOfMyHand() > 20)
                        {
                            _actionChoise = 1;
                        }
                        else
                        {
                            _renderTool.ShowTwoOptionsMenu();
                            _actionChoise = BlackJackCalculator.TakeChoise();
                        }

                        _again = true;

                        break;

                    case (int)PlayerActions.Split:


                        _blackJackGame.Split(hand);
                        _blackJackGame.Player.MyHand.CurrentCardNr++;


                        _again = false;
                        break;

                    default:
                        _renderTool.ShowWrongSelectionError();
                        _again = false;
                        break;
                }
            }
        }



    }
}



