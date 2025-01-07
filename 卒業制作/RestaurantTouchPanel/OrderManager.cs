using System.Collections.Generic;
using static RestaurantTouchPanel.MenuSelectionWindow;

public class OrderManager {
    // シングルトンインスタンス
    private static OrderManager _instance;
    public static OrderManager Instance {
        get {
            if (_instance == null) {
                _instance = new OrderManager();
            }
            return _instance;
        }
    }

    // 注文リスト
    public List<OrderItem> OrderItems { get; private set; }

    // コンストラクタ
    private OrderManager() {
        OrderItems = new List<OrderItem>();
    }

    // 注文リストをクリア
    public void ClearOrders() {
        OrderItems.Clear();
    }
}
