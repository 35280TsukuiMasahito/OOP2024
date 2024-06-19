using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    // List 7-19
    // 略語と対応する日本語を管理するクラス
    class Abbreviations : IEnumerable<KeyValuePair<string,string>>{
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        //7.2.1
        public int cnt {
            get {
                return _dict.Count();
            }
        }

        //7.2.2
        public Boolean Remove(String str) {
            return _dict.Remove(str);
        }

        public void ThreeStr() {
            var strings = _dict.Where(x=>x.Key.Length==3).ToList();
            foreach(var item in strings) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
        }

        // コンストラクタ
        public Abbreviations() {
            var lines = File.ReadAllLines("Abbreviations.txt");
            _dict = lines.Select(line => line.Split('='))
                         .ToDictionary(x => x[0], x => x[1]);
        }

        // 要素を追加
        public void Add(string abbr, string japanese) {
            _dict[abbr] = japanese;
        }

        // インデクサ - 省略語をキーに取る
        public string this[string abbr] {
            get {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }

        // 日本語から対応する省略語を取り出す
        public string ToAbbreviation(string japanese) {
            return _dict.FirstOrDefault(x => x.Value == japanese).Key;
        }

        // 日本語の位置を引数に与え、それが含まれる要素(Key,Value)をすべて取り出す
        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring) {
            foreach (var item in _dict) {
                if (item.Value.Contains(substring))
                    yield return item;
            }
        }

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return ((IEnumerable<KeyValuePair<string, string>>)_dict).GetEnumerator();
        }
    }
}
