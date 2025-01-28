using System.Collections.Generic;
using System.Windows;

namespace RestaurantTouchPanel {
    public partial class OrderHistoryWindow : Window {
        public OrderHistoryWindow() {
            InitializeComponent();
            LoadOrderHistory();
        }

        private void LoadOrderHistory() {
            // データベースから注文履歴を取得
            var orderHistory = DatabaseManager.GetOrderHistory();
            OrderListView.ItemsSource = orderHistory; // ListView にデータをバインド
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            var menuWindow = new OrderWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
    }

    public class OrderHistory {
        public int Id { get; set; } // 注文ID
        public string Name { get; set; } // 商品名
        public int Quantity { get; set; } // 数量
        public int Price { get; set; } // 単価
        public int Total { get; set; } // 合計
        public string Status { get; set; } // ステータス（例: "調理中", "提供済み"）
    }

}
