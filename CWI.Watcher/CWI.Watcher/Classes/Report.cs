using CWI.Watcher.Models;
using CWI.Watcher.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CWI.Watcher.Classes
{
    public class Report
    {
        public void Generate()
        {
            if (Storage.FileNamesRead.Count == 0)
                return;

            string reportFile = Path.Combine(Domain.PathOut, $"Report-{DateTime.Now.ToString("yyyyMMdd-hhmmss")}.txt");

            using (StreamWriter report = new StreamWriter(reportFile))
            {
                report.WriteLine("Relatório - Análise de Vendas");
                report.WriteLine("-------------------------------------------");
                report.WriteLine("- Quantidade de clientes no arquivo de entrada: " + Storage.Customers.Count.ToString());
                report.WriteLine("- Quantidade de vendedores no arquivo de entrada: " + Storage.Sellers.Count.ToString());

                int idExpensiveSale = Storage.Sales
                    .OrderByDescending(o => o.TotalSalePrice)
                    .First()
                    .Id;

                report.WriteLine($"- ID da venda mais cara: {idExpensiveSale.ToString()}");

                string salesmanName = Storage.Sales
                    .GroupBy(g => g.SalesmanName)
                    .Select(s => new
                    {
                        Name = s.Key,
                        TotalSale = s.Sum(q => q.TotalSalePrice)
                    })
                    .OrderBy(o => o.TotalSale)
                    .First()
                    .Name;

                report.WriteLine($"- O pior vendedor: {salesmanName}");

                if (Storage.FileNamesRead.Count > 0)
                {
                    report.WriteLine("-------------------------------------------");
                    report.WriteLine("Arquivos analisados nesse relatório: " + String.Join(", ", Storage.FileNamesRead));
                }

                if (Storage.FileNamesErrors.Count > 0)
                {
                    report.WriteLine("-------------------------------------------");
                    report.WriteLine("Arquivos descartados por erro: " + String.Join(", ", Storage.FileNamesErrors));
                }
            }
        }
    }
}
