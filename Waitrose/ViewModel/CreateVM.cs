﻿using System.ComponentModel.DataAnnotations;

namespace Waitrose.ViewModel
{
    public class CreateVM
    {
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string CheckPassword { get; set; }
    }
}
