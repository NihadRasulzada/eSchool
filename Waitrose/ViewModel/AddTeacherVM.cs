using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Waitrose.ViewModel
{
    public class AddTeacherVM
    {
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public bool isMale { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Format duzgun deyil.")]
        public string PhoneNumber { get; set; }
    }
}
