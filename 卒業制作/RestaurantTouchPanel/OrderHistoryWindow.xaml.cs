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
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
    }
}
