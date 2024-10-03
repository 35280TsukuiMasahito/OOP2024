using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(x=>x.Price);
            Console.WriteLine(max);
        }

        private static void Exercise1_3() {
            var quary = Library.Books
                .GroupBy(b => b.PublishedYear)
                .Select(x => new { Publisher = x.Key,Count = x.Count()})
                .OrderBy(x=>x.Publisher);
            
            foreach (var x in quary) {
                Console.WriteLine("{0}年 {1}冊",x.Publisher,x.Count);
            }
        }

        private static void Exercise1_4() {
            var query = Library.Books
                .Join(Library.Categories,
                    book => book.CategoryId,
                    Category => Category.Id,
                    (book, Category) => new {
                        book.Title,
                        book.PublishedYear,
                        book.Price,
                        CategoryName = Category.Name,
                    }).OrderByDescending(x => x.PublishedYear)
                    .ThenByDescending(x => x.Price);

            foreach(var x in query) {
                Console.WriteLine("{0}年 {1}円 {2}", x.PublishedYear, x.Price, x.CategoryName);
            }
        }


        private static void Exercise1_5() {
            var query = Library.Books
                .Where(b => b.PublishedYear == 2016)
                .Join(Library.Categories, //結合する2番目のシーケンス
                book => book.CategoryId, //対象シーケンスの結合キー
                Category => Category.Id, //結合する2番目の結合キー
                (book, Category) => Category.Name)
                .Distinct();

            foreach (var x in query) {
                Console.WriteLine(x);
            }
        }

        private static void Exercise1_6() {
            var query = Library.Books
                        .Join(Library.Categories,
                            book => book.CategoryId,
                            Category => Category.Id,
                            (book, Category) => new {
                                book.Title,
                                CategoryName = Category.Name
                            })
                        .GroupBy(x => x.CategoryName)
                        .OrderBy(x=>x.Key);

            foreach(var x in query) {
                Console.WriteLine("#{0}",x.Key);
                foreach(var item  in x) {
                    Console.WriteLine("  {0}",item.Title);
                }
            }
        }

        private static void Exercise1_7() {
            var categoresId = Library.Categories.Single(x=>x.Name == "Depelopment").Id;
            var query = Library.Books.Where(x=>x.CategoryId == categoresId)
                .GroupBy(x=>x.PublishedYear)
                .OrderBy(x=>x.Key);

            foreach (var x in query) {
                Console.WriteLine("#{0}年",x.Key);
                foreach(var item in x) {
                    Console.WriteLine("  {0}", item.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var query = Library.Categories
                .GroupJoin(Library.Books,
                            c => c.Id,
                            b => b.CategoryId,
                            (c, b) => new { CategoryName = c.Name,
                                            Count = b.Count()
                            })
                .Where(x=>x.Count >= 4);

            foreach (var item in query) {
                Console.WriteLine(item.CategoryName + "("+item.Count + "冊");
            }
        }
    }
}
