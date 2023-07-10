using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Waitrose.Models;

namespace Waitrose.ViewModel
{
    public class StudentProfileVM
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateofBirth { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public List<string> ParentNames { get; set; }
        public bool isMale { get; set; }
        [DataType(DataType.Password)]
        public string ResendPassword { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
    }
}
