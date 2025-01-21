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
            this.Loaded += MenuSelectionWindow_Loaded;
            orderItems = new List<OrderItem>();
        }

        private void MenuSelectionWindow_Loaded(object sender, RoutedEventArgs e) {
            UpdateOrderList(); // ウィンドウがロードされたときに注文リストを更新
        }


        private void MenuItem_Click(object sender, RoutedEventArgs e) {
            if (!OrderManager.Instance.CanAddOrder()) {
                MessageBox.Show("注文できる種類は最大7種類までです。", "制限超過", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; // 制限を超える場合、処理を中断
            }

            if (sender is Button button) {
                string productName = "";
                int productPrice = 0;

                // 商品の情報を設定
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

                var existingItem = OrderManager.Instance.OrderItems.FirstOrDefault(item => item.Name == productName);

                if (existingItem != null) {
                    existingItem.Quantity++;
                } else {
                    OrderManager.Instance.OrderItems.Add(new OrderItem(productName, 1, productPrice));
                }

                UpdateOrderList();
            }
        }


        private void ClearOrders_Click(object sender, RoutedEventArgs e) {
            // 注文内容を一括クリア
            OrderManager.Instance.ClearOrders();

            // リストボックスを更新
            UpdateOrderList();

            // コンソールにログを出力（デバッグ用）
            Console.WriteLine("注文内容がクリアされました");
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

                if (subCategory == "つまみ") {
                    // MenuSelectionWindow を開く
                    var menuSelectionWindow = new TumamiWindow();
                    menuSelectionWindow.Show();

                    // 現在のウィンドウを閉じる（必要に応じて）
                    this.Close();
                } else if (subCategory == "焼き鳥") {
                    // MenuSelectionWindow を開く
                    var menuSelectionWindow = new YakitoriWindow();
                    menuSelectionWindow.Show();

                    // 現在のウィンドウを閉じる（必要に応じて）
                    this.Close();
                } else if (subCategory == "一品料理") {
                    // MenuSelectionWindow を開く
                    var menuSelectionWindow = new IppinWindow();
                    menuSelectionWindow.Show();
                    this.Close();
                } else if (subCategory == "揚げ物") {
                    // MenuSelectionWindow を開く
                    var menuSelectionWindow = new MenuSelectionWindow();
                    menuSelectionWindow.Show();
                    this.Close();
                } else {
                    // 他のサブカテゴリの場合、メッセージを表示するだけ
                    MessageBox.Show($"{subCategory} サブカテゴリが選択されました。", "サブカテゴリ選択", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        private void SaveOrdersToDatabase() {
            foreach (var order in OrderManager.Instance.OrderItems) {
                DatabaseManager.SaveOrder(order.Name, order.Quantity, order.Price);
            }
        }
    }
}
