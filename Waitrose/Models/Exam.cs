using System.Collections.Generic;

namespace Waitrose.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public List<Mark> Marks { get; set; }
    }
}
