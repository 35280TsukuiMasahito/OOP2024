using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantTouchPanel {
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application {
        public static int PeopleCount { get; set; } = 1; // デフォルト値として 1 人を設定
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            DatabaseManager.InitializeDatabase();
        }
    }
}

