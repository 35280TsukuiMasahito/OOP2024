using CustomerApp.Objects;
using Microsoft.Win32;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        List<Customer> _customers;
        private string _selectedImagePath;

        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        private void ClearFields() {
            // 入力フィールドをクリア
            NameTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            SearchTextBox.Text = null;

            // 画像プレビューをクリア
            CustomerImage.Source = null;

            // 画像パスのリセット
            _selectedImagePath = null;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text)) {
                MessageBox.Show("すべてのフィールドを入力してください。", "入力エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var customer = new Customer() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                ImageData = CustomerImage.Source != null ? ImageHelper.ImageToByteArray(_selectedImagePath) : null
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
            ClearFields();
        }


        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                _customers = connection.Table<Customer>().ToList();

                CustomerListView.ItemsSource = _customers;

            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _customers.Where(x => x.Name.Contains(SearchTextBox.Text)).ToList();
            CustomerListView.ItemsSource = filterList;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = CustomerListView.SelectedItem as Customer;
            if (item == null) {
                MessageBox.Show("削除する行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Delete(item);

                CustomerListView.ItemsSource = _customers;

            }
            ReadDatabase();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer == null) {
                MessageBox.Show("更新する行を選択してください");
                return;
            }

            // 入力フィールドのデータを更新
            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            // 画像パスを更新
            if (!string.IsNullOrEmpty(_selectedImagePath)) {
                selectedCustomer.ImageData = CustomerImage.Source != null ? ImageHelper.ImageToByteArray(_selectedImagePath) : null;
            }

            // データベースを更新
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer); // プライマリキーを使って更新
            }

            // UI更新と通知
            ReadDatabase();
            MessageBox.Show("顧客情報を更新しました。", "成功", MessageBoxButton.OK, MessageBoxImage.Information);

            // 入力フィールドをクリア
            ClearFields();
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;

                // 画像プレビュー
                CustomerImage.Source = ImageHelper.ByteArrayToImage(selectedCustomer.ImageData);
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == true) {
                _selectedImagePath = openFileDialog.FileName;

                // 画像をバイト配列に変換してプレビュー表示
                var imageBytes = ImageHelper.ImageToByteArray(_selectedImagePath);
                CustomerImage.Source = ImageHelper.ByteArrayToImage(imageBytes);
            }
        }

        private void RemoveImageButton_Click(object sender, RoutedEventArgs e) {
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            if (selectedCustomer == null) {
                MessageBox.Show("画像を削除する顧客を選択してください");
                return;
            }

            // 画像データをクリア
            selectedCustomer.ImageData = null;
            CustomerImage.Source = null; // プレビューをクリア
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e) {
            // テキストボックスをクリア
            NameTextBox.Text = string.Empty;
            PhoneTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;

            // 画像プレビューをクリア
            CustomerImage.Source = null;

            // 画像パスのリセット
            _selectedImagePath = null;

            MessageBox.Show("すべての入力フィールドをクリアしました。", "クリア", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static class ImageHelper {
            public static byte[] ImageToByteArray(string imagePath) {
                return System.IO.File.ReadAllBytes(imagePath);
            }

            public static BitmapImage ByteArrayToImage(byte[] byteArray) {
                if (byteArray == null || byteArray.Length == 0) return null;

                var bitmapImage = new BitmapImage();
                using (var stream = new System.IO.MemoryStream(byteArray)) {
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                }
                return bitmapImage;
            }
        }
    }
}
