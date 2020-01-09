using CWI.Watcher.Shared;
using System;

namespace CWI.Watcher.Models
{
    public class Item
    {
        private const int _indexId = 0;
        private const int _indexQuantity = 1;
        private const int _indexPrice = 2;

        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalItemPrice => (Quantity * Price);

        public Item(string[] fields)
        {
            if (fields.Length != 3)
                throw new IndexOutOfRangeException("Fields not match with model.");

            Id = int.Parse(fields[_indexId]);
            Quantity = int.Parse(fields[_indexQuantity]);
            Price = decimal.Parse(fields[_indexPrice].Replace(Domain.DecimalSymbol, ","));
        }
    }
}
