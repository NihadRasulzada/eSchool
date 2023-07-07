using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waitrose.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Section { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool isMale { get; set; }
        public List<StudentParent> StudentParents { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
    }
}
