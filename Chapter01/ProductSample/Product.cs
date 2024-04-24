using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp {
    public class Product {

        public int Code { get; set; } //商品コード  自動実装プロパティ
        public string Name { get; set; } //商品名
        public int Price { get; set; } //商品価格(税抜き)
        

        //消費税額を求める(消費税額は10%)
        public int GetTax() {
            return (int)(Price*0.1);
        }
        //税込価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
        //コンストラクタ
        public Product(int Code, String Name, int Price) {
            this.Code = Code;
            this.Name = Name;
            this.Price = Price;
        }
    }
}
