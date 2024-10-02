using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {
            //InsertBooks();
            //foreach (var book in GetBooks()) {
            //    Console.WriteLine(book.Title);
            //}

             AddAuthors();

            //AddBooks();

            // DiaplayAllBooksV2();
        }

        private static void UpdateBook() {//データの変更
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }
        private static void DeleteBook() {//データの消去
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
        static void InsertBooks() {//データの追加
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }
        static void DiaplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title}{book.PublishedYear}");
            }
            Console.ReadLine();
        }
        static void DiaplayAllBooksV2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.ToList()) {
                    Console.WriteLine("{0},{1},{2}({3:yyyy/MM/dd})",
                        book.Title, book.PublishedYear,
                        book.Author.Name, book.Author.Birthday
                        );
                }
            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                    //Where(book => book.Author.Name.StartsWith("夏目"))
                    .ToList();
            }
        }
        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子",
                };
                db.Author.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治",
                };
                db.Author.Add(author2);
                var author3 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Author.Add(author1);
                var author4 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Author.Add(author2);
                db.SaveChanges();
            }
        }
        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                //var author1 = db.Author.Single(a=>a.Name == "与謝野晶子");
                //var book1 = new Book {
                //    Title = "みだれ髪",
                //    PublishedYear = 2000,
                //    Author = author1,
                //};
                //db.Books.Add(book1);
                //var author2 = db.Author.Single(a => a.Name == "宮沢賢治");
                //var book2 = new Book {
                //    Title = "銀河鉄道の夜",
                //    PublishedYear = 1989,
                //    Author = author2,
                //};
                //db.Books.Add(book2);
                var author3 = db.Author.Single(a => a.Name == "夏目漱石");
                var book3 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author3,
                };
                db.Books.Add(book3);
                var author4 = db.Author.Single(a => a.Name == "川端康成");
                var book4 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author4,
                };
                db.Books.Add(book4);
                var author5 = db.Author.Single(a => a.Name == "菊池寛");
                var book5 = new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = author5,
                };
                db.Books.Add(book5);
                var author6 = db.Author.Single(a => a.Name == "宮沢賢治");
                var book6 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author6,
                };
                db.Books.Add(book6);
                db.SaveChanges();
            }
        }
        static void DiaplayLongestTitleBook() {
            using (var db = new BooksDbContext()) {
                // 書籍の中からタイトルが最も長い書籍を取得する
                var longestTitleBook = db.Books
                    .OrderByDescending(book => book.Title.Length)
                    .FirstOrDefault();

                if (longestTitleBook != null) {
                    Console.WriteLine("タイトルが最も長い書籍:");
                    Console.WriteLine("{0},{1},{2}({3:yyyy/MM/dd})",
                        longestTitleBook.Title, longestTitleBook.PublishedYear,
                        longestTitleBook.Author.Name, longestTitleBook.Author.Birthday);
                } else {
                    Console.WriteLine("書籍が見つかりませんでした。");
                }
            }
        }
    }
}
