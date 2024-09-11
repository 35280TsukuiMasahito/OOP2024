using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RSSReader {
    public partial class RSSリーダー : Form {
        private Dictionary<string, string> categoryUrls;
        private List<ItemData> items;
        private List<ItemData> favoriteItems; // お気に入りアイテムのリスト

        public RSSリーダー() {
            InitializeComponent();

            categoryUrls = new Dictionary<string, string> {
                { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
                { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
                { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
                { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
                { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" }
            };

            // コンボボックスに分類を追加
            cb.Items.AddRange(categoryUrls.Keys.ToArray());
            cb.Items.Add("お気に入り");
            cb.SelectedIndex = 0; // 最初のアイテムを選択

            favoriteItems = new List<ItemData>(); // お気に入りリストの初期化
        }

        private void button1_Click(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = items?.FirstOrDefault(item => item.Title == selectedTitle);

                if (selectedItem != null) {
                    if (!favoriteItems.Any(item => item.Title == selectedItem.Title)) {
                        favoriteItems.Add(selectedItem);

                        // 「お気に入り」カテゴリが選択されている場合は、お気に入りリストにアイテムを追加
                        if (cb.SelectedItem.ToString() == "お気に入り") {
                            lbRssTitle.Items.Add(selectedItem.Title);
                        }
                    } else {
                        MessageBox.Show("このアイテムはすでにお気に入りに登録されています。");
                    }
                }
            } else {
                MessageBox.Show("お気に入りに追加するには、まずアイテムを選択してください。");
            }
        }
    

        private void cb_SelectedIndexChanged(object sender, EventArgs e) {
            if (cb.SelectedItem.ToString() == "お気に入り") {
                // 「お気に入り」を選択した場合、お気に入りリストを表示
                lbRssTitle.Items.Clear();
                foreach (var item in favoriteItems) {
                    lbRssTitle.Items.Add(item.Title);
                }
            } else {
                // その他のカテゴリを選択した場合
                LoadRssFeed(cb.SelectedItem.ToString());
            }
        }

        private void LoadRssFeed(string category) {
            lbRssTitle.Items.Clear();

            if (categoryUrls.TryGetValue(category, out var rssUrl)) {
                using (var wc = new WebClient()) {
                    try {
                        var url = wc.OpenRead(rssUrl);
                        var xdoc = XDocument.Load(url);

                        items = xdoc.Root.Descendants("item")
                            .Select(item => new ItemData {
                                Title = item.Element("title")?.Value ?? "No Title",
                                Link = item.Element("link")?.Value ?? "#"
                            }).ToList();

                        foreach (var item in items) {
                            lbRssTitle.Items.Add(item.Title);
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("エラーが発生しました: " + ex.Message);
                    }
                }
            } else {
                MessageBox.Show("選択されたカテゴリのURLが見つかりません。");
            }
        }


        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                var selectedItem = items?.FirstOrDefault(item => item.Title == selectedTitle);
                tbRssUrl.Text = lbRssTitle.SelectedItem.ToString();

                if (selectedItem != null) {
                    try {
                        webView21.Source = new Uri(selectedItem.Link);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("ナビゲート中にエラーが発生しました: " + ex.Message);
                    }
                }
            }
        }

        public class ItemData {
            public string Title { get; set; }
            public string Link { get; set; }
        }

        private void button2_Click(object sender, EventArgs e) {
            // 「お気に入り」カテゴリが選択されている場合
            if (cb.SelectedItem.ToString() == "お気に入り") {
                if (lbRssTitle.SelectedItem != null) {
                    // 選択されたタイトルを取得
                    var selectedTitle = lbRssTitle.SelectedItem.ToString();
                    var itemToRemove = favoriteItems.FirstOrDefault(item => item.Title == selectedTitle);

                    // お気に入りリストからアイテムを削除
                    if (itemToRemove != null) {
                        favoriteItems.Remove(itemToRemove);
                        lbRssTitle.Items.Remove(selectedTitle); // リストボックスからも削除

                        // リストが空になった場合の処理（オプション）
                        if (favoriteItems.Count == 0) {
                            MessageBox.Show("お気に入りが全て削除されました。");
                        }
                    } else {
                        MessageBox.Show("選択されたアイテムはお気に入りに存在しません。");
                    }
                } else {
                    MessageBox.Show("削除するアイテムを選択してください。");
                }
            } else {
                MessageBox.Show("「お気に入り」カテゴリを選択してください。");
            }
        }
    }
}
