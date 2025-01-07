using System;
using System.Data.SQLite;

public class DatabaseManager {
    private const string DatabaseFile = @"C:\Users\infosys\Documents\Orders.db";
    private const string ConnectionString = "Data Source=" + DatabaseFile;

    public static void InitializeDatabase() {
        // データベースファイルが存在しない場合、作成
        if (!System.IO.File.Exists(DatabaseFile)) {
            SQLiteConnection.CreateFile(DatabaseFile);
        }

        using (var connection = new SQLiteConnection(ConnectionString)) {
            connection.Open();

            // 注文テーブルの作成
            string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Orders (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Quantity INTEGER NOT NULL,
                    Price INTEGER NOT NULL,
                    Total INTEGER NOT NULL
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
                INSERT INTO Orders (Name, Quantity, Price, Total)
                VALUES (@Name, @Quantity, @Price, @Total);";

                using (var command = new SQLiteCommand(insertQuery, connection)) {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Total", quantity * price);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Order saved successfully.");
        }
        catch (Exception ex) {
            Console.WriteLine($"Error saving order: {ex.Message}");
        }
    }


}
