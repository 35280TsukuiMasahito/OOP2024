using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static RestaurantTouchPanel.MenuSelectionWindow;

namespace RestaurantTouchPanel {
    public partial class CheckWindow : Window {
        public CheckWindow() {
            InitializeComponent();
            this.Loaded += CheckWindow_Loaded;
        }

        private void CheckWindow_Loaded(object sender, RoutedEventArgs e) {
            LoadOrderSummary();
            DisplayTotalAmount();
        }

        private void LoadOrderSummary() {
            OrderSummaryListBox.Items.Clear();
            foreach (var item in OrderManager.Instance.OrderItems) {
                OrderSummaryListBox.Items.Add(item.ToString());
            }
        }

        private void DisplayTotalAmount() {
            int total = OrderManager.Instance.OrderItems.Sum(item => item.Quantity * item.Price);
            TotalAmountText.Text = $"合計金額: ¥{total}";
        }

        private void CalculatePerPerson_Click(object sender, RoutedEventArgs e) {
            if (int.TryParse(PeopleCountTextBox.Text, out int peopleCount) && peopleCount > 0) {
                int total = OrderManager.Instance.OrderItems.Sum(item => item.Quantity * item.Price);
                int perPerson = total / peopleCount;
                PerPersonAmountText.Text = $"一人当たりの金額: ¥{perPerson}";
            } else {
                MessageBox.Show("人数を正しい形式で入力してください。", "エラー", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e) {
            // カテゴリボタンがクリックされた場合の処理
            // 料理ボタンがクリックされた場合
            if ((sender as Button)?.Content.ToString() == "料理") {
                var menuWindow = new MenuSelectionWindow();
                this.Close();
                menuWindow.ShowDialog(); // モーダルで開く
            } else if ((sender as Button)?.Content.ToString() == "おすすめ・鍋") {
                var menuWindow = new OsusumeWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "刺身・寿司・サラダ") {
                var menuWindow = new SasimiWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "アルコール①") {
                var menuWindow = new BiruWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "アルコール②") {
                var menuWindow = new ShochuWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "ノンアル・ソフドリ") {
                var menuWindow = new Drink1Window();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "デザート") {
                var menuWindow = new IceWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "サービス") {
                var menuWindow = new ServiceWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "特選メニュー") {
                var menuWindow = new TokusenWindow();
                this.Close();
                menuWindow.ShowDialog();
            } else if ((sender as Button)?.Content.ToString() == "トップ画面") {
                var menuWindow = new OrderWindow();
                this.Close();
                menuWindow.ShowDialog();
            }
        }
    }
}
