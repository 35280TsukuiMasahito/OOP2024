using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class OrderWindow : Window {
        public int peoplecount;

        public OrderWindow() : this(1) { } // 引数なしコンストラクタで peoplecount にデフォルト値を設定

        public OrderWindow(int peoplecount) {
            InitializeComponent();
            this.peoplecount = peoplecount;
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
            } else {
                MessageBox.Show($"{(sender as Button)?.Content}がクリックされました。");
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e) {
            int numberOfPeople = 4; // 実際には人数入力フォームから取得
            var checkWindow = new CheckWindow(numberOfPeople);
            this.Close(); // 現在のウィンドウを閉じる
            checkWindow.Show();
        }




        private void OrderHistoryButton_Click(object sender, RoutedEventArgs e) {
            // 注文履歴ウィンドウを開く
            var historyWindow = new OrderHistoryWindow();
            this.Close(); // 現在のウィンドウを閉じる
            historyWindow.Show(); // モーダルでなく通常表示
        }



        private void RecommendedButton_Click(object sender, RoutedEventArgs e) {
            // おすすめ商品ボタンがクリックされた場合の処理
            MessageBox.Show("おすすめ商品画面へ進みます。", "おすすめ商品", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
