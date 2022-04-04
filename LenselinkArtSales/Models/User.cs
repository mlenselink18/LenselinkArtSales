using System;
using System.Collections.Generic;

namespace LenselinkArtSales.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Active { get; set; }
        public int? RoleId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? SecurityQuestionID { get; set; }
        public string? SecurityAnswer { get; set; }

        public string FirstLastname
        {
            get
            {
                var display = "";

                if (FirstName != null && FirstName.Trim() != "")
                    display += FirstName;

                if (FirstName != null && FirstName.Trim() != "" && LastName != null && LastName.Trim() != "")
                    display += " " + LastName;

                return display;
            }
        }
        public bool IsAdmin()
        {
            if (this.RoleId == 2)
                return true;
            else
                return false;
        }

        public string RoleTitle
        {
            get
            {
                string display = "Customer";

                switch(this.RoleId)
                {
                    case 1:
                        display = "Customer";
                        break;
                    case 2:
                        display = "Admin";
                        break;
                    case 3:
                        display = "Artist";
                        break;
                    default:
                        display = "Customer";
                        break;
                }

                return display;
            }
        }
    }
}
