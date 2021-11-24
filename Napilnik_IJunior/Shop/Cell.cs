using System;

namespace Napilnik.Shop
{
    class Cell : IProductCell
    {
        private Good _good;
        private int _count;

        public Cell(Good good, int count)
        {
            if (good == null)
                throw new ArgumentNullException(nameof(good));
            if (count < 0)
                throw new ArgumentException(nameof(count));

            _good = good;
            _count = count;
        }

        public Good Good => _good;
        public int Count => _count;

        public void Merge(IProductCell other)
        {
            if (_good.Equals(other.Good) == false)
                throw new InvalidOperationException();

            _count += other.Count;
        }

        public void Detach(IProductCell other)
        {
            if (_good.Equals(other.Good) == false)
                throw new InvalidOperationException();
            if (_count < other.Count)
                throw new InvalidOperationException();

            _count -= other.Count;
        }
    }

}
