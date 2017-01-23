using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMusic.Db
{
    public class ArtistIdentifier : IdentifierDescriptor
    {
        [Key]
        [Column(Order = 0)]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}