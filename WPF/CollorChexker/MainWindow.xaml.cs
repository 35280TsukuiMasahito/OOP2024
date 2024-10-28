using CollorChexker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            DataContext = GetColorList();
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

            // コンボボックスから選択された色の名前を取得
            string colorName = null;
            if (colorComboBox.SelectedItem is MyColor selectedColor) {
                // スライダーの値が選択された色と一致している場合、色名を使用
                if (selectedColor.Color.R == r && selectedColor.Color.G == g && selectedColor.Color.B == b) {
                    colorName = selectedColor.Name;
                }
            }

            // 名前が取得できなかった場合はRGB値を使用
            if (string.IsNullOrEmpty(colorName)) {
                colorName = $"R: {r}, G: {g}, B: {b}";
            }

            // MyColorインスタンスを作成
            MyColor myColor = new MyColor {
                Color = Color.FromRgb(r, g, b),
                Name = colorName
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
            if (stockList.SelectedItem is MyColor selectedColor) {
                // MyColorからRGBの値を取得
                byte r = selectedColor.Color.R;
                byte g = selectedColor.Color.G;
                byte b = selectedColor.Color.B;

                // スライダーを更新
                Rslider.Value = r;
                Gslider.Value = g;
                Bslider.Value = b;

                // 色を更新
                UpdateColor();
            }
        }

        private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorComboBox.SelectedItem is MyColor selectedColor) {
                // MyColorからRGBの値を取得
                byte r = selectedColor.Color.R;
                byte g = selectedColor.Color.G;
                byte b = selectedColor.Color.B;

                // スライダーの値を設定
                Rslider.Value = r;
                Gslider.Value = g;
                Bslider.Value = b;

                // 色を更新
                UpdateColor();
            }
        }
        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

    }

}
