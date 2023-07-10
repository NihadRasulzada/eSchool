using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.ViewModel
{
    public class ParentProfileVM
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateofBirth { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public List<string> StudentNames { get; set; }
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
