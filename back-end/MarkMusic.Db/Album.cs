using System.Collections.Generic;

namespace MarkMusic.Db
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? NumberOfTracks { get; set; }

        public virtual List<Song> Songs { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual List<AlbumIdentifier> Identifiers { get; set; }
    }
}