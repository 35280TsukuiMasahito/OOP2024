using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class BiruWindow : Window {
        public BiruWindow() {
            InitializeComponent();
            this.Loaded += BiruWindow_Loaded;
        }

        private void BiruWindow_Loaded(object sender, RoutedEventArgs e) {
            UpdateOrderList(); // ウィンドウがロードされたときに注文リストを更新
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            // 注文種類の制限をチェック
            if (!OrderManager.Instance.CanAddOrder()) {
                MessageBox.Show("注文できる種類は最大7種類までです。", "制限超過", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // 制限を超えた場合、処理を中断
            }

            if (sender is Button button) {
                string productName = "";
                int productPrice = 0;

                // ボタンのTagを元に商品情報を設定
                switch (button.Tag) {
                    case "1":
                        productName = "生ビール";
                        productPrice = 450;
                        break;
                    case "2":
                        productName = "小ジョッキ";
                        productPrice = 380;
                        break;
                    case "3":
                        productName = "エクストラコールド";
                        productPrice = 450;
                        break;
                    case "4":
                        productName = "グラスワイン赤";
                        productPrice = 450;
                        break;
                    case "5":
                        productName = "グラスワイン白";
                        productPrice = 450;
                        break;
                }

                var existingItem = OrderManager.Instance.OrderItems
                    .FirstOrDefault(item => item.Name == productName);

                if (existingItem != null) {
                    existingItem.Quantity++;
                    Console.WriteLine($"Updated quantity: {existingItem.Name}, Quantity: {existingItem.Quantity}");
                } else {
                    OrderManager.Instance.OrderItems.Add(new OrderItem(productName, 1, productPrice));
                    Console.WriteLine($"Added new item: {productName}");
                }

                UpdateOrderList();
            }
        }

        private void UpdateOrderList() {
            // 現在の選択を保持
            var selectedIndex = OrderListBox.SelectedIndex;

            // 注文リストを更新
            OrderListBox.Items.Clear();
            foreach (var item in OrderManager.Instance.OrderItems) {
                OrderListBox.Items.Add(item.ToString());
            }

            // 選択状態を復元
            if (selectedIndex >= 0 && selectedIndex < OrderListBox.Items.Count) {
                OrderListBox.SelectedIndex = selectedIndex;
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

            var thankYouWindow = new ThankYouWindow();
            thankYouWindow.Show();

            OrderManager.Instance.ClearOrders();
            UpdateOrderList();

            this.Close();
        }

        private void ClearOrders_Click(object sender, RoutedEventArgs e) {
            // 注文リストをすべて削除
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
                    var orderWindow = new OrderWindow();
                    orderWindow.Show();
                    this.Close();
                } else {
                    MessageBox.Show($"{content} カテゴリが選択されました。", "カテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void SubCategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string subCategory = button.Content.ToString();

                if (subCategory == "ビール・ワイン") {
                    var biruWindow = new BiruWindow();
                    biruWindow.Show();
                    this.Close();
                } else if (subCategory == "サワー") {
                    var sourWindow = new SourWindow();
                    sourWindow.Show();
                    this.Close();
                } else if (subCategory == "ハイボール") {
                    var highballWindow = new HighballWindow();
                    highballWindow.Show();
                    this.Close();
                } else if (subCategory == "カクテル") {
                    var cocktailWindow = new CocktailWindow();
                    cocktailWindow.Show();
                    this.Close();
                } else {
                    MessageBox.Show($"{subCategory} サブカテゴリが選択されました。", "サブカテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
