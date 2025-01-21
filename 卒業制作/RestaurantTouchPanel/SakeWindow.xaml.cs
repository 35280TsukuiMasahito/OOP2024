using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class SakeWindow : Window {
        private const int MaxOrderTypes = 7; // 注文の種類数の制限

        public SakeWindow() {
            InitializeComponent();
            this.Loaded += SakeWindow_Loaded;
        }

        private void SakeWindow_Loaded(object sender, RoutedEventArgs e) {
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
                        productName = "森伊蔵(1合)";
                        productPrice = 650;
                        break;
                    case "2":
                        productName = "赤兎馬(1合)";
                        productPrice = 650;
                        break;
                    case "3":
                        productName = "富乃宝山(1合)";
                        productPrice = 550;
                        break;
                    case "4":
                        productName = "越乃寒梅(1合)";
                        productPrice = 550;
                        break;
                    case "5":
                        productName = "菊水(1合)";
                        productPrice = 550;
                        break;
                    case "6":
                        productName = "八海山(1合)";
                        productPrice = 550;
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
            // カテゴリボタンがクリックされた場合の処理
            // 料理ボタンがクリックされた場合
            if ((sender as Button)?.Content.ToString() == "料理") {
                var menuWindow = new MenuSelectionWindow();
                this.Close();
                menuWindow.ShowDialog(); // モーダルで開く
            } else if ((sender as Button)?.Content.ToString() == "おすすめ・鍋") {
                var menuWindow = new OsusumeWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "刺身・寿司・サラダ") {
                var menuWindow = new SasimiWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "アルコール①") {
                var menuWindow = new BiruWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "アルコール②") {
                var menuWindow = new ShochuWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "ノンアル・ソフドリ") {
                var menuWindow = new Drink1Window();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "デザート") {
                var menuWindow = new IceWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "サービス") {
                var menuWindow = new ServiceWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "特選メニュー") {
                var menuWindow = new TokusenWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "トップ画面") {
                var menuWindow = new OrderWindow();
                this.Close();
                menuWindow.ShowDialog();
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
