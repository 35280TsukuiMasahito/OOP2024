using System;
using System.Windows;

namespace RestaurantTouchPanel {
    public partial class App : Application {
        public static int PeopleCount { get; set; } = 1; // デフォルト値として 1 人を設定

        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            DatabaseManager.InitializeDatabase();
        }
    }
}
