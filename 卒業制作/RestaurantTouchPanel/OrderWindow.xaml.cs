﻿using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class OrderWindow : Window {
        public OrderWindow() {
            InitializeComponent();
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
            } else if ((sender as Button)?.Content.ToString() == "ノンアル・ソフドリ") {
            } else if ((sender as Button)?.Content.ToString() == "デザート") {
            } else if ((sender as Button)?.Content.ToString() == "サービス") {
            } else if ((sender as Button)?.Content.ToString() == "特選メニュー") {
            } else {
                MessageBox.Show($"{(sender as Button)?.Content}がクリックされました。");
            }
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e) {
            // お会計ボタンがクリックされた場合の処理
            MessageBox.Show("お会計画面へ進みます。", "お会計", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OrderHistoryButton_Click(object sender, RoutedEventArgs e) {
            // 注文履歴確認ボタンがクリックされた場合の処理
            MessageBox.Show("注文履歴確認画面へ進みます。", "注文履歴", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RecommendedButton_Click(object sender, RoutedEventArgs e) {
            // おすすめ商品ボタンがクリックされた場合の処理
            MessageBox.Show("おすすめ商品画面へ進みます。", "おすすめ商品", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
