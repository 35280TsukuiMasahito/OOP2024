using RestaurantTouchPanel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class DatabaseManager {
    private const string DatabaseFile = @"C:\Users\infosys\Documents\Orders.db";
    private const string ConnectionString = "Data Source=" + DatabaseFile;

    // データベース初期化
    public static void InitializeDatabase() {
        if (!System.IO.File.Exists(DatabaseFile)) {
            SQLiteConnection.CreateFile(DatabaseFile);
        }

        using (var connection = new SQLiteConnection(ConnectionString)) {
            connection.Open();

            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Price INTEGER NOT NULL,
                    Total INTEGER NOT NULL,
                    Status TEXT DEFAULT '調理中', -- 初期ステータス
                    OrderTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP -- 注文時間
                );";
            using (var command = new SQLiteCommand(createTableQuery, connection)) {
                command.ExecuteNonQuery();
            }
        }
    }

    // 注文をデータベースに保存
    public static void SaveOrder(string name, int quantity, int price) {
        try {
            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();

                string insertQuery = @"
                INSERT INTO Orders (Name, Quantity, Price, Total, Status)
                VALUES (@Name, @Quantity, @Price, @Total, '調理中');"; // デフォルトで調理中

                using (var command = new SQLiteCommand(insertQuery, connection)) {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Total", quantity * price);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error saving order: {ex.Message}");
        }
    }

    // ステータスの更新
    public static void UpdateOrderStatus(int orderId, string newStatus) {
        try {
            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();

                string updateQuery = @"
                UPDATE Orders
                SET Status = @Status
                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateQuery, connection)) {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@Id", orderId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0) {
                        Console.WriteLine($"No order found with Id: {orderId}");
                    }
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error updating order status: {ex.Message}");
        }
    }

    // 合計金額の計算
    public static int GetTotalAmount() {
        try {
            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();

                string query = "SELECT SUM(Total) FROM Orders;";
                using (var command = new SQLiteCommand(query, connection)) {
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error calculating total amount: {ex.Message}");
            return 0;
        }
    }

    // 注文履歴の取得
    public static List<OrderHistory> GetOrderHistory() {
        var orderHistory = new List<OrderHistory>();

        using (var connection = new SQLiteConnection(ConnectionString)) {
            connection.Open();

            string query = "SELECT Id, Name, Quantity, Price, Total, Status, OrderTime FROM Orders";
            using (var command = new SQLiteCommand(query, connection)) {
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        orderHistory.Add(new OrderHistory {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Price = Convert.ToInt32(reader["Price"]),
                            Total = Convert.ToInt32(reader["Total"]),
                            Status = reader["Status"].ToString(),
                            OrderTime = Convert.ToDateTime(reader["OrderTime"]) // 注文時刻を追加
                        });
                    }
                }
            }
        }

        return orderHistory;
    }

    public static void SavePeopleCount(int peopleCount) {
        try {
            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();

                string query = @"
                CREATE TABLE IF NOT EXISTS Settings (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    PeopleCount INTEGER NOT NULL
                );";
                using (var command = new SQLiteCommand(query, connection)) {
                    command.ExecuteNonQuery();
                }

                // 既存の人数データを削除
                using (var deleteCommand = new SQLiteCommand("DELETE FROM Settings", connection)) {
                    deleteCommand.ExecuteNonQuery();
                }

                // 新しい人数を保存
                using (var insertCommand = new SQLiteCommand("INSERT INTO Settings (PeopleCount) VALUES (@PeopleCount)", connection)) {
                    insertCommand.Parameters.AddWithValue("@PeopleCount", peopleCount);
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"利用人数の保存に失敗しました: {ex.Message}");
        }
    }


}
