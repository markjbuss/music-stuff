using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMusic.Db
{
    public class AlbumIdentifier : IdentifierDescriptor
    {
        [Key]
        [Column(Order = 0)]
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}