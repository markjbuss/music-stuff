//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarkMusic.OldDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public int NumberOfTracks { get; set; }
    
        public virtual Artist Artist { get; set; }
    }
}
