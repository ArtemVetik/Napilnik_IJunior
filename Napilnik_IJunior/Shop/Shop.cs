using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik.Shop
{
    class Shop : IShop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
        }

        public Cart Cart()
        {
            return new Cart(this);
        }

        public void Withdraw(IReadOnlyDictionary<Good, int> products)
        {
            _warehouse.Withdraw(products);
        }

        public int GetAviableCount(Good good)
        {
            var pair = _warehouse.Goods.FirstOrDefault(pair => pair.Key.Equals(good));

            if (pair.Equals(default(KeyValuePair<Good, int>)))
                throw new InvalidOperationException("The product is out of stock");

            return pair.Value;
        }

        public string GeneratePayLink(IReadOnlyDictionary<Good, int> payItems)
        {
            string itemLink = string.Empty;
            foreach (var item in payItems)
                itemLink += string.Format("id=\"{0}\"&count={1}&", item.Key.Name, item.Value);

            return string.Format("https://pay.shop.net?{0}", itemLink);
        }
    }
}
