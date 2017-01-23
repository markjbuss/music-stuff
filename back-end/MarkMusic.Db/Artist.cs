using System.Collections.Generic;

namespace MarkMusic.Db
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Album> Albums { get; set; }
        public virtual List<Song> Songs { get; set; }
        public virtual List<ArtistIdentifier> Identifiers { get; set; }
    }
}