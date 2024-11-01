using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game_subscribe
{
    public class TransactionScope : IDisposable
    {
        private GameState _gameState;

        public TransactionScope(GameState gameState)
        {
            _gameState = gameState;
            _gameState.BeginTransaction();
        }

        public void Dispose()
        {
            _gameState.EndTransaction();
        }
    }
}
