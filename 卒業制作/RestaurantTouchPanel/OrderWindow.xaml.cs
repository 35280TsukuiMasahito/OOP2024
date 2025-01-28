using System;
using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class OrderWindow : Window {
        public int PeopleCount { get; private set; }

        public OrderWindow() : this(App.PeopleCount) { } // デフォルトは PeopleCount を取得

        public OrderWindow(int peoplecount) {
            InitializeComponent();
            this.PeopleCount = peoplecount;

            Console.WriteLine($"OrderWindow initialized with PeopleCount: {this.PeopleCount}"); // デバッグ
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                string category = button.Content.ToString();
                Window menuWindow = null;

                switch (category) {
                    case "料理":
                        menuWindow = new MenuSelectionWindow();
                        break;
                    case "おすすめ・鍋":
                        menuWindow = new OsusumeWindow();
                        break;
                    case "刺身・寿司・サラダ":
                        menuWindow = new SasimiWindow();
                        break;
                    case "アルコール①":
                        menuWindow = new BiruWindow();
                        break;
                    case "アルコール②":
                        menuWindow = new ShochuWindow();
                        break;
                    case "ノンアル・ソフドリ":
                        menuWindow = new Drink1Window();
                        break;
                    case "デザート":
                        menuWindow = new IceWindow();
                        break;
                    case "サービス":
                        menuWindow = new ServiceWindow();
                        break;
                    case "特選メニュー":
                        menuWindow = new TokusenWindow();
                        break;
                    case "トップ画面":
                        menuWindow = new OrderWindow(App.PeopleCount);
                        break;
                    default:
                        MessageBox.Show($"{category}がクリックされました。");
                        return;
                }

                if (menuWindow != null) {
                    this.Close();
                    menuWindow.Show();
                }
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e) {
            var checkWindow = new CheckWindow(PeopleCount);
            this.Close();
            checkWindow.Show();
        }

        private void OrderHistoryButton_Click(object sender, RoutedEventArgs e) {
            var historyWindow = new OrderHistoryWindow();
            this.Close();
            historyWindow.Show();
        }

        private void RecommendedButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("おすすめ商品画面へ進みます。", "おすすめ商品", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
