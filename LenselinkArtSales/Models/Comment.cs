using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? ArtId { get; set; }
        public string? CommentBody { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? Commenter { get; set; }
    }
}
