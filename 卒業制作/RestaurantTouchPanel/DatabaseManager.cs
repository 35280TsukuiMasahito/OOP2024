using RestaurantTouchPanel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

public class DatabaseManager {
    private const string DatabaseFile = @"C:\Users\infosys\Documents\Orders.db";
    private const string ConnectionString = "Data Source=" + DatabaseFile;

    public static void InitializeDatabase() {
        // データベースファイルを確認し、なければ作成
        if (!System.IO.File.Exists(DatabaseFile)) {
            SQLiteConnection.CreateFile(DatabaseFile);
        }

        using (var connection = new SQLiteConnection(ConnectionString)) {
            connection.Open();

            // Ordersテーブル作成または既存テーブルの初期化
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Price INTEGER NOT NULL,
                    Total INTEGER NOT NULL,
                    Status TEXT DEFAULT '調理中'
                );";
            using (var command = new SQLiteCommand(createTableQuery, connection)) {
                command.ExecuteNonQuery();
            }
        }
    }

    public static void SaveOrder(string name, int quantity, int price) {
        Console.WriteLine($"Attempting to save order: {name}, Quantity: {quantity}, Price: {price}");
        try {
            using (var connection = new SQLiteConnection(ConnectionString)) {
                connection.Open();

                string insertQuery = @"
            INSERT INTO Orders (Name, Quantity, Price, Total, Status)
            VALUES (@Name, @Quantity, @Price, @Total, @Status);";

                using (var command = new SQLiteCommand(insertQuery, connection)) {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Total", quantity * price);
                    command.Parameters.AddWithValue("@Status", "調理中"); // 初期値を調理中に設定
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Order saved successfully.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Error saving order: {ex.Message}");
        }
    }


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

    public static List<OrderHistory> GetOrderHistory() {
        var orderHistory = new List<OrderHistory>();

        using (var connection = new SQLiteConnection(ConnectionString)) {
            connection.Open();

            string query = "SELECT Id, Name, Quantity, Price, Total, Status FROM Orders";
            using (var command = new SQLiteCommand(query, connection)) {
                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        orderHistory.Add(new OrderHistory {
                            Id = int.Parse(reader["Id"].ToString()),
                            Name = reader["Name"].ToString(),
                            Quantity = int.Parse(reader["Quantity"].ToString()),
                            Price = int.Parse(reader["Price"].ToString()),
                            Total = int.Parse(reader["Total"].ToString()),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
        }

        return orderHistory;
    }
}
