using CollorChexker;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace CollorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        private List<MyColor> colorList;
        public MainWindow() {
            InitializeComponent();

            // カラーデータを取得して DataContext に設定
            colorList = GetColorList().ToList();
            DataContext = colorList;
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

            // 現在のRGB値に一致する色名を取得
            string colorName = null;

            // colorListから現在のRGBと一致する色を検索
            var matchingColor = colorList.FirstOrDefault(c => c.Color.R == r && c.Color.G == g && c.Color.B == b);

            // 一致する色があればその名前を使用
            if (matchingColor != null) {
                colorName = matchingColor.Name;
            } else {
                // 一致する色がない場合はRGB値を名前として使用
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

            ClearComboBoxSelection();
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

        private void ClearComboBoxSelection() {
            colorComboBox.SelectedItem = null;
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

        private void btDelete_Click(object sender, RoutedEventArgs e) {
            // 選択された項目があるか確認
            if (stockList.SelectedItem is MyColor selectedColor) {
                // 選択された色をリストから削除
                stockList.Items.Remove(selectedColor);
            } else {
                // 選択されていない場合、エラーメッセージを表示
                MessageBox.Show("削除する色を選択してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

}
