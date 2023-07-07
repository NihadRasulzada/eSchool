using System.Collections.Generic;
using System.Reflection;

namespace Waitrose.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ClassSection> ClassSections { get; set; }
        public List<Student> Students { get; set; }
    }
}
