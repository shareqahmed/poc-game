using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game
{
    public class TransactionScope : IDisposable
    {
        private List<Action> _pendingNotifications = new List<Action>();
        private GameState _gameState;
        
        public TransactionScope(GameState gameState)
        {
            _gameState = gameState;
            _gameState.BeginTransaction();
        }


        //public void RegisterNotification(Action notificationAction)
        //{
        //    _pendingNotifications.Add(notificationAction);
        //}


        public void Dispose()
        {
            _gameState.EndTransaction();
            //foreach (var notify in _pendingNotifications)
            //{
            //   notify.Invoke();
            //}
            //_pendingNotifications.Clear();
        }
    }

}
