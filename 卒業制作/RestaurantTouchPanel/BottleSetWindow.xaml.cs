using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class BottleSetWindow : Window {
        private const int MaxOrderTypes = 7; // 注文の種類数の制限

        public BottleSetWindow() {
            InitializeComponent();
            this.Loaded += BottleSetWindow_Loaded;
        }

        private void BottleSetWindow_Loaded(object sender, RoutedEventArgs e) {
            UpdateOrderList();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            if (OrderManager.Instance.OrderItems.Count >= MaxOrderTypes) {
                MessageBox.Show($"注文は{MaxOrderTypes}種類までです。", "注文制限", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (sender is Button button) {
                string productName = "";
                int productPrice = 0;

                switch (button.Tag) {
                    case "1":
                        productName = "ミネラルウォーター";
                        productPrice = 200;
                        break;
                    case "2":
                        productName = "炭酸水";
                        productPrice = 200;
                        break;
                    case "3":
                        productName = "アイス";
                        productPrice = 150;
                        break;
                    case "4":
                        productName = "カットレモン";
                        productPrice = 200;
                        break;
                    case "5":
                        productName = "スライスレモン";
                        productPrice = 200;
                        break;
                    case "6":
                        productName = "梅干し";
                        productPrice = 200;
                        break;
                }

                var existingItem = OrderManager.Instance.OrderItems
                    .FirstOrDefault(item => item.Name == productName);

                if (existingItem != null) {
                    existingItem.Quantity++;
                } else {
                    OrderManager.Instance.OrderItems.Add(new OrderItem(productName, 1, productPrice));
                }

                UpdateOrderList();
            }
        }

        private void UpdateOrderList() {
            OrderListBox.Items.Clear();
            foreach (var item in OrderManager.Instance.OrderItems) {
                OrderListBox.Items.Add(item.ToString());
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e) {
            if (OrderListBox.SelectedItem is string selectedItem) {
                var selectedName = selectedItem.Split('-')[0].Trim();
                var item = OrderManager.Instance.OrderItems.FirstOrDefault(i => i.Name == selectedName);
                if (item != null) {
                    item.Quantity++;
                    UpdateOrderList();
                }
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e) {
            if (OrderListBox.SelectedItem is string selectedItem) {
                var selectedName = selectedItem.Split('-')[0].Trim();
                var item = OrderManager.Instance.OrderItems.FirstOrDefault(i => i.Name == selectedName);
                if (item != null) {
                    if (item.Quantity > 1) {
                        item.Quantity--;
                    } else {
                        OrderManager.Instance.OrderItems.Remove(item);
                    }
                    UpdateOrderList();
                }
            }
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e) {
            SaveOrdersToDatabase();
            OrderManager.Instance.ClearOrders();
            UpdateOrderList();

            MessageBox.Show("注文が確定しました。ありがとうございました！", "確認", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ClearOrders_Click(object sender, RoutedEventArgs e) {
            OrderManager.Instance.ClearOrders();
            UpdateOrderList();
        }

        private void SaveOrdersToDatabase() {
            foreach (var order in OrderManager.Instance.OrderItems) {
                DatabaseManager.SaveOrder(order.Name, order.Quantity, order.Price);
            }
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string content = button.Content.ToString();

                if (content == "トップ画面") {
                    var mainMenu = new MainWindow();
                    mainMenu.Show();
                    this.Close();
                } else {
                    MessageBox.Show($"{content} カテゴリが選択されました。", "カテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void SubCategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string subCategory = button.Content.ToString();

                if (subCategory == "酎ハイ") {
                    var shochuWindow = new ShochuWindow();
                    shochuWindow.Show();
                } else if (subCategory == "日本酒") {
                    var sakeWindow = new SakeWindow();
                    sakeWindow.Show();
                } else if (subCategory == "ボトル") {
                    var bottleWindow = new BottleWindow();
                    bottleWindow.Show();
                } else if (subCategory == "ボトルセット") {
                    var bottleSetWindow = new BottleSetWindow();
                    bottleSetWindow.Show();
                }

                this.Close();
            }
        }
    }
}
