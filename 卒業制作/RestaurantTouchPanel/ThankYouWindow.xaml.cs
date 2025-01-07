using System;
using System.Threading.Tasks;
using System.Windows;

namespace RestaurantTouchPanel {
    public partial class ThankYouWindow : Window {
        public ThankYouWindow() {
            InitializeComponent();
            AutoCloseAndReturnToTop();
        }

        private async void AutoCloseAndReturnToTop() {
            await Task.Delay(2000); // 2秒間表示

            // トップ画面を開く
            var topWindow = new OrderWindow(); // トップ画面のクラス名を指定
            topWindow.Show();

            // 現在のウィンドウを閉じる
            this.Close();
        }
    }
}
