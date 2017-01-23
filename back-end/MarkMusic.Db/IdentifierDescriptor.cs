using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarkMusic.Db
{
    public class IdentifierDescriptor
    {
        [Key]
        [Column(Order = 1)]
        public IdentifierType Type { get; set; }

        public string Identifier { get; set; }
    }
}