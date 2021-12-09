using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Napilnik.Shop
{
    class Cart
    {
        private readonly IShop _shop;
        private readonly Dictionary<Good, int> _payItems;

        public Cart(IShop shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _shop = shop;
            _payItems = new Dictionary<Good, int>();
        }

        public IReadOnlyDictionary<Good, int> Items => _payItems;

        public void Add(Good good, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            int aviableCount = _shop.GetAviableCount(good);
            var pair = _payItems.FirstOrDefault(pair => pair.Key.Equals(good));

            if (pair.Value + count > aviableCount)
                throw new InvalidOperationException("There is not enough product in the store");

            if (pair.Equals(default(KeyValuePair<Good, int>)))
                _payItems[good] = count;
            else
                _payItems[pair.Key] = pair.Value + count; 
        }

        public Order Order()
        {
            _shop.Withdraw(_payItems);
            return new Order(_shop, _payItems);
        }
    }
}
