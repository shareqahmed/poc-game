﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game
{
    public class ShopService
    {
        private static readonly ShopService _instance = new ShopService();

        public static ShopService Get()
        {
            return _instance;
        }

        //public void BuyStars(int stars, int forCoins)
        //{
        //    GameStateService.Get().State.Stars += stars;
        //    UseCoins(forCoins);
        //}

        //public void UseCoins(int coins)
        //{
        //    GameStateService.Get().State.Coins -= coins;
        //}
    }
}
