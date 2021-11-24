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

        public void Withdraw(IReadOnlyList<IProductCell> products)
        {
            _warehouse.Withdraw(products);
        }

        public int GetAviableCount(Good good)
        {
            IProductCell cell = _warehouse.Cells.FirstOrDefault(cell => cell.Good.Equals(good));

            if (cell == null)
                throw new ArgumentNullException(nameof(cell));

            return cell.Count;
        }

        public string GeneratePayLink(IReadOnlyList<IProductCell> payItems)
        {
            string itemLink = string.Empty;
            foreach (var item in payItems)
                itemLink += string.Format("id=\"{0}\"&count={1}&", item.Good.Name, item.Count);

            return string.Format("https://pay.shop.net?{0}", itemLink);
        }
    }
}
