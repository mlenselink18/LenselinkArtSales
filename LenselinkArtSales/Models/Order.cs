using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Notes { get; set; }
        public string NotesDisplay
        {
            get
            {
                var display = "";

                if (Notes != null)
                    display = Notes.Trim();

                return display;
            }
        }
    }
}
