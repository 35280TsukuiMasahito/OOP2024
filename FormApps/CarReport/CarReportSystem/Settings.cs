using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static Settings? instance;  //自分自身のインスタンスを格納

        public int MainFormColor { get; set; }
        
        //コンストラクタ(privateにすることによりnewできなくなる)
        private Settings() { }

        //自インスタンスを返却するメソッド
        public static Settings GetInstance() {
            if(instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
