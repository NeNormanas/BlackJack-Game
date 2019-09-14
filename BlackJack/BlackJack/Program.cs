using BlackJack.Controllers;
using BlackJack.Data;
using System;
using System.Collections.Generic;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
                GameController Controller = new GameController();
                Controller.StartGameController();
        }
    }
}
