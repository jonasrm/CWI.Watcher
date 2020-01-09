using CWI.Watcher.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CWI.Watcher.Models
{
    public class Sale
    {
        private const int _indexId = 1;
        private const int _indexSalesmanName = 3;
        private const int _indexItems = 2;

        public int Id { get; set; }
        public string SalesmanName { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public decimal TotalSalePrice => Items.Sum(s => s.TotalItemPrice);

        public Sale(string[] fields)
        {
            if (fields.Length != 4)
                throw new IndexOutOfRangeException("Fields not match with model.");

            Id = int.Parse(fields[_indexId]);
            SalesmanName = fields[_indexSalesmanName];

            string[] splitedItems = fields[_indexItems].Replace("[", "").Replace("]", "").Split(Domain.DelimiterItems);

            foreach (string item in splitedItems)
                Items.Add(new Item(item.Split(Domain.DelimiterItem)));
        }
    }
}
