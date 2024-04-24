using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    public class Song {
        public String Title { get; set; }
        public String ArtistName { get; set; }
        public int Length { get; set; }


        public  Song(String Title, String ArtistName, int Length) { 
            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Length;
        }
    }
}
