using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250515_DelegatesDemo
{
    public class Publisher
    {
        private NewIterationStarted _iterationStarted;
        private int _iterationCount;

        public Publisher(int iterationCount)
        {
            _iterationCount = iterationCount;
        }

        #region Subscribe / unsubscribe

        //public void Subscribe(NewIterationStarted handler)
        //{
        //    //_iterationStarted += handler;    // додавання обробника в ланцюжок викликів

        //    _iterationStarted = (NewIterationStarted)Delegate.Combine(_iterationStarted, handler);
        //}

        //public void UnSubscribe(NewIterationStarted handler)
        //{
        //    _iterationStarted -= handler;    // видалення обробника з ланцюжкя викликів
        //}

        #endregion

        #region Work with event

        //public event NewIterationStarted Started;
        public event NewIterationStarted Started
        {
            add    // Subscribe
            {
                // Validation
                _iterationStarted += value;
            }
            remove  // unsubscribe
            {
                // Validation
                _iterationStarted -= value;
            }
        }

        #endregion


        public void Run()
        {
            for (int i = 0; i < _iterationCount; i++)
            {
                if (_iterationStarted != null)
                {
                    _iterationStarted(i);    // Call callback functions
                }

                Console.WriteLine($"iteration: {i}");
            }
        }
    }
}
