using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game_subscribe
{
    public class GameState
    {
        private bool _inTransaction = false;
        private bool _coinsChanged = false;
        private bool _starsChanged = false;

        private int _stars;
        private int _coins;
        public event Action CoinsChanged = () => { };
        public event Action StarsChanged = () => { };
        private Dictionary<string, List<Action>> _subscriptions = new Dictionary<string, List<Action>>();


        public int Coins
        {
            get => _coins;
            set
            {
                if (_coins != value)
                {
                    _coins = value;
                    if (_inTransaction)
                    {
                        _coinsChanged = true;
                    }
                    else
                    {
                        NotifySubscribers(nameof(Coins));
                    }
                }
            }
        }

        public int Stars
        {
            get => _stars;
            set
            {
                if (_stars != value)
                {
                    _stars = value;
                    if (_inTransaction)
                    {
                        _starsChanged = true;
                    }
                    else
                    {
                        NotifySubscribers(nameof(Stars));
                    }
                }
            }
        }

        public void Subscribe(string propertyName, Action handler)
        {
            if (!_subscriptions.ContainsKey(propertyName))
            {
                _subscriptions[propertyName] = new List<Action>();
            }
            _subscriptions[propertyName].Add(handler);
        }

        public void Unsubscribe(string propertyName, Action handler)
        {
            if (_subscriptions.ContainsKey(propertyName))
            {
                _subscriptions[propertyName].Remove(handler);
            }
        }

        private void NotifySubscribers(string propertyName)
        {
            if (_subscriptions.ContainsKey(propertyName))
            {
                foreach (var subscriber in _subscriptions[propertyName])
                {
                    subscriber.Invoke();
                }
            }
        }

        public void BeginTransaction()
        {
            Console.WriteLine("Transaction started.");
            _inTransaction = true;
        }

        public void EndTransaction()
        {
            Console.WriteLine("Attempting to commit transaction.");
            _inTransaction = false;
            if (_coinsChanged)
            {
                NotifySubscribers(nameof(Coins));
                _coinsChanged = false;
            }
            if (_starsChanged)
            {
                NotifySubscribers(nameof(Stars));
                _starsChanged = false;
            }
        }

    }

}
