using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Waitrose.Models
{
    public class Student
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
        public List<StudentParent> StudentParents { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
