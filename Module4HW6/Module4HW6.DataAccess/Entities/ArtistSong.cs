using System;
using System.Collections.Generic;
using System.Text;

namespace Module4HW6.DataAccess.Entities
{
    public class ArtistSong
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
