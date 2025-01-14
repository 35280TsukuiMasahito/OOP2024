using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class CocktailWindow : Window {
        private const int MaxOrderTypes = 7; // 注文の種類数の制限

        public CocktailWindow() {
            InitializeComponent();
            this.Loaded += CocktailWindow_Loaded;
        }

        private void CocktailWindow_Loaded(object sender, RoutedEventArgs e) {
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
                        productName = "カシスオレンジ";
                        productPrice = 450;
                        break;
                    case "2":
                        productName = "カシスソーダ";
                        productPrice = 450;
                        break;
                    case "3":
                        productName = "カシスウーロン";
                        productPrice = 450;
                        break;
                    case "4":
                        productName = "モスコミュール";
                        productPrice = 450;
                        break;
                    case "5":
                        productName = "レゲエパンチ";
                        productPrice = 450;
                        break;
                    case "6":
                        productName = "スクリュードライバー";
                        productPrice = 450;
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

                if (subCategory == "ビール・ワイン") {
                    var biruWindow = new BiruWindow();
                    biruWindow.Show();
                } else if (subCategory == "サワー") {
                    var sourWindow = new SourWindow();
                    sourWindow.Show();
                } else if (subCategory == "ハイボール") {
                    var highballWindow = new HighballWindow();
                    highballWindow.Show();
                } else if (subCategory == "カクテル") {
                    var cocktailWindow = new CocktailWindow();
                    cocktailWindow.Show();
                }

                this.Close();
            }
        }
    }
}
