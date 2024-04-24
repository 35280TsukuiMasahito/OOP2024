using SampleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product Karinto =new Product(123,"かりんとう",180);
            Product Daihuku = new Product(124, "大福", 200);
            Product Dorayaki = new Product(98, "どら焼き", 210);

            int price = Karinto.Price;
            int taxIncluded = Karinto.GetPriceIncludingTax();

            int dprice =Daihuku.Price;
            int dtaxIncluded=Daihuku.GetPriceIncludingTax();

            int doraprice = Dorayaki.Price;
            int dorayakiTax = Dorayaki.GetTax();

            Console.WriteLine(Karinto.Name+"の税込金額" + taxIncluded + "円" +" [税抜き"+price+"円]");
            Console.WriteLine(Daihuku.Name + "の税込金額" + dtaxIncluded + "円" + " [税抜き" + dprice + "円]");
            Console.WriteLine($"{dorayakiTax}円");
        }
    }
}
