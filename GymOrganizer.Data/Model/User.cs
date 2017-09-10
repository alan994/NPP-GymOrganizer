using GymOrganizer.Data.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymOrganizer.Data.Model
{
    [Table("Users")]
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public UserType Type { get; set; }
    }
}
