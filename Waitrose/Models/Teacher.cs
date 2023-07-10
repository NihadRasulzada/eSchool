using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool isMale { get; set; }
    }
}
