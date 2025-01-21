using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class OsusumeWindow : Window {
        public OsusumeWindow() {
            InitializeComponent();
            this.Loaded += OsusumeWindow_Loaded;
        }

        private void OsusumeWindow_Loaded(object sender, RoutedEventArgs e) {
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
                        productName = "若鳥の唐揚げ";
                        productPrice = 500;
                        break;
                    case "2":
                        productName = "枝豆";
                        productPrice = 320;
                        break;
                    case "3":
                        productName = "ポテトフライ";
                        productPrice = 400;
                        break;
                    case "4":
                        productName = "チキン南蛮";
                        productPrice = 520;
                        break;
                    case "5":
                        productName = "山芋の鉄板焼き";
                        productPrice = 400;
                        break;
                    case "6":
                        productName = "きゅうりの浅漬け";
                        productPrice = 320;
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

                if (subCategory == "おすすめ") {
                    var osusumeWindow = new OsusumeWindow();
                    osusumeWindow.Show();
                    this.Close();
                } else if (subCategory == "鍋") {
                    var nabeWindow = new NabeWindow(); // 鍋用の画面が必要な場合
                    nabeWindow.Show();
                    this.Close();
                } else {
                    MessageBox.Show($"{subCategory} サブカテゴリが選択されました。", "サブカテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
