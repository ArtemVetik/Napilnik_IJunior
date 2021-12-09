using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Napilnik.Shop
{
    class Warehouse
    {
        private readonly Dictionary<Good, int> _goods;

        public Warehouse()
        {
            _goods = new Dictionary<Good, int>();
        }

        public IReadOnlyDictionary<Good, int> Goods => _goods;

        public void Delive(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            var pair = _goods.FirstOrDefault(pair => pair.Key.Equals(good));

            if (pair.Equals(default(KeyValuePair<Good, int>)))
                _goods[good] = count;
            else
                _goods[pair.Key] = pair.Value + count;
        }

        public void Withdraw(IReadOnlyDictionary<Good, int> products)
        {
            foreach (var product in products)
            {
                if (_goods.ContainsKey(product.Key) == false)
                    throw new InvalidOperationException();

                if (_goods[product.Key] < product.Value)
                    throw new InvalidOperationException();
            }

            foreach (var product in products)
                _goods[product.Key] -= product.Value;
        }
    }
}
