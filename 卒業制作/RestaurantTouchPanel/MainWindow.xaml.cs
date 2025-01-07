using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class MainWindow : Window {
        private Button SelectedButton = null; // 現在選択されているボタン

        public MainWindow() {
            InitializeComponent();
        }

        private void PeopleButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                // 前回の選択をリセット
                if (SelectedButton != null) {
                    SelectedButton.Tag = null; // 選択解除
                }

                // 現在のボタンを選択状態にする
                SelectedButton = button;
                SelectedButton.Tag = "Selected"; // スタイルトリガーが発動する

                NextButton.IsEnabled = true; // 次へボタンを有効化
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            if (SelectedButton != null) {
                // ボタンのContentから利用人数を取得
                var content = SelectedButton.Content.ToString();
                if (content.EndsWith(" 人") && int.TryParse(content.Replace(" 人", ""), out int peopleCount)) {
                    // 注文画面に人数を渡す
                    var orderWindow = new OrderWindow();
                    orderWindow.Show();
                    this.Close(); // 現在のウィンドウを閉じる
                }
            }
        }
    }
}
