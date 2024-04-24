using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    internal class Program {
        static void Main(string[] args) {
            var songs = new Song[] {
                new Song("xxx", "yyy", 100),
                new Song("aaa", "bbb", 200)
            };
            PrintSongs(songs);
        }
        private static void PrintSongs(Song[] songs) {
            Console.WriteLine(@"{0:hh\:mm\:ss}", TimeSpan.FromSeconds(songs.Length));
        }
    }
}
