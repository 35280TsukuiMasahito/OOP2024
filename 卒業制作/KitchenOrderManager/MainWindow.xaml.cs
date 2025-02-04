using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Threading;

namespace KitchenOrderManager {
    public partial class MainWindow : Window {
        private const string ConnectionString = "Data Source=C:\\Users\\infosys\\Documents\\Orders.db";
        private DispatcherTimer orderUpdateTimer;

        public MainWindow() {
            InitializeComponent();
            LoadOrders();
            StartAutoUpdate();
        }

        // ✅ 5秒ごとに注文データを更新
        private void StartAutoUpdate() {
            orderUpdateTimer = new DispatcherTimer();
            orderUpdateTimer.Interval = TimeSpan.FromSeconds(5);
            orderUpdateTimer.Tick += (s, e) => LoadOrders();
            orderUpdateTimer.Start();
        }

        // ✅ データベースから注文情報を取得して DataGrid に表示
        private void LoadOrders() {
            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();

                    string query = "SELECT Id, Name, Quantity, Price, Total, Status FROM Orders";

                    using (var command = new SQLiteCommand(query, connection))
                    using (var adapter = new SQLiteDataAdapter(command)) {
                        DataTable ordersTable = new DataTable();
                        adapter.Fill(ordersTable);

                        // DataGrid にデータをバインド
                        OrdersDataGrid.ItemsSource = ordersTable.DefaultView;

                        // ✅ 合計金額と利用人数を更新
                        UpdateTotalAmount();
                        UpdatePeopleCount();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"注文データの読み込みに失敗しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ✅ 合計金額を計算して表示
        private void UpdateTotalAmount() {
            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();
                    string query = "SELECT SUM(Total) FROM Orders";
                    using (var command = new SQLiteCommand(query, connection)) {
                        var result = command.ExecuteScalar();
                        int totalAmount = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                        TotalAmountText.Text = $"合計金額: ¥{totalAmount:N0}"; // 例: "¥2,500"
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"合計金額の更新エラー: {ex.Message}");
            }
        }

        // ✅ 利用人数を表示
        // 利用人数をデータベースから取得して表示
        private void UpdatePeopleCount() {
            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();
                    string query = "SELECT PeopleCount FROM Settings ORDER BY Id DESC LIMIT 1";

                    using (var command = new SQLiteCommand(query, connection)) {
                        var result = command.ExecuteScalar();
                        int peopleCount = (result != DBNull.Value && result != null) ? Convert.ToInt32(result) : 1;
                        PeopleCountText.Text = $"利用人数: {peopleCount} 人";
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"利用人数の取得エラー: {ex.Message}");
            }
        }


        // ✅ ステータス一括変更
        private void UpdateSelectedOrdersStatus(string newStatus) {
            if (OrdersDataGrid.SelectedItems.Count == 0) {
                MessageBox.Show("注文を選択してください。", "注意", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction()) {
                        foreach (var selectedItem in OrdersDataGrid.SelectedItems) {
                            if (selectedItem is DataRowView row) {
                                int orderId = Convert.ToInt32(row["Id"]);
                                string query = "UPDATE Orders SET Status = @Status WHERE Id = @Id";

                                using (var command = new SQLiteCommand(query, connection)) {
                                    command.Parameters.AddWithValue("@Status", newStatus);
                                    command.Parameters.AddWithValue("@Id", orderId);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        transaction.Commit();
                    }
                }
                LoadOrders(); // 更新後にデータを再読み込み
            }
            catch (Exception ex) {
                MessageBox.Show($"ステータスの一括更新に失敗しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // ✅ 調理中ボタン
        private void SetCookingStatusButton_Click(object sender, RoutedEventArgs e) {
            UpdateSelectedOrdersStatus("調理中");
        }

        // ✅ 提供済みに変更ボタン
        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e) {
            UpdateSelectedOrdersStatus("提供済み");
        }
    }
}
