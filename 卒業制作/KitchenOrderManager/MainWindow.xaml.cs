using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KitchenOrderManager {
    public partial class MainWindow : Window {
        private const string ConnectionString = "Data Source=C:\\Users\\infosys\\Documents\\Orders.db;";

        public MainWindow() {
            InitializeComponent();
            LoadOrders();
        }

        // 注文データをロードしてデータグリッドに表示
        private void LoadOrders() {
            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();

                    string query = "SELECT Id, Name, Quantity, Price, Total, Status FROM Orders";
                    using (var command = new SQLiteCommand(query, connection)) {
                        using (var adapter = new SQLiteDataAdapter(command)) {
                            DataTable ordersTable = new DataTable();
                            adapter.Fill(ordersTable);
                            OrdersDataGrid.ItemsSource = ordersTable.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"注文データの読み込み中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // 選択された注文のステータスを "調理中" に変更
        private void SetCookingStatusButton_Click(object sender, RoutedEventArgs e) {
            UpdateOrderStatus("調理中");
        }

        // 選択された注文のステータスを "提供済み" に変更
        private void SetDeliveredStatusButton_Click(object sender, RoutedEventArgs e) {
            UpdateOrderStatus("提供済み");
        }

        // ステータスを更新する共通メソッド
        private void UpdateOrderStatus(string newStatus) {
            var selectedRows = OrdersDataGrid.SelectedItems.Cast<DataRowView>().ToList();

            if (!selectedRows.Any()) {
                MessageBox.Show("変更する注文を選択してください。", "注意", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try {
                using (var connection = new SQLiteConnection(ConnectionString)) {
                    connection.Open();

                    foreach (var row in selectedRows) {
                        int orderId = Convert.ToInt32(row["Id"]);
                        string query = "UPDATE Orders SET Status = @Status WHERE Id = @Id";

                        using (var command = new SQLiteCommand(query, connection)) {
                            command.Parameters.AddWithValue("@Status", newStatus);
                            command.Parameters.AddWithValue("@Id", orderId);
                            command.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("ステータスが更新されました。", "完了", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadOrders(); // データを再読み込み
            }
            catch (Exception ex) {
                MessageBox.Show($"ステータスの更新中にエラーが発生しました: {ex.Message}", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // データを再読み込み
        private void ReloadButton_Click(object sender, RoutedEventArgs e) {
            LoadOrders();
        }
    }
}
