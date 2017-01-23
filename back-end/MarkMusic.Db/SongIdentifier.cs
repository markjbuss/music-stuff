using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMusic.Db
{
    public class SongIdentifier : IdentifierDescriptor
    {
        [Key]
        [Column(Order = 0)]
        public int SongId { get; set; }

        public virtual Song Song { get; set; }
    }
}