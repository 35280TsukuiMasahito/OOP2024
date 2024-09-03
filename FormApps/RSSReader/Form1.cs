using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;


namespace RSSReader {
    public partial class Form1 : Form {
        private Dictionary<string, string> rssItems = new Dictionary<string, string>();


        public Form1() {
            InitializeComponent();
            // イベントハンドラーの登録
            lbRssTitle.SelectedIndexChanged += lbRssTitle_SelectedIndexChanged;
        }

        private void button1_Click(object sender, EventArgs e) {
                using (var wc = new WebClient()) {
                    var url = wc.OpenRead(tbRssUrl.Text);
                    var xdoc = XDocument.Load(url);

                    // リストボックスをクリア
                    lbRssTitle.Items.Clear();
                    rssItems.Clear();

                    var items = xdoc.Descendants("item");
                    foreach (var item in items) {
                        var title = item.Element("title")?.Value;
                        var link = item.Element("link")?.Value;

                        if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(link)) {
                            lbRssTitle.Items.Add(title);
                            rssItems[title] = link; // タイトルとリンクのペアを保存
                        }
                    }
                }
            
        }

        private void lbRssTitle_SelectedIndexChanged(object sender, EventArgs e) {
            if (lbRssTitle.SelectedItem != null) {
                var selectedTitle = lbRssTitle.SelectedItem.ToString();
                if (rssItems.TryGetValue(selectedTitle, out var url)) {
                        webBrowser1.Navigate(url);
                    webBrowser1.ScriptErrorsSuppressed = true;
                }
            }
        }
    }
}
