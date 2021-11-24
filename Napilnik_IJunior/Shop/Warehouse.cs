using System.Collections.Generic;
using System.Collections;

namespace Napilnik.Shop
{
    class Warehouse : IEnumerable<IProductCell>
    {
        private readonly List<Cell> _cells;

        public Warehouse()
        {
            _cells = new List<Cell>();
        }

        public IReadOnlyList<IProductCell> Cells => _cells;

        public void Delive(Good good, int count)
        {
            var newCell = new Cell(good, count);
            int cellIndex = _cells.FindIndex(cell => cell.Good.Equals(good));

            if (cellIndex < 0)
                _cells.Add(newCell);
            else
                _cells[cellIndex].Merge(newCell);
        }

        public void Withdraw(IReadOnlyList<IProductCell> products)
        {
            foreach (var product in products)
            {
                var cell = _cells.Find(cell => cell.Good.Equals(product.Good));
                cell.Detach(product);
            }
        }

        public IEnumerator<IProductCell> GetEnumerator()
        {
            foreach (var cell in _cells)
                yield return cell;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return GetEnumerator();
        }
    }
}
