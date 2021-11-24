using System;
using System.Collections.Generic;
using System.Collections;

namespace Napilnik.Shop
{
    class Cart : IEnumerable<IProductCell>
    {
        private readonly IShop _shop;
        private List<Cell> _payItems;

        public Cart(IShop shop)
        {
            if (shop == null)
                throw new ArgumentNullException(nameof(shop));

            _shop = shop;
            _payItems = new List<Cell>();
        }

        public IReadOnlyList<IProductCell> Items => _payItems;

        public void Add(Good good, int count)
        {
            var newCell = new Cell(good, count);
            int cellIndex = _payItems.FindIndex(cell => cell.Good.Equals(good));

            int aviableCount = _shop.GetAviableCount(good);
            int countInCart = cellIndex < 0 ? 0 : _payItems[cellIndex].Count;

            if (countInCart + count > aviableCount)
                throw new InvalidOperationException();

            if (cellIndex < 0)
                _payItems.Add(newCell);
            else
                _payItems[cellIndex].Merge(newCell);
        }

        public Order Order()
        {
            _shop.Withdraw(_payItems);
            return new Order(_shop, _payItems);
        }

        public IEnumerator<IProductCell> GetEnumerator()
        {
            foreach (var cell in _payItems)
                yield return cell;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}
