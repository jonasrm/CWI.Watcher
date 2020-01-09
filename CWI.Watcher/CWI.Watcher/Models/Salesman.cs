using CWI.Watcher.Shared;
using System;

namespace CWI.Watcher.Models
{
    public class Salesman
    {
        private const int _indexCPF = 1;
        private const int _indexName = 2;
        private const int _indexSalary = 3;

        public string CPF { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Salesman(string[] fields)
        {
            if (fields.Length != 4)
                throw new IndexOutOfRangeException("Fields do not match model.");

            CPF = fields[_indexCPF];
            Name = fields[_indexName];
            Salary = decimal.Parse(fields[_indexSalary].Replace(Domain.DecimalSymbol, ","));
        }
    }
}
