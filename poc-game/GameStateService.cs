using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace poc_game
{
    public class GameStateService
    {
        private GameState _gameState = new GameState();

        public GameStateService() 
        {


           
            _gameState.CoinsChanged += CoinsChanged;
            _gameState.StarsChanged += StarsChanged;
            
        }

        // transaction manager 
        public void Init(int coins, int stars)
        {
            _gameState.BeginTransaction();
            _gameState.Coins = coins;
            _gameState.Stars = stars;
            _gameState.EndTransaction();
        }



        public void BuyStars(int stars, int price)
        {
            _gameState.BeginTransaction();
            _gameState.Coins -= price; // Trigger CoinsChanged
            _gameState.Stars += stars; // Trigger StarsChanged
            _gameState.EndTransaction();
        }


        // scoped
        //public void Init(int coins, int stars)
        //{
        //    using (var scope = new TransactionScope(_gameState))
        //    {
        //        _gameState.Coins = coins;
        //        _gameState.Stars = stars;

        //       // scope.RegisterNotification(() => Console.WriteLine("Transaction completed with changes."));
        //    }


        //}
        //public void BuyStars(int stars, int price)
        //{
        //    using (var scope = new TransactionScope(_gameState))
        //    {
        //        _gameState.Coins -= price; // Triggers CoinsChanged if necessary
        //        _gameState.Stars += stars; // Triggers StarsChanged if necessary

        //        //scope.RegisterNotification(() => Console.WriteLine("Transaction completed with changes."));
        //    }
        //}


        private void CoinsChanged()
        {
            Console.WriteLine($"Observer: Coins have changed to {_gameState.Coins}.");
        }


        private void StarsChanged()
        {
            Console.WriteLine($"Observer: Stars have changed to {_gameState.Stars}.");
            // More complex operations here
        }

        public GameState State
        {
            get { return _gameState; }
        }
    }
}
