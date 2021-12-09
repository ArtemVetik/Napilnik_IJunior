using System;
using System.Collections.Generic;

namespace Napilnik.Shop
{
    class Order
    {
        private readonly IShop _shop;
        private readonly IReadOnlyDictionary<Good, int> _payItems;

        public Order(IShop shop, IReadOnlyDictionary<Good, int> payItems)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));
            if (payItems == null)
                throw new ArgumentNullException(nameof(payItems));

            _shop = shop;
            _payItems = payItems;
        }

        public string Paylink => _shop.GeneratePayLink(_payItems);
    }
}
