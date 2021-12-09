using System;

namespace Napilnik.Shop
{
    class Good : IEquatable<Good>
    {
        private readonly string _name;

        public Good(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            _name = name;
        }

        public string Name => _name;

        public bool Equals(Good other)
        {
            return _name == other.Name;
        }
    }
}
