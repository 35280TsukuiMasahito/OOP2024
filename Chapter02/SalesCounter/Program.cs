using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    internal class Program {
        static void Main(string[] args) {

            SalesCounter sales = new SalesCounter(ReadSales("data/sales.csv"));
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            foreach(KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine("{0},{1}",obj.Key,obj.Value);
            }
        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);
            }
            return sales;
        }

    }
}
