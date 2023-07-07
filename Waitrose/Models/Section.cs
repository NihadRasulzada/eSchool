using System.Collections.Generic;

namespace Waitrose.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ClassSection> ClassSections { get; set; }
    }
}
