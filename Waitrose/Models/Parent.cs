using System.Collections.Generic;

namespace Waitrose.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public List<StudentParent> StudentParents { get; set; }
    }
}
