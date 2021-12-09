using System.Collections.Generic;

namespace Napilnik.Shop
{
    interface IShop
    {
        public void Withdraw(IReadOnlyDictionary<Good, int> products);
        public int GetAviableCount(Good good);
        public string GeneratePayLink(IReadOnlyDictionary<Good, int> payItems);
    }
}
