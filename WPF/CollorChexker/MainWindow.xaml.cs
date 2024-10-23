using CollorChexker;
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

namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Rslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColor();
        }
        private void Gslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColor();
        }

        private void Bslider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            UpdateColor();
        }

        private void UpdateColor() {
            byte r = (byte)Rslider.Value;
            byte g = (byte)Gslider.Value;
            byte b = (byte)Bslider.Value;
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));

        }

        private void btStock_Click(object sender, RoutedEventArgs e) {
            // RGBの値を取得
            byte r = (byte)Rslider.Value;
            byte g = (byte)Gslider.Value;
            byte b = (byte)Bslider.Value;

            // MyColorインスタンスを作成
            MyColor myColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = $"R: {r}, G: {g}, B: {b}"
            };
            // 既に登録されているかチェック
            if (!IsColorAlreadyRegistered(myColor)) {
                stockList.Items.Add(myColor);
            } else {
                MessageBox.Show("この色はすでに登録されています。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool IsColorAlreadyRegistered(MyColor color) {
            // stockListに登録されている色と比較
            return stockList.Items.OfType<MyColor>().Any(c =>
                c.Color.R == color.Color.R &&
                c.Color.G == color.Color.G &&
                c.Color.B == color.Color.B);
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem != null) {
                // 選択されたアイテムを取得
                string selectedItem = stockList.SelectedItem.ToString();

                // R, G, Bの値を解析
                string[] parts = selectedItem.Split(new[] { ", " }, StringSplitOptions.None);
                byte r = byte.Parse(parts[0].Split(':')[1].Trim());
                byte g = byte.Parse(parts[1].Split(':')[1].Trim());
                byte b = byte.Parse(parts[2].Split(':')[1].Trim());

                // スライダーを更新
                Rslider.Value = r;
                Gslider.Value = g;
                Bslider.Value = b;

                // 色を更新
                UpdateColor();
            }
        }
    }
}
