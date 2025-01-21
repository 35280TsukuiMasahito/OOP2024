using System;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace RestaurantTouchPanel {
    public partial class CheckWindow : Window {
        private int peopleCount;
        private int totalAmount;

        public CheckWindow(int peopleCount) {
            InitializeComponent();
            this.peopleCount = peopleCount;

            // データベースから合計金額を取得
            totalAmount = CalculateTotalAmount();

            // 合計金額と一人当たりの金額を表示
            TotalAmountTextBlock.Text = $"合計金額: ¥{totalAmount}";
            AmountPerPersonTextBlock.Text = $"一人当たり: ¥{totalAmount / peopleCount}";
        }

        private int CalculateTotalAmount() {
            int total = 0;
            const string connectionString = @"Data Source=C:\Users\infosys\Documents\Orders.db";

            try {
                using (var connection = new SQLiteConnection(connectionString)) {
                    connection.Open();

                    string query = "SELECT SUM(Total) FROM Orders";
                    using (var command = new SQLiteCommand(query, connection)) {
                        var result = command.ExecuteScalar();
                        if (result != DBNull.Value) {
                            total = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"合計金額の計算中にエラーが発生しました: {ex.Message}");
            }

            return total;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
