using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class ChangeLog
    {
        public int Id { get; set; }
        public int? TableNameId { get; set; }
        public int? RecordId { get; set; }
        public string? ChangeType { get; set; }
        public int? ChangedById { get; set; }
        public DateTime? ChangedDate { get; set; }
    }
}
