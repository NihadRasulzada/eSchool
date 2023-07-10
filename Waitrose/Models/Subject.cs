using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana bosh ola bilmez")]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
