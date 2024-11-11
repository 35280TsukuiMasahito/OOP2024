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

namespace VisibilityConverter {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RadioButton_Checked_赤(object sender, RoutedEventArgs e) {
            b1.Background = (SolidColorBrush)FindResource("red");
        }

        private void RadioButton_Checked_黄(object sender, RoutedEventArgs e) {
            b1.Background = (SolidColorBrush)FindResource("yellow");
        }

        private void RadioButton_Checked_緑(object sender, RoutedEventArgs e) {
            b1.Background = (SolidColorBrush)FindResource("green");
        }

        //private void Button_Click(object sender, RoutedEventArgs e) {
        //    Resources["ButtonBrushKey"] = new SolidColorBrush(Colors.DarkSeaGreen);
        //}
    }
}
