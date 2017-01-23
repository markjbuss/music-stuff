using System.Collections.Generic;

namespace MarkMusic.Db
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AlbumId { get; set; }
        public int? TrackNumber { get; set; }
        public virtual List<Artist> Artists { get; set; }
        public virtual Album Album { get; set; }
        public virtual List<SongIdentifier> Identifiers { get; set; }
    }
}