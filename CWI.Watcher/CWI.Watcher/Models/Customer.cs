using System;

namespace CWI.Watcher.Models
{
    public class Customer
    {
        private const int _indexCNPJ = 1;
        private const int _indexName = 2;
        private const int _indexBusinessArea = 3;

        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }

        public Customer(string[] fields)
        {

            if (fields.Length != 4)
                throw new IndexOutOfRangeException("Fields not match with model.");

            CNPJ = fields[_indexCNPJ];
            Name = fields[_indexName];
            BusinessArea = fields[_indexBusinessArea];
        }

    }
}
