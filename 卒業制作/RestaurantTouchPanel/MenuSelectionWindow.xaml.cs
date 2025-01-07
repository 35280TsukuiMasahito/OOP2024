using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class MenuSelectionWindow : Window {
        // 注文内容を管理するリスト
        private List<OrderItem> orderItems;

        public MenuSelectionWindow() {
            InitializeComponent();
            orderItems = new List<OrderItem>();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string productName = "";
                int productPrice = 0;

                switch (button.Tag) {
                    case "1":
                        productName = "若鳥の唐揚げ";
                        productPrice = 500;
                        break;
                    case "2":
                        productName = "軟骨の唐揚げ";
                        productPrice = 500;
                        break;
                    case "3":
                        productName = "ポテトフライ";
                        productPrice = 400;
                        break;
                    case "4":
                        productName = "カマンベールポテト";
                        productPrice = 400;
                        break;
                    case "5":
                        productName = "山芋の磯部揚げ";
                        productPrice = 400;
                        break;
                    case "6":
                        productName = "手羽先の唐揚げ";
                        productPrice = 500;
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
                // 商品名を抽出
                var selectedName = selectedItem.Split('-')[0].Trim();

                // 注文リストから該当商品を検索
                var item = OrderManager.Instance.OrderItems.FirstOrDefault(i => i.Name == selectedName);
                if (item != null) {
                    item.Quantity++;

                    // 現在の選択状態を保持
                    var selectedIndex = OrderListBox.SelectedIndex;

                    // リストを更新
                    UpdateOrderList();

                    // 選択状態を復元
                    OrderListBox.SelectedIndex = selectedIndex;
                }
            }
        }





        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e) {
            if (OrderListBox.SelectedItem is string selectedItem) {
                // 商品名を抽出
                var selectedName = selectedItem.Split('-')[0].Trim();

                // 注文リストから該当商品を検索
                var item = OrderManager.Instance.OrderItems.FirstOrDefault(i => i.Name == selectedName);
                if (item != null) {
                    if (item.Quantity > 1) {
                        item.Quantity--;
                    } else {
                        OrderManager.Instance.OrderItems.Remove(item);
                    }

                    // 現在の選択状態を保持
                    var selectedIndex = OrderListBox.SelectedIndex;

                    // リストを更新
                    UpdateOrderList();

                    // 選択状態を復元（削除された場合、選択は前のアイテムに移る）
                    if (selectedIndex < OrderListBox.Items.Count) {
                        OrderListBox.SelectedIndex = selectedIndex;
                    } else if (OrderListBox.Items.Count > 0) {
                        OrderListBox.SelectedIndex = OrderListBox.Items.Count - 1;
                    }
                }
            }
        }




        private void ConfirmOrder_Click(object sender, RoutedEventArgs e) {
            SaveOrdersToDatabase();

            // 「ご注文ありがとうございます」の画面を表示
            var thankYouWindow = new ThankYouWindow();
            thankYouWindow.Show();

            // 注文リストをクリア
            OrderManager.Instance.ClearOrders();
            UpdateOrderList();

            // このウィンドウを閉じたい場合
            this.Close();
        }



        // 注文アイテムを管理するクラス
        public class OrderItem {
            public string Name { get; set; }        // 商品名
            public int Quantity { get; set; }      // 数量
            public int Price { get; set; }         // 単価

            // コンストラクタ
            public OrderItem(string name, int quantity, int price) {
                Name = name;
                Quantity = quantity;
                Price = price;
            }

            // 表示用のオーバーライド
            public override string ToString() {
                return $"{Name} - 数量: {Quantity}個";
            }
        }


        private void CategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                // 大分類ボタンがクリックされた場合の処理
                MessageBox.Show($"{button.Content} カテゴリが選択されました。", "カテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);

                // 必要に応じて大分類に基づいて小分類を切り替える処理を追加できます。
            }
        }

        private void SubCategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                // 小分類ボタンがクリックされた場合の処理
                MessageBox.Show($"{button.Content} サブカテゴリが選択されました。", "サブカテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);

                // 必要に応じてサブカテゴリに基づいて商品リストを切り替える処理を追加できます。
            }
        }

        private void SaveOrdersToDatabase() {
            foreach (var order in OrderManager.Instance.OrderItems) {
                DatabaseManager.SaveOrder(order.Name, order.Quantity, order.Price);
            }
        }

    }
}
