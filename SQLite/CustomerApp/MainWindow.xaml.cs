﻿using CustomerApp.Objects;
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
                ImagePath = _selectedImagePath,
            };

            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }
            ReadDatabase();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e) {

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
            selectedCustomer.Name = NameTextBox.Text;
            selectedCustomer.Phone = PhoneTextBox.Text;
            selectedCustomer.Address = AddressTextBox.Text;

            // データベースで顧客情報を更新
            using (var connection = new SQLiteConnection(App.databasePass)) {
                connection.CreateTable<Customer>();
                connection.Update(selectedCustomer); // プライマリキーを使ってレコードを更新
            }
            ReadDatabase();
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // ListView から選択されたアイテムを取得
            var selectedCustomer = CustomerListView.SelectedItem as Customer;

            // 選択された顧客が存在すれば、その情報をテキストボックスに反映
            if (selectedCustomer != null) {
                NameTextBox.Text = selectedCustomer.Name;
                PhoneTextBox.Text = selectedCustomer.Phone;
                AddressTextBox.Text = selectedCustomer.Address;
            }
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e) {
            // OpenFileDialogを使って画像ファイルを選択
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"; // 画像のファイル拡張子を制限
            if (openFileDialog.ShowDialog() == true) {
                _selectedImagePath = openFileDialog.FileName;  // 選択した画像のパスを保存

                // 画像プレビューを表示
                CustomerImage.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(_selectedImagePath));
            }
        }
    }
}
