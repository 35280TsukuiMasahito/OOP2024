using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {


            Console.WriteLine("生年月日を入力");
            Console.Write("年:");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月:");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日:");
            int day = int.Parse(Console.ReadLine());

            var date = new DateTime(year, month, day);

            //var dt1 = new DateTime(2024, 9, 19);
            //var dt2 = new DateTime(2010, 3, 12, 8, 45, 20);
            //Console.WriteLine(dt1);
            //Console.WriteLine(dt2);

            //var today = DateTime.Today;
            //var now = DateTime.Now;
            //Console.WriteLine("Today:{0}",today);
            //Console.WriteLine("now:{0}",now);

            //var isLeapYear = DateTime.IsLeapYear(2024);
            //if(isLeapYear) {
            //    Console.WriteLine("閏年です");
            //} else {
            //    Console.WriteLine("閏年ではありません");
            //}

            DayOfWeek dayOfWeek = date.DayOfWeek;

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str =date.ToString("ggyy年M月d日",culture);
            Console.WriteLine("あなたは"+str+"生まれです");

            var today = DateTime.Today;
            TimeSpan diff = today - date; 
            Console.WriteLine("あなたが生まれてから{0}日目です",diff.Days+1);
        }
    }

    //switch (dayOfWeek) {
    //    case DayOfWeek.Sunday:
    //        Console.WriteLine("日曜日です");
    //        break;
    //    case DayOfWeek.Monday:
    //        Console.WriteLine("月曜日です");
    //        break;
    //    case DayOfWeek.Tuesday:
    //        Console.WriteLine("火曜日です");
    //        break;
    //    case DayOfWeek.Wednesday:
    //        Console.WriteLine("水曜日です");
    //        break;
    //    case DayOfWeek.Thursday:
    //        Console.WriteLine("木曜日です");
    //        break;
    //    case DayOfWeek.Friday:
    //        Console.WriteLine("金曜日です");
    //        break;
    //    case DayOfWeek.Saturday:
    //        Console.WriteLine("土曜日です");
    //        break;
    //    default:
    //        Console.WriteLine("その他の曜日です");
    //        break;
    //}
}
