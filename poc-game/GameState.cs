using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_game
{
    public class GameState
    {



        // improvements
        private bool _inTransaction = false;
        private bool _coinsChanged = false;
        private bool _starsChanged = false;

        private int _stars;
        private int _coins;
        public event Action CoinsChanged = () => { };
        public event Action StarsChanged = () => { };

        // scoped
        //public int Coins
        //{
        //    get => _coins;
        //    set
        //    {
        //        if (_coins != value)
        //        {
        //            _coins = value;
        //            if (_inTransaction)
        //            {
        //                _coinsChanged = true;
        //            }
        //            else
        //            {
        //                CoinsChanged();
        //            }

        //        }
        //    }
        //}



        //public int Stars
        //{
        //    get => _stars;
        //    set
        //    {
        //        if (_stars != value)
        //        {
        //            _stars = value;
        //            if (_inTransaction)
        //            {
        //                _starsChanged = true;

        //            }

        //            else
        //            {
        //                StarsChanged();
        //            }
        //        }
        //    }
        //}



        //public void BeginTransaction()
        //{
        //    Console.WriteLine("Transaction started.");
        //    _inTransaction = true;
        //}

        //public void EndTransaction()
        //{
        //    Console.WriteLine("Attempting to commit transaction.");
        //    _inTransaction = false;
        //    if (_coinsChanged)
        //    {
        //        Console.WriteLine("Notifying about coin change.");
        //        CoinsChanged();
        //        _coinsChanged = false;
        //    }
        //    if (_starsChanged)
        //    {
        //        Console.WriteLine("Notifying about stars change.");
        //        StarsChanged();
        //        _starsChanged = false;
        //    }
        //}



        //// for central
        private TransactionManager _transactionManager = new TransactionManager();
        public int Coins
        {
            get => _coins;
            set
            {
                if (_coins != value)
                {
                    _coins = value;
                    _transactionManager.RegisterChange(CoinsChanged);
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
                    _transactionManager.RegisterChange(StarsChanged);
                }
            }
        }

        public void BeginTransaction()
        {
            _transactionManager.BeginTransaction();
        }

        public void EndTransaction()
        {
            _transactionManager.EndTransaction();
        }
    }
}