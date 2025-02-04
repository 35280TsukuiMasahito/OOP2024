using System;
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
                ResetPeopleButtonStyles();

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

                Console.WriteLine($"Selected People Count: {App.PeopleCount}"); // デバッグ用ログ
            }
        }

        private void ResetPeopleButtonStyles() {
            foreach (var child in PeopleButtonGrid.Children) {
                if (child is Button btn) {
                    btn.Tag = null; // すべてのボタンの選択状態をリセット
                }
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e) {
            if (_selectedButton != null) {
                string content = _selectedButton.Content.ToString(); // 例: "3 人"
                int selectedPeople = int.Parse(content.Split(' ')[0]); // "3" を取得

                // 🔥 PeopleCount を保存
                App.PeopleCount = selectedPeople;
                DatabaseManager.SavePeopleCount(selectedPeople); // データベースに保存

                Console.WriteLine($"Saved People Count: {App.PeopleCount}");

                var orderWindow = new OrderWindow(App.PeopleCount);
                orderWindow.Show();
                this.Close();
            } else {
                MessageBox.Show("人数を選択してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
