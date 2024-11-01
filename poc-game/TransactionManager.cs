using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game
{
    public class TransactionManager
    {
        private bool _inTransaction = false;
        private List<Action> _pendingNotifications = new List<Action>();

        public void BeginTransaction()
        {
            _inTransaction = true;
        }

        public void EndTransaction()
        {
            foreach (var notify in _pendingNotifications)
            {
                notify.Invoke();
            }
            _pendingNotifications.Clear();
            _inTransaction = false;
        }

        public void RegisterChange(Action notificationAction)
        {
            if (_inTransaction)
            {
                _pendingNotifications.Add(notificationAction);
            }
            else
            {
                notificationAction.Invoke();
            }
        }
    }

}
