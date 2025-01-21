using System.Windows;
using System.Windows.Controls;

namespace RestaurantTouchPanel {
    public partial class MainWindow : Window {
        private Button _selectedButton = null; // 現在選択されているボタンを保持

        public MainWindow() {
            InitializeComponent();
        }

        private void PeopleButton_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                // すでに選択されているボタンをリセット
                if (_selectedButton != null) {
                    _selectedButton.Tag = null; // 選択状態を解除
                }

                // 新しく選択されたボタンを設定
                button.Tag = "Selected";
                _selectedButton = button;

                // ボタンの Content から人数を取得
                string content = button.Content.ToString(); // 例: "1 人"
                int selectedPeople = int.Parse(content.Split(' ')[0]); // "1" を取得

                // 選択した人数を静的プロパティに保存
                App.PeopleCount = selectedPeople;

                // 次へボタンを有効化
                NextButton.IsEnabled = true;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            // OrderWindow を開き、現在のウィンドウを閉じる
            var orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }
    }
}
