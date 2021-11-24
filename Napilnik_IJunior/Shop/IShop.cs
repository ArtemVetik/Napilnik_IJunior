using System.Collections.Generic;

namespace Napilnik.Shop
{
    interface IShop
    {
        public void Withdraw(IReadOnlyList<IProductCell> products);
        public int GetAviableCount(Good good);
        public string GeneratePayLink(IReadOnlyList<IProductCell> payItems);
    }
}
