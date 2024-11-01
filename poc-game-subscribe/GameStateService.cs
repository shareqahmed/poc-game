using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game_subscribe
{
    public class GameStateService
    {
        private GameState _gameState = new GameState();

        public GameStateService()
        {

            _gameState.Subscribe("Coins", () => CoinsChanged());
            _gameState.Subscribe("Stars", () => StarsChanged());

        }



        public void Init(int coins, int stars)
        {
            using (var scope = new TransactionScope(_gameState))
            {
                _gameState.Coins = coins;
                _gameState.Stars = stars;
            }
            Console.WriteLine("Initialization transaction completed.");
        }

        public void BuyStars(int stars, int price)
        {
            using (var scope = new TransactionScope(_gameState))
            {
                _gameState.Coins -= price;
                _gameState.Stars += stars;
            }
            Console.WriteLine("Buying stars transaction completed.");
        }


        private void CoinsChanged()
        {
            Console.WriteLine($"Observer: Coins have changed to {_gameState.Coins}.");
        }

        private void StarsChanged()
        {
            Console.WriteLine($"Observer: Stars have changed to {_gameState.Stars}.");
        }

        public GameState State
        {
            get { return _gameState; }
        }
    }

}
