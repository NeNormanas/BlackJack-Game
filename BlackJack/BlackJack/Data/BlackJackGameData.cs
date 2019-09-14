using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Controllers
{
    public class BlackJackGameData
    {
        public Dealer Dealer { get; set; }
        public Player Player { get; set; }

        public BlackJackGameData()
        {
            Dealer = new Dealer();
            Player = new Player();

            Game(Dealer, Player);
        }

        public void Game(Dealer dealer, Player player)
        {
            Dealer = dealer;
            Player = player;

            for (int i = 0; i < 2; i++)
            {
                Player.RequestACard(Dealer.DealCard());
                Dealer.RequestACard(Dealer.DealCard());
            }
            Player.MyHand.AceInit();
            Dealer.MyHand.AceInit();

        }

        
        public void MakeBet(int betAmmount)
        {
            if (betAmmount > Player.Money)
            {
                Player.Money -= Player.Money;
            }
            else
            {
                Player.Money -= betAmmount;
            }
           
        }
        public void Split(Hand hand)
        {
            Hand SplitedHand_Left2 = new Hand();
            Hand SplitedHand_Right2 = new Hand();

            SplitedHand_Left2.AddACard(hand.Cards[0]);
            SplitedHand_Left2.AddACard(Dealer.DealCard());

            SplitedHand_Right2.AddACard(hand.Cards[1]);
            SplitedHand_Right2.AddACard(Dealer.DealCard());

            Player.Hands.Add(SplitedHand_Left2);
            Player.Hands.Add(SplitedHand_Right2);


        }
        public void Hit(Hand hand)
        {
            if (hand.ReturnValueOfMyHand() <= 21)
            {
                hand.AddACard(Dealer.DealCard());
                //DealACardToPlayer();
                //Player.MyHand.AceInit();
                hand.AceInit();
            }

        }
        public void Stand(Hand hand)
        {
            hand.AceInit();
            DealerTakesCardsTillSixteen();
            Dealer.MyHand.AceInit();
        }


        // BLACK JACK FUNKCIONALUMAS

        public bool CanPlayerSplit(Hand hand)
        {
            if (hand.ReturnValueOfOneCardCard(0) == hand.ReturnValueOfOneCardCard(1) || (hand.ReturnACard(0).Face == Face.Ace && hand.ReturnACard(1).Face == Face.Ace))
            {
                return true;
            }
            return false;
        }

        public void DealerTakesCardsTillSixteen()
        {
            while (Dealer.MyHand.ReturnValueOfMyHand() <= 16)
            {
                Dealer.RequestACard(Dealer.DealCard());
                Dealer.MyHand.AceInit();
            }
        }

    }

}

