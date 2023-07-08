using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu Xana Bosh Ola Bilmez")]
        public string Name { get; set; }
        public bool isDeactive { get; set; }
        public List<ClassSection> ClassSections { get; set; }
    }
}
