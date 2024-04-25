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
                new Song("Let it be","The Beatles",243),
                new Song("Bridge Over","Simon & Garfunkel",293),
                new Song("Close To You","Carpenters",276),
                new Song("Honesty","Billy Joel",231),
                new Song("I will Always","Whiksbsabk",273)
            };
            var numbers = new int[] {
                1,
                2,
                3,
                4,
                5,
            };

            PrintSongs(songs);
        }
        private static void PrintSongs(Song[] songs) {
            foreach (var song in songs) {

                Console.WriteLine(@"{0},{1},{2:mm\:ss}", song.Title,song.ArtistName,TimeSpan.FromSeconds(song.Length));
            }
        }
    }
}
