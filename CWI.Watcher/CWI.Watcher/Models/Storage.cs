using System;
using System.Collections.Generic;

namespace CWI.Watcher.Models
{
    public static class Storage
    {
        private const int _indexType = 0;
        private const string _typeSalesman = "001";
        private const string _typeCustomer = "002";
        private const string _typeSale = "003";       

        public static List<string> FileNamesRead { get; set; } = new List<string>();
        public static List<string> FileNamesErrors { get; set; } = new List<string>();
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Sale> Sales { get; set; } = new List<Sale>();
        public static List<Salesman> Sellers { get; set; } = new List<Salesman>();

        /// <summary>
        /// Clear Storage
        /// </summary>
        public static void Clear()
        {
            FileNamesRead.Clear();
            FileNamesErrors.Clear();
            Customers.Clear();
            Sales.Clear();
            Sellers.Clear();
        }

        /// <summary>
        /// Add data according to the fields
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fields"></param>
        public static void Add(string[] fields)
        {
            if (fields.Length == 0)
                throw new ArgumentOutOfRangeException("Fields are empty.");

            switch (fields[_indexType])
            {
                case _typeSalesman:
                    Sellers.Add(new Salesman(fields));
                    break;
                case _typeCustomer:
                    Customers.Add(new Customer(fields));
                    break;
                case _typeSale:
                    Sales.Add(new Sale(fields));
                    break;
                default:
                    throw new InvalidOperationException("Unknown record type.");
            }
        }
    }
}
