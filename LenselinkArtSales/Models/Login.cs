using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class Login
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? UserId { get; set; }
        public int? SecurityQuestionId { get; set; }
        public string? SecurityAnswer { get; set; }
    }
}
