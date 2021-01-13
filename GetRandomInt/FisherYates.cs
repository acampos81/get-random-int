using System;
using System.Collections.Generic;
namespace GetRandomInt
{
    public class FisherYates
    {
        private Random _rnd;
        private int _index;
        private List<int> _valueRange;
        
        public Action OnNumbersComplete;

        public FisherYates(int min, int max)
        {
            _rnd = new Random();
            InitValueRange(min, max);
        }

        public void AddCompleteCallback(Action callback)
        {
            OnNumbersComplete = callback;
        }

        public int GetRandomInt()
        {
            if (_index == _valueRange.Count)
            {
                _index = 0;
                Shuffle(_valueRange);
            }

            return _valueRange[_index++];
        }

        private void InitValueRange(int min, int max)
        {
            _valueRange = new List<int>();

            var count = (max - min)+1;

            for (int i = 0; i < count; i++)
                _valueRange.Add(min + i);

            Shuffle(_valueRange);
        }

        // Fisher-Yates Shuffle with complexity of O(n)
        // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle#The_modern_algorithm
        private void Shuffle(List<int> list)
        {
            if (OnNumbersComplete != null)
                OnNumbersComplete();

            var count = list.Count;
            while (count > 1)
            {
                count--;
                var i = _rnd.Next(count + 1);
                var val = list[i];
                list[i] = list[count];
                list[count] = val;
            }
        }
    }
}
