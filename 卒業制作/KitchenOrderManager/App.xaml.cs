using System;
using System.Windows;

namespace KitchenOrderManager {
    public partial class App : Application {
        public static int PeopleCount { get; set; } = 1; // ✅ 初期値を1人に設定

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            DatabaseManager.InitializeDatabase(); // データベース初期化 (RestaurantTouchPanelからコピー)
        }
    }
}
