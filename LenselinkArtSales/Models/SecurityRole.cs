using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class SecurityRole
    {

        public SecurityRole() : base()
        {

        }

        //public SecurityRole(string roleName)
        //{
        //    Name = roleName;
        //}
        public int Id { get; set; }
        public string? RoleDescription { get; set; }
    }
}
