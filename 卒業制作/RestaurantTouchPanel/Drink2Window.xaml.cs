using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class Drink2Window : Window {
        private const int MaxOrderTypes = 7; // 注文の種類数の制限

        public Drink2Window() {
            InitializeComponent();
            this.Loaded += Drink2Window_Loaded;
        }

        private void Drink2Window_Loaded(object sender, RoutedEventArgs e) {
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
                        productName = "コーラ";
                        productPrice = 280;
                        break;
                    case "2":
                        productName = "メロンソーダ";
                        productPrice = 280;
                        break;
                    case "3":
                        productName = "ジンジャエール";
                        productPrice = 280;
                        break;
                    case "4":
                        productName = "オレンジジュース";
                        productPrice = 280;
                        break;
                    case "5":
                        productName = "グレープフルーツ";
                        productPrice = 280;
                        break;
                    case "6":
                        productName = "アセロラジュース";
                        productPrice = 280;
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

                if (subCategory == "ソフドリ1") {
                    var drink1Window = new Drink1Window();
                    drink1Window.Show();
                } else if (subCategory == "ソフドリ2") {
                    var drink2Window = new Drink2Window();
                    drink2Window.Show();
                } else if (subCategory == "ノンアル") {
                    var nonAlcoholWindow = new NonAlcoholWindow();
                    nonAlcoholWindow.Show();
                }

                this.Close();
            }
        }
    }
}
